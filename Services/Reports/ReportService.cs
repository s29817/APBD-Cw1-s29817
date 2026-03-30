using System.Text;
using APBD_Cw1_s29817.Enums;
using APBD_Cw1_s29817.Services.Equipment;
using APBD_Cw1_s29817.Services.Loans;
using APBD_Cw1_s29817.Services.Users;

namespace APBD_Cw1_s29817.Services.Reports;

public class ReportService : IReportService
{
    private readonly IEquipmentService _equipmentService;
    private readonly ILoanService _loanService;
    private readonly IUserService _userService;

    public ReportService(IUserService userService, IEquipmentService equipmentService, ILoanService loanService)
    {
        _userService = userService;
        _equipmentService = equipmentService;
        _loanService = loanService;
    }

    public string BuildSummaryReport(DateTime today)
    {
        var allEquipment = _equipmentService.GetAll();
        var allLoans = _loanService.GetAll();
        var overdueLoans = _loanService.GetOverdueLoans(today);
        var totalPenalty = allLoans.Sum(loan => loan.PenaltyAmount);

        var builder = new StringBuilder();
        builder.AppendLine("===== RENTAL SUMMARY REPORT =====");
        builder.AppendLine($"Users in system: {_userService.GetAll().Count}");
        builder.AppendLine($"All equipment: {allEquipment.Count}");
        builder.AppendLine($"Available: {allEquipment.Count(item => item.Status == EquipmentStatus.Available)}");
        builder.AppendLine($"Borrowed: {allEquipment.Count(item => item.Status == EquipmentStatus.Borrowed)}");
        builder.AppendLine($"Unavailable: {allEquipment.Count(item => item.Status == EquipmentStatus.Unavailable)}");
        builder.AppendLine($"All loans: {allLoans.Count}");
        builder.AppendLine($"Active loans: {allLoans.Count(loan => loan.IsActive)}");
        builder.AppendLine($"Overdue loans: {overdueLoans.Count}");
        builder.AppendLine($"Collected penalties: {totalPenalty:C}");
        builder.AppendLine("=================================");

        return builder.ToString();
    }
}