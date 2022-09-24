namespace Autopark;

public class ElectricalEngine : Engine
{
    private double ElectricityConsumption { get; set; }

    public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1)
    {
        ElectricityConsumption = electricityConsumption;
    }

    public double GetMaxKilometers(double batterySize)
    {
        return batterySize / ElectricityConsumption;
    }
}