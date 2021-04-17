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
            RepeatSymbol('M', quantity);

        private static string ToRomanHundreds(int quantity) =>
            ToSymbols(
                quantity,
                oneSymbol: 'C',
                fiveSymbol: 'D',
                tenSymbol: 'M');

        private static string ToRomanTens(int quantity) =>
            ToSymbols(
                quantity,
                oneSymbol: 'X',
                fiveSymbol: 'L',
                tenSymbol: 'C');

        private static string ToRomanUnits(int quantity) =>
            ToSymbols(
                quantity,
                oneSymbol: 'I',
                fiveSymbol: 'V',
                tenSymbol: 'X');

        private static string ToSymbols(
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
                    return RepeatSymbol(oneSymbol, quantity);

                case 4: // IV
                    return $"{oneSymbol}{fiveSymbol}";

                case 5: // V
                case 6: // VI
                case 7: // VII
                case 8: // VIII
                    return $"{fiveSymbol}{RepeatSymbol(oneSymbol, quantity % 5)}";

                case 9: // IX
                    return $"{oneSymbol}{tenSymbol}";

                default:
                    return string.Empty;
            }
        }

        private static string RepeatSymbol(char symbol, int count) =>
            new string(symbol, count);
    }
}