using APBD_Cw1_s29817.Enums;

namespace APBD_Cw1_s29817.Services.Users;

public abstract class Equipment
{
    private static int _nextId = 1;

    protected Equipment(string name, string manufacturer)
    {
        Id = _nextId++;
        Name = name;
        Manufacturer = manufacturer;
        Status = EquipmentStatus.Available;
    }

    public int Id { get; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public EquipmentStatus Status { get; private set; }

    public void MarkBorrowed() => Status = EquipmentStatus.Borrowed;
    public void MarkAvailable() => Status = EquipmentStatus.Available;
    public void MarkUnavailable() => Status = EquipmentStatus.Unavailable;

    public abstract string GetSpecification();

    public override string ToString()
        => $"[{Id}] {Name} ({Manufacturer}) | Status: {Status} | {GetSpecification()}";
}