namespace BankOcr.Model
{
    public class Zero : INumber
    {
        public Zero()
        {
            Representation = new[]
            {
                " _ ",
                "| |",
                "|_|"
            };
        }

        public string[] Representation { get; }
        public char Value { get { return '0'; } }
    }
}