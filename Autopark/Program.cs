using System;
using Autopark;

public class Program
{
    public static void Main()
    {
        double buffMax = 0;
        int indexMax = 0;
        VehicleType[] autopark = {new VehicleType("Bus", 1.2), 
            new VehicleType("Car" ,1),
            new VehicleType("Rink", 1.5),
            new VehicleType("Tractor", 1.2)
        };

        Vehicle[] vehicles =
        {
            new Vehicle(autopark[0], new GasolineEngine(2,8.1), "Volkswagen Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue),
            new Vehicle(autopark[0], new GasolineEngine(2.18, 8.5), "Volkswagen Crafter", "6427 AA-7", 2500, 2014, 227010, Color.White),
            new Vehicle(autopark[0], new ElectricalEngine(50),"Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green),
            new Vehicle(autopark[1], new DieselEngine(1.6, 7.2),"Golf 5", "8682 AX-7", 1200, 2016, 230451, Color.Gray),
            new Vehicle(autopark[1], new ElectricalEngine(25),"Tesla Model S 70D", "E001 AA-7", 2200, 2019, 10454, Color.White),
            new Vehicle(autopark[2], new DieselEngine(3.2, 25),"Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow),
            new Vehicle(autopark[3], new DieselEngine(4.75, 20.1),"MTZ Belarus-1025.4", "1145 AB-7", 120, 2020, 109, Color.Red)
        };

        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine(vehicles[i]);
        }
        
        Array.Sort(vehicles);
        Console.WriteLine(new string('-',22));
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine(vehicles[i]);
        }

        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine("Max kilometers of" + vehicles[i] + " : " + vehicles[i].Engine.GetMaxKilometers(100));
            if (vehicles[i].Engine.GetMaxKilometers(100) > buffMax)
            {
                buffMax = vehicles[i].Engine.GetMaxKilometers(100);
                indexMax = i;
            }
        }
        
        Console.WriteLine("\nMax kilometers index: " + indexMax);
        Console.WriteLine(vehicles[indexMax]);
    }
}