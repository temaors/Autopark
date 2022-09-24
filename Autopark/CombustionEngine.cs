namespace Autopark;

public class CombustionEngine : Engine
{
    protected double EngineCapacity { get; set; }
    protected double FuelConsumptionPer100 { get; set; }

    public CombustionEngine(string typeName, double taxCoefficient) : base(typeName, taxCoefficient) { }

    public double GetMaxKilometres(double fuelTankCapacity)
    {
        return fuelTankCapacity * 100 / FuelConsumptionPer100;
    }
}