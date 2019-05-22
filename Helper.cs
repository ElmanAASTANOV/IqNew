using System;

namespace iq
{
    public static class Helper
    {
        static bool DEbug = false;
        public enum DayTypes
        {
            Null = 0,
            Is = 1,
            Istirahet = 2,
            Mezuniyyet = 3,
            Xeste = 4
        }

        public static int IseCixaBilen(int[,] table, int userCount, int day)
        {
            int count = 0;

            for (int i = 0; i < userCount; i++)
            {
                if (table[i, day] == (int)DayTypes.Null)
                {
                    count++;
                }
            }

            return count;
        }
        public static void Show(int[,] table, int h, int w, int[,] isYukuList)
        {
            string[] gaps = { " ", "  " };
            System.Console.Write("   ");
            for (int i = 0; i < w; i++)
            {
                //if( i==0 )  System.Console.Write(i + "  ");
                System.Console.Write(i + 1 + " ");
            }
            System.Console.WriteLine();



            for (int i = 0; i < h; i++)
            {
                string gap1 = i < 10 ? gaps[1] : gaps[0];
                System.Console.Write(i + gap1);

                for (int j = 0; j < w; j++)
                {
                    string gap = j < 8 ? gaps[0] : gaps[1];

                    string yuk = DEbug ? isYukuList[i, j].ToString() : "";

                    switch (table[i, j])
                    {
                        case (int)DayTypes.Istirahet:
                            System.Console.Write("*" + yuk + gap);
                            break;

                        case (int)DayTypes.Is:
                            System.Console.Write("-" + yuk + gap);
                            break;

                        case (int)DayTypes.Xeste:
                            System.Console.Write("X" + yuk + gap);
                            break;

                        case (int)DayTypes.Mezuniyyet:
                            System.Console.Write("M" + yuk + gap);
                            break;
                        case (int)DayTypes.Null:
                            System.Console.Write("N" + yuk + gap);
                            break;
                    }
                }
                System.Console.WriteLine();
            }

        }

        public static void FillWorkDay(int[,] table, int day, int userCount, int[,] isYukuList)
        {

            for (int user = 0; user < userCount; user++)
            {
                if (table[user, day] == (int)DayTypes.Null)
                {
                    table[user, day] = (int)DayTypes.Is;
                    isYukuList[user, day] = isYukuList[user, day == 0 ? 1 : day - 1] + 1;
                }
                else
                {
                    isYukuList[user, day] = 0;
                }
            }
        }

        public static void Sort(int[,] isYukuList, int[] indexList, int userCount, int day, int pivot)
        {

            // for (int item= 0; item<userCount; item++)
            //     {
            //         System.Console.Write(indexList[item]+ "-" +isYukuList[indexList[item],day]+ " ");
            //     }
            //     System.Console.WriteLine();

            for (int i = 0; i < userCount; i++)
            {

                for (int j = 0; j < userCount - 1 - i; j++)
                {
                    if (isYukuList[indexList[j], day] < isYukuList[indexList[j + 1], day])
                    {
                        int temp = indexList[j];
                        indexList[j] = indexList[j + 1];
                        indexList[j + 1] = temp;
                    }

                    if (isYukuList[indexList[j], day] == isYukuList[indexList[j + 1], day])
                    {
                        if (indexList[j] < pivot + 1 && indexList[j + 1] > pivot + 1)
                        {
                            int temp = indexList[j];
                            indexList[j] = indexList[j + 1];
                            indexList[j + 1] = temp;
                        }
                        else
                        {
                            // if (indexList[j] > indexList[j + 1])
                            // {
                            //     int temp = indexList[j];
                            //     indexList[j] = indexList[j + 1];
                            //     indexList[j + 1] = temp;
                            // }
                        }
                    }

                }
                // for (int item= 0; item<userCount; item++)
                // {
                //     System.Console.Write(indexList[item]+ "-" +isYukuList[indexList[item],day]+ " ");
                // }
                // System.Console.WriteLine();
            }

        }
    }
}