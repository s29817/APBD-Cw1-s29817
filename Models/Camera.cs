namespace APBD_Cw1_s29817.Models;

public class Camera : Equipment
{
    public Camera(string name, string manufacturer, int megapixels)
        : base(name, manufacturer)
    {
        Megapixels = megapixels;
    }

    public int Megapixels { get; set; }

    public override string GetSpecification()
    {
        return $"Camera | {Megapixels} MP";
    }
}