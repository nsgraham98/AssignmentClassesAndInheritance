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

        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.soundRating = soundRating;
            this.feature = feature;
        }

        public Dishwasher() { }

        public string SoundRating { get => soundRating; set => soundRating = value; }
        public string Feature { get => feature; set => feature = value; }

        public override string ToString()
        {
            //return base.ToString();
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Feature};{SoundRating};";
        }

        public static string ToStringDetailed(Dishwasher dw)
        {
            return $"Item Number: {dw.ItemNumber}\nBrand: {dw.Brand}\nQuantity: {dw.Quantity}\nWattage: {dw.Wattage}\nColor: {dw.Color}\nPrice: {dw.Price}\nFeature: {dw.Feature}\nSoundRating: {dw.SoundRating}\n";
        }
    }
}
