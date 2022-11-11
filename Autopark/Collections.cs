using System.Globalization;

namespace Autopark;

public class Collections
{
    public List<Rent> Rents { get; }
    public List<Vehicle> Vehicles { get; }
    public List<VehicleType?> VehicleTypes { get; }

    public Collections() // it should be constructor with paths as parameters
    {
        Rents = new List<Rent>(); // no need to initialize here
        VehicleTypes = new List<VehicleType?>(); // no need to initialize here
        Vehicles = new List<Vehicle>(); // no need to initialize here
        
        VehicleTypes = LoadTypes("./types.csv");
        Rents = LoadRents("./rents.csv");
        Vehicles = LoadVehicles("./vehicles.csv");

    }

    public List<VehicleType?> LoadTypes(string inFile)
    {
        var typesList = new List<VehicleType?>();
        if (File.Exists(inFile))
        {
            string[] line = File.ReadAllLines(inFile);

            foreach (var t in line) //rename variable
            {
                typesList.Add(CreateType(t));
            }
        }
        else
        {
            Console.WriteLine("Error! Can not find the file: " + inFile);
        }
        return typesList;
    }
        
    public List<Vehicle> LoadVehicles(string inFile)
    {
        var vehicleList = new List<Vehicle>();
        if (File.Exists(inFile))
        {
            string[] line = File.ReadAllLines(inFile);

            foreach (var t in line) //rename variable
            {
                vehicleList.Add(CreateVehicle(t));
            }
        }
        else
        {
            Console.WriteLine("Error! Can not find the file: " + inFile);
        }
        return vehicleList;
    }
    public Vehicle CreateVehicle(string csvString)
    {
        string[] data = csvString.Split(',');
        var vehicle = new Vehicle
        (
            int.Parse(data[0]),
            GetVehicleTypeById(int.Parse(data[1])),
            GetEngine(data[2]),
            data[3],
            data[4],
            int.Parse(data[5]),
            int.Parse(data[6]),
            int.Parse(data[7]),
            double.Parse(data[8]),
            Enum.Parse<Color>(data[9])
        );
        foreach (Rent rent in Rents)
        {
            if (rent.Id == vehicle.Id)
            {
                vehicle.listRent.Add(rent);
            }
        }

        return vehicle;
    }
    
    private VehicleType? GetVehicleTypeById(int id)
    {
        foreach (VehicleType? type in VehicleTypes) // We can simplify this.
        {
            if (type != null && type.Id == id)
            {
                return type;
            }
        }
        return null;
    }

    public List<Rent> LoadRents(string inFile)
    {
        var rentsList = new List<Rent>();
        if (File.Exists(inFile))
        {
            string[] line = File.ReadAllLines(inFile);

            foreach (var t in line) //rename variable
            {
                rentsList.Add(CreateRegisterData(t));
            }
        }
        else
        {
            Console.WriteLine("Error! Can not find the file: " + inFile);
        }
        return rentsList;
    }
    
    public VehicleType CreateType(string str)
    {
        string[] data = str.Split(',');

        return new VehicleType(int.Parse(data[0]), data[1], double.Parse(data[2], CultureInfo.InvariantCulture) // We can change culture info for all project
        );
    }

    public AbstractEngine? GetEngine(string str)
    {
        AbstractEngine? engine = null;
        string[] engineStringPieces = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string engineType = engineStringPieces[0];
        switch (engineType)
        {
            case "Gasoline":
                engine = new GasolineEngine(double.Parse(engineStringPieces[1], CultureInfo.InvariantCulture), double.Parse(engineStringPieces[2], CultureInfo.InvariantCulture));
                break;

            case "Diesel":
                engine = new DieselEngine(double.Parse(engineStringPieces[1], CultureInfo.InvariantCulture), double.Parse(engineStringPieces[2], CultureInfo.InvariantCulture));
                break;

            case "Electrical":
                engine = new ElectricalEngine(double.Parse(engineStringPieces[1], CultureInfo.InvariantCulture));
                break;
        }
        return engine;
    }
    public Rent CreateRegisterData(string str)
    {
        string[] data = str.Split(',');

        return new Rent(int.Parse(data[0]), DateTime.ParseExact(data[1], "dd.MM.yyyy", CultureInfo.CurrentCulture),
            double.Parse(data[2], CultureInfo.InvariantCulture));
    }
    
    public void Insert(int index, Vehicle v)
    {
        if (index > Vehicles.Count || index < 0)
        {
            Vehicles.Add(v);
        }
        else
        {
            Vehicles.Insert(index, v);
        }
    }

    public int Delete(int index)
    {
        if (index > Vehicles.Count)
        {
            return -1;
        }
        else
        {
            Vehicles.RemoveAt(index);
            return index;
        }
    }
    
    public double SumTotalProfit() => Vehicles.Sum(vehicle => vehicle.GetTotalProfit());

    public void Print()
    {
        Console.WriteLine("{0,-5}{1,-15}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
            "Id",
            "Type", 
            "ModelName",
            "Number", 
            "Weight (kg)",
            "Year",
            "Mileage",
            "Color",
            "Income",
            "Tax",
            "Profit"
        );
        foreach (Vehicle v in Vehicles)
        {
            Console.WriteLine("{0,-5}{1,-15}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                v.Id,
                v.Type,
                v.ModelName,
                v.RegistrationNumber,
                v.Weight,
                v.ManufactureYear,
                v.Mileage,
                v.Color,
                v.GetTotalIncome().ToString("0.00"),
                v.GetCalcTaxPerMonth().ToString("0.00"),
                v.GetTotalProfit().ToString("0.00"));
        }
        Console.WriteLine($"{"Total",-5}{"",-120}{SumTotalProfit(),-10:0.00}");
    }
    public void Sort(IComparer<Vehicle> comparator) => Vehicles.Sort(comparator);
}