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
                if (input == null)
                {
                    throw new NullReferenceException("Input argument is null.");
                }

                throw new ArgumentOutOfRangeException(nameof(input));
            }

            var negativeNumberLabel = 0;
            var numberList = new List<int>();

            if (input[0] == '-')
            {
                numberList.Add(input[0]);
                negativeNumberLabel = 1;
            }

            for (int i = negativeNumberLabel; i < input.Length; i++)
            {
                if (!char.IsNumber(input[i]))
                {
                    number = default(int);
                    return false;
                }

                numberList.Add(GetIntFromChar(input[i]));
            }

            number = GetNumberFromList(numberList);
            return true;
        }

        /// <summary>
        /// Get int number from char.
        /// </summary>
        /// <param name="letter">The char.</param>
        /// <returns>The number type int.</returns>
        private static int GetIntFromChar(char letter) => (int)letter - CodeZeroAsii;

        /// <summary>
        /// Method for get number from array type int
        /// </summary>
        /// <param name="inputList">input array</param>
        /// <returns>result number</returns>
        private static int GetNumberFromList(List<int> inputList)
        {
            var result = 0;
            var degree = 1;
            var negativeNumberLabel = inputList[0] != '-' ? 0 : 1;

            for (int i = inputList.Count - 1; i >= negativeNumberLabel; i--)
            {
                try
                {
                    checked
                    {
                        result += inputList[0] != '-' ? inputList[i] * degree : (-1) * inputList[i] * degree;
                    }
                }
                catch (OverflowException e)
                {
                    if (inputList[0] == '-')
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

            return result;
        }
    }
}

