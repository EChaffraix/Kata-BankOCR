namespace BankOcr.Model
{
    class Three : INumber
    {
        public Three()
        {
            Representation = new string[]
            {
                " _ ",
                " _|",
                " _|"
            };
        }

        public string[] Representation { get; }
        public char Value { get { return '3'; } }
    }
}