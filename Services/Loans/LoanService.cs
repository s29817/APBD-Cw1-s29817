using APBD_Cw1_s29817.Enums;
using APBD_Cw1_s29817.Exceptions;
using APBD_Cw1_s29817.Models;

namespace APBD_Cw1_s29817.Services.Loans;

public class LoanService : ILoanService
{
    private readonly List<Loan> _loans = [];
    private readonly IPenaltyPolicy _penaltyPolicy;

    public LoanService(IPenaltyPolicy penaltyPolicy)
    {
        _penaltyPolicy = penaltyPolicy;
    }

    public Loan Borrow(User user, Models.Equipment equipment, DateTime borrowedAt, int numberOfDays)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new BusinessRuleException($"Equipment '{equipment.Name}' is not available.");
        }

        var activeLoanCount = _loans.Count(loan => loan.IsActive && loan.User.Id == user.Id);
        if (activeLoanCount >= user.LoanLimit)
        {
            throw new BusinessRuleException(
                $"User {user.FirstName} {user.LastName} exceeded the limit of {user.LoanLimit} active loans.");
        }

        if (numberOfDays <= 0)
        {
            throw new BusinessRuleException("Loan period must be greater than 0 days.");
        }

        var dueDate = borrowedAt.Date.AddDays(numberOfDays);
        var loan = new Loan(user, equipment, borrowedAt, dueDate);

        equipment.MarkBorrowed();
        _loans.Add(loan);

        return loan;
    }

    public decimal Return(int loanId, DateTime returnedAt)
    {
        var loan = _loans.FirstOrDefault(item => item.Id == loanId)
                   ?? throw new NotFoundException($"Loan with id {loanId} was not found.");

        if (!loan.IsActive)
        {
            throw new BusinessRuleException($"Loan {loanId} is already closed.");
        }

        var penalty = _penaltyPolicy.Calculate(loan.DueDate, returnedAt);
        loan.Close(returnedAt, penalty);
        loan.Equipment.MarkAvailable();

        return penalty;
    }

    public IReadOnlyCollection<Loan> GetActiveLoansForUser(int userId)
        => _loans.Where(loan => loan.IsActive && loan.User.Id == userId).ToList().AsReadOnly();

    public IReadOnlyCollection<Loan> GetOverdueLoans(DateTime today)
        => _loans.Where(loan => loan.IsOverdue(today)).ToList().AsReadOnly();

    public IReadOnlyCollection<Loan> GetAll() => _loans.AsReadOnly();
}