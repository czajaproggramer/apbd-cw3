namespace ConsoleApp1;

public class Camera : Device
{
    public int[] MaxResolution { get; set; }
    public int MaxFPS { get; set; }
    public float Weight { get; set; }
    public int[] Dimensions { get; set; }

    public Camera(string name, string brand, double regularPrice, int[] maxResolution,
        int maxFps, float weight, int[] dimensions) : base(name, brand, regularPrice)
    {
        MaxResolution = maxResolution;
        MaxFPS = maxFps;
        Weight = weight;
        Dimensions = dimensions;
    }
}