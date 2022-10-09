using Autopark;

public class Program
{
    public static void Main()
    {
        Collections autopark = new Collections();
        autopark.Insert
        (
            -1,
            new Vehicle
            (
                8, autopark.VehicleTypes[1],
                new GasolineEngine(4.8, 12.3),
                "Ferrari 458 Italia",
                "1111 TT-7",
                1530,
                2022,
                500,
                80,
                Color.Red
            )
        );

        autopark.Print();

        autopark.Delete(1);
        autopark.Delete(4);
        Console.WriteLine("Deletion of elements 1, 4 successfully done!");
        Console.WriteLine();
        autopark.Print();
        
        autopark.Sort(new VehicleComparer());
        Console.WriteLine("Elements was sorted successfully");
        autopark.Print();
        
        var queue = new CustomQueue<Vehicle>();

        Console.WriteLine();
        foreach (var vehicle in autopark.Vehicles)
        {
            Console.WriteLine("Car gets into car wash:");
            Console.WriteLine(vehicle);
            queue.Enqueue(vehicle);
        }

        Console.WriteLine();
        foreach (var vehicle in queue)
        {
            Console.WriteLine($"Vehicle {vehicle} is washing now.");
        }

        Console.WriteLine();
        while (queue.Count != 0)
        {
            Console.WriteLine("Car lefts a car wash:");
            Console.WriteLine(queue.Dequeue());
        }

        Console.WriteLine();
        var stack = new CustomStack<Vehicle>();

        Console.WriteLine();
        foreach (var vehicle in autopark.Vehicles)
        {
            Console.WriteLine("Car gets into garage:");
            Console.WriteLine(vehicle);
            stack.Push(vehicle);
        }

        var myCar = autopark.Vehicles[3];
        Console.WriteLine();
        Console.WriteLine($"Does garage contain this car:\n{myCar}\n???");
        Console.WriteLine(stack.Contains(myCar));
        Console.WriteLine();

        while (stack.Count != 0)
        {
            Console.WriteLine("Car lefts a garage:");
            Console.WriteLine(stack.Pop());
        }

        Console.WriteLine();
        
        var sparePartsList = new SparePartsDictionary("./orders.csv");
        sparePartsList.Print();
    }
}