using System;

namespace iq
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Debug = false;
            /*--Input--*/

            int n = 10;
            int a = 7;
            int min = 2;
            int max = 4;
            int day = 30;

            /*-------*/

            int[,] table = new int[15, 31]{
                {3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,4,4, 4,4,4,4,4, 4,4,4,4,0, 0,0,0,0,0, 3,3,3,3,3, 0,0,0,0,0, 0},
                {0,0,0,4,4, 4,4,0,0,0, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,3,3 ,3,3,3,0,0, 0},
                {3,3,3,3,3, 0,3,3,3,3, 3,3,3,3,3, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,4,4,4, 4,4,4,4,4, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},

                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 4,4,4,4,4, 4,4,4,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},

                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
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
            for (int today = 0; today < day-1; today++)
            {
                int IseCixaBilen = Helper.IseCixaBilen(table, n, today);
                int IstirahetCixan = IseCixaBilen - a;
                int IseCixan = IseCixaBilen - IstirahetCixan;

                double YekunEvdeQalan = 0;

                 if (IstirahetCixan != 0)
                //if (true)
                {
                    double MinIstirahetIsciSayi = IseCixan / (double)IstirahetCixan < min ? IseCixaBilen / 3.0 : IstirahetCixan;
                    double MaxIstirahetIsciSayi = IseCixan / (double)IstirahetCixan > max ? IseCixaBilen / (double)max : IstirahetCixan;
                    YekunEvdeQalan = IseCixan / (double)IstirahetCixan < min ? MinIstirahetIsciSayi : MaxIstirahetIsciSayi;
                }
                double x = YekunEvdeQalan;
                int y = 0;
                bool k = false;
                while( !(x <=max && x >=min))
                {
                    x = (IseCixan - y) / (double)(IstirahetCixan + y);
                    y++;
                    k = true;
                    
                }

                if(k)YekunEvdeQalan = (IstirahetCixan +y - 1);
                System.Console.WriteLine("DAy"+ today + " res:" + YekunEvdeQalan +  "  x :" + x);

                if (Debug)
                {
                    System.Console.WriteLine($"day: {today}: YekunEvdeQalan:{YekunEvdeQalan}");
                }



                int pivot = 0;

                for (int j = 0; j < n; j++)
                {
                    if (YekunEvdeQalan == 0) break;

                    int cursor = IndexList[j];
                    // if (cursor == n) cursor = 0;
                    if (table[cursor, today] == (int)Helper.DayTypes.Null && table[cursor, today + 1] == (int)Helper.DayTypes.Null)
                    {
                        table[cursor, today] = (int)Helper.DayTypes.Istirahet;
                        YekunEvdeQalan--;
                        pivot = cursor;
                    }

                }

                Helper.FillWorkDay(table, today, n, isYuku);
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
