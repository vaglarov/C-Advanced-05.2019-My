using System;
using System.Linq;

namespace _006._Jagged_Array_Modification
{
    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            // Creat Array and Fill
            var inputNumberRow = int.Parse(Console.ReadLine());
            var jaggedArr = new int[inputNumberRow][];
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                var inputNumbers = Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();
                jaggedArr[row] = new int[inputNumbers.Length];
                for (int col = 0; col < inputNumbers.Length; col++)
                {
                    jaggedArr[row][col] = inputNumbers[col];
                }
            }

            // Operations
            string commandInput = string.Empty;
            while ((commandInput = Console.ReadLine()) != "END")
            {
                var commandInputParts = commandInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = commandInputParts[0];
                var rowCorrection = int.Parse(commandInputParts[1]);
                var colCorrection = int.Parse(commandInputParts[2]);
                var edditValue = int.Parse(commandInputParts[3]);
                if (rowCorrection < 0 ||
                    rowCorrection > jaggedArr.Length - 1 ||
                    colCorrection < 0 ||
                    colCorrection > jaggedArr[rowCorrection].Length - 1
                    )
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    switch (command)
                    {
                        case "Add":
                            jaggedArr[rowCorrection][colCorrection] += edditValue;
                            break;
                        case "Subtract":
                            jaggedArr[rowCorrection][colCorrection] -= edditValue;
                            break;
                        default:
                            Console.WriteLine("Wrong input!");
                            break;
                    }
                }
            }

            // Print jaggedArr
            Console.ForegroundColor = ConsoleColor.Red;
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[row]));
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
