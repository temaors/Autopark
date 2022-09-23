namespace Autopark;

public class Vehicle : IComparable
{
    private VehicleType Type { get; set; }
    private string? ModelName { get; set; }
    private string? RegistrationNumber { get; set; }
    private int Weight { get; set; }
    private int ManufactureYear { get; set; }
    private int Mileage { get; set; }
    private Color Color { get; set; }

    public Vehicle(VehicleType type, string modelName, string registrationNumber, int weight, int manufactureYear, int mileage, Color color)
    {
        Type = type;
        ModelName = modelName;
        RegistrationNumber = registrationNumber;
        Weight = weight;
        ManufactureYear = manufactureYear;
        Mileage = mileage;
        Color = color;
    }
    public double GetCalcTaxPerMonth()
    {
        double result = 0.0;
        result = (Weight * 0.0013) + (Type.TaxCoefficient * 30) + 5;
        return result;
    }

    public override String ToString() =>
        $"{Type},{ModelName}, {RegistrationNumber}, {Weight}, {ManufactureYear}, {Mileage}, {Color}, {GetCalcTaxPerMonth().ToString("0.00")}";

    public int CompareTo(Object? obj)
    {
        Vehicle vehicle = obj as Vehicle;
        if (GetCalcTaxPerMonth() > vehicle.GetCalcTaxPerMonth())
        {
            return 1;
        }

        if (GetCalcTaxPerMonth() < vehicle.GetCalcTaxPerMonth())
        {
            return -1;
        }
        return 0;
    }
}