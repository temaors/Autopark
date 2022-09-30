namespace Autopark;

public class DieselEngine : AbstractCombustionEngine
{

    public DieselEngine(double engineCapacity, double fuelConsumptionPer100) : base("Diesel", 1.2)
    {
        EngineCapacity = engineCapacity;
        FuelConsumptionPer100 = fuelConsumptionPer100;
    }

    public override double GetMaxKilometres(double fuelTankCapacity)
    {
        return fuelTankCapacity / FuelConsumptionPer100;
    }

    public override double GetMaxKilometers(double fuelTank)
    {
        throw new NotImplementedException();
    }
}