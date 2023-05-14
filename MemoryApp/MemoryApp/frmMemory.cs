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
        Random rnd = new();
        enum gamestatusenum { startup, Player1turn, Player2turn };
        gamestatusenum gamestatus = gamestatusenum.startup;
        string path = System.Windows.Forms.Application.StartupPath + @"\Pics\";
        List<string> picnamelist = new() { "avacodo", "banana", "cherries", "coconut", "dragon fruit", "grapes", "green apple",
                    "lemon", "lime", "onion", "orange", "papaya", "pear", "pinnaple", "plum", "pomagranate", "red delicious", "strawberry", "tomato", "watermelon" };
        List<Button> listallbuttons = new();
        PictureBox backpicbox = new();
        PictureBox frontpicbox = new();
        PictureBox tblpicbox = new();
        PictureBox blank = new();
        List<Button> listallbuttonsforpairing = new();
        string pic;
        int playerClickCount = 0;
        int scoreplayer1 = 0;
        int scoreplayer2 = 0;
        public frmMemory()
        {
            InitializeComponent();
            AddAllButtonsToList(listallbuttons);
            btnStart.Click += BtnStart_Click;
            SetButtonVisible(listallbuttons, false);
            for (int i = 1; i <= 40; i++)
            {
                Button btn = (Button)Controls.Find("btn" + i.ToString(), true)[0];
                btn.Click += Btn_Click;
            }
            AddAllButtonsToList(listallbuttonsforpairing);
            btnDone1.Click += BtnDone1_Click;
            TblScore1Visible(false);
        }
        private void SetDisplayMessage(string message)
        {
            lblPlayerTurnDisplay.Text = message;
        }
        private void AddAllButtonsToList(List<Button> lst)
        {
            lst.AddRange(new[] {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20,
                btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40});
        }
        private void SetLstButtonColor(List<Button> lstbtn, Color clr,bool backcolor)
        {
            if (backcolor == true)
            lstbtn.ForEach(b => b.BackColor = clr);
            else
                lstbtn.ForEach(b => b.ForeColor = clr);
        }
        private void SetButtonColor(Button btn, Color clr, bool backcolor)
        {
            if(backcolor == true)
            btn.BackColor = clr;
            else
                btn.ForeColor = clr;

        }
        private void SetlstImageBox(List<Button> list, PictureBox box)
        {
            list.ForEach(b => b.BackgroundImage = box.Image);
            list.ForEach(b => b.BackgroundImageLayout = ImageLayout.Zoom);
            if (box == backpicbox)
            {
                SetLstButtonColor(list, Color.Black, true);
                SetLstButtonColor(list, Color.Black, false); ;
            }
            else
            {
                SetLstButtonColor(list, Color.White, true);
                SetLstButtonColor(list, Color.Black, false);
            }
        }
        private void SetbtnImageBox(Button btn, PictureBox box)
        {
            btn.BackgroundImage = box.Image;
            btn.BackgroundImageLayout = ImageLayout.Zoom;
            if (box == backpicbox)
            {
                SetButtonColor(btn, Color.Black, true);
                SetButtonColor(btn, Color.Black, false);
            }
            else
            {
                SetButtonColor(btn, Color.White, true);
                SetButtonColor(btn, Color.Black, false);
            }
        }
        private void SettblImageBox(TableLayoutPanel tbl, PictureBox box)
        {
            tbl.BackgroundImage = box.Image;
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

        private void SetButtonWithPic(int intname)
            {
            intname = rnd.Next(0, listallbuttonsforpairing.Count());
            pic = picnamelist[num - 1];
            listallbuttonsforpairing[intname].Text = pic;
            listallbuttonsforpairing.Remove(listallbuttonsforpairing[intname]);
        }
        private void PairButtons()
        {
            
            for (int i = 1; i < 21; i++)
            {
                num = i;
                int num1 = 0;
                SetButtonWithPic(num1);
                int num2 = 0;
                SetButtonWithPic(num2);
            }
        }
        private void SetEndResults( string winner, string image)
        {
            SetDisplayMessage(winner);
            SetImage(image, tblpicbox);
            SettblImageBox(tblCards, tblpicbox);
        }
        private void ClearTurns()
        {
            playerClickCount = 0;
            firstClickedButton = null;
            secondClickedButton = null;
        }
        private void tblPlayersVisible(bool tf)
        {
            tblPlayer1.Visible = tf;
            tblPlayer2.Visible = tf;
        }
        private void TblScore1Visible( bool tf)
        {
            tblScore1.Visible = tf;
        }
        private void SetBtnStartText(string txt)
        {
            btnStart.Text = txt;
        }
        private void BtnStart_Click(object? sender, EventArgs e)
        {
            tblpicbox.Image = null;
            SettblImageBox(tblCards, blank);

            if (txtName1.Text == "" || txtName2.Text == "")
            {
                MessageBox.Show("Please enter both player names");
            }
            else if (btnStart.Text == "New Game")
            {
                tblPlayersVisible(true);
                SetBtnStartText("Start");
                SetButtonVisible(listallbuttons, false);
                TblScore1Visible(false);
                listallbuttonsforpairing.Clear();
                AddAllButtonsToList(listallbuttonsforpairing);
                scoreplayer1 = 0;
                scoreplayer2 = 0;
                lblScoreNum1.Text = "0";
                lblScoreNum2.Text = "0";
                SetDisplayMessage("Enter Names To Begin");
                ClearTurns();
            }
            else
            {
                SetBtnStartText("New Game");
                TblScore1Visible(true);
                lblScore1.Text = txtName1.Text + "'s Score";
                lblScore2.Text = txtName2.Text + "'s Score";
                SetDisplayMessage(txtName1.Text + "'s Turn");
                tblPlayersVisible(false);
                SetButtonVisible(listallbuttons, true);
                SetImage("cover", backpicbox);
                PairButtons();
                SetlstImageBox(listallbuttons, backpicbox);
                gamestatus = gamestatusenum.Player1turn;
                btnDone1.Visible = false;
            }
        }
        private void DetectWinner()
        {
            if (scoreplayer1 > scoreplayer2)
            {
                SetEndResults(txtName1.Text + " Won!!!!", "fireworks");
            }
            else if (scoreplayer1 < scoreplayer2)
            {
                SetEndResults(txtName2.Text + " Won!!!!", "fireworks");
            }
            else if (scoreplayer1 == scoreplayer2)
            {
                SetEndResults("TIE!!!!", "tie");
            }
        }
        private void GotMatch()
        {
            SetButtonVisible(firstClickedButton, false);
            SetButtonVisible(secondClickedButton, false);
            ClearTurns();
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
            if (scoreplayer1 + scoreplayer2 == 20)
            {
                DetectWinner();
            }
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            if (playerClickCount >= 2)
                return;
            else
            {
                Button clickedButton = (Button)sender;
                if (firstClickedButton != null)
                {
                    if (firstClickedButton.Name == clickedButton.Name)
                    {
                        return;
                    }
                }
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
                            GotMatch();

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
            SetbtnImageBox(firstClickedButton, backpicbox);
            SetbtnImageBox(secondClickedButton, backpicbox);
            ClearTurns();
            if (gamestatus == gamestatusenum.Player1turn)
            {
                gamestatus = gamestatusenum.Player2turn;
                SetDisplayMessage(txtName2.Text + "'s Turn");
            }
            else if (gamestatus == gamestatusenum.Player2turn)
            {
                gamestatus = gamestatusenum.Player1turn;
                SetDisplayMessage(txtName1.Text + "'s Turn");
            }
        }
    }
}