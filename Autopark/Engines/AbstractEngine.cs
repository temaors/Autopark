namespace Autopark;

public abstract class AbstractEngine
{
    private string? TypeOfEngine { get; set; }
    public double TaxCoefficientByEngineType { get; set; }

    public AbstractEngine(string typeOfEngine, double taxCoefficientByEngineType)
    {
        TypeOfEngine = typeOfEngine;
        TaxCoefficientByEngineType = TaxCoefficientByEngineType;
    }
    public abstract double GetMaxKilometers(double fuelTank);
}