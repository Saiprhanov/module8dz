using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul8.2
{
    class UtilityBills
    {
        private double heatingRate; // Тариф на отопление (на 1 м2 площади)
        private double waterRate;   // Тариф на воду (на 1 чел)
        private double gasRate;     // Тариф на газ (на 1 чел)
        private double repairRate;  // Тариф на текущий ремонт (на 1 м2 площади)

        public UtilityBills(double heatingRate, double waterRate, double gasRate, double repairRate)
        {
            this.heatingRate = heatingRate;
            this.waterRate = waterRate;
            this.gasRate = gasRate;
            this.repairRate = repairRate;
        }

        public double this[string paymentType]
        {
            get
            {
                switch (paymentType.ToLower())
                {
                    case "отопление":
                        return heatingRate;
                    case "вода":
                        return waterRate;
                    case "газ":
                        return gasRate;
                    case "ремонт":
                        return repairRate;
                    default:
                        throw new ArgumentException("Недопустимый вид платежа");
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double heatingRate = 2.0; // Тариф на отопление (на 1 м2 площади)
            double waterRate = 1.5;   // Тариф на воду (на 1 чел)
            double gasRate = 1.0;     // Тариф на газ (на 1 чел)
            double repairRate = 3.0;  // Тариф на текущий ремонт (на 1 м2 площади)

            UtilityBills utilityBills = new UtilityBills(heatingRate, waterRate, gasRate, repairRate);

            Console.Write("Введите площадь помещения (в м2): ");
            double area = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите количество проживающих людей: ");
            int numberOfResidents = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите сезон (осень/зима): ");
            string season = Console.ReadLine().ToLower();

            Console.Write("Есть ли льготы (ветеран труда/ветеран войны/нет): ");
            string discountType = Console.ReadLine().ToLower();

            double heatingCost = area * utilityBills["отопление"];
            double waterCost = numberOfResidents * utilityBills["вода"];
            double gasCost = numberOfResidents * utilityBills["газ"];
            double repairCost = area * utilityBills["ремонт"];

            if (season == "зима")
            {
                heatingCost *= 1.2; // Увеличиваем стоимость отопления на 20% зимой
            }

            double totalCost = heatingCost + waterCost + gasCost + repairCost;

            double discount = 0.0;

            if (discountType == "ветеран труда")
            {
                discount = totalCost * 0.3; // 30% скидка для ветерана труда
            }
            else if (discountType == "ветеран войны")
            {
                discount = totalCost * 0.5; // 50% скидка для ветерана войны
            }

            double finalCost = totalCost - discount;

            Console.WriteLine("Вид платежа\t\tНачислено\tЛьготная скидка\tИтого");
            Console.WriteLine($"Отопление\t\t{heatingCost:C2}\t\t{discount:C2}\t\t{heatingCost - discount:C2}");
            Console.WriteLine($"Вода\t\t\t{waterCost:C2}\t\t{discount:C2}\t\t{waterCost - discount:C2}");
            Console.WriteLine($"Газ\t\t\t{gasCost:C2}\t\t{discount:C2}\t\t{gasCost - discount:C2}");
            Console.WriteLine($"Ремонт\t\t\t{repairCost:C2}\t\t{discount:C2}\t\t{repairCost - discount:C2}");
            Console.WriteLine("\nИтоговая сумма:\t\t\t\t\t\t" + finalCost.ToString("C2"));
            Console.ReadKey();
        }
    }
}
