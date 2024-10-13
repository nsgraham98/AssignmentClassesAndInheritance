using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sven_.Assignment_1
{
    public class Microwave : Appliance
    {
        float capacity;
        string room_type;

        public float Capacity { get => capacity; set => capacity = value; }
        public string Room_type { get => room_type; set => room_type = value; }


        public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, double price, float capacity, string room_type)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.capacity = capacity;
            this.room_type = room_type;
        }

        public override string ToString()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Capacity};{room_type};";
        }

        public static string ToString_Readable(Microwave MiWa)
        {
            return $"ItemNumber: {MiWa.ItemNumber}\nBrand: {MiWa.Brand}\nQuantity: {MiWa.Quantity}\nWattage: {MiWa.Wattage}\nColor: {MiWa.Color}\nPrice: {MiWa.Price}\nCapacity: {MiWa.Capacity}\nRoomType: {MiWa.room_type}\n";
        }



    }
}
