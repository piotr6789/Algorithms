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
        public static int[] limits = { 2, 32, 23, 32, 53, 32, 33, 21, 22, 15, 12, 10, 5, 4 };
        public static bool hasCoin = true;

        public static void Start()
        {
            while (hasCoin)
            {
                summary = "";
                Random randomAmount = new Random();
                payment = randomAmount.Next(50, 1000);
                //payment = double.Parse(Console.ReadLine());
                //CheckCash();
                Console.WriteLine("Cena wynosi: {0}zł", payment);
                Console.Write("Podaj kwotę: ");
                double check = double.Parse(Console.ReadLine());
                check = check * 100;
                payment = payment * 100;
                amount = (check - payment);


                int[][] coinsUsed = new int[(int)amount + 1][];
                for (int i = 0; i <= amount; i++)
                {
                    coinsUsed[i] = new int[coins.Length];
                }

                int[] minCoins = new int[(int)amount + 1];
                for (int i = 1; i <= amount; i++)
                {
                    minCoins[i] = int.MaxValue - 1;
                }

                int[] limitsHelper = new int[limits.Length];
                limits.CopyTo(limitsHelper, 0);

                for (int i = 0; i < coins.Length; i++)
                {
                    while (limitsHelper[i] > 0)
                    {
                        for (int j = (int)amount; j >= 0; j--)
                        {
                            int currentAmount = j + coins[i];
                            if (currentAmount <= amount)
                            {
                                if (minCoins[currentAmount] > minCoins[j] + 1)
                                {
                                    minCoins[currentAmount] = minCoins[j] + 1;

                                    coinsUsed[j].CopyTo(coinsUsed[currentAmount], 0);
                                    coinsUsed[currentAmount][i] += 1;
                                }
                            }
                        }

                        limitsHelper[i] -= 1;
                    }
                }

                if (minCoins[(int)amount] == int.MaxValue - 1)
                {
                    Console.WriteLine("Brak możliwości wydania reszty");
                }
                for (int i = limits.Length - 1; i >= 0; i--)
                {
                    while (coinsUsed[(int)amount][i] > 0)
                    {
                        if (i == 0)
                        {
                            summary = summary + "0.01" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 1)
                        {
                            summary = summary + "0.02" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 2)
                        {
                            summary = summary + "0.05" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 3)
                        {
                            summary = summary + "0.1" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 4)
                        {
                            summary = summary + "0.2" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 5)
                        {
                            summary = summary + "0.5" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 6)
                        {
                            summary = summary + "1" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 7)
                        {
                            summary = summary + "2" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 8)
                        {
                            summary = summary + "5" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 9)
                        {
                            summary = summary + "10" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 10)
                        {
                            summary = summary + "20" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 11)
                        {
                            summary = summary + "50" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 12)
                        {
                            summary = summary + "100" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                        if (i == 13)
                        {
                            summary = summary + "200" + "zł ";
                            coinsUsed[(int)amount][i]--;
                            limits[i]--;
                        }
                    }
                }

                Console.WriteLine(summary + "\n");
            }
        }

        public static void CheckCash()
        {
            for (int i = 0; i < limits.Length; i++)
            {
                Console.WriteLine(limits[i] + " : " + (double)coins[i]/100 + "zł");
            }
        }
    }
}