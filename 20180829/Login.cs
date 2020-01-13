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
    //로그인창 
    public partial class Login : Form
    {
        public static string LoginID = "truth650";
        public static bool IsLogin = false;
        public static int LoginIndex = 0;
        //개인정보
        public static List<User> UserList = new List<User>();
       public static List<Memo> MemoList = new List<Memo>();
        //남은휴가정보
        public static List<Vacation> VacationList = new List<Vacation>();
        //휴가신청정보
        public static List<RequestV> RequestVList = new List<RequestV>();
        //영수증신청정보
        public static List<Expense> ExpenseList = new List<Expense>();
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Container();
            WbDB.Singleton.Close();

        }

        //초기 회원정보
        private void Container()
        {
            WbDB.Singleton.Open();
            UserList = WbDB.Singleton.Member(UserList);
            WbDB.Singleton.Open();
            VacationList = WbDB.Singleton.Vacation_L(VacationList);
            WbDB.Singleton.Open();
            MemoList = WbDB.Singleton.Memo_L(MemoList);
            WbDB.Singleton.Open();
            ExpenseList = WbDB.Singleton.LoadExpense(ExpenseList);
            WbDB.Singleton.Open();
            RequestVList = WbDB.Singleton.Requse_L(RequestVList);
        }

        //회원가입 창 열기
        private void Button2_Click(object sender, EventArgs e)
        {
            SignUp form3 = new SignUp();
            form3.StartPosition = FormStartPosition.CenterParent;
            form3.Show(this);
            this.Visible = false;
        }




       

        //ID/PW 찾기
        private void Button4_Click(object sender, EventArgs e)
        {
            FindMem form8 = new FindMem();
            form8.Show();
            this.Visible = false;
        }

        //종료버튼(완전 종료)
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        //종료버튼(완전 종료)
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //최소화버튼
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        //아이디 텍스트박스 클릭시
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            pictureBox1.Image = Properties.Resources.customer1_32px;
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            textBox1.ForeColor = Color.FromArgb(0, 0, 0);


            pictureBox2.Image = Properties.Resources.password_32px;
            panel1.BackColor = Color.FromArgb(255, 255, 255);
            textBox2.ForeColor = Color.FromArgb(255, 255, 255);

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.customer1_32px;
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            textBox1.ForeColor = Color.FromArgb(0, 0, 0);


            pictureBox2.Image = Properties.Resources.password_32px;
            panel1.BackColor = Color.FromArgb(255, 255, 255);
            textBox2.ForeColor = Color.FromArgb(255, 255, 255);
        }


        //비번 텍스트박스 클릭시
        private void textBox2_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = Properties.Resources.customer_32px;
            panel2.BackColor = Color.FromArgb(255, 255, 255);
            textBox1.ForeColor = Color.FromArgb(255, 255, 255);

            textBox2.Clear();
            textBox2.PasswordChar = '●';
            pictureBox2.Image = Properties.Resources.password1_32px;
            panel1.BackColor = Color.FromArgb(0, 0, 0);
            textBox2.ForeColor = Color.FromArgb(0, 0, 0);
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.customer_32px;
            panel2.BackColor = Color.FromArgb(255, 255, 255);
            textBox1.ForeColor = Color.FromArgb(255, 255, 255);

            textBox2.Clear();
            textBox2.PasswordChar = '●';
            pictureBox2.Image = Properties.Resources.password1_32px;
            panel1.BackColor = Color.FromArgb(0, 0, 0);
            textBox2.ForeColor = Color.FromArgb(0, 0, 0);
        }


        //상단바 코드
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



        //로그인
        private void button1_Click(object sender, EventArgs e)
        {
            Main form2 = new Main();
            int Index = 0;   //로그인 된 유저의 인덱스 순서
            int ErrorType = 0; // 1. 아이디가 없을경우 2. 아이디는 맞지만 비밀번호가 틀린 경우 3. 로그인 성공

            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0) //칸이 비어있지 않은 경우
            {
                for (int i = 0; i < UserList.Count; i++) //아이디개수만큼 반복
                {
                    if (textBox1.Text == UserList[i].Id)   //아이디가 맞을경우
                    {
                        if (textBox2.Text == UserList[i].Pw) //비밀번호도 맞을경우
                        {
                            Index = i;
                            ErrorType = 3;
                            break;
                        }
                        else  //아이디는 맞지만 비밀번호는 틀릴경우
                        {
                            ErrorType = 2;
                            break;
                        }
                    }
                    else     //아이디가 없을 경우
                    {
                        ErrorType = 1;
                    }
                }
                if (ErrorType == 1)
                {
                    MessageBox.Show("Username is not found.");
                }
                else if (ErrorType == 2)
                {
                    MessageBox.Show("Please confirm your password.");
                }
                else if (ErrorType == 3)
                {
                    
                    MessageBox.Show("Welcome to " + UserList[Index].F_Name);
                    form2.ShowDialog();  //메인 창 띄우기
                    IsLogin = true; //로그인 상태변경
                    LoginIndex = Index;
                    LoginID = textBox1.Text; //로그인된 아이디 정보 담아주기
                    this.Visible = false;  //로그인창 숨기기
                }
            }
            else
            {
                MessageBox.Show("아이디나 비밀번호를 입력해주세요.");
            }
        }
        //엔터 로그인
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        }
    }
}
