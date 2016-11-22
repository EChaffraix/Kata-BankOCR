namespace BankOcr.Model
{
    class Nine : INumber
    {
        public Nine()
        {
            Representation = new string[]
            {
                " _ ",
                "|_|",
                " _|"
            };
        }

        public string[] Representation { get; }
        public char Value { get { return '9'; } }
    }
}