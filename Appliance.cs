using AssignmentClassesAndInheritance;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OOP2AssignmentClassesAndInheritance
{
    public class Appliance
    {
        long itemNumber;
        string brand;
        int quantity;
        double wattage;
        string color;
        double price;

        public Appliance(long itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            this.itemNumber = itemNumber;
            this.brand = brand;
            this.quantity = quantity;
            this.wattage = wattage;
            this.color = color;
            this.price = price;
        }
        
        public Appliance() { }

        public long ItemNumber { get => itemNumber; set => itemNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Wattage { get => wattage; set => wattage = value; }
        public string Color { get => color; set => color = value; }
        public double Price { get => price; set => price = value; }

        public static bool IsAvailable(Appliance app)
        {
            if (app.Quantity > 0)
            {
                return true;
            }
            else { return false; }
        }

        public static Appliance Checkout(Appliance app)
        {
            Console.WriteLine($"Appliance \"{app.ItemNumber}\" has been checked out.\n");
            app.Quantity--;
            return app;
        }
        public static void FormatForFile(List<Appliance> appList)
        {
            List<string> appStringList = new List<string>();
            string path = "..\\..\\res\\appliances.txt";
            foreach (Appliance app in appList)
            {
                if (app is Refrigerator)
                {
                    Refrigerator rf = app as Refrigerator;
                    string rfString = rf.ToString();
                    appStringList.Add(rfString);
                }
                if (app is Microwave)
                {
                    Microwave mw = app as Microwave;
                    string mwString = mw.ToString();
                    appStringList.Add(mwString);
                }
                if (app is Vacuum)
                {
                    Vacuum v = app as Vacuum;
                    string vString = v.ToString();
                    appStringList.Add(vString);
                }
                if (app is Dishwasher)
                {
                    Dishwasher dw = app as Dishwasher;
                    string dwString = dw.ToString();
                    appStringList.Add(dwString);
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string appString in appStringList)
                {
                    sw.WriteLine(appString);
                }
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
