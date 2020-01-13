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
    //회원가입 창
    public partial class SignUp : Form
    {
        public static List<User>sign_up = new List<User>();
        
        public SignUp()
        {
            InitializeComponent();
        }

        //아래는 버튼 이벤트및 기타 이벤트입니다.

        //종료이벤트
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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

        //중복체크
        private void button1_Click_1(object sender, EventArgs e)
        {
            int index = 1;

            if (textBox1.Text.Length != 0) // 텍스트박스가 비어잇지 않은 경우
            {
                for (int i = 0; i < Login.UserList.Count; i++) //아이디개수만큼 반복
                {
                    if (textBox1.Text == Login.UserList[i].Id)  //이미 아이디가 존재할 경우
                    {
                        MessageBox.Show("이미 존재하는 아이디입니다.");
                        textBox1.Clear();
                        index = 2;
                        break;
                    }
                }
                if (index == 1)
                {
                    MessageBox.Show("사용가능한 아이디입니다.");
                    textBox2.ReadOnly = false;
                    textBox3.ReadOnly = false;
                    textBox4.ReadOnly = false;
                }
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime();
            sign_up.Add(new User("asd", "qweqw", "asdasd", "asd", 2019, 9, 27,"a",1234,
            "sadasd", "asdasd", "asdads", "asdads", 123, "asdads",
            "asdads", "asdads", dateTime, "asdads", 123, 12, "asdads", "asdads",
            "asdads", 21, 212));
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("비밀번호와 비밀번호 확인이 다릅니다.");
                textBox3.Clear();
                textBox2.Clear();
                textBox3.Select();
            }
            else
            {
                if (textBox2.Text == textBox3.Text)
                {
                    sign_up[0].Id = textBox1.Text;
                    sign_up[0].Pw = textBox3.Text;
                    sign_up[0].Question = comboBox6.Text;
                    sign_up[0].Answer = textBox4.Text;
                    this.Hide();
                    SignUp2 form1 = new SignUp2();
                    form1.ShowDialog();
                    this.Close();
                }
            }   
        }

        //이벤트
        //Username
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        //password
        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.PasswordChar = '●';
            textBox3.ForeColor = Color.Black;
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.PasswordChar = '●';
            textBox3.ForeColor = Color.Black;
        }


        //password 확인
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.PasswordChar = '●';
            textBox2.ForeColor = Color.Black;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.PasswordChar = '●';
            textBox2.ForeColor = Color.Black;
        }



        //질의응답
        private void comboBox6_Enter(object sender, EventArgs e)
        {
            comboBox6.ForeColor = Color.Black;
        }
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


    }
}

