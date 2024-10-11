using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2AssignmentClassesAndInheritance
{
    public class Microwave : Appliance
    {
        float capacity;
        string roomType;

        public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, double price, float capacity, string roomType) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.capacity = capacity;
            this.roomType = roomType;
        }

        public float Capacity { get => capacity; set => capacity = value; }
        public string RoomType { get => roomType; set => roomType = value; }

        public override string ToString()
        {
            //return base.ToString();
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\n";
        }
    }
}
