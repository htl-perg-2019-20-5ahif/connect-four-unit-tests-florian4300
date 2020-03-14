using System;

namespace ConnectFour.Logic
{
    public class Board
    {
        /// <summary>
        /// [Column, Row]
        /// </summary>
        private readonly byte[,] GameBoard = new byte[7,6];

        internal int Player = 0;

        public void AddStone(byte column)
        {
            if (column > 6 || column < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }

            for (int row = 0; row < 6; row++)
            {
                var cell = GameBoard[column, row];

                if (cell == 0)
                {
                    GameBoard[column, row] = (byte)(Player + 1);
                    Player = (Player + 1) % 2;
                    return;
                }
            }

            throw new InvalidOperationException("Column is full");
        }
        public int GetPlayer()
        {
            int temp =  this.Player;
            temp = (Player + 1) % 2;
            temp = temp + 1;
            return temp;
        }
        public bool CheckIfPlayerHasWon()
        {
            // horizontalCheck 
            for (int j = 0; j < 6 - 3; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (this.GameBoard[i,j] == this.GetPlayer() && this.GameBoard[i,j + 1] == this.GetPlayer() && this.GameBoard[i,j + 2] == this.GetPlayer() && this.GameBoard[i,j + 3] == this.GetPlayer())
                    {
                        return true;
                    }
                }
            }
            // verticalCheck
            for (int i = 0; i < 7 - 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (this.GameBoard[i,j] == this.GetPlayer() && this.GameBoard[i + 1,j] == this.GetPlayer() && this.GameBoard[i + 2,j] == this.GetPlayer() && this.GameBoard[i + 3,j] == this.GetPlayer())
                    {
                        return true;
                    }
                }
            }
            // ascendingDiagonalCheck 
            for (int i = 3; i < 7; i++)
            {
                for (int j = 0; j < 6 - 3; j++)
                {
                    if (this.GameBoard[i,j] == this.GetPlayer() && this.GameBoard[i - 1,j + 1] == this.GetPlayer() && this.GameBoard[i - 2,j + 2] == this.GetPlayer() && this.GameBoard[i - 3,j + 3] == this.GetPlayer())
                        return true;
                }
            }
            // descendingDiagonalCheck
            for (int i = 3; i < 7; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (this.GameBoard[i,j] == this.GetPlayer() && this.GameBoard[i - 1,j - 1] == this.GetPlayer() && this.GameBoard[i - 2,j - 2] == this.GetPlayer() && this.GameBoard[i - 3,j - 3] == this.GetPlayer())
                        return true;
                }
            }
            return false;
        }
        public byte[,] GetBoard()
        {
            return this.GameBoard;
        }

        public bool CheckIfBoardIsFull()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (this.GameBoard[i, j] == 0)
                        return true;
                }
            }
            return true;
        }
    }
}
