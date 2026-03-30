namespace APBD_Cw1_s29817.Services.Loans;

public interface IPenaltyPolicy
{
    decimal Calculate(DateTime dueDate, DateTime returnedAt);
}