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
    public partial class AddMemo : Form
    {
        Schedule sd;
        public AddMemo()
        {
            InitializeComponent();
        }
        public AddMemo(Schedule _sd)
        {
            InitializeComponent();
            sd = _sd;
        }

        private void AddMemo_Load(object sender, EventArgs e)
        {
            textBox1.Text = Schedule.ChoseYear.ToString();
            textBox2.Text = Schedule.ChoseMonth.ToString();
            textBox3.Text = Schedule.ChoseDay.ToString();
            this.ActiveControl = textBox4;
        }

        //메모 등록 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            //시간 등록
            DateTime dt = new DateTime(Schedule.ChoseYear, Schedule.ChoseMonth, Schedule.ChoseDay,
                int.Parse(textBox4.Text), int.Parse(textBox5.Text), 0);
            Login.MemoList.Add(new Memo(Login.LoginID, dt, textBox6.Text));
            sd.SetMemoList();
            this.Close();
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
        //상단바


        //이벤트

        //메모할 내용
        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox6.ForeColor = Color.Black;
        }
        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox6.ForeColor = Color.Black;
        }

        //이밴트
    }
}
