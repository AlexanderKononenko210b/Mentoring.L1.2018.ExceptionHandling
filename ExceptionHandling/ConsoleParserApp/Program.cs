using System;
using IntParser;

namespace ConsoleParserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var endOperationFlag = false;

            while (!endOperationFlag)
            {
                var chooseMenu = ChooseMethodForConvertOperation();

                if (chooseMenu == 0)
                {
                    ParseStringToInt();

                    if (ShowEndOperationQuestion()) break;
                }

                if (chooseMenu == 1)
                {
                    TryParseStringToInt();

                    if (ShowEndOperationQuestion()) break;
                }

                if (chooseMenu == 2)
                {
                    endOperationFlag = true;
                }
            }
        }

        /// <summary>
        /// Parse input string value to int using Parse method.
        /// </summary>
        private static void ParseStringToInt()
        {
            Console.WriteLine("Enter value for parsing operation:");

            try
            {
                Parser.Parse(Console.ReadLine(), out var number);

                Console.WriteLine($"Converting result: {number}");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Input value is empty. Please enter valid data. Incorrect argument: {e.ParamName}");
            }
            catch (OverflowException e)
            {
                if ((string)e.Data["numberLabel"] == "positive")
                {
                    Console.WriteLine("Input value more than int.MaxValue = 2,147,483,647.");
                }
                else
                {
                    Console.WriteLine("Input value less than int.MinValue = -2,147,483,648");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Try parse input string value to int using TryParse method.
        /// </summary>
        private static void TryParseStringToInt()
        {
            Console.WriteLine("Enter value for parsing operation:");

            if (!Parser.TryParse(Console.ReadLine(), out var number))
            {
                Console.WriteLine("Operation to convert the entered value to int format impossible");
            }
            else
            {
                Console.WriteLine($"Converting result: {number}");
            }
        }

        /// <summary>
        /// Show menu for choose convert operation method or enter.
        /// </summary>
        /// <returns>
        /// 0 - Parse method.
        /// 1 - TryParse method.
        /// 2 - Enter from application.
        /// </returns>
        private static int ChooseMethodForConvertOperation()
        {
            Console.WriteLine("Choose the method for converting operation or enter from application:");
            Console.WriteLine("0 - Parse");
            Console.WriteLine("1 - TryParse");
            Console.WriteLine("2 - Exit from application");
            var answer = Console.ReadLine();

            if (answer == "0")
            {
                return 0;
            }

            if (answer == "1")
            {
                return 1;
            }

            if (answer == "2")
            {
                return 2;
            }

            return ChooseMethodForConvertOperation();
        }

        /// <summary>
        /// Show end operation question.
        /// </summary>
        /// <returns>True if operation will has to stop otherwase false.</returns>
        private static bool ShowEndOperationQuestion()
        {
            Console.WriteLine("Continue converting?[Y/N]");
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
