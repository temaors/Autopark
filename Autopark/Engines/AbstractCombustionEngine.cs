namespace Autopark;

public abstract class AbstractCombustionEngine : AbstractEngine
{
    protected double EngineCapacity { get; set; }
    protected double FuelConsumptionPer100 { get; set; }

    public AbstractCombustionEngine(string typeName, double taxCoefficient) : base(typeName, taxCoefficient) { }
    
    public override double GetMaxKilometers(double fuelTankCapacity) => fuelTankCapacity * 100.0 / FuelConsumptionPer100;

    public override string ToString() => $"{base.ToString()} {EngineCapacity} {FuelConsumptionPer100}";

}