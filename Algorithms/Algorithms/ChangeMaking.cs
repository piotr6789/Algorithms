using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class ChangeMaking
    {
        public List<double> Cash = new List<double>();
        public List<double> Quantity = new List<double>();
        public List<double> QuantityHelper = new List<double>();
        public int count = 0;
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
            count = 14;
            Start();
        }

        public void Start()
        {
            while (hasMoney)
            {
                Random randomAmount = new Random();
                amount = randomAmount.Next(50, 1000);
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

                for(int i = 13; i >=0; i--)
                {
                    while(oddMoney - (Cash[i]) >= 0 && Quantity[i] != 0)
                    {
                        oddMoney = oddMoney - (Cash[i]);
                        Quantity[i]--;
                        summary = summary + Cash[i]/100 + "zł ";
                    }
                }

                if(oddMoney == 0)
                {
                    Console.WriteLine("Reszta: " + summary + "\n");
                    summary = "";
                    for (int i = 0; i < QuantityHelper.Count; i++)
                    {
                        QuantityHelper[i] = Quantity[i];
                    }
                }
                else
                {
                    Console.WriteLine("Brak możliwosci wydania reszty.\n");
                    for (int i = 0; i < QuantityHelper.Count; i++)
                    {
                        Quantity[i] = QuantityHelper[i];
                    }
                }
            }
        }

        public void CheckCash()
        {
            for(int i = 0; i < Cash.Count; i++)
            {
                Console.WriteLine(Quantity[i] + "  :  " + Cash[i]/100 + " zł");
            }
            Console.WriteLine();
        }
    }
}
