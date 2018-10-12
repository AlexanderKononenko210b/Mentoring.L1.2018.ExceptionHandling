using System;
using System.Collections.Generic;

namespace IntParser
{
    /// <summary>
    /// Represents a model of the <see cref="Parser"/> class.
    /// </summary>
    public static class Parser
    {
        private const int CodeZeroAsii = 48;
        private const int BaseScaleNotation = 10;

        /// <summary>
        /// Try parse string to int value.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="number">The out number.</param>
        /// <returns>If parse operation is success true otherwase false.</returns>
        public static bool TryParse(string input, out int number)
        {
            if (string.IsNullOrEmpty(input))
            {
                number = default(int);
                return false;
            }

            var numberList = new List<int>();
            var isNegative = false;

            if (input[0] == '-')
            {
                isNegative = true;
                input = input.Remove(0, 1);
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsNumber(input[i]))
                {
                    number = default(int);
                    return false;
                }

                numberList.Add(GetIntFromChar(input[i]));
            }

            try
            {
                number = GetNumberFromList(numberList, isNegative);
            }
            catch (Exception e)
            {
                number = default(int);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Try parse string to int value.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="number">The out number.</param>
        public static void Parse(string input, out int number)
        {
            if (string.IsNullOrEmpty(input))
            {
                if (input == null)
                {
                    throw new NullReferenceException("Input argument is null.");
                }

                throw new ArgumentOutOfRangeException(nameof(input));
            }

            var numberList = new List<int>();
            var isNegative = false;

            if (input[0] == '-')
            {
                isNegative = true;
                input = input.Remove(0, 1);
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsNumber(input[i]))
                {
                    throw new FormatException("The input string had the wrong format.");
                }

                numberList.Add(GetIntFromChar(input[i]));
            }

            number = GetNumberFromList(numberList, isNegative);
        }

        /// <summary>
        /// Get int number from char.
        /// </summary>
        /// <param name="letter">The char.</param>
        /// <returns>The number type int.</returns>
        private static int GetIntFromChar(char letter) => letter - CodeZeroAsii;

        /// <summary>
        /// Method for get number from array type int.
        /// </summary>
        /// <param name="inputList">The input list.</param>
        /// <param name="isNegative">The negative flag.</param>
        /// <returns>The number.</returns>
        private static int GetNumberFromList(List<int> inputList, bool isNegative)
        {
            var result = 0;
            var degree = 1;

            for (int i = inputList.Count - 1; i >= 0; i--)
            {
                try
                {
                    checked
                    {
                        result += inputList[i] * degree;
                    }
                }
                catch (OverflowException e)
                {
                    if (isNegative)
                    {
                        e.Data.Add("numberLabel", "negative");
                    }
                    else
                    {
                        e.Data.Add("numberLabel", "positive");
                    }

                    throw;
                }

                degree *= BaseScaleNotation;
            }

            return isNegative ? (-1) * result : result;
        }
    }
}

