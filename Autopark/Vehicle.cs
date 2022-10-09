namespace Autopark;

public class Vehicle : IComparable<Vehicle>
{
    private const int TaxMultiplier = 30;
    private const int TaxBasicShift = 5;
    private const double WeightCoefficient = 0.0013;
    
    public int Id { get; set; }
    public VehicleType? Type { get; set; }
    public AbstractEngine? Engine { get; set; }
    public string ModelName { get; set; }
    public string RegistrationNumber { get; set; }
    public int Weight { get; set; }
    public double TankVolume { get; set; }
    public int ManufactureYear { get; set; }
    public int Mileage { get; set; }
    public Color Color { get; set; }
    public List<Rent> listRent { get; set; }

    public Vehicle(int id, VehicleType? type, AbstractEngine? engine, string modelName, string registrationNumber, int weight, int manufactureYear, int mileage, double tankVolume, Color color) 
    {
        Id = id;
        Type = type;
        Engine = engine;
        ModelName = modelName;
        RegistrationNumber = registrationNumber;
        Weight = weight;
        ManufactureYear = manufactureYear;
        Mileage = mileage;
        TankVolume = tankVolume;
        Color = color;
        listRent = new List<Rent>();
    }
    
    public static Vehicle GetVehicleWithMinMileage(Vehicle[] vehicles)
    {
        int indexOfMinMileage = 0;
        double minMileage = vehicles[0].Mileage;

        for (int i = 0; i < vehicles.Length; i++)
        {
            if (minMileage > vehicles[i].Mileage)
            {
                minMileage = vehicles[i].Mileage;
                indexOfMinMileage = i;
            }
        }
        return vehicles[indexOfMinMileage];
    }

    public static Vehicle GetVehicleWithMaxMileage(Vehicle[] vehicles)
    {
        int indexOfMaxMileage = 0;
        double maxMileage = vehicles[0].Mileage;

        for (int i = 0; i < vehicles.Length; i++)
        {
            if (maxMileage < vehicles[i].Mileage)
            {
                maxMileage = vehicles[i].Mileage;
                indexOfMaxMileage = i;
            }
        }
        return vehicles[indexOfMaxMileage];
    }
    public double GetCalcTaxPerMonth()
    {
        return Weight * WeightCoefficient
               + Type.TaxCoefficient * Engine.TaxCoefficientByEngineType * TaxMultiplier + TaxBasicShift;
    }

    public override String ToString() =>
        $"{Type},{ModelName}, {RegistrationNumber}, {Weight}, {ManufactureYear}, {Mileage}, {Color}, {GetCalcTaxPerMonth().ToString("0.00")}";
    
    // public int CompareTo(Object? obj)
    // {
    //     Vehicle vehicle = obj as Vehicle;
    //     if (GetCalcTaxPerMonth() > vehicle.GetCalcTaxPerMonth())
    //     {
    //         return 1;
    //     }
    //
    //     if (GetCalcTaxPerMonth() < vehicle.GetCalcTaxPerMonth())
    //     {
    //         return -1;
    //     }
    //     return 0;
    // }

    public int CompareTo(Vehicle? other)
    {
        
        if (other != null && GetCalcTaxPerMonth() > other.GetCalcTaxPerMonth())
        {
            return 1;
        }

        if (other != null && GetCalcTaxPerMonth() < other.GetCalcTaxPerMonth())
        {
            return -1;
        }
        return 0;
    }

    public override bool Equals(object? obj)
    {
        return obj is Vehicle vehicle
               && Type.Equals(vehicle.Type)
               && ModelName.Equals(vehicle.ModelName);
    }

    public double GetTotalIncome()
    {
        double sum = 0;
        foreach (var rent in listRent)
        {
            sum += rent.Cost;
        }
        return sum;
    }

    public double GetTotalProfit()
    {
        return GetTotalIncome() - GetCalcTaxPerMonth();
    }
}