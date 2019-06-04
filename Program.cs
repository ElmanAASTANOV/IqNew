using System;

namespace iq
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Debug = false;

            #region Inputs--

            int n = 12;
            int a = 9;
            int min = 2;
            int max = 4;
            int day = 30;

            int[] lessPrioritedDays = { 6, 13, 20, 27 };


            #endregion

            #region Variables init

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

            int[,] table3 = new int[15, 31]{
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

            int[,] table2 = new int[15, 31]{
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {3,3,3,3,3, 3,3,3,3,3, 3,3,3,3,3, 3,3,3,3,3, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},

                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 3,3,3,3,3, 3,3,3,3,3, 3,3,3,3,3, 3,3,3,3,3, 0},
                {0,0,4,4,4, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},

                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,4,4,4,4, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0}
            };

            int[,] isYuku = new int[15, 31]{
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {3,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {4,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},

                {3,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {1,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {1,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},

                {2,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {2,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
                {3,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0},
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

            #endregion

            #region Stage 1
            System.Console.WriteLine("Stage: 1 - Apply free days by Formula\n");
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
                //if (Debug) System.Console.WriteLine("Day" + (today + 1) + " res:" + YekunEvdeQalan + "  x :" + x);

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

                    bool a1 = table[cursor, today] == (int)Helper.DayTypes.Null;
                    bool a2 = table[cursor, today + h] == (int)Helper.DayTypes.Null;
                    bool a3 = isYuku[cursor, today == 0 ? 0 : today - 1] >= min;
                    if (a1 && a2 && a3)
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

            #endregion

            #region Stage 2
            System.Console.WriteLine("Stage: 2 - Deleting \n");

            int[] workerCountsOfDays = Helper.SortWorkerCountOfDays(table, n, day);

            // System.Console.WriteLine("--- \n \n");

            // for (int l = 0; l < day; l++)
            // {
            //     System.Console.Write(workerCountsOfDays[l] + " ");
            // }

            // System.Console.WriteLine(" \n---\n");

            foreach (int i in workerCountsOfDays)
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

            #endregion

            #region Stage 3
            System.Console.WriteLine("Stage: 3 - Shifting\n");
            for (int z = 1; z <= 10; z++)
                for (int i = 1; i < day; i++)
                {
                    if (workerCount[i] >= a) continue;

                    for (int j = 0; j < n; j++)
                    {
                        if (table[j, i] != (int)Helper.DayTypes.Istirahet) continue;

                        int[] sortedDayArray = Helper.SortWorkerCountOfDaysOndInterval(table, n, day, i - 3 < 0 ? 0 : i - 3, i + 3 > day - 1 ? day - 1 : i + 3);

                        bool dayMoved = false;

                        foreach (int sortedDay in sortedDayArray)
                        {
                            if (table[j, sortedDay] != (int)Helper.DayTypes.Is) continue;

                            if (workerCount[sortedDay] - workerCount[i] >= 2)
                            {
                                table[j, i] = (int)Helper.DayTypes.Is;
                                table[j, sortedDay] = (int)Helper.DayTypes.Istirahet;

                                int r = Helper.CalWorkDay(table, sortedDay, j, Helper.Direction.Right, day);
                                int l = Helper.CalWorkDay(table, sortedDay, j, Helper.Direction.Left, day);

                                if ((r <= max && r >= min) && (l <= max && l >= min))
                                {
                                    workerCount[i]++;
                                    workerCount[sortedDay]--;
                                    dayMoved = true;
                                }
                                else
                                {
                                    table[j, i] = (int)Helper.DayTypes.Istirahet;
                                    table[j, sortedDay] = (int)Helper.DayTypes.Is;
                                }
                            }
                            if (dayMoved) break;
                        }

                    }
                }

            Helper.Show(table, n, day, isYuku);
            System.Console.WriteLine("\n ------------------------- \n ");

            #endregion

            #region Stage 4
            System.Console.WriteLine("Stage: 4 - Priorited days shifting\n");

            foreach (int i in lessPrioritedDays)
            {
                for (int j = 0; j < n; j++)
                {
                    if (table[j, i] != (int)Helper.DayTypes.Is) continue;

                    int[] sortedDayArray = Helper.SortWorkerCountOfDaysOndInterval(table, n, day, i - 3 < 0 ? 0 : i - 3, i + 3 > day - 1 ? day - 1 : i + 3);

                    bool dayMoved = false;

                    foreach (int sortedDay in sortedDayArray)
                    {
                        if (table[j, sortedDay] != (int)Helper.DayTypes.Istirahet) continue;

                        if (workerCount[i] > workerCount[sortedDay])
                        {
                            table[j, i] = (int)Helper.DayTypes.Istirahet;
                            table[j, sortedDay] = (int)Helper.DayTypes.Is;

                            int r = Helper.CalWorkDay(table, i, j, Helper.Direction.Right, day);
                            int l = Helper.CalWorkDay(table, i, j, Helper.Direction.Left, day);

                            if ((r <= max && r >= min) && (l <= max && l >= min))
                            {
                                workerCount[i]--;
                                workerCount[sortedDay]++;
                                dayMoved = true;
                            }
                            else
                            {
                                table[j, i] = (int)Helper.DayTypes.Is;
                                table[j, sortedDay] = (int)Helper.DayTypes.Istirahet;
                            }
                        }
                        if (dayMoved) break;
                    }

                }

            }

            Helper.Show(table, n, day, isYuku);
            System.Console.WriteLine("\n ------------------------- \n ");

            #endregion
        }
    }
}
