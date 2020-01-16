using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20180829
{
    public partial class MyInfo : Form
    {
        public MyInfo()
        {
            InitializeComponent();
        }

        private void MyInfo_Load(object sender, EventArgs e)
        {
            SetMyInfo();
        }


        private void SetMyInfo()
        {
            for (int i = 0; i < Login.UserList.Count; i++)
            {
                if (Login.UserList[i].Id == Login.LoginID)
                {
                    textBox1.Text = Login.UserList[i].Id;
                    comboBox6.Text = Login.UserList[i].Question;
                    textBox12.Text = Login.UserList[i].Answer;
                    comboBox2.Text = Login.UserList[i].Coun_Phone;
                    textBox6.Text = Login.UserList[i].Phone.ToString();
                    comboBox4.Text = Login.UserList[i].Coun_Phone;
                    textBox8.Text = Login.UserList[i].Addr1;
                    textBox7.Text = Login.UserList[i].Addr2;
                    textBox5.Text = Login.UserList[i].Addr_City;
                    textBox4.Text = Login.UserList[i].Addr_Zip.ToString();
                    comboBox1.Text = Login.UserList[i].Addr_State;
                    textBox11.Text = Login.UserList[i].Bank;
                    textBox9.Text = Login.UserList[i].Routing_Num.ToString();
                    textBox10.Text = Login.UserList[i].Account_Num.ToString();
                }
            }
        }

        //개인정보 수정
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                WbDB.Singleton.Open();
                WbDB.Singleton.UpdateMem(textBox1.Text, textBox3.Text, comboBox6.Text, textBox12.Text, comboBox2.Text, textBox6.Text, textBox8.Text,
                    textBox7.Text, textBox5.Text, int.Parse(textBox4.Text), comboBox1.Text, textBox11.Text, textBox9.Text, textBox10.Text);
                MessageBox.Show("변경되었습니다.");

                WbDB.Singleton.Open();
                Login.UserList.Clear();
                WbDB.Singleton.Member(Login.UserList);

            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지않습니다.");
            }
        }

        //상단바
        bool TagMove;
        int MValX, MValY;
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(226, 241, 255);
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(226, 241, 255);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }
        //상단바
    }
}
