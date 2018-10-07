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

                Console.WriteLine("Continue enter?[Y/N]");
                endOperationFlag = Console.ReadLine() != "Y";
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
    }
}
