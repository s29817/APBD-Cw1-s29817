namespace APBD_Cw1_s29817.Exceptions;


public class BusinessRuleException : DomainException
{
    public BusinessRuleException(string message) : base(message)
    {
    }
}