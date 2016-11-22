namespace BankOcr.Model
{
    class Seven : INumber
    {
        public Seven()
        {
            Representation = new string[]
            {
                " _ ",
                "  |",
                "  |"
            };
        }

        public string[] Representation { get; }
        public char Value { get { return '7'; } }
    }
}