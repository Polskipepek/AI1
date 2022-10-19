// See https://aka.ms/new-console-template for more information

using AI1.Core;
using AI1.Model;
using System.Reflection;

Console.WriteLine("Hello, Halinka!");
Console.WriteLine();

Console.WriteLine("Select data type: (ex. 1)");
Console.WriteLine("1. Air quality");
Console.WriteLine("2. King vs King & Rook chess endgame");
Console.WriteLine("3. Soybeans");
var selectedDataType = Console.ReadLine();

DataReader reader = new();

PropertyInfo[]? props = null;
Type propType;
List<AirQuality> airQualities = new List<AirQuality>();

switch (selectedDataType) {
    case "1":
        var table = reader.ReadData($"{Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data\\AirQualityUCI.txt");
        airQualities = TableToAirQualityMapper.Map(table);

        props = typeof(AirQuality).GetProperties();
        break;
    case "2":
        break;
    case "3":
        break;
    default:
        return;
}
if (props == null) throw new Exception("Props are null");

propType = ConsoleProgram.GetTypeOfSelectedFeature(props);
//var possibleCalcs = ConsoleProgram.GetPossibleCalculations(propType);

var keys = ConsoleProgram.GetIntCalculations(airQualities.Select(x => x.CO_GT)).Select(x => x.Key);
Console.Write("\t");
Console.WriteLine($"{string.Join("\t", keys)}");


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

Console.ReadLine();

static void WriteCalcs(IEnumerable<int> column, string columnName = "") {
    Console.WriteLine();
    var calcs = ConsoleProgram.GetIntCalculations(column);
    if (!columnName.Equals("")) {
        Console.Write($"{columnName};");
    }
    foreach (var calc in calcs) {
        Console.Write($"{calc.Value};");
    }

}