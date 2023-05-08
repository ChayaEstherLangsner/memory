using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MemoryApp
{
    public partial class frmMemory : Form
    {
        int num = 0;
        Button firstClickedButton = null;
        Button secondClickedButton = null;
        enum gamestatusenum { startup, Player1turn, Player2turn };
        gamestatusenum gamestatus = gamestatusenum.startup;
        string path = System.Windows.Forms.Application.StartupPath + @"\Pics\";
        List<string> picnamelist = new() { "avacodo", "banana", "cherries", "coconut", "dragon fruit", "grapes", "green apple",
                    "lemon", "lime", "onion", "orange", "papaya", "pear", "pinnaple", "plum", "pomagranate", "red delicious", "strawberry", "tomato", "watermelon" };
        List<Button> listallbuttons = new();
        PictureBox backpicbox = new();
        PictureBox frontpicbox = new();
        List<Button> listallbuttonsforpairing = new();
        string pic;
        int playerClickCount = 0;
        int scoreplayer1 = 0;
        int scoreplayer2 = 0;
        public frmMemory()
        {
            InitializeComponent();
            listallbuttons.AddRange(new[] {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20,
                btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40});
            listallbuttons.ForEach(b => b.Visible = false);
            btnStart.Click += BtnStart_Click;
            SetButtonVisible(listallbuttons, false);
            for (int i = 1; i <= 40; i++)
            {
                Button btn = (Button)Controls.Find("btn" + i.ToString(), true)[0];
                btn.Click += Btn_Click;
            }
            listallbuttonsforpairing.AddRange(new[] {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20,
                            btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40});
            btnDone1.Click += BtnDone1_Click;
            tblScore1.Visible = false;
        }
        private void SetlstImageBox(List<Button> list, PictureBox box)
        {
            list.ForEach(b => b.BackgroundImage = box.Image);
            list.ForEach(b => b.BackgroundImageLayout = ImageLayout.Stretch);
        }
        private void SetbtnImageBox(Button btn, PictureBox box)
        {
            btn.BackgroundImage = box.Image;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void SetButtonVisible(List<Button> lstbtn, bool tf)
        {
            lstbtn.ForEach(b => b.Visible = tf);
        }
        private void SetButtonVisible(Button btn, bool tf)
        {
            btn.Visible = tf;
        }
        private void SetImage(string image, PictureBox box)
        {
            box.Image = System.Drawing.Image.FromFile(path + image + ".png");
        }
        private void PairButtons()
        {
            Random rnd = new();
            for (int i = 1; i < 21; i++)
            {
                num = i;
                int num1 = rnd.Next(0, listallbuttonsforpairing.Count());
                pic = picnamelist[num - 1];
                listallbuttonsforpairing[num1].Text = pic;
                listallbuttonsforpairing.Remove(listallbuttonsforpairing[num1]);
                int num2 = rnd.Next(0, listallbuttonsforpairing.Count());
                pic = picnamelist[num - 1];
                listallbuttonsforpairing[num2].Text = pic;
                listallbuttonsforpairing.Remove(listallbuttonsforpairing[num2]);
            }
        }
        private void BtnStart_Click(object? sender, EventArgs e)
        {
            if (txtName1.Text == "" || txtName2.Text == "")
            {
                MessageBox.Show("Please enter both player names");
            }
            if (btnStart.Text == "New Game")
            {
                tblPlayer1.Visible = true;
                tblPlayer2.Visible = true;
                btnStart.Text = "Start";
                SetButtonVisible(listallbuttons, false);
                tblScore1.Visible = false;
                listallbuttonsforpairing.Clear();
                listallbuttonsforpairing.AddRange(new[] {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20,
                            btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40});
                scoreplayer1 = 0;
                scoreplayer2 = 0;
                playerClickCount = 0;
                lblScoreNum1.Text = "0";
                lblScoreNum2.Text = "0";
                lblPlayerTurnDisplay.Text = "Enter Names To Begin";
            }
            else
            {
                btnStart.Text = "New Game";
                tblScore1.Visible = true;
                tblScore2.Visible = true;
                lblScore1.Text = txtName1.Text + "'s Score";
                lblScore2.Text = txtName2.Text + "'s Score";
                lblPlayerTurnDisplay.Text = txtName1.Text + "'s Turn";
                tblPlayer1.Visible = false;
                tblPlayer2.Visible = false;

                SetButtonVisible(listallbuttons, true);
                SetImage("cover", backpicbox);
                SetlstImageBox(listallbuttons, backpicbox);
                PairButtons();
                gamestatus = gamestatusenum.Player1turn;
                btnDone1.Visible = false;
            }
        }
        private void Btn_Click(object? sender, EventArgs e)
        {

            if (playerClickCount >= 2)
                return;
            else
            {
                Button clickedButton = (Button)sender;
                if (secondClickedButton == null)
                {
                    pic = clickedButton.Text;

                    if (firstClickedButton == null)
                    {
                        firstClickedButton = clickedButton;
                        SetImage(pic, frontpicbox);
                        SetbtnImageBox(clickedButton, frontpicbox);
                    }
                    else if (secondClickedButton == null)
                    {
                        secondClickedButton = clickedButton;
                        SetImage(pic, frontpicbox);
                        SetbtnImageBox(clickedButton, frontpicbox);
                    }
                    playerClickCount++;
                    if (secondClickedButton != null)
                    {
                        

                        if (firstClickedButton.Text == secondClickedButton.Text)
                        {
                            playerClickCount = 0;
                            SetButtonVisible(firstClickedButton, false);
                            SetButtonVisible(secondClickedButton, false);
                            secondClickedButton = null;
                            firstClickedButton = null;
                            if (gamestatus == gamestatusenum.Player2turn)
                            {
                                scoreplayer2++;
                                lblScoreNum2.Text = scoreplayer2.ToString();
                            }
                            else if (gamestatus == gamestatusenum.Player1turn)
                            {
                                scoreplayer1++;
                                lblScoreNum1.Text = scoreplayer1.ToString();
                            }
                            if(scoreplayer1 + scoreplayer2 == 20)
                            {
                                if(scoreplayer1 > scoreplayer2)
                                {
                                    lblPlayerTurnDisplay.Text = txtName1.Text + "Won!!!!";
                                }
                                else if (scoreplayer1 < scoreplayer2)
                                {
                                    lblPlayerTurnDisplay.Text = txtName2.Text + "Won!!!!";
                                }
                                else if (scoreplayer1 == scoreplayer2)
                                {
                                    lblPlayerTurnDisplay.Text = "TIE!!!!";
                                }
                            }
                        }
                        else
                        {
                            btnDone1.Visible = true;
                        }
                    }
                }
            }
        }
        private void BtnDone1_Click(object? sender, EventArgs e)
        {

            btnDone1.Visible = false;
            playerClickCount = 0;
            if (gamestatus == gamestatusenum.Player1turn)
            {
                        SetbtnImageBox(firstClickedButton, backpicbox);
                        SetbtnImageBox(secondClickedButton, backpicbox);
                    
                    gamestatus = gamestatusenum.Player2turn;
                    secondClickedButton = null;
                    firstClickedButton = null;
                    lblPlayerTurnDisplay.Text = txtName2.Text + "'s Turn";
            }
            else if (gamestatus == gamestatusenum.Player2turn)
            {
                        SetbtnImageBox(firstClickedButton, backpicbox);
                        SetbtnImageBox(secondClickedButton, backpicbox);
                    gamestatus = gamestatusenum.Player1turn;
                    secondClickedButton = null;
                    firstClickedButton = null;
                    lblPlayerTurnDisplay.Text = txtName1.Text + "'s Turn";
            }
            
        }

    }
}
