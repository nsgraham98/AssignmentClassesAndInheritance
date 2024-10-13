using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sven_.Assignment_1
{
    public class Vacuum : Appliance
    {
        string grade;
        int battery_voltage;

        public string Grade { get => grade; set => grade = value; }
        public int Battery_voltage { get => battery_voltage; set => battery_voltage = value; }

        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int battery_voltage)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.grade = grade;
            this.battery_voltage = battery_voltage;
        }

        public override string ToString()
        {
            return $"Item#: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\n";
        }

        public static string ToString_Readable(Vacuum VaCu)
        {
            return $"ItemNumber: {VaCu.ItemNumber}\nBrand: {VaCu.Brand}\nQuantity: {VaCu.Quantity}\nWattage: {VaCu.Wattage}\nColor: {VaCu.Color}\nPrice: {VaCu.Price}\nGrade: {VaCu.Grade}\nBatteryVoltage: {VaCu.battery_voltage}\n";
        }
    }
}

