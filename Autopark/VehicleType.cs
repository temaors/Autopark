namespace Autopark;

public class VehicleType
{
    private string typeName;
    public double TaxCoefficient { get; set; }

    public string TypeName
    { 
        get { return typeName; }
        set { typeName = value; } 
    }

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

    public override string ToString() => $"{TypeName}, {TaxCoefficient} ";
}