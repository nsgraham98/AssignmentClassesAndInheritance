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

        public Refrigerator() { } 

        public int NumDoors { get => numDoors; set => numDoors = value; }
        public float Height { get => height; set => height = value; }
        public float Width { get => width; set => width = value; }

        public override string ToString()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{NumDoors};{Height};{Width};";
        }
        public static string ToStringDetailed(Refrigerator rf)
        {
            return $"ItemNumber: {rf.ItemNumber}\nBrand: {rf.Brand}\nQuantity: {rf.Quantity}\nWattage: {rf.Wattage}\nColor: {rf.Color}\nPrice: {rf.Price}\nNumDoors: {rf.NumDoors}\nHeight: {rf.Height}\nWidth: {rf.Width}\n";
        }
    }
}
