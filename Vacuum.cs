using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2AssignmentClassesAndInheritance
{
    public class Vacuum : Appliance
    {
        string grade;
        int batteryVoltage;

        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.grade = grade;
            this.batteryVoltage = batteryVoltage;
        }
        public Vacuum() { }

        public string Grade { get => grade; set => grade = value; }
        public int BatteryVoltage { get => batteryVoltage; set => batteryVoltage = value; }

        public override string ToString()
        {
            //return base.ToString();
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Grade};{BatteryVoltage};";
        }

        public static string ToStringDetailed(Vacuum v)
        {
            return $"ItemNumber: {v.ItemNumber}\nBrand: {v.Brand}\nQuantity: {v.Quantity}\nWattage: {v.Wattage}\nColor: {v.Color}\nPrice: {v.Price}\nGrade: {v.Grade}\nBatteryVoltage: {v.BatteryVoltage}\n";
        }
    }
}
