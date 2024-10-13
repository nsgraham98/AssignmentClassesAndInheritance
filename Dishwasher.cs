using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sven_.Assignment_1
{
    public class Dishwasher : Appliance
    {
        string sound_rating;
        string feature;

        public string Sound_Rating { get => sound_rating; set => sound_rating = value; }
        public string Feature { get => feature; set => feature = value; }

        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price, string sound_rating, string feature)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Sound_Rating = sound_rating;
            this.Feature = feature;
        }

        public override string ToString()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Feature};{Sound_Rating}";
        }

        public static string ToString_Readable(Dishwasher DiWa)
        {
            return $"Item#: {DiWa.ItemNumber}\nBrand: {DiWa.Brand}\nQuantity: {DiWa.Quantity}\nWattage: {DiWa.Wattage}\nColor: {DiWa.Color}\nPrice: {DiWa.Price}\nFeature: {DiWa.Feature}\nSoundRating: {DiWa.Sound_Rating}\n";
        }
    }
}
