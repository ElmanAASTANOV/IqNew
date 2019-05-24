using System;

namespace iq
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Debug = false;
            /*--Input--*/

            int n = 6;
            int a = 4;
            int min = 2;
            int max = 6;
            int day = 30;

            /*-------*/

            int[,] table = new int[15, 31]{
                {3,3,3,3,3, 3,3,3,3,3, 3,3,3,3,3, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,3,3,3,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 3,3,3,3,3, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {3,3,3,0,0, 0,0,0,0,0, 3,3,3,3,3, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0},

                {0,0,0,0,0, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {3,3,3,3,3, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 3,3,3,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,3,3, 3,3,3,3,3, 3,3,3,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 3,3,3,3,3, 3,3,3,3,3, 0,4,4,4,4, 0,0,0,0,0, 0,0,0,0,0, 0},
                {3,3,3,0,0, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0,4,4,4,4, 4,4,4,4,4, 0},

                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,4,4,4,4, 0,0,0,0,0, 4,4,4,4,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0}
            };
            int[,] isYuku = new int[15, 31]{
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},

                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},

                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0}
            };

            int[] IndexList = new int[15]{
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14
            };

            Helper.DEbug = Debug;
            for (int today = 0; today < day; today++)
            {
                int IseCixaBilen = Helper.IseCixaBilen(table, n, today);
                int IstirahetCixan = IseCixaBilen - a;
                int IseCixan = IseCixaBilen - IstirahetCixan;

                double YekunEvdeQalan = 0;

                 if (IstirahetCixan != 0)
                //if (true)
                {
                    double MinIstirahetIsciSayi = IseCixan / (double)IstirahetCixan < min ? IseCixaBilen / ((min + max) / 2.0) : IstirahetCixan;
                    double MaxIstirahetIsciSayi = IseCixan / (double)IstirahetCixan > max ? IseCixaBilen / (double)max : IstirahetCixan;
                    YekunEvdeQalan = IseCixan / (double)IstirahetCixan < min ? MinIstirahetIsciSayi : MaxIstirahetIsciSayi;
                }
                double x = YekunEvdeQalan;
                int y = 0;
                bool k = false;
                while( !(x <=max && x >=min) && x - 1 >= 0)
                {
                    x = (IseCixan - y) / (double)(IstirahetCixan + y);
                    y++;
                    k = true;
                    if(Debug) System.Console.WriteLine("run" + x);
                    
                }

                if(k)YekunEvdeQalan = (IstirahetCixan +y - 1);
                if(Debug) System.Console.WriteLine("Day"+ (today + 1) + " res:" + YekunEvdeQalan +  "  x :" + x);

                if (Debug)
                {
                    System.Console.WriteLine($"day: {today +1}: YekunEvdeQalan:{YekunEvdeQalan}");
                }



                int pivot = 0;

                for (int j = 0; j < n; j++)
                {
                    if (YekunEvdeQalan <= 0) break;

                    int cursor = IndexList[j];

                    int h = today == day - 1 ? 0 : 1;
                    // if (cursor == n) cursor = 0;
                    if (table[cursor, today] == (int)Helper.DayTypes.Null && 
                        table[cursor, today + h] == (int)Helper.DayTypes.Null)
                    {
                        
                        pivot = cursor;
                        
                        table[cursor, today] = (int)Helper.DayTypes.Istirahet;
                        YekunEvdeQalan--;
                       
                    }

                }

                Helper.FillWorkDay(table, today, n, isYuku, min, max);
                Helper.Sort(isYuku, IndexList, n, today, pivot);

                // System.Console.WriteLine();

                // foreach (var item in IndexList)
                // {
                //     System.Console.Write(item + " ");
                // }

            }

            Helper.Show(table, n, day, isYuku);

            // Helper.Sort(isYuku,IndexList, n,27);

            // System.Console.WriteLine();

            // foreach (var item in IndexList)
            // {
            //     System.Console.Write(item + " ");
            // }

        }
    }
}
