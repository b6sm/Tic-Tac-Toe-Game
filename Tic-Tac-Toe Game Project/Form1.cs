using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public enum enPlayer
        {
            Player1,Player2
            
        }

        public enum enWinner
        {
            Player1,Player2,GameInProgress,Draw
        }

       public struct stGameStatus
        {
           public enWinner Winner;
            public short PlayCount;

            

            public bool GameOver;

           

        }
        

        enPlayer PlayerTurn = enPlayer.Player1;
        stGameStatus GameStatus = default(stGameStatus);

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255,255,255,255);

            Pen WhitePen = new Pen(White);
            WhitePen.Width = 10;

            WhitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            WhitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(WhitePen, 650, 75, 650, 350);

            e.Graphics.DrawLine(WhitePen, 500, 75, 500, 350);

            e.Graphics.DrawLine(WhitePen, 375, 165, 780, 165);

            e.Graphics.DrawLine(WhitePen, 375, 270, 780, 270);

        }

        void EndGame()
        {
            lbPlayer.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.Player1:

                    lbWinner.Text = "Player 1";
                    break;
                case enWinner.Player2:

                    lbWinner.Text = "Player 2";

                    break;
                default:

                    lbWinner.Text = "Draw";

                    break;
            }

            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn2.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();

                    return true;
                }
            }

            GameStatus.GameOver = false;
            return false;
           
        }

        bool ChickIfDraw()
        {
            if ((Convert.ToString( button1.Tag) == "x" || Convert.ToString( button1.Tag) == "y") && (Convert.ToString( button2.Tag) == "x" || Convert.ToString( button2.Tag) == "y") &&
                (Convert.ToString( button3.Tag) == "x" || Convert.ToString( button3.Tag) == "y") && (Convert.ToString( button4.Tag) == "x" || Convert.ToString( button4.Tag) == "y") &&
                (Convert.ToString( button5.Tag) == "x" || Convert.ToString( button5.Tag) == "y") && (Convert.ToString( button6.Tag) == "x" || Convert.ToString( button6.Tag) == "y") &&
                (Convert.ToString( button7.Tag) == "x" || Convert.ToString( button7.Tag) == "y") && (Convert.ToString( button8.Tag) == "x" || Convert.ToString( button8.Tag) == "y") &&
                (Convert.ToString( button9.Tag) == "x" || Convert.ToString( button9.Tag) == "y"))
            {
                lbWinner.Text = "Draw";
                lbPlayer.Text = "Game Over";
                MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        public void CheckWinner()
        {
            //row
            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;
            //Colmn
            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;
            //x
            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;

           
        }

        public void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.BackgroundImage = Properties.Resources.Letter_X_Transparent_Images;
                        PlayerTurn = enPlayer.Player2;
                        lbPlayer.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.BackgroundImage = Properties.Resources.pngkey_com_tic_tac_toe_png_2056274;
                        PlayerTurn = enPlayer.Player1;
                        lbPlayer.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();

                        break;
                   
                }
            }

            else
            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9 && GameStatus.GameOver==false)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        private void RestartGame(Button btn)
        {
            btn.BackgroundImage = Properties.Resources.question_mark_icon_41632;
            btn.Tag = "?";
            btn.BackColor = Color.Black;
        }

        void RestartForm()
        {
           RestartGame(button1);
           RestartGame(button2);
           RestartGame(button3);
           RestartGame(button4);
           RestartGame(button5);
           RestartGame(button6);
           RestartGame(button7);
           RestartGame(button8);
           RestartGame(button9);

            PlayerTurn = enPlayer.Player1;
            lbPlayer.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lbWinner.Text = "In Progress";

        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);

        }

       
        private void btmRestart_Click(object sender, EventArgs e)
        {
            RestartForm();
        }

       
    }
}
