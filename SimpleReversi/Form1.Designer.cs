namespace SimpleReversi
{
    partial class Reversi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.scorePanel = new System.Windows.Forms.Panel();
            this.whiteScoreLabel = new System.Windows.Forms.Label();
            this.blackScoreLabel = new System.Windows.Forms.Label();
            this.movePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.playerMoveOKButton = new System.Windows.Forms.Button();
            this.moveTypeLabel = new System.Windows.Forms.Label();
            this.moveLabel = new System.Windows.Forms.Label();
            this.randomMoveButton = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.boardLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.chooseComputerStylePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.minimaxDepthUpDown = new System.Windows.Forms.NumericUpDown();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.computerRandomButton = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.infoPanel.SuspendLayout();
            this.scorePanel.SuspendLayout();
            this.movePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.chooseComputerStylePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimaxDepthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.scorePanel);
            this.infoPanel.Controls.Add(this.movePanel);
            this.infoPanel.Controls.Add(this.newGameButton);
            this.infoPanel.Controls.Add(this.stopButton);
            this.infoPanel.Location = new System.Drawing.Point(321, 102);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(123, 275);
            this.infoPanel.TabIndex = 1;
            // 
            // scorePanel
            // 
            this.scorePanel.Controls.Add(this.whiteScoreLabel);
            this.scorePanel.Controls.Add(this.blackScoreLabel);
            this.scorePanel.Location = new System.Drawing.Point(12, 148);
            this.scorePanel.Name = "scorePanel";
            this.scorePanel.Size = new System.Drawing.Size(98, 60);
            this.scorePanel.TabIndex = 5;
            // 
            // whiteScoreLabel
            // 
            this.whiteScoreLabel.AutoSize = true;
            this.whiteScoreLabel.Location = new System.Drawing.Point(19, 34);
            this.whiteScoreLabel.Name = "whiteScoreLabel";
            this.whiteScoreLabel.Size = new System.Drawing.Size(47, 13);
            this.whiteScoreLabel.TabIndex = 1;
            this.whiteScoreLabel.Text = "White: 2";
            // 
            // blackScoreLabel
            // 
            this.blackScoreLabel.AutoSize = true;
            this.blackScoreLabel.Location = new System.Drawing.Point(19, 10);
            this.blackScoreLabel.Name = "blackScoreLabel";
            this.blackScoreLabel.Size = new System.Drawing.Size(46, 13);
            this.blackScoreLabel.TabIndex = 0;
            this.blackScoreLabel.Text = "Black: 2";
            // 
            // movePanel
            // 
            this.movePanel.Controls.Add(this.panel1);
            this.movePanel.Controls.Add(this.playerMoveOKButton);
            this.movePanel.Controls.Add(this.moveTypeLabel);
            this.movePanel.Controls.Add(this.moveLabel);
            this.movePanel.Controls.Add(this.randomMoveButton);
            this.movePanel.Location = new System.Drawing.Point(12, 3);
            this.movePanel.Name = "movePanel";
            this.movePanel.Size = new System.Drawing.Size(98, 134);
            this.movePanel.TabIndex = 4;
            this.movePanel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 71);
            this.panel1.TabIndex = 5;
            // 
            // playerMoveOKButton
            // 
            this.playerMoveOKButton.Location = new System.Drawing.Point(34, 111);
            this.playerMoveOKButton.Name = "playerMoveOKButton";
            this.playerMoveOKButton.Size = new System.Drawing.Size(32, 23);
            this.playerMoveOKButton.TabIndex = 5;
            this.playerMoveOKButton.Text = "OK";
            this.playerMoveOKButton.UseVisualStyleBackColor = true;
            this.playerMoveOKButton.Visible = false;
            this.playerMoveOKButton.Click += new System.EventHandler(this.playerMoveOKButton_Click);
            // 
            // moveTypeLabel
            // 
            this.moveTypeLabel.AutoSize = true;
            this.moveTypeLabel.Location = new System.Drawing.Point(-3, 40);
            this.moveTypeLabel.Name = "moveTypeLabel";
            this.moveTypeLabel.Size = new System.Drawing.Size(106, 13);
            this.moveTypeLabel.TabIndex = 4;
            this.moveTypeLabel.Text = "Select cell or choose";
            // 
            // moveLabel
            // 
            this.moveLabel.AutoSize = true;
            this.moveLabel.Location = new System.Drawing.Point(19, 0);
            this.moveLabel.Name = "moveLabel";
            this.moveLabel.Size = new System.Drawing.Size(59, 13);
            this.moveLabel.TabIndex = 3;
            this.moveLabel.Text = "Your Move";
            // 
            // randomMoveButton
            // 
            this.randomMoveButton.Location = new System.Drawing.Point(6, 67);
            this.randomMoveButton.Name = "randomMoveButton";
            this.randomMoveButton.Size = new System.Drawing.Size(89, 23);
            this.randomMoveButton.TabIndex = 1;
            this.randomMoveButton.Text = "Random Move";
            this.randomMoveButton.UseVisualStyleBackColor = true;
            this.randomMoveButton.Click += new System.EventHandler(this.randomMoveButton_Click);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(18, 217);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(89, 23);
            this.newGameButton.TabIndex = 2;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(18, 246);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(89, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Quit";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(343, 64);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(85, 23);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Start";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click_1);
            // 
            // boardLayoutPanel
            // 
            this.boardLayoutPanel.ColumnCount = 8;
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.Location = new System.Drawing.Point(29, 102);
            this.boardLayoutPanel.Name = "boardLayoutPanel";
            this.boardLayoutPanel.RowCount = 8;
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.boardLayoutPanel.Size = new System.Drawing.Size(275, 275);
            this.boardLayoutPanel.TabIndex = 2;
            this.boardLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.boardLayoutPanel_Paint);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Computer chooses move";
            // 
            // chooseComputerStylePanel
            // 
            this.chooseComputerStylePanel.Controls.Add(this.label3);
            this.chooseComputerStylePanel.Controls.Add(this.minimaxDepthUpDown);
            this.chooseComputerStylePanel.Controls.Add(this.radioButton2);
            this.chooseComputerStylePanel.Controls.Add(this.computerRandomButton);
            this.chooseComputerStylePanel.Location = new System.Drawing.Point(166, 10);
            this.chooseComputerStylePanel.Name = "chooseComputerStylePanel";
            this.chooseComputerStylePanel.Size = new System.Drawing.Size(278, 30);
            this.chooseComputerStylePanel.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Depth";
            // 
            // minimaxDepthUpDown
            // 
            this.minimaxDepthUpDown.Location = new System.Drawing.Point(218, 6);
            this.minimaxDepthUpDown.Name = "minimaxDepthUpDown";
            this.minimaxDepthUpDown.Size = new System.Drawing.Size(57, 20);
            this.minimaxDepthUpDown.TabIndex = 2;
            this.minimaxDepthUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(94, 6);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(63, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Minimax";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // computerRandomButton
            // 
            this.computerRandomButton.AutoSize = true;
            this.computerRandomButton.Checked = true;
            this.computerRandomButton.Location = new System.Drawing.Point(3, 6);
            this.computerRandomButton.Name = "computerRandomButton";
            this.computerRandomButton.Size = new System.Drawing.Size(78, 17);
            this.computerRandomButton.TabIndex = 0;
            this.computerRandomButton.TabStop = true;
            this.computerRandomButton.Text = "At Random";
            this.computerRandomButton.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Reversi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 427);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.chooseComputerStylePanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.boardLayoutPanel);
            this.Name = "Reversi";
            this.Text = "Reversi";
            this.infoPanel.ResumeLayout(false);
            this.scorePanel.ResumeLayout(false);
            this.scorePanel.PerformLayout();
            this.movePanel.ResumeLayout(false);
            this.movePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.chooseComputerStylePanel.ResumeLayout(false);
            this.chooseComputerStylePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimaxDepthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.TableLayoutPanel boardLayoutPanel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label moveLabel;
        private System.Windows.Forms.Panel movePanel;
        private System.Windows.Forms.Button randomMoveButton;
        private System.Windows.Forms.Panel chooseComputerStylePanel;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton computerRandomButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label moveTypeLabel;
        private System.Windows.Forms.Button playerMoveOKButton;
        private System.Windows.Forms.Panel scorePanel;
        private System.Windows.Forms.Label whiteScoreLabel;
        private System.Windows.Forms.Label blackScoreLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown minimaxDepthUpDown;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

