namespace ConsoleApp1;

public class Laptop : Device
{
    public string OSys { get; set; }
    public int YearOfProd { get; }

    public Laptop(string name, string brand, double regularPrice, string oSys, int yearOfProd)
        : base(name, brand, regularPrice)
    {
        OSys = oSys;
        YearOfProd = yearOfProd;
    }
}