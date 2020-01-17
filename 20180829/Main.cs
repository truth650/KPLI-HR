using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        public static List<Holiday> holidaylist = new List<Holiday>();
        public static List<Memo> memolist = new List<Memo>();
        //메모등록을 위해 날짜를 넘겨주는 변수
        public static int ChoseYear = 0;
        public static int ChoseMonth = 0;
        public static int ChoseDay = 0;
        public static int memoidx = 0;

        static Button[] btn = new Button[42];
        //n번째 요일검사(btn.name)
        static int[] sun = new int[6];
        static int[] mon = new int[6];
        static int[] tue = new int[6];
        static int[] wed = new int[6];
        static int[] thu = new int[6];
        static int[] fri = new int[6];
        static int[] sat = new int[6];

        #region 날짜변수 정의
        //기준날짜(최초 현재날짜)
        static DateTime today = DateTime.Now.Date;
        //이번달 첫날
        static DateTime firstDay = today.AddDays(1 - today.Day);
        //이번달 마지막 날
        static DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);

        #endregion

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SetHeadLine();

            holidaylist.Clear();

            Container();

            LunarDateUpdate();

            CalendarSet();
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

        //내 정보
        private void button8_Click(object sender, EventArgs e)
        {
            MyInfo my_form = new MyInfo();
            my_form.ShowDialog();
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
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Black;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Black;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }
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
            if (Login.UserList[Login.LoginIndex].Authority == 1 || Login.UserList[Login.LoginIndex].Authority == 0)
            {
                MessageBox.Show("관리자 권한이 없습니다.");
            }
            else
            {
                this.Hide();
                Administrator a_form = new Administrator();
                a_form.ShowDialog();
                this.Close();
                form1.Visible = false;
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

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            B_board b_form = new B_board();
            b_form.ShowDialog();
            this.Close();
            form1.Visible = false;
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Schedule sch_form = new Schedule();
            sch_form.ShowDialog();
            this.Close();
            form1.Visible = false;
        }

        //공지사항 
        private void SetHeadLine()
        {
            for (int i = Login.BoardList.Count - 1; i > 0; i--)
            {
                if(Login.BoardList[i].Category == "공지사항")
                {
                    richTextBox1.SelectedRtf = Login.BoardList[i].Contents_Info;
                    richTextBox1.Text = Login.BoardList[i].Contents;
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                    richTextBox1.Font = new Font("Noto Sans KR", 25, FontStyle.Regular);
                    richTextBox1.WordWrap = false;
                    richTextBox1.Multiline = true;
                    richTextBox1.ScrollToCaret();
                    break;
                }
            }
        }



        //Container에 있는 공휴일 음력->양력 업데이트
        public void LunarDateUpdate()
        {
            for (int i = 0; i < holidaylist.Count; i++)
            {
                if (holidaylist[i].DayofWeek == "Lunar")
                {
                    DateTime dt = new DateTime();
                    dt = new DateTime(today.Year, holidaylist[i].Month, holidaylist[i].Day);
                    DateTime SolarDay = new DateTime();
                    SolarDay = ConvertFromKoreaLunarDate(dt);
                    holidaylist[i].Year = SolarDay.Year;
                    holidaylist[i].Month = SolarDay.Month;
                    if (holidaylist[i].Name == "부처님오신날" && SolarDay.Year == 2020)
                    {
                        holidaylist[i].Month = SolarDay.Month - 1;
                    }
                    if (holidaylist[i].Name == "설날" && holidaylist[i].Day == 1)
                    {
                        holidaylist[i - 1].Month = SolarDay.Month;
                        holidaylist[i - 1].Day = SolarDay.Day - 1;
                    }
                    holidaylist[i].Day = SolarDay.Day;
                }
            }
        }


        //음력 -> 양력변환
        public DateTime ConvertFromKoreaLunarDate(DateTime lunarDate)
        {
            DateTime returnDate = new DateTime();

            DateTime date = lunarDate;
            KoreanLunisolarCalendar ksc = new KoreanLunisolarCalendar();

            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (ksc.GetMonthsInYear(year) > 12)
            {
                int leapMonth = ksc.GetLeapMonth(year);

                if (month >= leapMonth - 1)
                {
                    returnDate = ksc.ToDateTime(year, month + 1, day, 0, 0, 0, 0);
                }
                else
                {
                    returnDate = ksc.ToDateTime(year, month, day, 0, 0, 0, 0);
                }
            }
            else
            {
                returnDate = ksc.ToDateTime(year, month, day, 0, 0, 0, 0);
            }


            return returnDate;
        }

        //자료 업로드
        private void Container()
        {
            if (holidaylist.Count == 0)
            {
                //미국
                holidaylist.Add(new Holiday("US", "Static", "New Years Day", today.Year, 1, 1, 0, "0"));
                holidaylist.Add(new Holiday("US", "Dynamic", "Martin Luther king Jr's Birthday", today.Year, 1, 0, 3, "Mon"));
                holidaylist.Add(new Holiday("US", "Dynamic", "President Day", today.Year, 2, 0, 3, "Mon"));
                holidaylist.Add(new Holiday("US", "Dynamic", "Memorial Day", today.Year, 5, 0, 3, "Mon"));
                holidaylist.Add(new Holiday("US", "Static", "Independence Day", today.Year, 7, 4, 0, "0"));
                holidaylist.Add(new Holiday("US", "Dynamic", "Labor Day", today.Year, 9, 0, 1, "Mon"));
                holidaylist.Add(new Holiday("US", "Dynamic", "Columbus Day", today.Year, 10, 0, 2, "Mon"));
                holidaylist.Add(new Holiday("US", "Static", "Veterans Day", today.Year, 7, 4, 0, "0"));
                holidaylist.Add(new Holiday("US", "Dynamic", "Thanksgiving Day", today.Year, 11, 0, 4, "Thu"));
                holidaylist.Add(new Holiday("US", "Static", "Christmas", today.Year, 12, 25, 0, "0"));

                //한국 Solar = 양력, Lunar = 음력
                holidaylist.Add(new Holiday("KOR", "Static", "신정", today.Year, 1, 1, 0, "Solar"));
                holidaylist.Add(new Holiday("KOR", "Static", "설날", today.Year, 1, 5, 0, "Lunar"));
                holidaylist.Add(new Holiday("KOR", "Static", "설날", today.Year, 1, 1, 0, "Lunar"));
                holidaylist.Add(new Holiday("KOR", "Static", "설날", today.Year, 1, 2, 0, "Lunar"));
                holidaylist.Add(new Holiday("KOR", "Static", "삼일절", today.Year, 3, 1, 0, "Solar"));
                holidaylist.Add(new Holiday("KOR", "Static", "부처님오신날", today.Year, 4, 8, 0, "Lunar"));
                holidaylist.Add(new Holiday("KOR", "Static", "어린이날", today.Year, 5, 5, 0, "Solar"));
                holidaylist.Add(new Holiday("KOR", "Static", "현충일", today.Year, 6, 6, 0, "Solar"));
                holidaylist.Add(new Holiday("KOR", "Static", "광복절", today.Year, 8, 15, 0, "Solar"));
                holidaylist.Add(new Holiday("KOR", "Static", "추석", today.Year, 8, 14, 0, "Lunar"));
                holidaylist.Add(new Holiday("KOR", "Static", "추석", today.Year, 8, 15, 0, "Lunar"));
                holidaylist.Add(new Holiday("KOR", "Static", "추석", today.Year, 8, 16, 0, "Lunar"));
                holidaylist.Add(new Holiday("KOR", "Static", "개천절", today.Year, 10, 3, 0, "Solar"));
                holidaylist.Add(new Holiday("KOR", "Static", "한글날", today.Year, 10, 9, 0, "Solar"));
                holidaylist.Add(new Holiday("KOR", "Static", "크리스마스", today.Year, 12, 25, 0, "Solar"));
            }
        }

        //불규칙 휴일계산(ex.세번째 주 월요일)
        private void IrregularHolidays(int first, int lastday)
        {
            int a = 1;
            int b = 2;
            int c = 3;
            int d = 4;
            int e = 5;
            int f = 6;
            int g = 7;
            sun = new int[] { 0, 0, 0, 0, 0, 0 };
            mon = new int[] { 0, 0, 0, 0, 0, 0 };
            tue = new int[] { 0, 0, 0, 0, 0, 0 };
            wed = new int[] { 0, 0, 0, 0, 0, 0 };
            thu = new int[] { 0, 0, 0, 0, 0, 0 };
            fri = new int[] { 0, 0, 0, 0, 0, 0 };
            sat = new int[] { 0, 0, 0, 0, 0, 0 };
            //시작: 일요일
            if (first == 1)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (a <= lastday)
                    {
                        sun[i] = a;
                        a += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (b <= lastday)
                    {
                        mon[i] = b;
                        b += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (c <= lastday)
                    {
                        tue[i] = c;
                        c += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (d <= lastday)
                    {
                        wed[i] = d;
                        d += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (e <= lastday)
                    {
                        thu[i] = e;
                        e += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (f <= lastday)
                    {
                        fri[i] = f;
                        f += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (g <= lastday)
                    {
                        sat[i] = g;
                        g += 7;
                    }
                }
            }
            //시작: 월요일
            if (first == 2)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (a <= lastday)
                    {
                        mon[i] = a;
                        a += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (b <= lastday)
                    {
                        tue[i] = b;
                        b += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (c <= lastday)
                    {
                        wed[i] = c;
                        c += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (d <= lastday)
                    {
                        thu[i] = d;
                        d += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (e <= lastday)
                    {
                        fri[i] = e;
                        e += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (f <= lastday)
                    {
                        sat[i] = f;
                        f += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (g <= lastday)
                    {
                        sun[i] = g;
                        g += 7;
                    }
                }
            }
            //시작: 화요일
            if (first == 3)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (a <= lastday)
                    {
                        tue[i] = a;
                        a += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (b <= lastday)
                    {
                        wed[i] = b;
                        b += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (c <= lastday)
                    {
                        thu[i] = c;
                        c += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (d <= lastday)
                    {
                        fri[i] = d;
                        d += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (e <= lastday)
                    {
                        sat[i] = e;
                        e += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (f <= lastday)
                    {
                        sun[i] = f;
                        f += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (g <= lastday)
                    {
                        mon[i] = g;
                        g += 7;
                    }
                }
            }
            //시작: 수요일
            if (first == 4)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (a <= lastday)
                    {
                        wed[i] = a;
                        a += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (b <= lastday)
                    {
                        thu[i] = b;
                        b += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (c <= lastday)
                    {
                        fri[i] = c;
                        c += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (d <= lastday)
                    {
                        sat[i] = d;
                        d += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (e <= lastday)
                    {
                        sun[i] = e;
                        e += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (f <= lastday)
                    {
                        mon[i] = f;
                        f += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (g <= lastday)
                    {
                        tue[i] = g;
                        g += 7;
                    }
                }
            }
            //시작: 목요일
            if (first == 5)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (a <= lastday)
                    {
                        thu[i] = a;
                        a += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (b <= lastday)
                    {
                        fri[i] = b;
                        b += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (c <= lastday)
                    {
                        sat[i] = c;
                        c += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (d <= lastday)
                    {
                        sun[i] = d;
                        d += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (e <= lastday)
                    {
                        mon[i] = e;
                        e += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (f <= lastday)
                    {
                        tue[i] = f;
                        f += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (g <= lastday)
                    {
                        wed[i] = g;
                        g += 7;
                    }
                }
            }
            //시작: 금요일
            if (first == 6)
            {
                mon[4] = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (a <= lastday)
                    {
                        fri[i] = a;
                        a += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (b <= lastday)
                    {
                        sat[i] = b;
                        b += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (c <= lastday)
                    {
                        sun[i] = c;
                        c += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (d <= lastday)
                    {
                        mon[i] = d;
                    }
                    d += 7;
                }
                for (int i = 0; i < 6; i++)
                {
                    if (e <= lastday)
                    {
                        tue[i] = e;
                        e += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (f <= lastday)
                    {
                        wed[i] = f;
                        f += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (g <= lastday)
                    {
                        thu[i] = g;
                        g += 7;
                    }
                }
            }
            //시작: 토요일
            if (first == 7)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (a <= lastday)
                    {
                        sat[i] = a;
                        a += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (b <= lastday)
                    {
                        sun[i] = b;
                        b += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (c <= lastday)
                    {
                        mon[i] = c;
                        c += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (d <= lastday)
                    {
                        tue[i] = d;
                        d += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (e <= lastday)
                    {
                        wed[i] = e;
                        e += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (f <= lastday)
                    {
                        thu[i] = f;
                        f += 7;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (g <= lastday)
                    {
                        fri[i] = g;
                        g += 7;
                    }
                }
            }
        }

        //불규칙 휴일 -> 월 일로 변환
        private void SetIrregularHolidays()
        {
            for (int i = 0; i < holidaylist.Count; i++)
            {
                if (holidaylist[i].Count != 0)
                {
                    if (holidaylist[i].DayofWeek == "Mon" && holidaylist[i].Name != "Memorial Day")
                    {
                        int a = holidaylist[i].Count;
                        holidaylist[i].Day = mon[a - 1];
                    }
                    else if (holidaylist[i].DayofWeek == "Mon" && holidaylist[i].Name == "Memorial Day")
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (mon[j] != 0)
                            {
                                holidaylist[i].Day = mon[j];
                            }
                        }
                    }
                    else if (holidaylist[i].DayofWeek == "Thu")
                    {
                        int a = holidaylist[i].Count;
                        holidaylist[i].Day = thu[a - 1];
                    }
                }
            }
        }

        private void test()
        {
            textBox7.Text = today.Year.ToString();
            textBox8.Text = today.Month.ToString();
        }
        //달력 셋팅
        private void CalendarSet()
        {
            string office = null;
            Color thiscolor = Color.PaleVioletRed; //현재 사무실
            Color othercolor = Color.LightSkyBlue; //반대 사무실
            panel7.Controls.Clear();
            panel6.Controls.Clear();

            textBox7.Text = today.Year.ToString();
            textBox8.Text = today.Month.ToString();
            #region 요일
            int Week_X = 0;
            int Week_Y = 0;
            int num1 = 1;

            //로그인 사무실 계산
            for (int i = 0; i < Login.UserList.Count; i++)
            {
                if (Login.UserList[i].Id == Login.LoginID)
                {
                    office = Login.UserList[i].Office;
                }
            }

            for (int i = 0; i < 7; i++)
            {
                Label label = new Label();
                label.Size = new Size(97, 30);
                switch (num1)
                {
                    //1: 일요일, 7: 월요일
                    case 1:
                        label.Text = " Sun";
                        break;

                    case 2:
                        label.Text = " Mon";
                        break;

                    case 3:
                        label.Text = " Tue";
                        break;

                    case 4:
                        label.Text = " Wed";
                        break;

                    case 5:
                        label.Text = " Thu";
                        break;

                    case 6:
                        label.Text = " Fri";
                        break;

                    case 7:
                        label.Text = " Sat";
                        break;
                }
                label.Location = new Point(Week_X, Week_Y);
                label.Visible = true;
                label.AutoSize = false;
                label.BorderStyle = System.Windows.Forms.BorderStyle.None;
                label.TextAlign = ContentAlignment.MiddleCenter;
                if (num1 == 7)
                {
                    label.ForeColor = Color.Blue;
                }
                else if (num1 == 1)
                {
                    label.ForeColor = Color.Red;
                }
                panel6.Controls.Add(label);
                Week_X += 97;
                num1++;
            }
            #endregion

            #region 날짜

            //매월 1일 지정
            int first = 1;
            int count = 1;
            switch (firstDay.DayOfWeek.ToString())
            {
                //1: 일요일, 7: 월요일
                case "Sunday":
                    first = 1;
                    break;

                case "Monday":
                    first = 2;
                    break;

                case "Tuesday":
                    first = 3;
                    break;

                case "Wednesday":
                    first = 4;
                    break;

                case "Thursday":
                    first = 5;
                    break;

                case "Friday":
                    first = 6;
                    break;

                case "Saturday":
                    first = 7;
                    break;
            }
            //시작요일을 넘겨주기 위한 변수
            IrregularHolidays(first, lastDay.Day);
            SetIrregularHolidays();

            int Button_X = 0;
            int Button_Y = 0;
            int day = 1;
            int num2 = 1;
            for (int i = 0; i < 42; i++)
            {
                //버튼객체 생성
                btn[i] = new Button();
                btn[i].Name = "btn" + day;
                btn[i].Size = new Size(97, 50);
                btn[i].Font = new Font("Noto Sans KR", 9, FontStyle.Regular);
                btn[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn[i].Text = "";
                btn[i].TextAlign = ContentAlignment.TopLeft;
                btn[i].Location = new Point(Button_X, Button_Y);
                btn[i].Visible = true;
                if (day == first)
                {
                    if (day <= (lastDay.Day + (first - 1)) && count <= lastDay.Day)
                    {
                        btn[i].Text = count.ToString();

                        //휴일 표시
                        for (int j = 0; j < holidaylist.Count; j++)
                        {
                            if (holidaylist[j].Year == lastDay.Year && holidaylist[j].Month.ToString() == textBox8.Text
                                && btn[i].Text == holidaylist[j].Day.ToString())
                            {
                                if (holidaylist[j].Office == "US")
                                {
                                    if (office == "NY" || office == "NJ" || office == "CA")
                                    {
                                        btn[i].BackColor = thiscolor;
                                        btn[i].Text = count.ToString() + "  " + holidaylist[j].Name;
                                    }
                                    else
                                    {
                                        btn[i].BackColor = othercolor;
                                        btn[i].Text = count.ToString() + "  " + holidaylist[j].Name;
                                    }
                                }
                                else if (holidaylist[j].Office == "KOR")
                                {
                                    if (office == "SEOUL")
                                    {
                                        btn[i].BackColor = thiscolor;
                                        btn[i].Text = count.ToString() + "  " + holidaylist[j].Name;
                                    }
                                    else
                                    {
                                        btn[i].BackColor = othercolor;
                                        btn[i].Text = count.ToString() + "  " + holidaylist[j].Name;
                                    }
                                }
                            }
                        }
                        count++;
                        first++;
                    }
                }
                panel7.Controls.Add(btn[i]);
                Button_X += 97;
                num2++;
                if (num2 > 7)
                {
                    Button_Y += 50;
                    Button_X = 0;
                    num2 = 1;
                }
                day++;
            }
            #endregion
        }

        //이전버튼
        private void button10_Click(object sender, EventArgs e)
        {
            int nowyear = today.Year;
            //이전달 마지막 날     
            DateTime last_day = today.AddDays(0 - today.Day);
            //이전달 첫 날
            DateTime first_Day = last_day.AddDays(1 - last_day.Day);

            today = today.AddMonths(-1);

            firstDay = first_Day;
            lastDay = last_day;

            if (today.Year != nowyear)
            {
                holidaylist.Clear();
                Container();
                LunarDateUpdate();
            }

            CalendarSet();
        }



        //다음달조회
        private void button9_Click_1(object sender, EventArgs e)
        {
            int nowyear = today.Year;
            //다음달 첫 날
            DateTime first_Day = lastDay.AddDays(1);

            //다음달 마지막 날
            DateTime last_day = first_Day.AddMonths(1).AddDays(-1);
            today = today.AddMonths(+1);

            firstDay = first_Day;
            lastDay = last_day;

            if (today.Year != nowyear)
            {
                holidaylist.Clear();
                Container();
                LunarDateUpdate();
            }
            CalendarSet();
        }
    }
}
