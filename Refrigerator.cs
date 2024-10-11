using AssignmentClassesAndInheritance;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2AssignmentClassesAndInheritance
{
    public class Refrigerator : Appliance
    {
        int numDoors;
        float height;
        float width;

        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, int numDoors, float height, float width) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.numDoors = numDoors;
            this.height = height;
            this.width = width;
        }

        public int NumDoors { get => numDoors; set => numDoors = value; }
        public float Height { get => height; set => height = value; }
        public float Width { get => width; set => width = value; }

        public override string ToString()
        {
            //return base.ToString();
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\n";
        }
    }
}
