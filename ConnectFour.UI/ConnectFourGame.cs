using ConnectFour.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour.UI
{
    public class ConnectFourGame
    {
        Board board = new Board();
        public void StartGame()
        {
            do
            {
                try
                {

                byte col = this.GetInputStone();
                this.board.AddStone(col);
                this.printGameBoard();


                } catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                } catch(ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!this.CheckGameEnded());
            Console.WriteLine("Player " + this.GetPlayer() + " has won");
        }
        private bool CheckGameEnded()
        {
            if (this.board.CheckIfPlayerHasWon() || this.board.CheckIfBoardIsFull())
            {
                return true;
            }
            return false;
        }

        private int GetPlayer()
        {
            return board.GetPlayer();
        }
        private byte GetInputStone()
        {
            string index = "";
            byte parsedIndex;
            do
            {
                Console.Write("Player " + GetPlayer() + " please enter a column index: ");
                index = Console.ReadLine();

            } while (!Byte.TryParse(index, out parsedIndex));
            return parsedIndex;

        }
        private void printGameBoard()
        {
            for (int row = 5; row > -1; row--)
            {
                for (int column = 0; column < 7; column++)
                {
                    Console.Write(this.board.GetBoard()[column,row]+"\t");
                }
                Console.WriteLine();
            }
        }
    }
}
