using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BankOcr.Tests
{
    [TestFixture]
    public class BankAccountTester
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void GivenANonThreeLineString_WhenConvertIsCalled_ThenItThrowAnException(int lineNumber)
        {
            var account = new BankAccount();
            var lines = new List<string>();

            for (var i = 0; i < lineNumber; i++)
            {
                lines.Add(string.Empty);
            }

            account.Raw = lines.ToArray();

            Assert.Catch<Exception>(account.ConvertToNumber);
        }

        [TestCase(26)]
        [TestCase(28)]
        public void GivenAThreeLineStringButNon27Long_WhenConvertIsCalled_ThenItThrowAnException(int length)
        {
            var account = new BankAccount();
            var lines = new List<string>();

            for (var i = 0; i < 3; i++)
            {
                var s = new char[length];
                lines.Add(s.ToString());
            }

            account.Raw = lines.ToArray();

            Assert.Catch<Exception>(account.ConvertToNumber);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void GivenAnInvalidNumberAtASpecificPosition_WhenConvertIsCalled_ThenAccountNumberIsPartiallyRetrieved(int invalid)
        {
            var account = new BankAccount();
            var builder = new StringBuilder("    _  _     _  _  _  _  _ ");

            for (int i = 0; i < BankAccount.WIDTH; i++)
            {
                builder[(BankAccount.WIDTH * invalid) + i] = '.';
            }

            account.Raw = new[]
            {
                builder.ToString(),
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|"
            };
            builder.Clear();
            builder.Append("123456789");
            builder[invalid] = '?';
            var expected = builder.ToString();

            Assert.DoesNotThrow(account.ConvertToNumber);

            Assert.AreEqual(expected, account.Number);
        }

        [Test]
        public void GivenAnInvalidNumber_WhenConvertIsCalled_ThenAccountNumberIs_OnlyQuestionMark()
        {
            var account = new BankAccount();

            account.Raw = new[]
            {
                "___________________________",
                "|_||_|| ||_||_   |  |  ||_ ",
                "  | _||_||_||_|  |  |  | _|"
            };

            Assert.DoesNotThrow(account.ConvertToNumber);
            Assert.AreEqual("?????????", account.Number);
        }


        [Test]
        public void GivenARandomValidNumber_WhenConvertIsCalled_ThenAccountNumberIs_490867715()
        {
            var account = new BankAccount();

            account.Raw = new[]
            {
                "    _  _  _  _  _  _     _ ",
                "|_||_|| ||_||_   |  |  ||_ ",
                "  | _||_||_||_|  |  |  | _|"
            };

            Assert.DoesNotThrow(account.ConvertToNumber);
            Assert.AreEqual("490867715", account.Number);
        }

        [Test]
        public void GivenOnlyOneIntoTheString_WhenConvertIsCalled_ThenAccountNumberIs_111111111()
        {
            var account = new BankAccount();

            account.Raw = new[]
            {
                "                           ",
                "  |  |  |  |  |  |  |  |  |",
                "  |  |  |  |  |  |  |  |  |"
            };

            Assert.DoesNotThrow(account.ConvertToNumber);
            Assert.AreEqual("111111111", account.Number);
        }

        [Test]
        public void GivenOrderedNumbersFromOneToNine_WhenConvertIsCalled_ThenAccountNumberIs_123456789()
        {
            var account = new BankAccount();

            account.Raw = new[]
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|"
            };

            Assert.DoesNotThrow(account.ConvertToNumber);
            Assert.AreEqual("123456789", account.Number);
        }
    }
}