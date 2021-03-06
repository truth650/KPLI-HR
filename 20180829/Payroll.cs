﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20180829
{
    public partial class Payroll : Form
    {
        public static List<Expense> expenses = new List<Expense>(); //전송을 위한 임시리스트
        float Total = 0;
        string UserID = null;
        byte[] file = null;
        string filename = null;
        string extension = null;  

        public Payroll()
        {
            InitializeComponent();
        }

        private void Payroll_Load(object sender, EventArgs e)
        {
            Total = 0;
            byte[] b = new byte[100];
            expenses.Add(new Expense(DateTime.Now, "a", "a", 1, 1, 1 ,1, 1, 1, 1, 1,"a", b, "a","a", "a"));

            DateTime dt = DateTime.Now;
            textBox10.Text = dt.Year.ToString() + " - " + dt.Date.Month.ToString() + " - " + dt.Date.Day;
            //이름찾아오기
            for(int i = 0; i < Login.UserList.Count; i++)
            {
                if(Login.UserList[i].Id == Login.LoginID)
                {
                    textBox1.Text = Login.UserList[i].F_Name + " " + Login.UserList[i].L_NAME;
                    UserID = Login.UserList[i].Id;
                }               
            }
            textBox9.Text = "$  " + Total.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MyInfo my_form = new MyInfo();
            my_form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form1 = new Login();
            form1.ShowDialog(); //로그인창 보이기
            Login.IsLogin = false; //로그아웃 상태로 변경
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
            Environment.Exit(0);
        }
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Black;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Black;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
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

        //관리자모드
        private void button3_Click(object sender, EventArgs e)
        {
            if (Login.UserList[Login.LoginIndex].Authority == 1 || Login.UserList[Login.LoginIndex].Authority == 0)
            {
                MessageBox.Show("You don't have permission.");
            }
            else
            {
                this.Hide();
                Administrator a_form = new Administrator();
                a_form.ShowDialog();
                this.Close();
            }
        }
        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.Image = Properties.Resources.administrator_32px;
            button3.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.Font = new Font("Noto Sans KR Medium", 14, FontStyle.Underline);
        }
        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.Font = new Font("Noto Sans KR Medium", 14, FontStyle.Bold);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Font = new Font("Noto Sans KR Medium", 14, FontStyle.Underline);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font("Noto Sans KR Medium", 14, FontStyle.Bold);
        }
        #region Total
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Result();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please check.");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Result();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check.");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Result();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check.");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Result();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check.");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Result();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check.");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Result();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check.");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Result();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check.");
            }
        }

              

        private void Result()
        {
            Total = float.Parse(textBox2.Text) + float.Parse(textBox3.Text) + float.Parse(textBox4.Text) + float.Parse(textBox5.Text)
                + float.Parse(textBox6.Text) + float.Parse(textBox7.Text) + float.Parse(textBox8.Text);

            textBox9.Text = "$  " + Total.ToString();
        }
        #endregion

        //영수증 첨부창
        private void button11_Click(object sender, EventArgs e)
        {
            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*) | *.*";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                //파일이름 띄어주기
                filename = Path.GetFileName(ofd.FileName);
                textBox12.Text = filename;
                file = File.ReadAllBytes(ofd.FileName); //파일 바이트 변환 후 보내주기
                extension = Path.GetExtension(ofd.FileName);   //파일 확장자 보내주기
            }
        }
        private void button11_MouseHover(object sender, EventArgs e)
        {
            button11.ForeColor = Color.Black;
        }
        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.ForeColor = Color.White;
        }

        //내 영수증 처리현황 보기
        private void button10_Click(object sender, EventArgs e)
        {
            ExpenseStatus expensestatus = new ExpenseStatus();
            expensestatus.Show();
        }

        //영수증 신청
        private void button9_Click(object sender, EventArgs e)
        {
            //영수증 정보담기
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,
                DateTime.Now.Minute, DateTime.Now.Second);
            expenses[0].Date = dt;
            expenses[0].ID = UserID;
            expenses[0].Name = textBox1.Text;
            expenses[0].AE = float.Parse(textBox2.Text);
            expenses[0].ME = float.Parse(textBox3.Text);
            expenses[0].OS = float.Parse(textBox4.Text);
            expenses[0].Gift = float.Parse(textBox5.Text);
            expenses[0].OE = float.Parse(textBox6.Text);
            expenses[0].Advertisment = float.Parse(textBox7.Text);
            expenses[0].ETC = float.Parse(textBox8.Text);
            string s = textBox9.Text.Replace("$", "");
            expenses[0].Total = float.Parse(s);
            expenses[0].Contents = textBox11.Text;
            if(file == null)
            {
                byte[] b = new byte[100];
                file = b;
            }
            expenses[0].Image = file;
            if(filename == null)
            {
                filename = "";
            }
            expenses[0].Filename = filename;
            if (extension == null)
            {
                extension = "";
            }         
            expenses[0].Extension = extension;
            expenses[0].Approval = "Payment waiting";

            WbDB.Singleton.Open();
            WbDB.Singleton.InsertExpense(expenses[0]);
        }
}

        
    }

