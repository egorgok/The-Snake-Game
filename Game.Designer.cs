namespace TheSnakeGame
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.body1 = new System.Windows.Forms.PictureBox();
            this.apple1 = new System.Windows.Forms.PictureBox();
            this.apple2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.body1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apple1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apple2)).BeginInit();
            this.SuspendLayout();
            // 
            // body1
            // 
            this.body1.Image = ((System.Drawing.Image)(resources.GetObject("body1.Image")));
            this.body1.Location = new System.Drawing.Point(245, 245);
            this.body1.Name = "body1";
            this.body1.Size = new System.Drawing.Size(10, 10);
            this.body1.TabIndex = 0;
            this.body1.TabStop = false;
            // 
            // apple1
            // 
            this.apple1.Image = ((System.Drawing.Image)(resources.GetObject("apple1.Image")));
            this.apple1.Location = new System.Drawing.Point(120, 310);
            this.apple1.Name = "apple1";
            this.apple1.Size = new System.Drawing.Size(10, 10);
            this.apple1.TabIndex = 1;
            this.apple1.TabStop = false;
            // 
            // apple2
            // 
            this.apple2.Image = ((System.Drawing.Image)(resources.GetObject("apple2.Image")));
            this.apple2.Location = new System.Drawing.Point(315, 165);
            this.apple2.Name = "apple2";
            this.apple2.Size = new System.Drawing.Size(10, 10);
            this.apple2.TabIndex = 3;
            this.apple2.TabStop = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.apple2);
            this.Controls.Add(this.apple1);
            this.Controls.Add(this.body1);
            this.Name = "Game";
            this.Text = "Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.body1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apple1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apple2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox body1;
        private System.Windows.Forms.PictureBox apple1;
        private System.Windows.Forms.PictureBox apple2;
    }
}