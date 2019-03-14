using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class ChangeMaking
    {
        public static double payment = 0;
        public static string summary = "";
        public static double amount = 0;
        public static int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000 };
        public static int[] limits = { 123, 55, 54, 32, 12, 34, 22, 11, 9, 8, 7, 6, 5, 4 };
        public static bool hasKey = true;

        public static void Start()
        {
            while (hasKey)
            {
                summary = "";
                Random randomAmount = new Random();
                payment = randomAmount.Next(50, 1000);
                //amount = double.Parse(Console.ReadLine());
                Console.WriteLine("Cena wynosi: {0}zł", payment);
                Console.Write("Podaj kwotę: ");
                amount = (double.Parse(Console.ReadLine()) - payment) * 100;


                int[][] coinsUsed = new int[(int)amount + 1][];
                for (int i = 0; i <= amount; ++i)
                {
                    coinsUsed[i] = new int[coins.Length];
                }

                int[] minCoins = new int[(int)amount + 1];
                for (int i = 1; i <= amount; ++i)
                {
                    minCoins[i] = int.MaxValue - 1;
                }

                int[] limitsCopy = new int[limits.Length];
                limits.CopyTo(limitsCopy, 0);

                for (int i = 0; i < coins.Length; ++i)
                {
                    while (limitsCopy[i] > 0)
                    {
                        for (int j = (int)amount; j >= 0; --j)
                        {
                            int currAmount = j + coins[i];
                            if (currAmount <= amount)
                            {
                                if (minCoins[currAmount] > minCoins[j] + 1)
                                {
                                    minCoins[currAmount] = minCoins[j] + 1;

                                    coinsUsed[j].CopyTo(coinsUsed[currAmount], 0);
                                    coinsUsed[currAmount][i] += 1;
                                }
                            }
                        }

                        limitsCopy[i] -= 1;
                    }
                }

                if (minCoins[(int)amount] == int.MaxValue - 1)
                {
                    Console.WriteLine("Brak możliwości wydania reszty");
                }
                for (int i = 0; i < limits.Length; i++)
                {
                    while (coinsUsed[(int)amount][i] >= 0)
                    {
                        if (i == 0)
                        {
                            summary = summary + "0.01" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 1)
                        {
                            summary = summary + "0.02" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 2)
                        {
                            summary = summary + "0.05" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 3)
                        {
                            summary = summary + "0.1" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 4)
                        {
                            summary = summary + "0.2" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 5)
                        {
                            summary = summary + "0.5" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 6)
                        {
                            summary = summary + "1" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 7)
                        {
                            summary = summary + "2" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 8)
                        {
                            summary = summary + "5" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 9)
                        {
                            summary = summary + "10" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 10)
                        {
                            summary = summary + "20" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 11)
                        {
                            summary = summary + "50" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 12)
                        {
                            summary = summary + "100" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                        if (i == 13)
                        {
                            summary = summary + "200" + "zł ";
                            coinsUsed[(int)amount][i]--;
                        }
                    }
                }

                Console.WriteLine(summary);
            }
        }
    }
}