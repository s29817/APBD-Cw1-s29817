using APBD_Cw1_s29817.Enums;

namespace APBD_Cw1_s29817.Services.Users;

public abstract class User
{
    private static int _nextId = 1;

    protected User(string firstName, string lastName)
    {
        Id = _nextId++;
        FirstName = firstName;
        LastName = lastName;
    }

    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract UserType UserType { get; set; }
    public abstract int LoanLimit { get; set; }

    public override string ToString() => $"[{Id}] {FirstName} {LastName} ({UserType})";
}