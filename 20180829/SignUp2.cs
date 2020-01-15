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
    public partial class SignUp2 : Form
    {
       
        public SignUp2()
        {
            InitializeComponent();
        }

        //Form Load
        private void SignUp2_Load(object sender, EventArgs e)
        {
            textBox16.MaxLength = 9;
            textBox6.MaxLength = 10;
            textBox1.MaxLength = 5;
        }

        //다음 페이지
        private void button2_Click(object sender, EventArgs e)
        {
            SignUp.sign_up[0].F_Name = textBox4.Text;
            SignUp.sign_up[0].L_NAME = textBox5.Text;
            SignUp.sign_up[0].Year = dateTimePicker1.Value.Year;
            SignUp.sign_up[0].Month = dateTimePicker1.Value.Month;
            SignUp.sign_up[0].Day = dateTimePicker1.Value.Day;
            SignUp.sign_up[0].Gender = comboBox3.Text;
            SignUp.sign_up[0].Ssn = int.Parse(textBox16.Text);
            SignUp.sign_up[0].Coun_Phone = comboBox2.Text;
            SignUp.sign_up[0].Phone = int.Parse(textBox6.Text);
            SignUp.sign_up[0].Addr1 = textBox7.Text;
            SignUp.sign_up[0].Addr2 = textBox3.Text;
            SignUp.sign_up[0].Addr_City = textBox2.Text;
            SignUp.sign_up[0].Addr_State = comboBox1.Text;
            SignUp.sign_up[0].Addr_Zip = int.Parse(textBox1.Text);

            this.Hide();
            SignUp3 form1 = new SignUp3();
            form1.ShowDialog();
            this.Close();
        }

        //아래는 버튼 이벤트및 기타 이벤트입니다.

        //종료이벤트
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l_form = new Login();
            l_form.Visible = true;
            this.Close();
        }

        //최소화이벤트
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //상단바 클릭시 폼 이동
        bool TagMove;
        int MValX, MValY;
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }
        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = false;
        }

        //상단바


        //이벤트

        //개인정보    
        //이름
        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox4.ForeColor = Color.Black;
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.ForeColor = Color.Black;
        }
        //성
        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox5.ForeColor = Color.Black;
        }
        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.ForeColor = Color.Black;
        }

        //남/여
        private void comboBox3_Enter(object sender, EventArgs e)
        {
            comboBox3.ForeColor = Color.Black;
        }
        
        //SSN
        private void textBox16_Click(object sender, EventArgs e)
        {
            textBox16.Clear();
            textBox16.ForeColor = Color.Black;
        }
        private void textBox16_Enter(object sender, EventArgs e)
        {
            textBox16.ForeColor = Color.Black;
        }
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            textBox16.Clear();
        }

        //폰넘버(국가)
        private void comboBox2_Enter(object sender, EventArgs e)
        {
            comboBox2.ForeColor = Color.Black;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            if (comboBox2.Text == "USA")
            {
                textBox6.Text = "ex) 6196788496";
            }
            else if (comboBox2.Text == "KOR")
            {
                textBox6.Text = "ex) 1012345678";
            }
        }
        //폰
        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox6.ForeColor = Color.Black;
        }
        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.ForeColor = Color.Black;
        }


        //주소
        //나라선택
        private void comboBox4_Enter(object sender, EventArgs e)
        {
            comboBox4.ForeColor = Color.Black;
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
            if (comboBox4.Text == "USA")
            {
                this.comboBox1.Enabled = true;
            }
            else if (comboBox4.Text == "Korea")
            {
                this.comboBox1.Enabled = false;
                label2.Visible = false;
            }
        }

        //주소 입력1 - 번지
        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox7.ForeColor = Color.Black;
        }
        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.ForeColor = Color.Black;
        }
        //주소 입력2 - 상세 정보
        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.ForeColor = Color.Black;
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        //도시( 예)대전,천안,등등)
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.ForeColor = Color.Black;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        //도시
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.ForeColor = Color.Black;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        //우편 번호
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

    }
}
