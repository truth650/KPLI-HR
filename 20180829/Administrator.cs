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
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
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
        //상단바


        //이벤트
        //메인
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m_form = new Main();
            m_form.ShowDialog();
            this.Close();
        }
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.Image = Properties.Resources.home_32px;
            button2.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //게시판
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            B_board b_form = new B_board();
            b_form.ShowDialog();
            this.Close();
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
        }
        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button6.Image = Properties.Resources.check_32px;
            button6.ForeColor = Color.FromArgb(255, 255, 255);
        }
        
        //로그아웃      
        private void button1_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            form1.Visible = true; //로그인창 보이기
            Login.IsLogin = false; //로그아웃 상태로 변경
            this.Close();
        }

        //휴가관리 및 승인
        private void button7_Click(object sender, EventArgs e)
        {
            VacationAdministration va = new VacationAdministration();
            va.Show();
        }

        //영수증 관리
        private void button9_Click(object sender, EventArgs e)
        {
            PayrollAdministration pa = new PayrollAdministration();
            pa.Show();
        }

    }
}
