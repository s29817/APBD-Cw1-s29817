using APBD_Cw1_s29817.Enums;
using APBD_Cw1_s29817.Exceptions;

namespace APBD_Cw1_s29817.Services.Equipment;

public class EquipmentService : IEquipmentService
{
    private readonly List<Models.Equipment> _equipment = [];

    public void Add(Models.Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public Models.Equipment GetById(int equipmentId)
    {
        return _equipment.FirstOrDefault(item => item.Id == equipmentId)
               ?? throw new NotFoundException($"Equipment with id {equipmentId} was not found.");
    }

    public IReadOnlyCollection<Models.Equipment> GetAll()
    {
        return _equipment.AsReadOnly();
    }

    public IReadOnlyCollection<Models.Equipment> GetAvailable()
    {
        return _equipment.Where(item => item.Status == EquipmentStatus.Available).ToList().AsReadOnly();
    }

    public void MarkUnavailable(int equipmentId)
    {
        var equipment = GetById(equipmentId);
        equipment.MarkUnavailable();
    }
}