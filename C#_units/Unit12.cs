using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_units
{
    public class Unit12
    {
        public static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
        public static char currentPlayer = 'X';
        public static int moveCount = 0;


        public static void DisplayBoard()
        {
            Console.WriteLine("-------------");
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("-------------");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("-------------");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            Console.WriteLine("-------------");
        }

        public static void PlayerMove()
        {
            int choice;
            bool validMove = false;

            do
            {
                Console.WriteLine($"Игрок {currentPlayer}, выберите клетку (0-8): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) && choice >= 0 && choice < 9 && board[choice] != 'X' && board[choice] != 'O')
                {
                    board[choice] = currentPlayer;
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Недопустимый ход, попробуйте снова.");
                }
            } while (!validMove);
        }

        public static int CheckWin()
        {
            // Возможные выигрышные комбинации
            int[,] winCombos = new int[,]
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Горизонтали
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Вертикали
                {0, 4, 8}, {2, 4, 6}            // Диагонали
            };

            for (int i = 0; i < winCombos.GetLength(0); i++)
            {
                if (board[winCombos[i, 0]] == currentPlayer &&
                    board[winCombos[i, 1]] == currentPlayer &&
                    board[winCombos[i, 2]] == currentPlayer)
                {
                    return 1; // Победа
                }
            }

            // Проверка на ничью
            if (moveCount >= 8)
            {
                return -1; // Ничья
            }

            return 0; // Игра продолжается
        }

        public static void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }
}
