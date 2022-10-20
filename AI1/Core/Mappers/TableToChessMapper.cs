using AI1.Model;
using System.Data;
using System.Globalization;

namespace AI1.Core.Mappers {
    internal static class TableToChessMapper {
        public static List<Chess> Map(DataTable table) {
            List<Chess> list = new();
            foreach (DataRow dr in table.Rows) {
                list.Add(new Chess {
                    WhiteKingColumn = (char)dr[0],
                    WhiteKingRow = int.Parse((string)dr[1]),
                    WhiteRookColumn = (char)dr[2],
                    WhiteRookRow = int.Parse((string)dr[3]),
                    BlackKingColumn = (char)dr[4],
                    BlackKingRow = int.Parse((string)dr[5]),
                    Depth = int.Parse((string)dr[6]),
                });
            }
            return list;
        }
    }
}
