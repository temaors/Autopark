namespace Autopark;

public class Vehicle
{
    private VehicleType Type { get; set; }
    private string? ModelName { get; set; }
    private string? RegistrationNumber { get; set; }
    private int Weight { get; set; }
    private int ManufactureYear { get; set; }
    private int Mileage { get; set; }
    private Color Color { get; set; }
    //
    // public int CompareTo(object? o)
    // {
    //     
    // }

    public double GetCalcTaxPerMonth()
    {
        return 0.0;
    } 
}

public interface IComparable
{
    int CompareTo(object? o);
}