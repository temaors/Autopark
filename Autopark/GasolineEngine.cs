namespace Autopark;

public class GasolineEngine : AbstractCombustionEngine
{
    public GasolineEngine(double engineCapacity, double fuelConsumptionPer100) : base("Gasoline", 1)
    {
        EngineCapacity = engineCapacity;
        FuelConsumptionPer100 = fuelConsumptionPer100;
    }
    
    public override double GetMaxKilometers(double fuelTank)
    {
        return fuelTank / FuelConsumptionPer100;
    }

    public override double GetMaxKilometres(double fuelTankCapacity)
    {
        throw new NotImplementedException();
    }
}