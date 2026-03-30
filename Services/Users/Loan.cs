namespace APBD_Cw1_s29817.Services.Users;

public sealed class Loan
{
    private static int _nextId = 1;

    public Loan(User user, Equipment equipment, DateTime borrowedAt, DateTime dueDate)
    {
        Id = _nextId++;
        User = user;
        Equipment = equipment;
        BorrowedAt = borrowedAt;
        DueDate = dueDate;
    }

    public int Id { get; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime BorrowedAt { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnedAt { get; private set; }
    public decimal PenaltyAmount { get; private set; }
    public bool IsActive => ReturnedAt is null;
    public bool IsOverdue(DateTime now) => IsActive && now.Date > DueDate.Date;

    public void Close(DateTime returnedAt, decimal penaltyAmount)
    {
        ReturnedAt = returnedAt;
        PenaltyAmount = penaltyAmount;
    }

    public override string ToString()
    {
        var returned = ReturnedAt is null ? "not returned" : ReturnedAt.Value.ToString("yyyy-MM-dd");
        return $"Loan [{Id}] | User: {User.FirstName} {User.LastName} | Equipment: {Equipment.Name} | Borrowed: {BorrowedAt:yyyy-MM-dd} | Due: {DueDate:yyyy-MM-dd} | Returned: {returned} | Penalty: {PenaltyAmount:C}";
    }
}