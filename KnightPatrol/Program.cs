using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightPatrol
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMap map = new ChessMap();
            map.CreateChessMap();
            map.Input();
            map.Output(map.MAP);
            map.FindKnight();
        }
    }
}
