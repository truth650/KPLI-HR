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
    //비밀번호 재설정
    public partial class CorrectionPW : Form
    {
        public CorrectionPW()
        {
            InitializeComponent();
        }

        //비밀번호 변경

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                WbDB.Singleton.Open();
                WbDB.Singleton.Password_U(Login.UserList[FindMem.SelectedNum].Id, textBox1.Text);
                Login.UserList.Clear();
                WbDB.Singleton.Open();
                WbDB.Singleton.Member(Login.UserList);
                MessageBox.Show("Password change complete.", "완료");
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
                Login l_form = new Login();
                l_form.Visible = true;
                this.Close();

            }
            else
            {
                MessageBox.Show("Password does not match.");
            }
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
            this.Hide();
            Login l_form = new Login();
            l_form.Visible = true;
            this.Close();
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Black;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }
        //상단바
    }
}
