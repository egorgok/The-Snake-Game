using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void StartBotMouseLeave(object sender, EventArgs e)
        {
            Start_bot.Image = Image.FromFile("C:\\Users\\egorgok\\source\\repos\\TheSnakeGame\\TheSnakeGame\\images\\Start\\Start1.png");
        }

        private void StartBotMouseEnter(object sender, EventArgs e)
        {
            Start_bot.Image = Image.FromFile("C:\\Users\\egorgok\\source\\repos\\TheSnakeGame\\TheSnakeGame\\images\\Start\\Start2.png");
        }

        private void ExitBot_MouseLeave(object sender, EventArgs e)
        {
            ExitBot.Image = Image.FromFile("C:\\Users\\egorgok\\source\\repos\\TheSnakeGame\\TheSnakeGame\\images\\Start\\Exit1.png");
        }

        private void ExitBot_MouseEnter(object sender, EventArgs e)
        {
            ExitBot.Image = Image.FromFile("C:\\Users\\egorgok\\source\\repos\\TheSnakeGame\\TheSnakeGame\\images\\Start\\Exit2.png");
        }

        private void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartGame(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Show();
            this.Hide();
        }
    }
}
