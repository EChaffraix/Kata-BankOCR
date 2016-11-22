namespace BankOcr.Model
{
    class One : INumber
    {
        public One()
        {
            Representation = new string[]
            {
                "   ",
                "  |",
                "  |"
            };
        }

        public string[] Representation { get; }
        public char Value { get { return '1'; } }
    }
}