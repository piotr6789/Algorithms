using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class ChangeMaking
    {
        public List<double> Cash = new List<double>();
        public List<double> Quantity = new List<double>();
        public List<double> QuantityHelper = new List<double>();
        public double[] oddMoneyArray;
        public double[] denominationArray;
        public int count = 14;
        public double amount = 0;
        public double payment = 0;
        public double oddMoney = 0;
        public string check = "";
        public string summary = "";
        public bool hasMoney = true;

        public ChangeMaking()
        {
            double[] valuesCash = { 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000 };
            double[] valuesQuantity = { 10, 20, 13, 15, 15, 12, 8, 9, 7, 5, 1, 2, 5, 3 };
            Cash.AddRange(valuesCash);
            Quantity.AddRange(valuesQuantity);
            QuantityHelper.AddRange(valuesQuantity);
            Start();
        }

        public void Start()
        {


            while (hasMoney)
            {
                Random randomAmount = new Random();
                amount = randomAmount.Next(50, 1000);
                //amount = double.Parse(Console.ReadLine());
                Console.WriteLine("Cena wynosi: {0}zł", amount);
                amount = amount * 100;
                Console.Write("Podaj kwotę lub sprawdź nominały: ");
                check = Console.ReadLine();

                if (check.Equals("sprawdz"))
                {
                    CheckCash();
                    continue;
                }
                else
                {
                    payment = double.Parse(check);
                    payment = payment * 100;
                    oddMoney = payment - amount;
                    summary = "";
                }

                oddMoneyArray = new double[(int)oddMoney + 1];
                denominationArray = new double[(int)oddMoney + 1];
                oddMoneyArray[0] = 0;

                for (int i = 1; i < oddMoneyArray.Length; i++)
                {
                    oddMoneyArray[i] = int.MaxValue;
                    denominationArray[i] = 0;
                }

                for (int j = 0; j < Cash.Count; j++)
                {
                    int n = (int)Cash[j];
                    for (int k = 0; k <= oddMoney - n; k++)
                    {
                        if (oddMoneyArray[k] < int.MaxValue)
                        {
                            if (oddMoneyArray[k] + 1 < oddMoneyArray[k + n])
                            {
                                oddMoneyArray[k + n] = oddMoneyArray[k] + 1;
                                denominationArray[k + n] = n;
                            }
                        }
                    }
                }
                if(denominationArray[(int)oddMoney] == 0)
                {
                    summary = "Brak możliwości wydania reszty";
                }
                else
                {
                    int numb = (int)oddMoney;
                    while (numb != 0)
                    {
                        summary = summary + denominationArray[numb] / 100 + "zł ";
                        numb = numb - (int)denominationArray[numb];
                    }

                    Console.WriteLine(summary);
                }
            }
            
        }

        public void CheckCash()
        {
            for (int i = 0; i < Cash.Count; i++)
            {
                Console.WriteLine(Quantity[i] + "  :  " + Cash[i] / 100 + " zł");
            }
            Console.WriteLine();
        }
    }
}
