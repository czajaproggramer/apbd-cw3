namespace ConsoleApp1;

public class Device
{
    public String Name { get; set; }
    public string Brand { get; set; }
    public double RegularPrice { get; set; }
    public int DId { get; }
    public bool IsAvailable { get; set; }
    private static int lastDId = 0;

    public Device(string name, string brand, double regularPrice)
    {
        Name = name;
        Brand = brand;
        RegularPrice = regularPrice;
        DId = lastDId++;
        IsAvailable = true;
    }
}