namespace APBD_Cw1_s29817.Services.Users;

public sealed class Projector : Equipment
{
    public Projector(string name, string manufacturer, int brightness)
        : base(name, manufacturer)
    {
        Brightness = brightness;
    }

    public int Brightness { get; set; }

    public override string GetSpecification()
        => $"Projector | Brightness: {Brightness} lm";
}