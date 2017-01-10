using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SimpleReversi
{
    public partial class Reversi : Form
    {
        private ReversiGame theGame = new ReversiGame();
       

        public enum Player { HUMAN, COMPUTER };
        public enum PlayStyle { RANDOM, MINIMAX };

        // PictureBoxes for the board
        BoardCell[,] boardDisplay = new BoardCell[8, 8];

        // Players choice of colour
        int playerColour = 1; // By default black
        Player currentPlayer = Player.HUMAN;
        bool playerMoving = false;

        // Computer opponent settings
        PlayStyle computerPlayStyle = PlayStyle.RANDOM;
        int minimaxDepth = 8;

        // Game not started on initialisation
        bool gameStarted = false;
        bool gameOver = false;

        public Reversi()
        {
            InitializeComponent();
            InitBoard();
        }

        private void InitBoard()
        {
            // Initialise board
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    boardDisplay[r, c] = new BoardCell(r, c);
                    boardDisplay[r, c].Dock = DockStyle.Fill;
                    switch (theGame.CellContents(r, c))
                    {
                        case -1:
                            boardDisplay[r, c].BackColor = Color.White;
                            break;
                        case 0:
                            boardDisplay[r, c].BackColor = Color.LightGreen;
                            break;
                        case 1:
                            boardDisplay[r, c].BackColor = Color.Black;
                            break;
                    }
                    boardDisplay[r, c].Click += HandleCellClick;
                }
            }

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    boardLayoutPanel.Controls.Add(boardDisplay[r, c], c, r);
                }
            }
        }

        public void HandleCellClick(object sender, EventArgs e)
        {
            MakePlayerMove(sender);
        }

        private void MakePlayerMove(object sender)
        {
            // Ignore unless player is making move

            if (!playerMoving) return;

            int[] loc = ((BoardCell)sender).Cell;
            if (!theGame.IsMoveLegal(loc[0], loc[1]))
            {
                string m = String.Format("Illegal move at  ({0},{1}).", loc[0] + 1, loc[1] + 1);
                MessageBox.Show(m);
            }
            else
            {
                theGame.MakeMove(loc[0], loc[1]);
                boardLayoutPanel.Refresh();

                // Disable random choice button etc
                moveTypeLabel.Visible = false;
                //randomMoveButton.Visible = false;

                // Uncover OK button
                playerMoveOKButton.Visible = true;
            }
        }

        private void StartNewGame()
        {
            // On clicking play button for the first time

            if (!gameStarted)
            {
               
               

                // Find out which colour player has chosen using
                // cute code to retrieve checked button with LINQ from
                // http://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked

                // Find out selected computer play style
                var checkedButton = chooseComputerStylePanel
                                      .Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
                if (checkedButton.Text == "At Random") computerPlayStyle = PlayStyle.RANDOM;
                else
                {
                    computerPlayStyle = PlayStyle.MINIMAX;
                    minimaxDepth = Decimal.ToInt32(minimaxDepthUpDown.Value);
                }

                // Disable computer play style radio buttons
                chooseComputerStylePanel.Enabled = false;

                // Disable start button
                playButton.Enabled = false;

                // Record that game has started
                gameStarted = true;
            }

            if (playerColour == 1) // player has chosen to be Black
            {
                // Player makes first move
                playerMoving = true;
                moveLabel.Text = "Your Move";
                movePanel.Visible = true;

            }
            else // player has chosen to be White
            {
                // Computer makes first move
                playerMoving = false;
                moveLabel.Text = "My Move";
                movePanel.Visible = true;
            }
        }

        private void boardLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    switch (theGame.CellContents(r, c))
                    {
                        case -1:
                            boardDisplay[r, c].BackColor = Color.White;
                            break;
                        case 0:
                            boardDisplay[r, c].BackColor = Color.LightGreen;
                            break;
                        case 1:
                            boardDisplay[r, c].BackColor = Color.Black;
                            break;
                    }
                }
            }
        }

        private void playButton_Click_1(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void MakeRandMove()
        {
            // get a move at random for player
            int[] movePos = theGame.FindRandomMove();
            theGame.MakeMove(movePos[0], movePos[1]);
        }

        private void randomMoveButton_Click(object sender, EventArgs e)
        {
            if (currentPlayer == Player.HUMAN)
            {
                MakeRandMove();
            }
            else
            {
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
                
                //Thread.Sleep(500000);
            }
            this.Refresh();
            boardLayoutPanel.Refresh();
        }

        private int[] NegaMaxMove(BackgroundWorker bw, int depth)
        {
            // Get best move
            int[] movePos = theGame.FindGoodMove(depth);
            //Thread.Sleep(30000);
            return movePos;

        }

        private void playerMoveOKButton_Click(object sender, EventArgs e)
        {
            playerMoveOKButton.Visible = false;
            playerMoving = false;
            
            if (gameOver)
            {
                moveLabel.Text = "Game Over";
                moveTypeLabel.Text = "";
                return;
            }

            moveLabel.Text = "My Move";

            int numComputerMoves = theGame.CountLegalMovesMoves();

            if(numComputerMoves != 0)
            {
                if (computerPlayStyle == PlayStyle.RANDOM)
                {
                    moveTypeLabel.Text = "Guessing...";

                    moveTypeLabel.Visible = true;

                    this.Refresh();

                    //Thread.Sleep(1000);

                    MakeRandMove();
                    boardLayoutPanel.Refresh();
                }
                else
                {
                    moveTypeLabel.Text = "Thinking....";

                    moveTypeLabel.Visible = true;
                    this.Refresh();
                    backgroundWorker1.RunWorkerAsync(minimaxDepth);
                }
            }
            else
            {
                moveTypeLabel.Text = "I've no legal.";

                moveTypeLabel.Visible = true;
                this.Refresh();
                Thread.Sleep(1000);
                theGame.SwapCurrentPlayer();
            }            
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            currentPlayer = Player.COMPUTER;

            BackgroundWorker helperBw = sender as BackgroundWorker;

            if (helperBw.CancellationPending)
            {
                //Thread.Sleep(5000);
                e.Cancel = true;
                return;
            }
            else
            {
                int arg = (int)e.Argument;
                e.Result = NegaMaxMove(helperBw, arg);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int[] testt = null;
            if (e.Cancelled)
            {
                
                MakeRandMove();
            }
            else if (e.Error != null)
            {
                 MessageBox.Show(e.Error.Message);
            }
            else
            {
                testt = (int[])e.Result; 
                theGame.MakeMove(testt[0], testt[1]); 
                boardLayoutPanel.Refresh();
            }

                moveLabel.Text = "Your Move";

                int blackScore = theGame.BlackCellCount();
                int whiteScore = theGame.WhiteCellCount();

                string bscoreMsg = "Black: " + blackScore;
                string wscoreMsg = "White: " + whiteScore;

                blackScoreLabel.Text = bscoreMsg;
                whiteScoreLabel.Text = wscoreMsg;

                int numComputerMoves = theGame.CountLegalMovesMoves();

                int numPlayerMoves = theGame.CountLegalMovesMoves();

                if (numPlayerMoves == 0)
                {
                    moveTypeLabel.Text = "You have no legal moves.";
                    playerMoveOKButton.Visible = true;
                    // If computer player has no legal moves game over!
                    if (numComputerMoves == 0)
                    {
                        gameOver = true;
                    }
                }
                else
                {
                    moveTypeLabel.Text = "Select cell or choose";
                    randomMoveButton.Visible = true;
                    playerMoving = true;
                }

        }

        private void newGameButton_Click(object sender, EventArgs e)
        {

        }
    }
}
