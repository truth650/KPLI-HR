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
    public partial class SignUp3 : Form
    {
        //회원가입시 휴가정보를 담기위한 리스트(임시)
        public static List<Vacation> vacationlist = new List<Vacation>();

        public SignUp3()
        {
            InitializeComponent();
        }

        //다음 페이지
        private void button2_Click(object sender, EventArgs e)
        {

            SignUp.sign_up[0].Join_Date = dateTimePicker1.Value;
            SignUp.sign_up[0].Office = comboBox6.Text;
            SignUp.sign_up[0].Department = comboBox1.Text;
            SignUp.sign_up[0].Position = comboBox8.Text;
            if(textBox9.Text == "Employee") //일반사용자
            {
                SignUp.sign_up[0].Authority = 1;
            }
            if (textBox9.Text == "Accounting Manager") //재무관리자
            {
                SignUp.sign_up[0].Authority = 2;
            }
            if (textBox9.Text == "HR Manager") //인사관리자
            {
                SignUp.sign_up[0].Authority = 3;
            }
            if (textBox9.Text == "Administrator") //총관리자
            {
                SignUp.sign_up[0].Authority = 4;
            }
            SignUp.sign_up[0].Bank = textBox7.Text;
            SignUp.sign_up[0].Routing_Num = int.Parse(textBox5.Text);
            SignUp.sign_up[0].Account_Num = int.Parse(textBox6.Text);

            //휴가 입력
            VacationCalculation();

            WbDB.Singleton.Open();

            WbDB.Singleton.AddMember(SignUp.sign_up[0]);
            //DB에 vacation 데이터를 보내는 함수



            WbDB.Singleton.Close();

            Login l_form = new Login();
            l_form.Show();
            this.Close();
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
        //상단바


        //이벤트

        //국가
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "USA")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("NY");
                comboBox6.Items.Add("NJ");
                comboBox6.Items.Add("CAL");
            }
            else if (comboBox3.Text == "KOR")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("SEOUL");
            }

        }
        private void comboBox3_Enter(object sender, EventArgs e)
        {
            comboBox3.ForeColor = Color.Black;
        }
        //지역
        private void comboBox6_Enter(object sender, EventArgs e)
        {
            comboBox6.ForeColor = Color.Black;
        }
        
        //직책
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.ForeColor = Color.Black;
        }
        //직급
        private void comboBox8_Enter(object sender, EventArgs e)
        {
            comboBox8.ForeColor = Color.Black;
        }

        //Authority
        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.ForeColor = Color.Black;
        }

        
        //은행 정보

        //은행 이름
        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox7.ForeColor = Color.Black;
        }
        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.ForeColor = Color.Black;
        }
        //은행 지점번호
        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox5.ForeColor = Color.Black;
        }
        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.ForeColor = Color.Black;
        }


        //은행 계좌번호
        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox6.ForeColor = Color.Black;
        }
        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.ForeColor = Color.Black;
        }

        //휴가 계산 함수
        private void VacationCalculation()
        {
            vacationlist[0].ID = SignUp.sign_up[0].Id;
            vacationlist[0].Name = SignUp.sign_up[0].F_Name + " " + SignUp.sign_up[0].L_NAME;
            vacationlist[0].SickDay = 24;

            if((SignUp.sign_up[0].Join_Date.Year - DateTime.Now.Year) == 0)
            {
                vacationlist[0].Annual = 0;
                vacationlist[0].YearVacation = 40 + (8 * 0);
            }
            else
            {
                int annual = (SignUp.sign_up[0].Join_Date.Year - DateTime.Now.Year) - 1;
                vacationlist[0].Annual = annual;
                vacationlist[0].YearVacation = 40 + (8 * annual);
            }
        }
    }
}
