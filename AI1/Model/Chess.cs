using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI1.Model {
    internal class Chess {
        public int WhiteKingRow { get; set; }
        public int BlackKingRow { get; set; }
        public int WhiteRookRow { get; set; }
        public char WhiteKingColumn { get; set; }
        public char BlackKingColumn { get; set; }
        public char WhiteRookColumn { get; set; }
        public int Depth { get; set; }
    }
}
