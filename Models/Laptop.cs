namespace APBD_Cw1_s29817.Models;

public class Laptop : Equipment
{
    public Laptop(string name, string manufacturer, int ramGb, double screenSize)
        : base(name, manufacturer)
    {
        RamGb = ramGb;
        ScreenSize = screenSize;
    }

    public int RamGb { get; set; }
    public double ScreenSize { get; set; }

    public override string GetSpecification()
    {
        return $"Laptop | RAM: {RamGb} GB | Screen: {ScreenSize:F1}\"";
    }
}