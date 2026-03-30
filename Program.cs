using APBD_Cw1_s29817.Exceptions;
using APBD_Cw1_s29817.Models;
using APBD_Cw1_s29817.Services.Equipment;
using APBD_Cw1_s29817.Services.Loans;
using APBD_Cw1_s29817.Services.Reports;
using APBD_Cw1_s29817.Services.Users;

IUserService userService = new UserService();
IEquipmentService equipmentService = new EquipmentService();
ILoanService loanService = new LoanService(new PenaltyPolicy(15m));
IReportService reportService = new ReportService(userService, equipmentService, loanService);

var student = new Student("Anna", "Nowak", "s12345");
var secondStudent = new Student("Piotr", "Wiśniewski", "s54321");
var employee = new Employee("Jan", "Kowalski", "IT");

userService.Add(student);
userService.Add(secondStudent);
userService.Add(employee);

var laptop = new Laptop("Dell Latitude 5440", "Dell", 16, 14.0);
var projector = new Projector("Epson EB-X49", "Epson", 3600);
var camera = new Camera("Canon EOS 2000D", "Canon", 24);
var secondLaptop = new Laptop("Lenovo ThinkPad T14", "Lenovo", 32, 14.0);
var thirdLaptop = new Laptop("HP ProBook 450", "HP", 8, 15.6);

foreach (var item in new Equipment[] { laptop, projector, camera, secondLaptop, thirdLaptop })
    equipmentService.Add(item);

Console.WriteLine("USERS:");
foreach (var user in userService.GetAll()) Console.WriteLine(user);

Console.WriteLine("\nALL EQUIPMENT:");
foreach (var item in equipmentService.GetAll()) Console.WriteLine(item);

Console.WriteLine("\nCORRECT BORROWING:");
var loan1 = loanService.Borrow(student, laptop, new DateTime(2026, 3, 10), 7);
Console.WriteLine($"Created loan {loan1.Id} for {student.FirstName} and equipment {laptop.Name}.");

Console.WriteLine("\nMARK EQUIPMENT AS UNAVAILABLE:");
equipmentService.MarkUnavailable(projector.Id);
Console.WriteLine($"Equipment {projector.Name} marked as unavailable.");

Console.WriteLine("\nINVALID OPERATION - BORROWING UNAVAILABLE EQUIPMENT:");
try
{
    loanService.Borrow(employee, projector, new DateTime(2026, 3, 11), 3);
}
catch (DomainException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\nINVALID OPERATION - STUDENT EXCEEDS LIMIT:");
try
{
    loanService.Borrow(student, camera, new DateTime(2026, 3, 11), 5);
    loanService.Borrow(student, secondLaptop, new DateTime(2026, 3, 11), 5);
}
catch (DomainException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\nAVAILABLE EQUIPMENT:");
foreach (var item in equipmentService.GetAvailable()) Console.WriteLine(item);

Console.WriteLine("\nACTIVE LOANS FOR STUDENT:");
foreach (var loan in loanService.GetActiveLoansForUser(student.Id)) Console.WriteLine(loan);

Console.WriteLine("\nRETURN ON TIME:");
var penalty1 = loanService.Return(loan1.Id, new DateTime(2026, 3, 16));
Console.WriteLine($"Loan {loan1.Id} closed. Penalty: {penalty1:C}");

Console.WriteLine("\nLATE RETURN WITH PENALTY:");
var employeeLoan = loanService.Borrow(employee, thirdLaptop, new DateTime(2026, 3, 1), 7);
var penalty2 = loanService.Return(employeeLoan.Id, new DateTime(2026, 3, 12));
Console.WriteLine($"Loan {employeeLoan.Id} closed. Penalty: {penalty2:C}");

Console.WriteLine("\nOVERDUE LOANS (2026-03-30):");
foreach (var overdueLoan in loanService.GetOverdueLoans(new DateTime(2026, 3, 30))) Console.WriteLine(overdueLoan);

Console.WriteLine();
Console.WriteLine(reportService.BuildSummaryReport(new DateTime(2026, 3, 30)));