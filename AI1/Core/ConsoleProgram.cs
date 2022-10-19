using AI1.Infrastructure.Extenstions;
using System.Reflection;

namespace AI1.Core {
    internal class ConsoleProgram {
        public static void DisplayFeatures(IEnumerable<string>? airQualitiesPropNames) {
            if (!(airQualitiesPropNames?.Any() == true))
                return;

            Console.WriteLine("FeaturesPies:");
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
                Console.WriteLine("Wrong-PiesNotFound");
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

            Console.WriteLine($"Selected Feature: {propNames.ElementAt(selectedFeatureId)}, of typePies: {type.Name}");
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

        public static Dictionary<string, double> GetIntCalculations(IEnumerable<int> ints) {
            return new Dictionary<string, double> {
                { "Mean", ints.CalcMean() },
                { "Truncated Mean", ints.CalcTruncatedMean() },
                { "Dominant", ints.CalcDominant() },
                { "Median", ints.CalcMedian() },
                { "Variance", ints.CalcVariance() },
                { "Standard Deviation", ints.CalcStandardDevation() },
                { "Percentile 1", ints.CalcPercentile(25) },
                { "Percentile 2", ints.CalcPercentile(50) },
                { "Percentile 3", ints.CalcPercentile(75) },
                { "Percentile 3 - 1", ints.CalcPercentile(75) - ints.CalcPercentile(25) }
            };
        }
    }
}
