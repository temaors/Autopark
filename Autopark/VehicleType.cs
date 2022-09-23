namespace Autopark;

public class VehicleType
{
    public string TypeName { get; set; }
    public double TaxCoefficient { get; set; }

    public VehicleType()
    {
        TypeName = "Bus";
        TaxCoefficient = 1;
    }

    public VehicleType(string typeName, double taxCoefficient)
    {
        TypeName = typeName;
        TaxCoefficient = taxCoefficient;
    }
    
    public void Display()
    {
        Console.WriteLine("TypeName = " + TypeName);
        Console.WriteLine("TaxCoefficient = " + TaxCoefficient);
    }

    public override string ToString() => $"{TypeName}, {TaxCoefficient}";
}