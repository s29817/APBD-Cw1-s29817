using APBD_Cw1_s29817.Models;

namespace APBD_Cw1_s29817.Services.Loans;

public interface ILoanService
{
    Loan Borrow(User user, Models.Equipment equipment, DateTime borrowedAt, int numberOfDays);
    decimal Return(int loanId, DateTime returnedAt);
    IReadOnlyCollection<Loan> GetActiveLoansForUser(int userId);
    IReadOnlyCollection<Loan> GetOverdueLoans(DateTime today);
    IReadOnlyCollection<Loan> GetAll();
}