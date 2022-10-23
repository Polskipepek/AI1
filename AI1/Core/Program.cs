// See https://aka.ms/new-console-template for more information

using AI1;
using AI1.Core;
using AI1.Core.Mappers;
using AI1.Model;
using System.Reflection;
using Microsoft.Win32;
Console.WriteLine("Hello, Halinka!");
Console.WriteLine();

Console.WriteLine("Select data type: (ex. 1)");
Console.WriteLine("1. Air quality");
Console.WriteLine("2. King vs King & Rook chess endgame");
Console.WriteLine("3. Soybeans");
var selectedDataType = Console.ReadLine();

DataReader reader = new();

PropertyInfo[]? props = null;
List<AirQuality> airQualities = new();
List<Chess> chessList = new();


var rootPath = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
switch (selectedDataType) {
    case "1":
        var table = reader.ReadData($"{rootPath}\\Data\\AirQualityUCI.csv", ";");
        airQualities = TableToAirQualityMapper.Map(table);

        ConsoleProgram.WriteAllCalcsForAirQuiality(airQualities);
        break;
    case "2":

        props = typeof(Chess).GetProperties();
        string bkc, wkc, wrc;
        int bkr, wkr, wrr;
        CreateChessPosition(out bkc, out bkr, out wkc, out wkr, out wrc, out wrr);

        var predict = ChessModel1.Predict(new ChessModel1.ModelInput() {
            Kc = wkc,
            Kr = wkr,
            Rc = wrc,
            Rr = wrr,
            Kc2 = bkc,
            Kr2 = bkr
        });

        Console.WriteLine($"Predicted result: {predict.Prediction}\nPrediction scores: {string.Join(", ", predict.Score)}");
        break;
    case "3":
        break;
    default:
        return;
}

Console.ReadLine();

static void CreateChessPosition(out string bkc, out int bkr, out string wkc, out int wkr, out string wrc, out int wrr) {
    Console.WriteLine("Let's check the depth!\nPlease create a chess position:");

    bkc = "0";
    while (bkc.Length == 0 || bkc.Length == 1 && (bkc.First() < 97 || bkc.First() > 104)) {
        Console.Write($"Black King Column (a-h): ");
        bkc = Console.ReadLine() ?? "";
    }

    bkr = 0;
    while (bkr < 1 || bkr > 8) {
        Console.Write($"Black King Row (1-8): ");
        int.TryParse(Console.ReadLine() ?? "0", out bkr);
    }

    wkc = "0";
    while (wkc.Length == 0 || wkc.Length == 1 && (wkc.First() < 97 || wkc.First() > 104)) {
        Console.Write($"White King Column (a-h): ");
        wkc = Console.ReadLine() ?? "";
    }

    wkr = 0;
    while (wkr < 1 || wkr > 8) {
        Console.Write($"White King Row (1-8): ");
        int.TryParse(Console.ReadLine() ?? "0", out wkr);

    }

    wrc = "0";
    while (wrc.Length == 0 || wrc.Length == 1 && (wrc.First() < 97 || wrc.First() > 104)) {
        Console.Write($"White Rook Column (a-h): ");
        wrc = Console.ReadLine() ?? "";
    }

    wrr = 0;
    while (wrr < 1 || wrr > 8) {
        Console.Write($"White Rook Row (1-8): ");
        int.TryParse(Console.ReadLine() ?? "0", out wrr);
    }
}