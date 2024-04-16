using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveFigureChessGame
{
    internal class Program
    {
        public class ChessGame
        {
            private char[,] chessboard;
            private int currentRow;
            private int currentColumn;

            public ChessGame()
            {
                InitializeChessboard();
                currentRow = 0;
                currentColumn = 0;
            }
            private void InitializeChessboard()
            {
                chessboard = new char[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        chessboard[i, j] = '*';
                    }
                }
                chessboard[0, 0] = 'X'; // Initial position of 'X'
            }
            private void PrintChessboard()
            {
                Console.WriteLine("   a b c d e f g h");
                for (int i = 0; i < 8; i++)
                {
                    Console.Write($"{8 - i} |");
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write($"{chessboard[i, j]}|");
                    }
                    Console.WriteLine();
                }
            }
            public void StartGame()
            {
                Console.WriteLine("Starting new game...");
                PrintChessboard();

                while (true)
                {
                    Console.Write("Enter the position to move 'X' (e.g., c4): ");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "exit")
                        break;

                    if (!IsValidInput(input))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid position (e.g., c4) or type 'exit' to quit.");
                        continue;
                    }

                    int column = input[0] - 'a';
                    int row = 8 - int.Parse(input[1].ToString());

                    if (!IsValidPosition(row, column))
                    {
                        Console.WriteLine("Invalid position. Please enter a valid position (e.g., c4) or type 'exit' to quit.");
                        continue;
                    }

                    chessboard[currentRow, currentColumn] = '*'; // Clear the current position
                    chessboard[row, column] = 'X'; // Move 'X' to the new position
                    currentRow = row;
                    currentColumn = column;

                    PrintChessboard();
                }
            }
            private bool IsValidInput(string input)
            {
                if (input.Length != 2 || !char.IsLetter(input[0]) || !char.IsDigit(input[1]))
                {
                    return false;
                }

                return true;
            }
            private bool IsValidPosition(int row, int column)
            {
                return (column >= 0 && column < 8 && row >= 0 && row < 8);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Help");
            Console.WriteLine("3. Exit");
            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    ChessGame game = new ChessGame();
                    game.StartGame();
                    break;
                case "2":
                    Console.WriteLine("Help:");
                    Console.WriteLine("This is a help message.");
                    break;
                case "3":
                    Console.WriteLine("Quitting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }
}
