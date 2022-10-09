namespace Autopark;

public class ElectricalEngine : AbstractEngine
{
    private double ElectricityConsumption { get; set; }

    public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1)
    {
        ElectricityConsumption = electricityConsumption;
    }

    public override double GetMaxKilometers(double batterySize)
    {
        return batterySize / ElectricityConsumption;
    }
    
    //public override string ToString() => $"{base.ToString()} {ElectricityConsumption}";

}