using System;
using System.Linq;

namespace LuhnAlgorithm
{
    public static class CreditCardValidator
    {
        public static bool IsValidCreditNumber(this string creditCardNumber)
        {
            return creditCardNumber.IsValid_LuhnAlgorithm();
        }

        static bool IsValid_LuhnAlgorithm(this string creditCardNumber)
        {
            var finalCreditNumber = creditCardNumber?.Trim().Replace(" ", "");

            if (string.IsNullOrEmpty(finalCreditNumber) || !finalCreditNumber.All(char.IsDigit))
                return false;

            var creditNumberArray = finalCreditNumber.Select(x => int.Parse(x.ToString())).AsEnumerable().Reverse().ToArray();

            for (int i = 0; i < creditNumberArray.Count(); i++)
            {
                if (i % 2 != 0)
                {
                    creditNumberArray[i] *= 2;
                    creditNumberArray[i] -= creditNumberArray[i] > 9 ? 9 : 0;
                }
            }

            return creditNumberArray.Sum() % 10 == 0;
        }
    }
}
