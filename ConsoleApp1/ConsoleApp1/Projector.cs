namespace ConsoleApp1;

public class Projector : Device
{
    public int[] Resolution { get; set; }
    public int MaxBrightness { get; set; } 
    public int NumberOfPorts { get; set; }

    public Projector(string name, string brand, double regularPrice, int[] resolution, 
        int maxBrightness, int numberOfPorts) : base(name, brand, regularPrice)
    {
        Resolution = resolution;
        MaxBrightness = maxBrightness;
        NumberOfPorts = numberOfPorts;
    }
}