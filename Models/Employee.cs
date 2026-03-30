using APBD_Cw1_s29817.Enums;

namespace APBD_Cw1_s29817.Models;

public sealed class Employee : User
{
    public Employee(string firstName, string lastName, string department)
        : base(firstName, lastName)
    {
        Department = department;
    }

    public string Department { get; set; }
    public override UserType UserType { get; set; } = UserType.Employee;
    public override int LoanLimit { get; set; } = 5;
}