namespace Autopark;

public class Rent
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public double Cost { get; set; }

    public Rent()
    {
        
    }

    public Rent(int id, DateTime dateTime, double rentPrice)
    {
        Id = id;
        DateTime = dateTime;
        Cost = rentPrice;
    }
}