namespace BankOcr.Model
{
    class Five : INumber
    {
        public Five()
        {
            Representation = new string[]
            {
                " _ ",
                "|_ ",
                " _|"
            };
        }

        public string[] Representation { get; }
        public char Value { get { return '5'; } }
    }
}