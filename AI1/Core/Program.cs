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
        var table = reader.ReadData("C:\\Users\\Michal\\source\\repos\\ML\\AI\\AI1\\AI1\\Data\\AirQualityUCI.txt");
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

//for (int i = 1; i < possibleCalcs.Count(); i++) {
//    Console.WriteLine($"{i}. {possibleCalcs.ElementAt(i)}");
//}

var calcs = ConsoleProgram.GetIntCalculations(airQualities.Select(x => x.CO_GT));

foreach (var calc in calcs) {
    Console.WriteLine($"{calc.Key}: {calc.Value}");
}

Console.ReadLine();

