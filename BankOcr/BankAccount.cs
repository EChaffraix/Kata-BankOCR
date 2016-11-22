using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOcr.Model;

namespace BankOcr
{
    public class BankAccount
    {
        const int HEIGHT = 3;
        public const int WIDTH = 3;
        const int ACCOUNT_LENGTH = 9;
        const int TOTAL_LENGTH = ACCOUNT_LENGTH * WIDTH;

        private List<INumber> numbers;
        public string[] Raw { get; set; }
        public string Number { get; set; }

        public BankAccount()
        {
            numbers = new List<INumber>
            {
                new Zero(),
                new One(),
                new Two(),
                new Three(),
                new Four(),
                new Five(),
                new Six(),
                new Seven(),
                new Eight(),
                new Nine()
            };
        }

        public void ConvertToNumber()
        {
            if (Raw == null || Raw.Length != HEIGHT || Raw.Any(e => e.Length != TOTAL_LENGTH))
            {
                throw new ArgumentException("Raw data is not 3 line long or each line is not 27 characters long");
            }

            StringBuilder builder = new StringBuilder(ACCOUNT_LENGTH);
            for (int i = 0; i < TOTAL_LENGTH; i = i + WIDTH)
            {
                char c = ConvertToNumber(i);
                builder.Append(c);
            }

            Number = builder.ToString();
        }

        private char ConvertToNumber(int pos)
        {
            bool found = false;
            char c = '?';
            INumber number = null;

            var input = ExtractInput(pos);
            for (int i = 0; !found && i < numbers.Count; i++)
            {
                number = numbers[i];
                found = true;
                int line = 0;
                while (found && line < HEIGHT)
                {
                    found &= number.Representation[line] == input[line];
                    line++;
                }
            }

            if (found && number != null)
            {
                c = number.Value;
            }
            return c;
        }

        private string[] ExtractInput(int pos)
        {
            string[] input = new string[HEIGHT];
            for (int i = 0; i < HEIGHT; i++)
            {
                input[i] = Raw[i].Substring(pos, WIDTH);
            }
            return input;
        }
    }
}
