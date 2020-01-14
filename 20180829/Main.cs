using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20180829
{
    //메인 창
    public partial class Main : Form
    {
        Login form1 = new Login(); //자식객체

        public Main()
        {
            InitializeComponent();
        }

        //로그아웃
        private void Button1_Click(object sender, EventArgs e)
        {
            form1.Visible = true; //로그인창 보이기
            Login.IsLogin = false; //로그아웃 상태로 변경
            this.Close();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Visible = true; //로그인 창으로
            Login.IsLogin = false; //로그아웃 상태로 변경
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
            Environment.Exit(0);
        }





        //사용자관리모드
        //private void Button5_Click(object sender, EventArgs e)
        //{
        //    if (Login.UserList[Login.LoginIndex].Level >= 2)
        //    {
        //        UserList form6 = new UserList();
        //        form6.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("관리자 권한이 없습니다.");
        //    }
        //}


        //이벤트
        //게시판
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            B_board b_form = new B_board();
            b_form.ShowDialog();
            this.Close();
            form1.Visible = false;
        }
        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.Image = Properties.Resources.bulleted_list_32px;
            button4.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //일정관리
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Schedule sch_form = new Schedule();
            sch_form.ShowDialog();
            this.Close();
            form1.Visible = false;
        }
        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button5.Image = Properties.Resources.schedule_32px;
            button5.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //급여관리
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payroll p_form = new Payroll();
            p_form.ShowDialog();
            this.Close();
            form1.Visible = false;
        }
        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button6.Image = Properties.Resources.check_32px;
            button6.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //관리자모드
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator a_form = new Administrator();
            a_form.ShowDialog();
            this.Close();
            form1.Visible = false;
        }



        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.Image = Properties.Resources.administrator_32px;
            button3.ForeColor = Color.FromArgb(255, 255, 255);
        }


    }
}
