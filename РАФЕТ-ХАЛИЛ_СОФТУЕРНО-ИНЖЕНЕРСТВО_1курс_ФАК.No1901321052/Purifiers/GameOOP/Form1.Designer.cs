namespace GameOOP
{
    partial class Purifiers
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
            this.txtScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            this.shieldP = new System.Windows.Forms.ProgressBar();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.shieldT = new System.Windows.Forms.Timer(this.components);
            this.labelS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtScore.ForeColor = System.Drawing.Color.White;
            this.txtScore.Location = new System.Drawing.Point(15, 566);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(80, 20);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "Score: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.mainGameTimerEvent);
            // 
            // player
            // 
            this.player.Image = global::GameOOP.Properties.Resources.pShip;
            this.player.Location = new System.Drawing.Point(449, 482);
            this.player.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(83, 87);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // shieldP
            // 
            this.shieldP.BackColor = System.Drawing.Color.Yellow;
            this.shieldP.ForeColor = System.Drawing.Color.Yellow;
            this.shieldP.Location = new System.Drawing.Point(811, 14);
            this.shieldP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.shieldP.Name = "shieldP";
            this.shieldP.Size = new System.Drawing.Size(165, 16);
            this.shieldP.TabIndex = 2;
            this.shieldP.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // shieldT
            // 
            this.shieldT.Interval = 1000;
            this.shieldT.Tick += new System.EventHandler(this.shieldT_Tick);
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelS.Location = new System.Drawing.Point(716, 14);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(89, 17);
            this.labelS.TabIndex = 3;
            this.labelS.Text = "Use Shield !!!";
            this.labelS.Click += new System.EventHandler(this.labelS_Click);
            // 
            // Purifiers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(979, 598);
            this.Controls.Add(this.labelS);
            this.Controls.Add(this.shieldP);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.player);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Purifiers";
            this.Text = "Purifiers";
            this.Load += new System.EventHandler(this.Purifiers_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ProgressBar shieldP;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Timer shieldT;
        private System.Windows.Forms.Label labelS;
    }
}

