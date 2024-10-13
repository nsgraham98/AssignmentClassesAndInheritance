using OOP2AssignmentClassesAndInheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AssignmentClassesAndInheritance
{
    public class Program
    {
        public static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine($"\nWelcome to Modern Appliances!\nHow may we assist you?\n1 – Check out appliance\n2 – Find appliances by brand\n3 – Display appliances by type\n4 – Produce random appliance list\n5 – Save & exit\nEnter option:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter the item number of an appliance:\n");
                    long itemNumber = Convert.ToInt64(Console.ReadLine());
                    List<Appliance> appList = LoadAppliances();
                    foreach (Appliance appObj in appList)
                        if (appObj.ItemNumber == itemNumber)
                        {
                            if (Appliance.IsAvailable(appObj))
                            {
                                appList.Remove(appObj);
                                Appliance newApp = Appliance.Checkout(appObj);
                                appList.Add(newApp);
                                Appliance.FormatForFile(appList);
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("The appliance is not available to be checked out.\n");
                                Main();
                            }
                        }
                    Console.WriteLine("No Appliance found with that item number.\n");
                    Main();
                    break;
                case "2":
                    Console.WriteLine("Enter brand to search for");
                    string brand = Console.ReadLine();
                    ShowBrands(brand);
                    Main();
                    break;
                case "3":
                    Console.WriteLine("Appliance Types:\n1 - Refrigerators\n2 - Vacuums\n3 - Microwaves\n4 - Dishwashers\nEnter type of appliance:");
                    int appChoice = Convert.ToInt16(Console.ReadLine());
                    ShowTypes(appChoice);
                    Main();
                    break;
                case "4":
                    displayRandom();
                    Main();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;

            }
        }

        public static void displayRandom()
        {
            List <Appliance> appList = LoadAppliances();
            Random rand = new Random();
            Console.WriteLine("Enter number of appliances:\n");
            int numChoice = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < numChoice; i++)
            {
                int index = rand.Next(appList.Count);
                Appliance randObj = appList[index];
                if (randObj is Refrigerator)
                {                    
                    Console.WriteLine(Refrigerator.ToStringDetailed((Refrigerator)randObj));
                }
                if (randObj is Microwave)
                {
                    Console.WriteLine(Microwave.ToStringDetailed((Microwave)randObj));
                }
                if (randObj is Dishwasher)
                {
                    Console.WriteLine(Dishwasher.ToStringDetailed((Dishwasher)randObj));
                }
                if (randObj is Vacuum)
                {
                    Console.WriteLine(Vacuum.ToStringDetailed((Vacuum)randObj));
                }
            }
        }

        public static List<Appliance> LoadAppliances() // parses appliances.txt into a single list (returns list)
        {
            string path = "..\\..\\res\\appliances.txt";
            List<Appliance> applianceList = new List<Appliance>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                switch (fields[0].Substring(0, 1))
                {
                    case "1":
                        float f7 = float.Parse(fields[7]);
                        float f8 = float.Parse(fields[8]);
                        Refrigerator refrigerator = new Refrigerator(Convert.ToInt64(fields[0]), fields[1], Convert.ToInt16(fields[2]), Convert.ToInt64(fields[3]), fields[4], Convert.ToDouble(fields[5]), Convert.ToInt16(fields[6]), f7, f8);
                        applianceList.Add(refrigerator);
                        break;
                    case "2":
                        Vacuum vacuum = new Vacuum(Convert.ToInt64(fields[0]), fields[1], Convert.ToInt16(fields[2]), Convert.ToInt64(fields[3]), fields[4], Convert.ToDouble(fields[5]), fields[6], Convert.ToInt16(fields[7]));
                        applianceList.Add(vacuum);
                        break;
                    case "3":
                        float f6 = float.Parse(fields[6]);
                        Microwave microwave = new Microwave(Convert.ToInt64(fields[0]), fields[1], Convert.ToInt16(fields[2]), Convert.ToInt64(fields[3]), fields[4], Convert.ToDouble(fields[5]), f6, fields[7]);
                        applianceList.Add(microwave);
                        break;
                    case "4":
                    case "5":
                        Dishwasher dishwasher = new Dishwasher(Convert.ToInt64(fields[0]), fields[1], Convert.ToInt16(fields[2]), Convert.ToInt64(fields[3]), fields[4], Convert.ToDouble(fields[5]), fields[6], fields[7]);
                        applianceList.Add((dishwasher));
                        break;
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "0":
                        Console.WriteLine("Error. Invalid ID");
                        break;
                }
            }
            return applianceList;
        }

        public static void ShowBrands(string brand)
        {
            bool valid = false;
            Console.WriteLine("Matching Appliances: \n");
            List<Appliance> appList = LoadAppliances();
            foreach (Appliance appliance in appList)
            {
                if (String.Equals(appliance.Brand, brand, StringComparison.OrdinalIgnoreCase))
                {
                    if (appliance is Refrigerator)
                    {
                        Console.WriteLine($"{Refrigerator.ToStringDetailed((Refrigerator)appliance)}");
                        valid = true;
                    }
                    if (appliance is Microwave)
                    {
                        Console.WriteLine($"{Microwave.ToStringDetailed((Microwave)appliance)}");
                        valid = true;
                    }
                    if (appliance is Dishwasher)
                    {
                        Console.WriteLine($"{Dishwasher.ToStringDetailed((Dishwasher)appliance)}");
                        valid = true;
                    }
                    if (appliance is Vacuum)
                    {
                        Console.WriteLine($"{Vacuum.ToStringDetailed((Vacuum)appliance)}");
                        valid = true;
                    }
                }
            }
            if (valid == false)
            {
                Console.WriteLine("No matching brand found.");
            }
        }

        public static void ShowTypes(int choice)
        {
            List<Appliance> appList = LoadAppliances();
            switch (choice)
            {
                case 1:
                    bool rfValid = false;
                    Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                    int doorChoice = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("\nMatching refrigerators:\n");
                    foreach (Appliance appliance in appList)
                    {
                        if (appliance is Refrigerator)
                        {
                            Refrigerator rf = appliance as Refrigerator;
                            if (doorChoice == rf.NumDoors)
                            {
                                Console.WriteLine($"{Refrigerator.ToStringDetailed(rf)}");
                                rfValid = true ;
                            }
                        }
                    }
                    if (rfValid == false) { Console.WriteLine("No matching refrigerators found."); }
                    Program.Main();
                    break;

                case 2:
                    bool vValid = false;
                    Console.WriteLine("Enter battery voltage value. 18 V(low) or 24 V(high)");
                    int battChoice = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("\nMatching vacuums:\n");
                    foreach (Appliance appliance in appList)
                    {
                        if (appliance is Vacuum)
                        {
                            Vacuum v = appliance as Vacuum;
                            if (v.BatteryVoltage == battChoice)
                            {
                                Console.WriteLine($"{Vacuum.ToStringDetailed(v)}");
                                vValid = true ;
                            }
                        }
                    }
                    if (vValid == false) { Console.WriteLine("No matching vacuums found."); }
                    Program.Main();
                    break;
                case 3:
                    bool mwValid = false;
                    Console.WriteLine("Room where the microwave will be installed: K(kitchen) or W(work site):");
                    string roomChoice = Console.ReadLine();
                    Console.WriteLine("\nMatching microwaves:\n");
                    foreach (Appliance appliance in appList)
                    {
                        if (appliance is Microwave)
                        {
                            Microwave mw = appliance as Microwave;
                            if (mw.RoomType == roomChoice)
                            {
                                Console.WriteLine($"{Microwave.ToStringDetailed(mw)}");
                                mwValid = true ;
                            }
                        }
                    }
                    if (mwValid == false) { Console.WriteLine("No matching microwave found."); }
                    Program.Main();
                    break;

                case 4:
                    bool dwValid = false;
                    Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):\n");
                    string soundChoice = Console.ReadLine();
                    Console.WriteLine("\nMatching dishwashers:\n");
                    foreach (Appliance appliance in appList)
                    {
                        if (appliance is Dishwasher)
                        {
                            Dishwasher dw = appliance as Dishwasher;
                            if (dw.SoundRating == soundChoice)
                            {
                                Console.WriteLine($"{Dishwasher.ToStringDetailed(dw)}");
                                dwValid = true ;
                            }
                        }
                    }
                    if (dwValid == false) { Console.WriteLine("No matching dishwasher found."); }
                    Program.Main();
                    break;
            }

        }


    }
}
