using System;

namespace iq
{
    class Program
    {
        static void Main(string[] args)
        {
            /*--Input--*/

            int n = 12;
            int a = 8;
            int min = 2;
            int max = 4;
            int day = 30;

            /*-------*/

            int[,] table = new int[15, 31]{
                {3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,3,3,3,3, 3,3,3,3,3, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,4,4,4, 4,4,4,4,4, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},

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

            for (int today = 0; today < day; today++)
            {
                int IseCixaBilen = Helper.IseCixaBilen(table, n, today);
                int IstirahetCixan = IseCixaBilen - a;
                int IseCixan = IseCixaBilen - IstirahetCixan;

                //System.Console.WriteLine(IseCixan);
                int YekunEvdeQalan = 0;

                if (IstirahetCixan != 0)
                {
                    int MinIstirahetIsciSayi = IseCixaBilen / IstirahetCixan < min ? IseCixaBilen / 3 : IstirahetCixan;
                    int MaxIstirahetIsciSayi = IseCixaBilen / IstirahetCixan > max ? IseCixaBilen / max : IstirahetCixan;
                    YekunEvdeQalan = IseCixan / IstirahetCixan < min ? MinIstirahetIsciSayi : MaxIstirahetIsciSayi;
                }


                 

                int pivot = 0;

                for (int j = 0; j < n; j++)
                {
                    if (YekunEvdeQalan == 0) break;

                    int cursor = IndexList[j];
                    // if (cursor == n) cursor = 0;
                    if (table[cursor, today] == (int)Helper.DayTypes.Null)
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
