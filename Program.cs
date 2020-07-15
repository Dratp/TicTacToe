using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe();
        }

        static void TicTacToe()
        {
            string[] spots = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int movenumber = 0;
            string player = "X";

            while (CheckWin(spots) == 0)
            {
                movenumber++;
                if (movenumber == 9)
                {
                    break;
                }
                DisplayBoard(spots);
                Console.WriteLine($"\n\tPlayer {player}'s move");
                spots[GetMove(spots)] = player;
                if (player == "X")
                {
                    player = "O";
                }
                else
                {
                    player = "X";
                }
            }
            if (CheckWin(spots) == 0)
            {
                Console.WriteLine("The game is a draw");
            }
            else
            {
                Console.WriteLine($"\tThe Winner is {spots[CheckWin(spots)]}!!!!");
                Console.WriteLine();
                DisplayBoard(spots);
            }

        }

        static void DisplayBoard(string[] spots)
        {
            string line = "-----------";
            Console.WriteLine($"\t {spots[0]} | {spots[1]} | {spots[2]}");
            Console.WriteLine($"\t{line}");
            Console.WriteLine($"\t {spots[3]} | {spots[4]} | {spots[5]}");
            Console.WriteLine($"\t{line}");
            Console.WriteLine($"\t {spots[6]} | {spots[7]} | {spots[8]}");
        }

        static int GetMove(string[] spots)
        {
            int move;
            string entry;
            bool isValid;
            bool isLegal;

            do
            {
                isLegal = false;
                Console.Write("What spot would you like to move to (1-9): ");
                entry = Console.ReadLine();
                isValid = int.TryParse(entry, out move);
//                Console.WriteLine($"Input = {entry}, move = {move}, Valid = {isValid} Legal = {isLegal} spot 5 is {spots[4]}");

                if (!(move > 9 || move < 0 ))
                {
                    if (spots[move-1] != entry)
                    {
                        Console.WriteLine("That spot is already taken");
                        isLegal = false;
                    }
                    else
                    {
                        isLegal = true;
                    }
                }
                else
                {
                    isLegal = false;
                }
                Console.Clear();
                //Console.WriteLine($"Valid = {isValid} Legal = {isLegal} move = {move} entry = {entry}");
            } while (!(isValid && isLegal));
            


            return move - 1;
        }
        static int CheckWin(string[] board)
        {
            int Win=0;

            if (board[0] == board[1] && board[1] == board[2]) { Win = 1; }
            if (board[2] == board[5] && board[5] == board[8]) { Win = 2; }
            if (board[0] == board[3] && board[3] == board[6]) { Win = 3; }
            if (board[2] == board[4] && board[4] == board[6]) { Win = 4; }
            if (board[3] == board[4] && board[4] == board[5]) { Win = 5; }
            if (board[6] == board[7] && board[7] == board[8]) { Win = 6; }
            if (board[1] == board[4] && board[4] == board[7]) { Win = 7; }
            if (board[1] == board[4] && board[4] == board[8]) { Win = 8; }
            return Win;
        }

    }

}
