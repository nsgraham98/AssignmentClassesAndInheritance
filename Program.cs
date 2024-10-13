using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Sven_.Assignment_1
{
    public class Program
    {
        static void Main()
        {
            Menu();
        }

        public static List<Appliance> LoadAppliancesFromList()
        {
            string path = "..\\..\\res\\appliances.txt";
            List<Appliance> appliances = new List<Appliance>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] fields = line.Split(';');
                if (fields.Length < 1)
                    continue;

                string itemType = fields[0].Length > 0 ? fields[0].Substring(0, 1) : "";

                switch (itemType)
                {
                    case "1":
                        if (fields.Length >= 9)
                        {
                            float f7 = float.Parse(fields[7]);
                            float f8 = float.Parse(fields[8]);
                            Refrigerator refrigerator = new Refrigerator(
                                Convert.ToInt64(fields[0]), fields[1],
                                Convert.ToInt16(fields[2]),
                                Convert.ToInt64(fields[3]), fields[4],
                                Convert.ToDouble(fields[5]),
                                Convert.ToInt16(fields[6]), f7, f8);
                            appliances.Add(refrigerator);
                        }
                        break;

                    case "2":
                        if (fields.Length >= 8)
                        {
                            Vacuum vacuum = new Vacuum(
                                Convert.ToInt64(fields[0]), fields[1],
                                Convert.ToInt16(fields[2]),
                                Convert.ToInt64(fields[3]), fields[4],
                                Convert.ToDouble(fields[5]), fields[6],
                                Convert.ToInt16(fields[7]));
                            appliances.Add(vacuum);
                        }
                        break;

                    case "3":
                        if (fields.Length >= 8)
                        {
                            float f6 = float.Parse(fields[6]);
                            Microwave microwave = new Microwave(
                                Convert.ToInt64(fields[0]), fields[1],
                                Convert.ToInt16(fields[2]),
                                Convert.ToInt64(fields[3]), fields[4],
                                Convert.ToDouble(fields[5]), f6, fields[7]);
                            appliances.Add(microwave);
                        }
                        break;

                    case "4":
                    case "5":
                        if (fields.Length >= 8)
                        {
                            Dishwasher dishwasher = new Dishwasher(
                                Convert.ToInt64(fields[0]), fields[1],
                                Convert.ToInt16(fields[2]),
                                Convert.ToInt64(fields[3]), fields[4],
                                Convert.ToDouble(fields[5]), fields[6], fields[7]);
                            appliances.Add(dishwasher);
                        }
                        break;

                    default:
                        Console.WriteLine($"Error - Invalid ID: {fields[0]}");
                        break;
                }
            }

            return appliances;
        }

        public static void ShowBrand(string brand)
        {
            bool valid = false;
            Console.WriteLine("Matching appliances:  \n");
            List<Appliance> appliances = LoadAppliancesFromList();

            foreach (Appliance appliance in appliances)
            {
                if (String.Equals(appliance.Brand, brand, StringComparison.OrdinalIgnoreCase))
                {
                    if (appliance is Dishwasher)
                    {
                        Console.WriteLine($"{Dishwasher.ToString_Readable((Dishwasher)appliance)}");
                        valid = true;
                    }

                    if (appliance is Microwave)
                    {
                        Console.WriteLine($"{Microwave.ToString_Readable((Microwave)appliance)}");
                        valid = true;
                    }

                    if (appliance is Refrigerator)
                    {
                        Console.WriteLine($"{Refrigerator.ToString_Readable((Refrigerator)appliance)}");
                        valid = true;
                    }

                    if (appliance is Vacuum)
                    {
                        Console.WriteLine($"{Vacuum.ToString_Readable((Vacuum)appliance)}");
                        valid = true;
                    }
                }

            }

            if (valid == false)
            {
                Console.WriteLine("No matching brand found.");
            }
        }

        public static void ShowType(int input)
        {
            List<Appliance> appliances = LoadAppliancesFromList();
            switch (input)
            {
                case 1:
                    bool ReFri_Valid = false;
                    Console.WriteLine("Enter the number of doors: 2 (double door), 3 (three doors), or 4 (four doors)");
                    int door_input = Convert.ToInt16(Console.ReadLine());

                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Refrigerator)
                        {
                            Refrigerator ReFri = appliance as Refrigerator;

                            if (door_input == ReFri.Num_of_doors)
                            {
                                Console.WriteLine($"{Refrigerator.ToString_Readable(ReFri)}");
                                ReFri_Valid = true;
                            }
                        }

                        if (ReFri_Valid == false)
                        {
                            Console.WriteLine("No matching refrigerators found.");
                        }
                    }

                    Program.Main();
                    break;

                case 2:
                    bool VaCu_Valid = false;
                    Console.WriteLine("Enter a battery voltage value. 10V (low) or 24V (high)");
                    int battery_input = Convert.ToInt16(Console.ReadLine());

                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Vacuum)
                        {
                            Vacuum VaCu = appliance as Vacuum;
                            if (VaCu.Battery_voltage == battery_input)
                            {
                                Console.WriteLine($"{Vacuum.ToString_Readable(VaCu)}");
                                VaCu_Valid = true;
                            }
                        }
                    }

                    if (VaCu_Valid == false)
                    {
                        Console.WriteLine("No matching vacuums found.");
                    }

                    Program.Main();
                    break;

                case 3:
                    bool MiWa_Valid = false;
                    Console.WriteLine("Room where the microwave will be installed: K - (Kitchen) or W - (Work Site)");
                    string room_input = Console.ReadLine();
                    Console.WriteLine("\nMatching Microwaves:\n");

                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Microwave)
                        {
                            Microwave MiWa = appliance as Microwave;
                            if (MiWa.Room_type == room_input)
                            {
                                Console.WriteLine($"{Microwave.ToString_Readable(MiWa)}");
                                MiWa_Valid = true;
                            }
                        }
                    }

                    if (MiWa_Valid == false)
                    {
                        Console.WriteLine("No matching microwave found.");
                    }

                    Program.Main();
                    break;

                case 4:
                    bool DiWa_Valid = false;
                    Console.WriteLine("Enter the sound rating of the dishwaser: Qt - (Quietest), Qr - (Quieter), Qu - (Quiet) or M - Moderate):\n");
                    string sound_input = Console.ReadLine();
                    Console.WriteLine("\nMatching Dishwashers:\n");

                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Dishwasher)
                        {
                            Dishwasher DiWa = appliance as Dishwasher;
                            if (DiWa.Sound_Rating == sound_input)
                            {
                                Console.WriteLine($"{Dishwasher.ToString_Readable(DiWa)}");
                                DiWa_Valid = true;
                            }
                        }
                    }

                    if (DiWa_Valid == false)
                    {
                        Console.WriteLine("No matching dishwashers found.");
                    }

                    Program.Main();
                    break;
            }
        }

        public static void DisplayRandom()
        {
            List<Appliance> appliances = LoadAppliancesFromList();
            Random random = new Random();
            Console.WriteLine("Enter a number of appliances:\n");
            int numInput = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < numInput; i++)
            {
                int index = random.Next(appliances.Count);
                Appliance randomItem = appliances[index];
                if (randomItem is Dishwasher)
                {
                    Console.WriteLine(Dishwasher.ToString_Readable((Dishwasher)randomItem));
                }

                if (randomItem is Microwave)
                {
                    Console.WriteLine(Microwave.ToString_Readable((Microwave)randomItem));
                }

                if (randomItem is Refrigerator)
                {
                    Console.WriteLine(Refrigerator.ToString_Readable((Refrigerator)randomItem));
                }

                if (randomItem is Vacuum)
                {
                    Console.WriteLine(Vacuum.ToString_Readable((Vacuum)randomItem));
                }
            }
        }

        public static void Menu()
        {
            Console.WriteLine($"Welcome to Modern Appliances!\nHow may we assit you?\n1 - Check out appliance\n2 - Find appliances by brand\n3 - Display appliances by type\n4 - Produce random appliance list\n5 - Save & Exit\nEnter Option:");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Enter the item number of an appliance:\n");
                    long itemNumber = Convert.ToInt64(Console.ReadLine());
                    List<Appliance> appliances = LoadAppliancesFromList();
                    foreach (Appliance item in appliances)
                        if (item.ItemNumber == itemNumber)
                        {
                            if (Appliance.IsAvailable(item))
                            {
                                appliances.Remove(item);
                                Appliance newItem = Appliance.Checkout(item);
                                appliances.Add(newItem);
                                Appliance.FormatForFile(appliances);
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("The appliance is not available to be checked out.\n");
                                Main();
                            }
                        }
                    Console.WriteLine("No appliance found with that item numbers.");
                    Main();
                    break;

                case "2":
                    Console.WriteLine("Enter a brand to search for");
                    string brand_input = Console.ReadLine();

                    ShowBrand(brand_input);
                    Main();
                    break;

                case "3":
                    Console.WriteLine("Appliances Types:\n1 - Refrigerators\n2 - Vacuums\n3 - Microwaves\n4 - Dishwasshers\nEnter type of appliance:");
                    int type_input = Convert.ToInt16(Console.ReadLine());
                    ShowType(type_input);
                    Main();
                    break;

                case "4":
                    DisplayRandom();
                    Main();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}