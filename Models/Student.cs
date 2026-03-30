using APBD_Cw1_s29817.Enums;

namespace APBD_Cw1_s29817.Models;

public class Student : User
{
    public Student(string firstName, string lastName, string studentNumber)
        : base(firstName, lastName)
    {
        StudentNumber = studentNumber;
    }

    public string StudentNumber { get; set; }
    public override UserType UserType { get; set; } = UserType.Student;
    public override int LoanLimit { get; set; } = 2;
}