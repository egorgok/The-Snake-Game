namespace TheSnakeGame
{
    partial class Start
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.TheSnakeGame = new System.Windows.Forms.PictureBox();
            this.Start_bot = new System.Windows.Forms.PictureBox();
            this.ExitBot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TheSnakeGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Start_bot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBot)).BeginInit();
            this.SuspendLayout();
            // 
            // TheSnakeGame
            // 
            this.TheSnakeGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TheSnakeGame.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TheSnakeGame.ImageLocation = "C:\\Users\\egorgok\\source\\repos\\TheSnakeGame\\TheSnakeGame\\images\\Start\\TheSnakeGame" +
    ".png";
            this.TheSnakeGame.Location = new System.Drawing.Point(110, 49);
            this.TheSnakeGame.Name = "TheSnakeGame";
            this.TheSnakeGame.Size = new System.Drawing.Size(575, 140);
            this.TheSnakeGame.TabIndex = 2;
            this.TheSnakeGame.TabStop = false;
            // 
            // Start_bot
            // 
            this.Start_bot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Start_bot.ImageLocation = "C:\\Users\\egorgok\\source\\repos\\TheSnakeGame\\TheSnakeGame\\images\\Start\\Start1.png";
            this.Start_bot.Location = new System.Drawing.Point(258, 264);
            this.Start_bot.Name = "Start_bot";
            this.Start_bot.Size = new System.Drawing.Size(281, 101);
            this.Start_bot.TabIndex = 3;
            this.Start_bot.TabStop = false;
            this.Start_bot.Click += new System.EventHandler(this.StartGame);
            this.Start_bot.MouseEnter += new System.EventHandler(this.StartBotMouseEnter);
            this.Start_bot.MouseLeave += new System.EventHandler(this.StartBotMouseLeave);
            // 
            // ExitBot
            // 
            this.ExitBot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExitBot.Image = ((System.Drawing.Image)(resources.GetObject("ExitBot.Image")));
            this.ExitBot.Location = new System.Drawing.Point(357, 371);
            this.ExitBot.Name = "ExitBot";
            this.ExitBot.Size = new System.Drawing.Size(90, 25);
            this.ExitBot.TabIndex = 4;
            this.ExitBot.TabStop = false;
            this.ExitBot.Click += new System.EventHandler(this.ExitGame);
            this.ExitBot.MouseEnter += new System.EventHandler(this.ExitBot_MouseEnter);
            this.ExitBot.MouseLeave += new System.EventHandler(this.ExitBot_MouseLeave);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitBot);
            this.Controls.Add(this.Start_bot);
            this.Controls.Add(this.TheSnakeGame);
            this.Name = "Start";
            this.Text = "TheSnakeGame";
            ((System.ComponentModel.ISupportInitialize)(this.TheSnakeGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Start_bot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox TheSnakeGame;
        private System.Windows.Forms.PictureBox Start_bot;
        private System.Windows.Forms.PictureBox ExitBot;
    }
}

