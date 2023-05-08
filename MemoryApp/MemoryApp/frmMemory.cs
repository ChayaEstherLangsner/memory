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
        List<Button> pair = new();
        PictureBox backpicbox = new();
        PictureBox frontpicbox = new();
        Dictionary<string, List<Button>> lists = new Dictionary<string, List<Button>>();
        List<Button> listallbuttonsforpairing = new();
        List<List<Button>> buttonlists = new() { };
        List<Button> pair1 = new();
        List<Button> pair2 = new();
        List<Button> pair3 = new();
        List<Button> pair4 = new();
        List<Button> pair5 = new();
        List<Button> pair6 = new();
        List<Button> pair7 = new();
        List<Button> pair8 = new();
        List<Button> pair9 = new();
        List<Button> pair10 = new();
        List<Button> pair11 = new();
        List<Button> pair12 = new();
        List<Button> pair13 = new();
        List<Button> pair14 = new();
        List<Button> pair15 = new();
        List<Button> pair16 = new();
        List<Button> pair17 = new();
        List<Button> pair18 = new();
        List<Button> pair19 = new();
        List<Button> pair20 = new();
        string pic;
        int playerClickCount = 2;
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
            btnPlayer1Turn.Click += BtnPlayer1Turn_Click;
            btnPlayer2Turn.Click += BtnPlayer2Turn_Click;
            tblScore1.Visible = false;
            tblScore2.Visible = false;
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
        private void SetImageBoxVisible(bool tf, PictureBox box)
        {
            box.Visible = tf;
        }
        private void SetImage(string image, PictureBox box)
        {
            box.Image = System.Drawing.Image.FromFile(path + image + ".png");
        }
        private void PairButtons()
        {
            Dictionary<string, List<Button>> pairs = new Dictionary<string, List<Button>>();
            Random rnd = new();
            for (int i = 1; i < 21; i++)
            {


                num = i;
                int num1 = rnd.Next(0, listallbuttonsforpairing.Count());
                pair.Add(listallbuttonsforpairing[num1]);
                pic = picnamelist[num - 1];
                listallbuttonsforpairing[num1].Text = pic;
                listallbuttonsforpairing.Remove(listallbuttonsforpairing[num1]);
                int num2 = rnd.Next(0, listallbuttonsforpairing.Count());
                pair.Add(listallbuttonsforpairing[num2]);
                pic = picnamelist[num - 1];
                listallbuttonsforpairing[num2].Text = pic;
                listallbuttonsforpairing.Remove(listallbuttonsforpairing[num2]);
                buttonlists.Remove(pair);
                string listName = "list" + i.ToString();
                lists.Add(listName, pair);
            }

        }
        private void BtnStart_Click(object? sender, EventArgs e)
        {
            if (txtName1.Text == "" || txtName2.Text == "")
            {
                MessageBox.Show("Please enter both player names");
            }
            else
            {
                tblScore1.Visible = true;
                tblScore2.Visible = true;
                lblScore1.Text = txtName1.Text + "'s Score";
                lblScore2.Text = txtName2.Text + "'s Score";
                btnPlayer1Turn.Text = txtName1.Text + "'s Turn";
                btnPlayer2Turn.Text = txtName2.Text + "'s Turn";
                tblPlayer1.Visible = false;
                tblPlayer2.Visible = false;
                gamestatus = gamestatusenum.Player1turn;
                SetButtonVisible(listallbuttons, true);
                SetImage("cover", backpicbox);
                SetlstImageBox(listallbuttons, backpicbox);
                PairButtons();

            }
        }
        private void Btn_Click(object? sender, EventArgs e)
        {
            if (playerClickCount >= 2)
                return;
            else
            { 
                Button clickedButton = (Button)sender;

            //if (player1ClickCount >= 2)
            //{ gamestatus = gamestatusenum.Player2turn; }
            if (secondClickedButton == null )
            {
                

                pic = clickedButton.Text;
                    //player1ClickCount++;
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
                    //if (secondClickedButton != null)
                    //{

                        //    if (firstClickedButton.Text == secondClickedButton.Text)
                        //    {
                        //        SetButtonVisible(firstClickedButton, false);
                        //        SetButtonVisible(secondClickedButton, false);
                        //        scoreplayer1++;
                        //        lblScoreNum1.Text = scoreplayer1.ToString();

                        //    }
                        //    else if (firstClickedButton.Text != secondClickedButton.Text)
                        //    {
                        //        SetbtnImageBox(firstClickedButton, backpicbox);
                        //        SetbtnImageBox(secondClickedButton, backpicbox);
                        //    }
                        //        gamestatus = gamestatusenum.Player2turn;
                        //        secondClickedButton = null;
                        //        firstClickedButton = null;

                        //    }
                        //}

                    //else if (secondClickedButton == null && gamestatus == gamestatusenum.Player2turn)
                    //{

                    //    pic = clickedButton.Text;
                    //    if (firstClickedButton == null)
                    //    {
                    //        firstClickedButton = clickedButton;
                    //    }
                    //    else if (secondClickedButton == null)
                    //    {
                    //        secondClickedButton = clickedButton;
                    //    }
                    //    SetImage(pic, frontpicbox);
                    //    SetbtnImageBox(clickedButton, frontpicbox);
                    //    if (secondClickedButton != null)
                    //    {
                    //        if (firstClickedButton.Text == secondClickedButton.Text)
                    //        {
                    //            SetButtonVisible(firstClickedButton, false);
                    //            SetButtonVisible(secondClickedButton, false);
                    //            scoreplayer2++;
                    //            lblScoreNum2.Text = scoreplayer2.ToString();

                    //        }
                    //        else if (firstClickedButton.Text != secondClickedButton.Text)
                    //        {
                    //            SetbtnImageBox(firstClickedButton, backpicbox);
                    //            SetbtnImageBox(secondClickedButton, backpicbox);
                    //        }
                    //        gamestatus = gamestatusenum.Player1turn;
                    //        secondClickedButton = null;
                    //        firstClickedButton = null;
                    //    }
                    //}
                }
            }
        }
        private void BtnPlayer2Turn_Click(object? sender, EventArgs e)
        {
            playerClickCount = 0;
            if (secondClickedButton != null)
            {

                if (firstClickedButton.Text == secondClickedButton.Text)
                {
                    SetButtonVisible(firstClickedButton, false);
                    SetButtonVisible(secondClickedButton, false);
                    scoreplayer1++;
                    lblScoreNum1.Text = scoreplayer1.ToString();

                }
                else if (firstClickedButton.Text != secondClickedButton.Text)
                {
                    SetbtnImageBox(firstClickedButton, backpicbox);
                    SetbtnImageBox(secondClickedButton, backpicbox);
                }
                gamestatus = gamestatusenum.Player2turn;
                secondClickedButton = null;
                firstClickedButton = null;
                

            }

    }

private void BtnPlayer1Turn_Click(object? sender, EventArgs e)
        {
            playerClickCount = 0;
            if (secondClickedButton != null)
            {

                if (firstClickedButton.Text == secondClickedButton.Text)
                {
                    SetButtonVisible(firstClickedButton, false);
                    SetButtonVisible(secondClickedButton, false);
                    scoreplayer2++;
                    lblScoreNum2.Text = scoreplayer2.ToString();

                }
                else if (firstClickedButton.Text != secondClickedButton.Text)
                {
                    SetbtnImageBox(firstClickedButton, backpicbox);
                    SetbtnImageBox(secondClickedButton, backpicbox);
                }
                gamestatus = gamestatusenum.Player1turn;
                secondClickedButton = null;
                firstClickedButton = null;


            }

        }
    }
}









//    public partial class frmMemory : Form
//    {
//        string path = Application.StartupPath + @"\Pics\";
//        int num = 0;
//        PictureBox box = new();
//        PictureBox picbox = new();
//        List<Button> listallbuttons = new();
//        List<Button> listallbuttonsforpairing = new();
//        List<List<Button>> buttonlists = new() {  };
//        List<Button> pair1 = new();
//        List<Button> pair2 = new();
//        List<Button> pair3 = new();
//        List<Button> pair4 = new();
//        List<Button> pair5 = new();
//        List<Button> pair6 = new();
//        List<Button> pair7 = new();
//        List<Button> pair8 = new();
//        List<Button> pair9 = new();
//        List<Button> pair10 = new();
//        List<Button> pair11 = new();
//        List<Button> pair12 = new();
//        List<Button> pair13 = new();
//        List<Button> pair14 = new();
//        List<Button> pair15 = new();
//        List<Button> pair16 = new();
//        List<Button> pair17 = new();
//        List<Button> pair18 = new();
//        List<Button> pair19 = new();
//        List<Button> pair20 = new();
//        bool player1turn = true;
//        List<string> picnamelist = new() { "avacodo", "banana", "cherries", "coconut", "dragon fruit", "grapes", "green apple", 
//            "lemon", "lime", "onion", "orange", "papaya", "pear", "pinnaple", "plum", "pomagranate", "red delicious", "strawberry", "tomato", "watermelon" };

//        public frmMemory()
//        {
//            InitializeComponent();
//            btnStart.Click += BtnStart_Click;
//            SetImage("cover", picbox);
//            listallbuttons.AddRange(new[] {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20,
//                btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40});
//            listallbuttonsforpairing.AddRange(new[] {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20,
//                btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40});
//            listallbuttons.ForEach(b => b.BackgroundImage = picbox.Image);
//            listallbuttons.ForEach(b => b.BackgroundImageLayout = ImageLayout.Stretch);
//            listallbuttons.ForEach(b => b.Visible = false);
//btn1.Click += Btn_Click;
//btn2.Click += Btn_Click;
//btn3.Click += Btn_Click;
//btn4.Click += Btn_Click;
//btn5.Click += Btn_Click;
//btn6.Click += Btn_Click;
//btn7.Click += Btn_Click;
//btn8.Click += Btn_Click;
//btn9.Click += Btn_Click;
//            btn10.Click += Btn_Click;
//            btn11.Click += Btn_Click;
//            btn12.Click += Btn_Click;
//            btn13.Click += Btn_Click;
//            btn14.Click += Btn_Click;
//            btn15.Click += Btn_Click;
//            btn16.Click += Btn_Click;
//            btn17.Click += Btn_Click;
//            btn18.Click += Btn_Click;
//            btn19.Click += Btn_Click;
//            btn20.Click += Btn_Click;
//            btn21.Click += Btn_Click;
//            btn22.Click += Btn_Click;
//            btn23.Click += Btn_Click;
//            btn24.Click += Btn_Click;
//            btn25.Click += Btn_Click;
//            btn26.Click += Btn_Click;
//            btn27.Click += Btn_Click;
//            btn28.Click += Btn_Click;
//            btn29.Click += Btn_Click;
//            btn30.Click += Btn_Click;
//            btn31.Click += Btn_Click;
//            btn32.Click += Btn_Click;
//            btn33.Click += Btn_Click;
//            btn34.Click += Btn_Click;
//            btn35.Click += Btn_Click;
//            btn36.Click += Btn_Click;
//            btn37.Click += Btn_Click;
//            btn38.Click += Btn_Click;
//            btn39.Click += Btn_Click;
//            btn40.Click += Btn_Click;


//        }


//        private void SetImageBox(List<Button> list, PictureBox box)
//        {
//            list.ForEach(b => b.BackgroundImage = box.Image);
//            list.ForEach(b => b.BackgroundImageLayout = ImageLayout.Stretch);
//            list.ForEach(b => b.Visible = false);
//        }
//        private void SetImage(string image, PictureBox box)
//        {
//            box.Image = Image.FromFile(path + image + ".png");
//        }

//        private void BtnStart_Click(object? sender, EventArgs e)
//        {
//            if (txtName1.Text == "" || txtName2.Text == "")
//            {
//                MessageBox.Show("Please enter both player names");
//            }
//            else
//            {
//                buttonlists.AddRange(new[] {pair1, pair2, pair3, pair4, pair5, pair6, pair7, pair8, pair9, pair10, pair11, pair12, pair13, pair14, pair15, pair16, pair17, pair18, pair19, pair20 });
//                listallbuttons.ForEach(b => b.Visible = true);
//                txtName1.Enabled = false;
//                txtName2.Enabled = false;
//                txtName1.Text = txtName1.Text + "'s Turn";
//                lblPlayer1.Visible = false;
//                tblPlayer2.Visible = false;
//                tblScore2.Visible = false;
//                player1turn = true;
//            //    picnamelist.AddRange(new[]
//            //    { "avacodo", "banana", "cherries", "coconut", "dragon fruit", "grapes", "green apple",
//            //"lemon", "lime", "onion", "orange", "papaya", "pear", "pinnaple", "plum", "pomagranate", "red delicious", "strawberry", "tomato", "watermelon" });
//                listallbuttonsforpairing.AddRange(new[] {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20,
//                btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40});
//                PairButtons();
//                listallbuttons.ForEach(b => b.Visible = true);
//            }
//        }
//        private void PairButtons()
//        {
//            Dictionary<string, List<Button>> pairs = new Dictionary<string, List<Button>>();
//            Random rnd = new();
//            for (int i = 1; i < 21; i++)
//            {

//                string pic;

//                int num1 = rnd.Next(0, listallbuttonsforpairing.Count());
//                var pair = buttonlists[rnd.Next(0, buttonlists.Count)];
//                pair.Add(listallbuttonsforpairing[num1]);
//                listallbuttonsforpairing.Remove(listallbuttonsforpairing[num1]);
//                int num2 = rnd.Next(0, listallbuttonsforpairing.Count());
//                pair.Add(listallbuttonsforpairing[num2]);
//                pic = picnamelist[num];
//                SetImageBox(pair, box);
//                SetImage(pic, box);
//                listallbuttonsforpairing.Remove(listallbuttonsforpairing[num2]);
//                //picnamelist.Remove(pic);
//                buttonlists.Remove(pair);
//                num = num + 1;
//            }

//        }
//        private void Btn_Click(object? sender, EventArgs e)
//        {
//            Button clickedButton = (Button)sender;
//            string clickedButtonName = clickedButton.Name;
//            picbox.Visible = false;
//            box.Visible = true;
//        }


//    }
//}
