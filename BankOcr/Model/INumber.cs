namespace BankOcr.Model
{
    public interface INumber
    {
        string[] Representation { get;  }
        char Value { get; }
    }
}