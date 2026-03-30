namespace APBD_Cw1_s29817.Services.Loans;

public class PenaltyPolicy : IPenaltyPolicy
{
    private readonly decimal _dailyRate;

    public PenaltyPolicy(decimal dailyRate)
    {
        _dailyRate = dailyRate;
    }

    public decimal Calculate(DateTime dueDate, DateTime returnedAt)
    {
        var overdueDays = (returnedAt.Date - dueDate.Date).Days;
        return overdueDays <= 0 ? 0m : overdueDays * _dailyRate;
    }
}