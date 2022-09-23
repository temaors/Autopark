using System;
using Autopark;

public class Program
{
    public static void Main()
    {
        double maxCoefficient = 0.0;
        int maxIndex = 0;
        double avgCoefficient = 0.0;
        VehicleType[] autopark = {new VehicleType("Bus", 1.2), 
            new VehicleType("Car" ,1),
            new VehicleType("Rink", 1.5),
            new VehicleType("Tractor", 1.2)
        };

        for (int i = 0; i < 4; i++)
        {
            autopark[i].Display();
            if (autopark[i].TaxCoefficient > maxCoefficient)
            {
                maxCoefficient = autopark[i].TaxCoefficient;
            }

            if (i == 3)
            {
                autopark[i].TaxCoefficient = 1.3;
            }
            
            avgCoefficient += autopark[i].TaxCoefficient;
        }

        Console.WriteLine("Average tax coefficient is " + avgCoefficient / 4);
        Console.WriteLine("Max tax coefficient is " + maxCoefficient);

        foreach (var car in autopark)
        {
            Console.WriteLine(car);
        }
    }
}