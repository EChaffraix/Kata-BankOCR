namespace BankOcr.Model
{
    class Two : INumber
    {
        public Two()
        {
            Representation = new string[]
            {
                " _ ",
                " _|",
                "|_ "
            };
        }

        public string[] Representation { get; }
        public char Value { get { return '2'; } }
    }
}