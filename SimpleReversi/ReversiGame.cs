using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleReversi
{
    class ReversiGame
    {
        // I represent the Reversi board as a simple 8x8 array of integers.
        // Each cell can have value either -1, 0, or 1 with meanings: 
        //   0 -- unoccupied, 
        //   1 -- Black cell, 
        //  -1 -- White cell
        private int[,] theBoard = new int[8, 8];

        // The current player is indicated by -1 for White and 1 for Black
        private int currentPlayer;

        // Game RNG
        Random gameRNG = new Random();

        // Constructor sets up initial board configuration
        // and sets the current player to Black.
        public ReversiGame()
        {
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    theBoard[r, c] = 0;
            theBoard[3, 3] = -1;
            theBoard[3, 4] = 1;
            theBoard[4, 3] = 1;
            theBoard[4, 4] = -1;
            currentPlayer = 1;
        }

        // The current board can be obtained with the following method. Note that all
        // changes to the board state have to be made via the subsequent API.
        public int[,] getBoard() {
            return (int[,]) theBoard.Clone();
        }

        // Current player
        public int CurrentPlayer { get { return currentPlayer; } }

        public void SwapCurrentPlayer() { currentPlayer = (-1) * currentPlayer; }

        // IsMoveLegal checks if proposed move is legal.
        // Move is represented as coords (r,c) of cell into which a disc would be placed.
        public bool IsMoveLegal(int r, int c)
        {
            // Can,t play off the board
            if (r<0|r>7|c<0|c>7) return false;

            // Can't play into square already occupied
            if (theBoard[r, c] != 0) return false;

            // Otherwise a move is legal if it would trap one or more cells
            // of the opposing player's colour between it and a cell of the 
            // current players colour.

            // Need to check this to right, left, up, down, up left,
            // up right, down left and down right from cell.

            // Brute force check -- is there a better way?

            // Search right
            // First if cell to right is off the board then there is no trap to the right
            bool movePossible = true;
            if (offBoard(r,c+1)) movePossible = false;
                // otherwise we need to check if cell is empty or same colour as player's
            else if ((theBoard[r,c+1] == 0) | (theBoard[r,c+1] == currentPlayer)) movePossible = false;
            // if move is still possibly legal at this point then cell to right is of opposing colour,
            // and we can  now track to the right until we find a cell of current player's colour, in 
            // which case we can return true, or we fall of the edge of the board or hit an empty cell.
            int k = 2;
            while (movePossible) {
                if (offBoard(r, c+k)) movePossible = false;
                else
                {
                    if (theBoard[r, c+k] == currentPlayer) return true;
                    else if (theBoard[r, c+k] == 0) movePossible = false;
                } 
                // if we get here then cell we've just looked at contains piece
                // of opposite colour so keep going
                k++;
            }
          
            // Following search have the same logic (in different directions) to the serach right above.

            // Search left
            movePossible = true;
            if (offBoard(r, c - 1)) movePossible = false;
            else if ((theBoard[r, c - 1] == 0) | (theBoard[r, c - 1] == currentPlayer)) movePossible = false;
            k = 2;
            while (movePossible) {
                if (offBoard(r, c - k)) movePossible = false;
                else
                {
                    if (theBoard[r, c - k] == currentPlayer) return true;
                    else if (theBoard[r, c - k] == 0) movePossible = false;
                }
                // if we get here then cell we've just looked at contains piece
                // of opposite colour so keep going
                k++;
            }

            // Search up
            movePossible = true;
            if (offBoard(r - 1, c )) movePossible = false;
            else if ((theBoard[r - 1, c] == 0) | (theBoard[r - 1, c] == currentPlayer)) movePossible = false;
            k = 2;
            while (movePossible)
            {
                if (offBoard(r-k, c)) movePossible = false;
                else
                {
                    if (theBoard[r-k, c] == currentPlayer) return true;
                    else if (theBoard[r-k, c] == 0) movePossible = false;
                }
                // if we get here then cell we've just looked at contains piece
                // of opposite colour so keep going
                k++;
            }

            // Search down
            movePossible = true;
            if (offBoard(r+1, c)) movePossible = false;
            else if ((theBoard[r + 1, c] == 0) | (theBoard[r + 1, c] == currentPlayer)) movePossible = false;
            k = 2;
            while (movePossible)
            {
                if (offBoard(r +k, c)) movePossible = false;
                else
                {
                    if (theBoard[r + k,c] == currentPlayer) return true;
                    else if (theBoard[r +k, c] == 0) movePossible = false;
                }
                // if we get here then cell we've just looked at contains piece
                // of opposite colour so keep going
                k++;
            }

            // Search diag down right
            movePossible = true;
            if (offBoard(r+1, c + 1)) movePossible = false;
            else if ((theBoard[r + 1, c + 1] == 0) | (theBoard[r + 1, c + 1] == currentPlayer)) movePossible = false;
            k = 2;
            while (movePossible)
            {
                if (offBoard(r + k, c+k)) movePossible = false;
                else
                {
                    if (theBoard[r + k, c+k] == currentPlayer) return true;
                    else if (theBoard[r + k, c+k] == 0) movePossible = false;
                }
                // if we get here then cell we've just looked at contains piece
                // of opposite colour so keep going
                k++;
            }

            // Search diag up left
            movePossible = true;
            if (offBoard(r-1, c - 1)) movePossible = false;
            else if ((theBoard[r - 1, c - 1] == 0) | (theBoard[r - 1, c - 1] == currentPlayer)) movePossible = false;
            k = 2;
            while (movePossible)
            {
                if (offBoard(r - k, c - k)) movePossible = false;
                else
                {
                    if (theBoard[r - k, c - k] == currentPlayer) return true;
                    else if (theBoard[r - k, c - k] == 0) movePossible = false;
                }
                // if we get here then cell we've just looked at contains piece
                // of opposite colour so keep going
                k++;
            }

            // Search diag up right
            movePossible = true;
            if (offBoard(r - 1, c + 1)) movePossible = false;
            else if ((theBoard[r - 1, c + 1] == 0) | (theBoard[r - 1, c + 1] == currentPlayer)) movePossible = false;
            k = 2;
            while (movePossible)
            {
                if (offBoard(r - k, c + k)) movePossible = false;
                else
                {
                    if (theBoard[r - k, c + k] == currentPlayer) return true;
                    else if (theBoard[r - k, c + k] == 0) movePossible = false;
                }
                // if we get here then cell we've just looked at contains piece
                // of opposite colour so keep going
                k++;
            }

            // Search diag down left
            movePossible = true;
            if (offBoard(r + 1, c - 1)) movePossible = false;
            else if ((theBoard[r + 1, c - 1] == 0) | (theBoard[r + 1, c - 1] == currentPlayer)) movePossible = false;
            k = 2;
            while (movePossible)
            {
                if (offBoard(r + k, c - k)) movePossible = false;
                else
                {
                    if (theBoard[r + k, c - k] == currentPlayer) return true;
                    else if (theBoard[r + k, c - k] == 0) movePossible = false;
                }
                // if we get here then cell we've just looked at contains piece
                // of opposite colour so keep going
                k++;
            }
            // If we reach here then move is illegal
            return false;
        }

        private bool offBoard(int r, int c)
        {
            if ((r < 0) | (r >= 8) | (c < 0) | (c >= 8)) return true;
            else return false;
        }

        // GetLegalMoves returns an 8x8 array of integers. This array has a 1 at (i,j)
        // if it is legal for the current player to play in that cell. The value 0 indicates 
        // that the current player may not play in that cell.
        public int[,] GetLegalMoves()
        {
            int[,] legalMoves = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (IsMoveLegal(i, j))
                    {
                        legalMoves[i, j] = 1;
                    }
                    else
                    {
                        legalMoves[i, j] = 0;
                    }
                }
            }

            return legalMoves;
        }

        public void MakeMove(int r, int c)
        {
            if (!IsMoveLegal(r, c)) return;

            // Make the move.
            // This requires
            // 1) changing contents of theBoard[r,c] to current players colour,
            theBoard[r, c] = currentPlayer;

            // 2) flipping the colours of cells trapped by the new play
            FlipCells(r, c);

            // Finally change the current player
            currentPlayer = (-1) * currentPlayer;
        }

        private void FlipCells(int r, int c)
        {
            // Flips cell trapped by a play at (r,c).

            // Flip right
            int nflips = NumberFlipsRight(r, c);
            for (int k = 1; k < nflips; k++)
            {
                theBoard[r, c+k] = currentPlayer;
            }

            // Flip left
            nflips = NumberFlipsLeft(r, c);
            for (int k = 1; k < nflips; k++)
            {
                theBoard[r, c-k] = currentPlayer;
            }

            // Flip down
            nflips = NumberFlipsDown(r, c);
            for (int k = 1; k < nflips; k++)
            {
                theBoard[r+k,c] = currentPlayer;
            }

            // Flip up
            nflips = NumberFlipsUp(r, c);
            for (int k = 1; k < nflips; k++)
            {
                theBoard[r-k, c] = currentPlayer;
            }

            // Flip diag down right
            nflips = NumberFlipsDownRight(r, c);
            for (int k = 1; k < nflips; k++)
            {
                theBoard[r+k, c+k] = currentPlayer;
            }
 
            // Flip diag up left
            nflips = NumberFlipsUpLeft(r, c);
            for (int k = 1; k < nflips; k++)
            {
                theBoard[r-k, c-k] = currentPlayer;
            }
 
            // Flip diag down left
            nflips = NumberFlipsDownLeft(r, c);
            for (int k = 1; k < nflips; k++)
            {
                theBoard[r+k, c-k] = currentPlayer;
            }
 
            // Flip diag up right
            nflips = NumberFlipsUpRight(r, c);
            for (int k = 1; k < nflips; k++)
            {
                theBoard[r-k, c+k] = currentPlayer;
            }
        }

        private int NumberFlipsUpRight(int r, int c)
        {
            // If play is in first two rows or last two columns there cannot be any flips up to the right.
            if ((r <= 2) | (c >= 6)) return 0;
            // If next cell up to right is current players colour or empty then no flips
            if ((theBoard[r - 1, c + 1] == currentPlayer) | (theBoard[r-1,c+1]==0)) return 0;
            // Otherwise count how many of the other players cells there are until we reach
            // a cell of current players. If we reach the edge or an empty cell before this then no flips.
            int count = 1;
            while (theBoard[r - count, c + count] != currentPlayer)
            {
                if (theBoard[r - count, c + count] == 0) return 0;
                if (offBoard(r  - count - 1, c + count + 1)) return 0;
                count++;
            }
            return count;
        }

        private int NumberFlipsDownLeft(int r, int c)
        {
            // If play is in last two rows or  first two columns there cannot be any flips down to the left.
            if ((r >= 6) | (c <= 2)) return 0;
            // If next cell down to the left is current players colour or empty then no flips
            if ((theBoard[r + 1, c - 1] == currentPlayer) | (theBoard[r + 1, c - 1] == 0)) return 0;
            // Otherwise count how many of the other players cells there are until we reach
            // a cell of current players. If we reach the edge or an empty cell before this then no flips.
            int count = 1;
            while (theBoard[r+count,c-count] != currentPlayer)
            {
                if (theBoard[r+count, c-count] == 0) return 0;
                if (offBoard(r+count + 1, c-count - 1)) return 0;
                count++;
            }
            return count;
        }

        private int NumberFlipsUpLeft(int r, int c)
        {
            // If play is in first two rows or columns there cannot be any flips up to the left.
            if ((r <= 2) | (c<= 2)) return 0;
            // If next cell up left is current players colour or empty then no flips
            if ((theBoard[r - 1, c-1] == currentPlayer)| (theBoard[r - 1, c-1] == 0)) return 0;
            // Otherwise count how many of the other players cells there are until we reach
            // a cell of current players. If we reach the edge or an empty cell  before this then no flips.
            int count = 1;
            while (theBoard[r - count, c-count] != currentPlayer)
            {
                if (theBoard[r - count, c - count] == 0) return 0;
                if (offBoard(r - count - 1, c-count-1)) return 0;
                count++;
            }
            return count;
        }

        private int NumberFlipsDownRight(int r, int c)
        {
            // If play is in last  two columns or rows there cannot be any flips down to the right.
            if ((r >= 6) | (c>=6)) return 0;

            // If next cell down to right is current players colour or empty then no flips
            if ((theBoard[r+1, c + 1] == currentPlayer) | (theBoard[r+1, c + 1] == 0)) return 0;
            // Otherwise count how many of the other players cells there are until we reach
            // a cell of current players. If we reach the edge or an empty cell before this then no flips.
            int count = 1;
            while (theBoard[r+count, c + count] != currentPlayer)
            {
                if (theBoard[r + count, c + count] == 0) return 0;
                if (offBoard(r+count + 1, c + count + 1)) return 0;
                count++;
            }
            return count;
        }

        private int NumberFlipsUp(int r, int c)
        {
            // If play is in first two rows there cannot be any flips above the play.
            if (r <= 2) return 0;
            // If next cell up is current players colour or empty then no flips
            if (theBoard[r - 1, c] == currentPlayer) return 0;
            if (theBoard[r - 1, c] == 0) return 0;
            // Otherwise count how many of the other players cells there are until we reach
            // a cell of current players. If we reach the edge or an empty cell before this then no flips.
            int count = 1;
            while (theBoard[r - count, c] != currentPlayer)
            {
                if (theBoard[r - count, c] == 0) return 0;
                if (offBoard(r - count - 1, c)) return 0;
                count++;
            }
            return count;
        }

        private int NumberFlipsDown(int r, int c)
        {
            // If play is in last two rows there cannot be any flips below the play.
            if (r >= 6) return 0;
            // If next cell down is current players colour or empty then no flips
            if (theBoard[r+1, c] == currentPlayer) return 0;
            if (theBoard[r + 1, c] == 0) return 0;
            // Otherwise count how many of the other players cells there are until we reach
            // a cell of current players. If we reach the edge or an empty cell before this then no flips.
            int count = 1;
            while (theBoard[r+count, c] != currentPlayer)
            {
                if (theBoard[r + count, c] == 0) return 0;
                if (offBoard(r+count+1, c)) return 0;
                count++;
            }
            return count;
        }

        private int NumberFlipsLeft(int r, int c)
        {
            // If play is in first two columns there cannot be any flips to the left.
            if (c <= 2) return 0;
            // If next cell to left is current players colour or empty then no flips
            if ((theBoard[r, c-1] == currentPlayer) | (theBoard[r, c-1] == 0)) return 0;
            // Otherwise count how many of the other players cells there are until we reach
            // a cell of current players. If we reach the edge or an empty cell before this then no flips.
            int count = 1;
            while (theBoard[r, c - count] != currentPlayer)
            {
                if (theBoard[r, c - count] == 0) return 0;
                if (offBoard(r, c - count - 1)) return 0;
                count++;
            }
            return count;
        }

        private int NumberFlipsRight(int r, int c)
        {
            // If play is in last  two columns there cannot be any flips to the right.
            if (c >= 6) return 0; 
            // If next cell to right is current players colour or empty then no flips
            if ((theBoard[r, c + 1] == currentPlayer) | (theBoard[r, c + 1] == 0)) return 0;
            // Otherwise count how many of the other players cells there are until we reach
            // a cell of current players. If we reach the edge or an empty cell before this then no flips.
            int count = 1;
            while (theBoard[r, c + count] != currentPlayer)
            {
                if (theBoard[r, c + count] == 0) return 0;
                if (offBoard(r, c + count + 1)) return 0;
                count++;
            }
            return count;
        }

        public int CellContents(int r, int c)
        {
            return theBoard[r, c];
        }

        // This method chooses a move at random from the current legal moves.
        // If there are no legal moves it returns {-1,-1}.
        public int[] FindRandomMove()
        {
            int[,] lMoves = GetLegalMoves();
            List<int[]> possMoveList = new List<int[]>();
            // Extract moves that are legal as a list of coordinates.
            for (int r=0; r<8; r++)
                for (int c=0; c<8; c++)
                    if (lMoves[r,c]==1) possMoveList.Add(new int[2] {r,c});
            int n = possMoveList.Count;
            if (n==0) return new int[2] {-1,-1};
            else return possMoveList[gameRNG.Next(0, n)];
        }

        // This method attempts to find a "good" move amongst the current legal moves
        public int[] FindGoodMove(int depth) 
        {
            int[,] legalMoves = GetLegalMoves();
            List<int[]> possMoveList = new List<int[]>();
            // Extract moves that are legal as a list of coordinates.
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    if (legalMoves[r, c] == 1) possMoveList.Add(new int[2] { r, c });
            int n = possMoveList.Count;
            if (n == 0) return new int[2] { -1, -1 }; // This shouldn't be possible!

            List<int> moveValueList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                // make copy of board position
                int[,] boardCopy = getBoard();
                // make the move
                int[] theMove = possMoveList[i];
                MakeMove(theMove[0], theMove[1]);
                moveValueList.Add(NegaMax(depth));
                UnMakeMove(boardCopy);
            }

            // Find maximum value move
            var indexAtMax = moveValueList.IndexOf(moveValueList.Max());

            return possMoveList[indexAtMax];

        }

        private void UnMakeMove(int[,] boardCopy)
        {
            // Restore board to original
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    theBoard[r, c] = boardCopy[r, c];

            // Restore current player
            currentPlayer = (-1) * currentPlayer;
        }

        private int NegaMax(int depth)
        {
            // If we have reached the bottom evaluate position
            if (depth==0) return(EvaluateBoard());

            int bestValue = -64;

            // Otherwise get list of moves from current position
            int[,] legalMoves = GetLegalMoves();
            List<int[]> possMoveList = new List<int[]>();
            // Extract moves that are legal as a list of coordinates.
            var task1 = Task.Factory.StartNew(() => extarctMove(legalMoves, possMoveList));
            int n = possMoveList.Count;
            Thread.Sleep(100);
            if (n == 0) return (EvaluateBoard());

            Task taskB = Task.Factory.StartNew(() => test(bestValue, n, possMoveList, depth));
            taskB.Wait();

            

            return bestValue;
          
        }

        private void test(int bestValue, int n, List<int[]> possMoveList, int depth)
        {
            for (int i = 0; i < n; i++)
            {
                // make copy of board position
                int[,] boardCopy = getBoard();
                // make the move
                int[] theMove = possMoveList[i];
                MakeMove(theMove[0], theMove[1]);
                int value = (-1) * NegaMax(depth - 1);
                UnMakeMove(boardCopy);
                bestValue = Math.Max(value, bestValue);
            }
        }

        private void extarctMove(int[,] legalMoves, List<int[]> possMoveList)
        {
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    if (legalMoves[r, c] == 1) possMoveList.Add(new int[2] { r, c });
        }

        private int EvaluateBoard()
        {
            // This is with viewpoint of player who made move
            // that led to this position. Since MakeMove sets the current
            // player to the next player  to moive we need to compensate for this. 

            int nblack = 0;
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    if (theBoard[r, c] == 1) nblack++;
            int nwhite = 0;
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    if (theBoard[r, c] == -1) nwhite++;
            return ((-1)* currentPlayer *  Math.Abs(nblack - nwhite));
        }

        internal int CountLegalMovesMoves()
        {
            int[,] lmoves = GetLegalMoves();        
            // count number of 1's in grid
            int nmoves = 0;
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    nmoves = nmoves + lmoves[r,c];
            return nmoves;
        }

        public int BlackCellCount()
        {
           int nblack = 0;
           for (int r = 0; r < 8; r++)
               for (int c = 0; c < 8; c++)
                   if (theBoard[r, c] == 1) nblack++;
           return nblack;
        }

        public int WhiteCellCount()
        {
            int nwhite = 0;
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    if (theBoard[r, c] == -1) nwhite++;
            return nwhite; 
        }
    }
}
