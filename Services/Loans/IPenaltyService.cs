namespace APBD_Cw1_s29817.Services.Loans;

public interface IPenaltyService
{
    decimal Calculate(DateTime dueDate, DateTime returnedAt);
}