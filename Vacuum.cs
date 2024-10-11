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

        public string Grade { get => grade; set => grade = value; }
        public int BatteryVoltage { get => batteryVoltage; set => batteryVoltage = value; }

        public override string ToString()
        {
            //return base.ToString();
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nGrade: {Grade}\nBattery Voltage: {BatteryVoltage}";
        }
    }
}
