namespace APBD_Cw1_s29817.Models;

public class Projector : Equipment
{
    public Projector(string name, string manufacturer, int brightness)
        : base(name, manufacturer)
    {
        Brightness = brightness;
    }

    public int Brightness { get; set; }

    public override string GetSpecification()
    {
        return $"Projector | Brightness: {Brightness} lm";
    }
}