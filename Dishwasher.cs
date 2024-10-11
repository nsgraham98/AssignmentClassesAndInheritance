using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2AssignmentClassesAndInheritance
{
    public class Dishwasher : Appliance
    {
        string soundRating;
        string feature;

        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price, string soundRating, string feature) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.soundRating = soundRating;
            this.feature = feature;
        }

        public string SoundRating { get => soundRating; set => soundRating = value; }
        public string Feature { get => feature; set => feature = value; }

        public override string ToString()
        {
            //return base.ToString();
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\n";
        }
    }
}
