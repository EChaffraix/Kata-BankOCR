namespace BankOcr.Model
{
    class Eight : INumber
    {
        public Eight()
        {
            Representation = new string[]
            {
                " _ ",
                "|_|",
                "|_|"
            };
        }

        public string[] Representation { get; }
        public char Value { get { return '8'; } }
    }
}