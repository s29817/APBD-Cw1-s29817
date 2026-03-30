namespace APBD_Cw1_s29817.Services.Equipment;

public interface IEquipmentService
{
    void Add(Models.Equipment equipment);
    Models.Equipment GetById(int equipmentId);
    IReadOnlyCollection<Models.Equipment> GetAll();
    IReadOnlyCollection<Models.Equipment> GetAvailable();
    void MarkUnavailable(int equipmentId);
}