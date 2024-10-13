using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sven_.Assignment_1
{
    public class Refrigerator : Appliance
    {
        int num_of_doors;
        float height;
        float width;

        public int Num_of_doors { get => num_of_doors; set => num_of_doors = value; }
        public float Height { get => height; set => height = value; }
        public float Width { get => width; set => width = value; }

        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, int num_of_doors, float height, float width)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Num_of_doors = num_of_doors;
            this.Height = height;
            this.Width = width;
        }

        public override string ToString()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{num_of_doors};{Height};{Width};";
        }

        public static string ToString_Readable(Refrigerator ReFri)
        {
            return $"ItemNumber: {ReFri.ItemNumber}\nBrand: {ReFri.Brand}\nQuantity: {ReFri.Quantity}\nWattage: {ReFri.Wattage}\\nColor: {ReFri.Color}\nPrice: {ReFri.Price}\nNumDoors: {ReFri.num_of_doors}\nHeight: {ReFri.Height}\nWidth: {ReFri.Width}\n";
        }
    }
}
