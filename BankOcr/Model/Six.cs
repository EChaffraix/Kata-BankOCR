namespace BankOcr.Model
{
    class Six : INumber
    {
        public Six()
        {
            Representation = new string[]
            {
                " _ ",
                "|_ ",
                "|_|"
            };
        }

        public string[] Representation { get; }
        public char Value { get { return '6'; } }
    }
}