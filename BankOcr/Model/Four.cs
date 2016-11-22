namespace BankOcr.Model
{
    class Four : INumber
    {
        public Four()
        {
            Representation = new string[]
            {
                "   ",
                "|_|",
                "  |"
            };
        }

        public string[] Representation { get; }
        public char Value { get { return '4'; } }
    }
}