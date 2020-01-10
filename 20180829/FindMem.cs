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
    public partial class FindMem : Form
    {
        public static int SelectedNum = 0;

        public FindMem()
        {
            InitializeComponent();
        }

        //상단바
        bool TagMove;
        int MValX, MValY;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //상단바

        //아이디 찾기
        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    bool findid = false;

        //    for(int i = 0; i < Login.UserList.Count; i++)
        //    {
        //        if(Login.UserList[i].Name == textBox1.Text &&
        //            Login.UserList[i].Age.ToString() == comboBox1.Text &&
        //            Login.UserList[i].Position == comboBox2.Text)
        //        {
        //            MessageBox.Show("아이디: " + Login.UserList[i].Id);
        //            findid = true;
        //            break;
        //        }
        //    }
        //    if (findid == false)
        //    {
        //        MessageBox.Show("일치하는 사용자가 없습니다.");
        //    }
        //}

        ////비밀번호 찾기
        //private void Button2_Click(object sender, EventArgs e)
        //{
        //    bool findpw = false;

        //    for (int i = 0; i < Login.UserList.Count; i++)
        //    {
        //        if (Login.UserList[i].Id == textBox2.Text &&
        //            Login.UserList[i].Name == textBox3.Text &&
        //            Login.UserList[i].Age.ToString() == comboBox3.Text)
        //        {
        //            SelectedNum = i;
        //            findpw = true;
        //            CorrectionPW form9 = new CorrectionPW();
        //            form9.Show();
        //            break;
        //        }
        //    }
        //    if (findpw == false)
        //    {
        //        MessageBox.Show("일치하는 사용자가 없습니다.");
        //    }
        //}


        //이벤트
        //아이디 찾기
        //이름
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
        }
        //성
        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox4.ForeColor = Color.Black;
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox4.ForeColor = Color.Black;
        }
        //폰 넘버
        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox5.ForeColor = Color.Black;
        }
        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox5.ForeColor = Color.Black;

        }

        


        //비번 찾기(비번 바꾸기)
        //유저 네임
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.ForeColor = Color.Black;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.ForeColor = Color.Black;
        }

        //질의 응답
        private void comboBox6_Enter(object sender, EventArgs e)
        {
            comboBox6.ForeColor = Color.Black;
        }
        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.ForeColor = Color.Black;
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.ForeColor = Color.Black;
        }

        //이벤트
    }
}
