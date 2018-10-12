using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endOperationFlag = false;

            while (!endOperationFlag)
            {
                Console.WriteLine("Enter the string");
                var input = Console.ReadLine();

                try
                {
                    ShowFirstLetter(input);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"Input value is empty. Please enter a valid value. Incorrect argument: {e.ParamName}.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                endOperationFlag = ShowEndOperationQuestion();
            }
        }

        /// <summary>
        /// Show first letter.
        /// </summary>
        /// <param name="input">The input letter.</param>
        private static void ShowFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentOutOfRangeException(nameof(input));
            }

            Console.WriteLine(GetFirstLetter(input));
        }

        /// <summary>
        /// Get first letter for line.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The first letter.</returns>
        private static char GetFirstLetter(string input) => input[0];

        /// <summary>
        /// Show end operation question.
        /// </summary>
        /// <returns>True if operation will has to stop otherwase false.</returns>
        private static bool ShowEndOperationQuestion()
        {
            Console.WriteLine("Continue input?[Y/N]");
            var answer = Console.ReadLine();

            if (answer == "Y")
            {
                return false;
            }

            if (answer == "N")
            {
                return true;
            }

            return ShowEndOperationQuestion();
        }
    }
}
