using System;
using System.Text;

namespace Project.BAL.Logic
{
    public class BookingReferenceGenerator
    {
        private const String LETTERS = "abcdefghijklmnopqrstuvwxyz";
        private readonly char[] Alphanumeric = (LETTERS + LETTERS.ToUpper() + "0123456789").ToCharArray();

        public string GenerateBookingReference()
        {
            return GenerateRandom(8);
        }

        private string GenerateRandom(int length)
        {
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(Alphanumeric[random.Next(Alphanumeric.Length)]);
            }

            return result.ToString();
        }
    }
}
