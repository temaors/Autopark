namespace Autopark;

public class Engine
{
    private string? TypeOfEngine { get; set; }
    public double TaxCoefficientByEngineType { get; set; }

    public Engine(string typeOfEngine, double taxCoefficientByEngineType)
    {
        TypeOfEngine = typeOfEngine;
        TaxCoefficientByEngineType = TaxCoefficientByEngineType;
    }
}