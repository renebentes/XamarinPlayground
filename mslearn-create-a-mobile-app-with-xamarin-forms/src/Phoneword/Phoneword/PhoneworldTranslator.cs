using System.Text;

namespace Phoneword
{
    public static class PhoneworldTranslator
    {
        private static string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        public static string ToNumber(string raw)
        {
            if (string.IsNullOrEmpty(raw))
            {
                return null;
            }

            raw = raw.ToUpperInvariant();
            var newNumber = new StringBuilder();

            foreach (var character in raw)
            {
                if (" -0123456789".Contains(character))
                {
                    newNumber.Append(character);
                }
            }

            return newNumber.ToString();
        }

        private static bool Contains(this string keyString, char character) => keyString.IndexOf(character) >= 0;

        private static int? TranslateToNumber(char character)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(character))
                {
                    return 2 + i;
                }
            }

            return null;
        }
    }
}