using System;

namespace RomanFormatter
{
    /// <summary>
    /// Integer formatter for roman notation.
    /// </summary>
    public static class RomanFormatter
    {
        /// <summary>
        /// Returns the roman notation of the positive integer.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Integer negative or null</exception>
        public static string ToRomanNotation(int positiveInteger)
        {
            if (positiveInteger <= 0)
            {
                throw new ArgumentOutOfRangeException("Integer must be strictly positive.");
            }

            var thousands = positiveInteger / 1000;
            var hundreds = positiveInteger % 1000 / 100;
            var tens = positiveInteger % 100 / 10;
            var units = positiveInteger % 10;

            return string.Concat(
                ToRomanThousands(thousands),
                ToRomanHundreds(hundreds),
                ToRomanTens(tens),
                ToRomanUnits(units));
        }

        private static string ToRomanThousands(int quantity) =>
            new String('M', quantity);

        private static string ToRomanHundreds(int quantity) =>
            ToRomanSymbols(
                quantity,
                oneSymbol: 'C',
                fiveSymbol: 'D',
                tenSymbol:'M');

        private static string ToRomanTens(int quantity) =>
            ToRomanSymbols(
                quantity,
                oneSymbol: 'X',
                fiveSymbol: 'L',
                tenSymbol:'C');

        private static string ToRomanUnits(int quantity) =>
            ToRomanSymbols(
                quantity,
                oneSymbol: 'I',
                fiveSymbol: 'V',
                tenSymbol:'X');

        private static string ToRomanSymbols(
            int quantity,
            char oneSymbol,
            char fiveSymbol,
            char tenSymbol)
        {
            switch (quantity)
            {
                case 1: // I
                case 2: // II
                case 3: // III
                    return new String(oneSymbol, quantity);
                case 4: // IV
                    return new String(oneSymbol, 1) + new String(fiveSymbol, 1);
                case 5: // V
                    return new String(fiveSymbol, 1);
                case 6: // VI
                case 7: // VII
                case 8: // VIII
                    return new String(fiveSymbol, 1) + new String(oneSymbol, quantity % 5);
                case 9: // IX
                    return new String(oneSymbol, 1) + new String(tenSymbol, 1);
                default:
                    return string.Empty;
            }
        }
    }
}