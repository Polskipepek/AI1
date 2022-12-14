using AI1.Model;
using System.Data;
using System.Globalization;

namespace AI1.Core.Mappers {
    internal static class TableToAirQualityMapper {
        public static List<AirQuality> Map(DataTable table) {
            List<AirQuality> list = new();
            foreach (DataRow dr in table.Rows) {
                list.Add(new AirQuality {
                    //Id = list.Count,
                    DateTime = DateTime.ParseExact($"{dr[0]}, {dr[1]}", "dd.MM.yyyy, HH.mm.ss", CultureInfo.CurrentCulture),
                    CO_GT = double.Parse((string)dr[2]),
                    PT08_S1 = double.Parse((string)dr[3]),
                    NMHC_GT = double.Parse((string)dr[4]),
                    C6H6_GT = double.Parse((string)dr[5]),
                    PT08_S2 = double.Parse((string)dr[6]),
                    NOx_GT = double.Parse((string)dr[7]),
                    PT08_S3 = double.Parse((string)dr[8]),
                    NO2_GT = double.Parse((string)dr[9]),
                    PT08_S4 = double.Parse((string)dr[10]),
                    PT08_S5 = double.Parse((string)dr[11]),
                    T = double.Parse((string)dr[12]),
                    RH = double.Parse((string)dr[13]),
                    AH = double.Parse((string)dr[14])
                });
            }
            return list;
        }
    }
}
