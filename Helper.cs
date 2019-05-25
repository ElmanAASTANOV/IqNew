using System;

namespace iq
{
    public static class Helper
    {
        public static bool DEbug = true;
        public enum DayTypes
        {
            Null = 0,
            Is = 1,
            Istirahet = 2,
            Mezuniyyet = 3,
            Xeste = 4
        }

        public enum Direction
        {
            Left = 0,
            Right = 1
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
                string gap1 = i <9 ? gaps[1] : gaps[0];
                System.Console.Write((i + 1) + gap1);
                int isYuk = 0;

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
                            isYuk++;
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
                System.Console.Write("  |" + isYuk);
                System.Console.WriteLine();
            }

            System.Console.Write("   ");
            for (int i = 0; i < w; i++)
            {
                int c = 0;
                for (int j = 0; j < h; j++)
                {
                    if (table[j, i] == (int)DayTypes.Is) c++;
                }
                string gap1 = i < 8 ? gaps[0] : gaps[1];
                System.Console.Write(c + gap1);
            }
        }

        public static void FillWorkDay(int[,] table, int day, int userCount, int[,] isYukuList, int min, int max)
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

                if (isYukuList[user, day] == (max + 1))
                {
                    table[user, day] = (int)DayTypes.Istirahet;
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

        public static void FillUserCounts(int[,] table, int[] workerCount, int userCount, int day)
        {
            for (int i = 0; i < day; i++)
            {
                int isYuk = 0;

                for (int j = 0; j < userCount; j++)
                {
                    if (table[j, i] == (int)DayTypes.Is) isYuk++;
                }

                workerCount[i] = isYuk;
            }

        }

        public static int CalWorkDay(int[,] table, int toDay,int user, Direction dir, int day)
        {
            int sum = 0;
            int x = dir == Direction.Left ? -1 : 1;
            toDay+=x;
            for (int i = toDay; i>=0 && i < day; i += x)
            {
                if(table[user, i]==(int)DayTypes.Is)
                sum++;
                else
                break;
            }

            return sum;
        }
    }
}