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
        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == textBox2.Text)
            {
                Login.UserList[FindMem.SelectedNum].Pw = textBox1.Text;
                MessageBox.Show("비밀번호가 변경되었습니다.", "완료");
                textBox1.Clear();
                textBox2.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
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
            l_form.ShowDialog();
            this.Close();
        }
        //상단바
    }
}
