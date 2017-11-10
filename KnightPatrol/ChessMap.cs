using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightPatrol
{
    class ChessMap
    {
        public int n;
        public int[,] map;
        public int d;
        public int c;
        public int k;
        public int K { get { return k; } set { k = value; } }
        public int N { get { return n; } set { n = value; } }
        public int[,] MAP
        {
            get
            {
                return map;
            }

            set
            {
                map = value;
            }
        }
        public int D
        {
            get
            {
                return d;
            }

            set
            {
                d = value;
            }
        }
        public int C
        {
            get
            {
                return c;
            }

            set
            {
                c = value;
            }
        }
        public ChessMap()
        {
            k = 1;
            n = 8;
            map = new int[n, n];
            d = 0;
            c = 0;
        }
        public void Input()
        {
            Console.Write("Enter location x : ");
            d = int.Parse(Console.ReadLine());
            Console.Write("Enter location y : ");
            c = int.Parse(Console.ReadLine());
            Console.WriteLine();
            map[d, c] = k;
            #region license
            /*
             * Nhan Kim Thành
             * 15DH110281
             */
            #endregion
        }
        public void CreateChessMap()
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    map[i, j] = 0;
                }
            }
        }
        public void Output(int[,] bc)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j= 0; j < 8; j++)
                {
                    if(bc[i,j] > 9)
                        Console.Write(bc[i,j] + " ");
                    else if(bc[i,j] == 0)
                        Console.Write(" . ");
                    else
                        Console.Write(" " + bc[i, j] + " ");
                }
                Console.WriteLine();
            }
            #region license
            /*
             * Nhan Kim Thành
             * 15DH110281
             */
            #endregion
        }
        int[,] tmp = new int[8, 8];
        public void CopyChessMap()
        {
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    tmp[i, j] = map[i, j];
            }
            #region license
            /*
             * Nhan Kim Thành
             * 15DH110281
             */
            #endregion
        }
        public int CountNextMove(int dong, int cot)
        {
            List<Tuple<int, int>> ds = new List<Tuple<int, int>>();
            NextMove(ds, tmp, dong ,cot);
            
            return ds.Count;
        }
        public void NextMove(List<Tuple<int, int>> ds, int[,] banco, int dong, int cot)
        {
            #region condition
            int dem = 0;
            if (dong + 2 < n && cot + 1 < n && banco[dong + 2, cot + 1] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(dong + 2, cot + 1));
            }
            if (dong + 1 < n && cot + 2 < n && banco[dong + 1, cot + 2] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(dong + 1, cot + 2));
            }
            if (dong - 1 >= 0 && cot + 2 < n && banco[dong - 1, cot + 2] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(dong - 1, cot + 2));
            }
            if (dong - 2 >= 0 && cot + 1 < n && banco[dong - 2, cot + 1] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(dong - 2, cot + 1));
            }
            if (dong - 2 >= 0 && cot - 1 >= 0 && banco[dong - 2, cot - 1] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(dong - 2, cot - 1));
            }
            if (dong - 1 >= 0 && cot - 2 >= 0 && banco[dong - 1, cot - 2] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(dong - 1, cot - 2));
            }
            if (dong + 1 < n && cot - 2 >= 0 && banco[dong + 1, cot - 2] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(dong + 1, cot - 2));
            }
            if (dong + 2 < n && cot - 1 >= 0 && banco[dong + 2, cot - 1] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(dong + 2, cot- 1));
            }

            #endregion
        }
        public void FindKnight()
        {
            if (k == 64)
            {
                Console.WriteLine("The knight patroled all the chess map location !");
                return;
            }
            else
            {
                List<Tuple<int, int>> ds = new List<Tuple<int, int>>();
                NextMove(ds, map, d, c);
                Console.WriteLine("List the future location(s) : ");
                int vt = -1;
                int max = 0;
                for (int i = 0; i < ds.Count; i++)
                {
                    CopyChessMap();
                    tmp[ds[i].Item1, ds[i].Item2] = k + 1;
                    Console.WriteLine(ds[i].Item1 + "-" + ds[i].Item2 + ", max : " + CountNextMove(ds[i].Item1, ds[i].Item2));
                    if (ds.Count == 1 && CountNextMove(ds[i].Item1, ds[i].Item2) == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" *** ");
                        Console.WriteLine("THIS IS THE END !");
                        Console.WriteLine("No more location can be patrol by the knight!");
                        Console.WriteLine("Max step = " + k);
                        Console.WriteLine();
                        return;
                    }
                    else
                    {
                        if (CountNextMove(ds[i].Item1, ds[i].Item2) > max)
                        {
                            max = CountNextMove(ds[i].Item1, ds[i].Item2);
                            vt = i;
                        }
                    }
                }
                Console.WriteLine();
                d = ds[vt].Item1;
                c = ds[vt].Item2;
                map[d, c] = ++k;
                Console.WriteLine("Next Location ( k = {0} ) : {1}-{2} ", k, d, c );
                Output(map);
                Console.WriteLine("===============================================");
                Console.WriteLine();
                FindKnight();
            }
        }
    }
}
