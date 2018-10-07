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
                Console.WriteLine("Enter the number");

                try
                {
                    if (!Parser.TryParse(Console.ReadLine(), out var number))
                    {
                        Console.WriteLine("Input string has not be converted to the int value.");
                    }

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

                    Console.WriteLine("Input value less than int.MinValue = -2,147,483,648");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Continue converting?[Y/N]");
                endOperationFlag = Console.ReadLine() != "Y";
            }
        }
    }
}
