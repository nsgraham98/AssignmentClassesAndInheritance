using System;
using System.Collections.Generic;
using System.Linq;
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

        public long ItemNumber { get => itemNumber; set => itemNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Wattage { get => wattage; set => wattage = value; }
        public string Color { get => color; set => color = value; }
        public double Price { get => price; set => price = value; }
    }
}
