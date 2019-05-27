using System;

namespace iq
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Debug = false;
            /*--Input--*/

            int n = 12;
            int a = 9;
            int min = 1;
            int max = 5;
            int day = 30;

            /*-------*/

            int[,] table = new int[15, 31]{
                {3,3,3,3,3, 3,3,3,3,3, 3,3,3,3,3, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,3,3,3,0, 0,4,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,4,0,0,0, 0},
                {0,0,0,0,0, 3,3,3,3,3, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {3,3,3,0,0, 0,0,0,0,0, 3,3,3,3,3, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0},

                {0,0,0,0,0, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,4,0,0,0, 0},
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
            int[] workerCount = new int[31];
            Helper.DEbug = Debug;

            //Stage 1
            System.Console.WriteLine("Stage: 1\n");
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
                while (!(x <= max && x >= min) && x - 1 >= 0)
                {
                    x = (IseCixan - y) / (double)(IstirahetCixan + y);
                    y++;
                    k = true;
                    if (Debug) System.Console.WriteLine("run" + x);

                }

                if (k) YekunEvdeQalan = (IstirahetCixan + y - 1);
                if (Debug) System.Console.WriteLine("Day" + (today + 1) + " res:" + YekunEvdeQalan + "  x :" + x);

                if (Debug)
                {
                    System.Console.WriteLine($"day: {today + 1}: YekunEvdeQalan:{YekunEvdeQalan}");
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
            }
            Helper.Show(table, n, day, isYuku);
            Helper.FillUserCounts(table, workerCount, n, day);
            System.Console.WriteLine("\n ------------------------- \n ");


            //Stage 2
            System.Console.WriteLine("Stage: 2\n");

            for (int i = 0; i < day; i++)
            {
                if (workerCount[i] == a) continue;

                for (int j = 0; j < n; j++)
                {
                    if (table[j, i] == (int)Helper.DayTypes.Istirahet)
                    {
                        int l = Helper.CalWorkDay(table, i, j, Helper.Direction.Left, day);
                        int r = Helper.CalWorkDay(table, i, j, Helper.Direction.Right, day);
                        //System.Console.WriteLine((i +1) + " " + (1 + j));
                        if (l + r + 1 <= max)
                        {
                            table[j, i] = (int)Helper.DayTypes.Is;
                            workerCount[i]++;
                        }

                    }

                    if (workerCount[i] == a) break;
                }

            }
            Helper.Show(table, n, day, isYuku);
            System.Console.WriteLine("\n ------------------------- \n ");

            //Stage 3
            System.Console.WriteLine("Stage: 3\n");
            for (int z = 1; z <= day; z++)
                for (int i = 1; i < day - 1; i++)
                {
                    if (workerCount[i] == a) continue;

                    for (int j = 0; j < n; j++)
                    {
                        if (table[j, i] != (int)Helper.DayTypes.Istirahet) continue;
                        if (Math.Abs(workerCount[i] - workerCount[i - 1]) > Math.Abs(workerCount[i] - workerCount[i + 1]))
                        {
                            if (Math.Abs(workerCount[i] - workerCount[i - 1]) >= 2)
                            {
                                int r = Helper.CalWorkDay(table, i, j, Helper.Direction.Right, day);
                                int l = Helper.CalWorkDay(table, i, j, Helper.Direction.Left, day);

                                if (r < max && l > min)
                                {
                                    table[j, i] = (int)Helper.DayTypes.Is;
                                    workerCount[i]++;
                                    table[j, i - 1] = (int)Helper.DayTypes.Istirahet;
                                    workerCount[i - 1]--;
                                }

                                //System.Console.WriteLine((i+1) + " -- " + (j+1) + "    " +l +  " - "+ r);

                            }
                        }
                        else
                        {
                            if (Math.Abs(workerCount[i] - workerCount[i + 1]) >= 2)
                            {
                                int r = Helper.CalWorkDay(table, i, j, Helper.Direction.Right, day);
                                int l = Helper.CalWorkDay(table, i, j, Helper.Direction.Left, day);

                                if (l < max && r > min)
                                {
                                    table[j, i] = (int)Helper.DayTypes.Is;
                                    workerCount[i]++;
                                    table[j, i + 1] = (int)Helper.DayTypes.Istirahet;
                                    workerCount[i + 1]--;
                                }

                                //System.Console.WriteLine((i+1) + " -- " + (j+1) + "    " +l +  " - "+ r);

                            }
                        }
                    }
                }

            Helper.Show(table, n, day, isYuku);
            System.Console.WriteLine("\n ------------------------- \n ");

            //Stage 4
            System.Console.WriteLine("Stage: 4\n");

            for (int i = 0; i < day; i++)
            {
                if ((i + 1) % 7 == 0 && workerCount[i] < a)
                {
                    for (int j = 0; j < n; j++)
                    {

                        if (workerCount[i] == a) break;

                        bool isShifted = false;

                        if (table[j, i] == (int)Helper.DayTypes.Is)
                        {

                            for (int l = 1; l <= 3; l++)
                            {
                                int index = Helper.MinValueOfBound(workerCount, i - l, i + l, 0, day - 1);
                            
                                if (table[j, index]==(int)Helper.DayTypes.Is && workerCount[index] < workerCount[i])
                                {
                                    System.Console.WriteLine($"day :{index + 1}    j:{j + 1}");
                                    if (index < i) // it is left 
                                    {
                                        int rig = Helper.CalWorkDay(table, index, j, Helper.Direction.Right, day);
                                        int left = Helper.CalWorkDay(table, index, j, Helper.Direction.Left, day);

                                        if (rig < max && left > min)
                                        {
                                            table[j, i] = (int)Helper.DayTypes.Istirahet;
                                            workerCount[i]--;
                                            table[j, index] = (int)Helper.DayTypes.Is;
                                            workerCount[index]++;

                                            isShifted = true;
                                        }
                                    }
                                    else
                                    {
                                        int rig = Helper.CalWorkDay(table, i, j, Helper.Direction.Right, day);
                                        int left = Helper.CalWorkDay(table, i, j, Helper.Direction.Left, day);

                                        if (left < max && rig > min)
                                        {
                                            table[j, i] = (int)Helper.DayTypes.Istirahet;
                                            workerCount[i]--;
                                            table[j, index] = (int)Helper.DayTypes.Is;
                                            workerCount[index]++;

                                            isShifted = true;
                                        }
                                    }
                                }
                                if (isShifted) break;
                            }
                        }

                    }
                }

            }

            Helper.Show(table, n, day, isYuku);
            System.Console.WriteLine("\n ------------------------- \n ");
        }
    }
}
