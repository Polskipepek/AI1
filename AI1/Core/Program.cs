// See https://aka.ms/new-console-template for more information

using AI1.Core;
using AI1.Core.Mappers;
using AI1.Model;
using System.Linq;
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
List<AirQuality> airQualities = new();
List<Chess> chessList = new();

var rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
switch (selectedDataType) {
    case "1":
        var table = reader.ReadData($"{rootPath}\\Data\\AirQualityUCI.txt");
        airQualities = TableToAirQualityMapper.Map(table);

        // props = typeof(AirQuality).GetProperties();
        // propType = ConsoleProgram.GetTypeOfSelectedFeature(props);
        ConsoleProgram.WriteAllCalcsForAirQuiality(airQualities);
        break;
    case "2":
        table = reader.ReadData($"{rootPath}\\Data\\krkopt.data");
        //chessList = TableToChessMapper.Map(table);

        props = typeof(Chess).GetProperties();
        propType = ConsoleProgram.GetTypeOfSelectedFeature(props);
        break;
    case "3":
        break;
    default:
        return;
}
//if (props == null) throw new Exception("Props are null");

//propType = ConsoleProgram.GetTypeOfSelectedFeature(props);
//WriteAllCalcsForAirQuiality(airQualities);

//var possibleCalcs = ConsoleProgram.GetPossibleCalculations(propType);


Console.ReadLine();

