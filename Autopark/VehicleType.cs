namespace Autopark;

public class VehicleType
{
    public int Id { get; set; }
    public string TypeName { get; set; }
    public double TaxCoefficient { get; set; }

    public VehicleType() // No need to initialize properties in default constructor
    {
        TypeName = "Bus";
        TaxCoefficient = 1;
    }

    public VehicleType(int id, string typeName, double taxCoefficient)
    {
        Id = id;
        TypeName = typeName;
        TaxCoefficient = taxCoefficient;
    }
    
    public void Display()
    {
        Console.WriteLine("TypeName = {0}\nTaxCoefficient = {1}", TypeName, TaxCoefficient);
    }

    public override string ToString() => $"{TypeName}, {TaxCoefficient} ";
}