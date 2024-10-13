using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sven_.Assignment_1
{
    public class Appliance
    {
        long itemNumber;
        string brand;
        int quantity;
        double wattage;
        string color;
        double price;

        public long ItemNumber { get => itemNumber; set => itemNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Wattage { get => wattage; set => wattage = value; }
        public string Color { get => color; set => color = value; }
        public double Price { get => price; set => price = value; }

        public Appliance(long itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            this.ItemNumber = itemNumber;
            this.Brand = brand;
            this.Quantity = quantity;
            this.Wattage = wattage;
            this.Color = color;
            this.Price = price;
        }

        public Appliance()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static void FormatForFile(List<Appliance> appliances)
        {
            List<string> itemStrings = new List<string>();
            string path = "..\\..\\res\\appliances.txt";
            foreach (Appliance item in appliances)
            {
                if (item is Dishwasher)
                {
                    Dishwasher DiWa = item as Dishwasher;
                    string DiWaSTR = DiWa.ToString();
                    itemStrings.Add(DiWaSTR);

                }

                if (item is Microwave)
                {
                    Microwave MiWa = item as Microwave;
                    string MiWaSTR = MiWa.ToString();
                    itemStrings.Add(MiWaSTR);

                }

                if (item is Refrigerator)
                {
                    Refrigerator ReFri = item as Refrigerator;
                    string ReFriSTR = ReFri.ToString();
                    itemStrings.Add(ReFriSTR);

                }

                if (item is Vacuum)
                {
                    Vacuum VaCu = item as Vacuum;
                    string VaCuSTR = VaCu.ToString();
                    itemStrings.Add(VaCuSTR);

                }

                using (StreamWriter stream = new StreamWriter(path))
                {
                    foreach (string itemString in itemStrings)
                        stream.WriteLine(itemString);
                }
            }
        }

        public static Appliance Checkout(Appliance item)
        {
            Console.WriteLine($"Appliance \"{item.itemNumber}\" has been checked out.");
            item.Quantity--;
            return item;

        }

        public static bool IsAvailable(Appliance item)
        {
            if (item.Quantity > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
