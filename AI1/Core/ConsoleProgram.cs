using AI1.Infrastructure.Extenstions;
using AI1.Model;
using System.Reflection;

namespace AI1.Core {
    internal class ConsoleProgram {
        public static void DisplayFeatures(IEnumerable<string>? airQualitiesPropNames) {
            if (!(airQualitiesPropNames?.Any() == true))
                return;

            Console.WriteLine("Features:");
            for (int i = 0; i < airQualitiesPropNames.Count(); i++) {
                Console.WriteLine($"{i + 1}. {airQualitiesPropNames.ElementAt(i)}");
            }
        }

        public static int SelectFeature(IEnumerable<string>? airQualitiesPropNames) {
            if (!(airQualitiesPropNames?.Any() == true))
                return -1;

            int props = airQualitiesPropNames.Count();

            Console.Write("Select Feature Number:");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int result) == false) DisplayFeatures(airQualitiesPropNames);

            if (result < 1 || result > props) {
                Console.WriteLine("NotFound");
                Console.WriteLine();
                Thread.Sleep(1000);
                Console.Clear();
                DisplayFeatures(airQualitiesPropNames);
            }
            Console.WriteLine();
            return result;
        }

        public static Type GetTypeOfSelectedFeature(PropertyInfo[] props) {
            IEnumerable<string> propNames = props.Select(x => x.Name);
            ConsoleProgram.DisplayFeatures(propNames);

            int selectedFeatureId = ConsoleProgram.SelectFeature(propNames);
            var type = props.First(x => x.Name == propNames.ElementAt(selectedFeatureId)).PropertyType;

            Console.WriteLine($"Selected Feature: {propNames.ElementAt(selectedFeatureId)}, of types: {type.Name}");
            return type;
        }

        public static string[] GetPossibleCalculations(Type type) {
            if (type == typeof(int)) {
                return new string[] { "Mean", "Truncated Mean", "Dominant", "Median", "Variance", "Standard Devation", "Percintile" };
            } else if (type == typeof(string)) {
                return new string[] { "OgonPsa.Length" };
            }
            return Array.Empty<string>();
        }

        public static Dictionary<string, double> GetDoubleCalculations(IEnumerable<double> doubles) {
            return new Dictionary<string, double> {
                { "Mean", doubles.CalcMean() },
                { "Truncated Mean", doubles.CalcTruncatedMean() },
                { "Dominant", doubles.CalcDominant() },
                { "Median", doubles.CalcMedian() },
                { "Variance", doubles.CalcVariance() },
                { "Stand.Deviation", doubles.CalcStandardDevation() },
                { "Percentile 1", doubles.CalcPercentile(25) },
                { "Percentile 2", doubles.CalcPercentile(50) },
                { "Percentile 3", doubles.CalcPercentile(75) },
                { "Percentile 4", doubles.CalcPercentile(75) - doubles.CalcPercentile(25) }
            };
        }

        public static void WriteCalcs(IEnumerable<double> column, string columnName = "") {
            Console.WriteLine();
            var calcs = GetDoubleCalculations(column);
            if (!columnName.Equals("")) {
                Console.Write($"{columnName};");
            }
            foreach (var calc in calcs) {
                Console.Write($"{calc.Value};");
            }
        }

        public static void WriteAllCalcsForAirQuiality(List<AirQuality> airQualities) {
            var keys = ConsoleProgram.GetDoubleCalculations(airQualities.Select(x => x.CO_GT)).Select(x => x.Key).Prepend("Feature");
            Console.WriteLine($"{string.Join(";", keys)}");

            WriteCalcs(airQualities.Select(x => x.CO_GT), "CO_GT");
            WriteCalcs(airQualities.Select(x => x.PT08_S1), "PT08_S1");
            WriteCalcs(airQualities.Select(x => x.NMHC_GT), "NMHC_GT");
            WriteCalcs(airQualities.Select(x => x.C6H6_GT), "C6H6_GT");
            WriteCalcs(airQualities.Select(x => x.PT08_S2), "PT08_S2");
            WriteCalcs(airQualities.Select(x => x.NOx_GT), "NOx_GT");
            WriteCalcs(airQualities.Select(x => x.PT08_S3), "PT08_S3");
            WriteCalcs(airQualities.Select(x => x.NO2_GT), "NO2_GT");
            WriteCalcs(airQualities.Select(x => x.PT08_S4), "PT08_S4");
            WriteCalcs(airQualities.Select(x => x.PT08_S5), "PT08_S5");
            WriteCalcs(airQualities.Select(x => x.T), "T");
            WriteCalcs(airQualities.Select(x => x.RH), "RH");
            WriteCalcs(airQualities.Select(x => x.AH), "AH");
            Console.WriteLine();
        }
    }
}
