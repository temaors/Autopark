namespace Autopark;

public abstract class AbstractCombustionEngine : AbstractEngine
{
    protected double EngineCapacity { get; set; }
    protected double FuelConsumptionPer100 { get; set; }

    public AbstractCombustionEngine(string typeName, double taxCoefficient) : base(typeName, taxCoefficient) { }

    public abstract double GetMaxKilometres(double fuelTankCapacity);
    // {
    //     return fuelTank / FuelConsumptionPer100;
    // }
}