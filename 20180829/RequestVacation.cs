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
    public partial class RequestVacation : Form
    {
        string name = ""; //신청자 이름
        Schedule sd;
        static int result;
       public static List<RequestV> request = new List<RequestV>();       

        public RequestVacation()
        {
            InitializeComponent();
        }
        public RequestVacation(Schedule _sd)
        {
            InitializeComponent();
            sd = _sd;
        }

        private void RequestVacation_Load_1(object sender, EventArgs e)
        {
            this.ActiveControl = radioButton2;
            textBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            SetRequestList();
        }

        private void SetRequestList()
        {
            listView1.Clear();
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Name", 60);
            listView1.Columns.Add("Type", 60);
            listView1.Columns.Add("Form", 90);
            listView1.Columns.Add("To", 90);
            listView1.Columns.Add("Destination", 60);
            listView1.Columns.Add("Contact Num", 70);
            listView1.Columns.Add("Agent", 50);
            listView1.Columns.Add("Approval", 30); //승인여부


            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            //신청자 이름조회
            for (int i = 0; i < Login.UserList.Count; i++)
            {
                if (Login.UserList[i].Id == Login.LoginID)
                {
                    name = Login.UserList[i].F_Name + " " + Login.UserList[i].L_NAME;
                }
            }

            //리스트뷰에 휴가신청내역 추가
            for (int i = 0; i < Login.RequestVList.Count; i++)
            {
                //리스트뷰 업데이트
                if (Login.LoginID == Login.RequestVList[i].ID)
                {
                    string[] arr = new string[9];                   
                    arr[0] = Login.RequestVList[i].RequestDate.ToString("yyyy-MM-dd HH:mm:ss");
                    arr[1] = name;
                    arr[2] = Login.RequestVList[i].Type;
                    arr[3] = Login.RequestVList[i].StartVacation.ToString("yyyy-MM-dd HH");
                    arr[4] = Login.RequestVList[i].EndVacation.ToString("yyyy-MM-dd HH");
                    arr[5] = Login.RequestVList[i].Destination; 
                    arr[6] = Login.RequestVList[i].Contact;
                    arr[7] = Login.RequestVList[i].Agent;
                    if (Login.RequestVList[i].Approval == false)
                    {
                        arr[8] = "Waiting";
                    }
                    else if (Login.RequestVList[i].Approval == true)
                    {
                        arr[8] = "approve";
                    }
                    ListViewItem item = new ListViewItem(arr);
                    item.UseItemStyleForSubItems = false;
                    //추가
                    listView1.Items.Add(item);
                }
            }
        }

        //휴가신청
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != null && comboBox2.Text != null && textBox2.Text != null && textBox3.Text != null && textBox6.Text != null)
            {
                int hour = 0;
                if (comboBox1.Text == "09:00")
                {
                    hour = 9;
                }
                if (comboBox1.Text == "14:00")
                {
                    hour = 14;
                }
                DateTime start = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day,
                hour, 0, 0);

                if (comboBox2.Text == "14:00")
                {
                    hour = 14;
                }
                if (comboBox2.Text == "18:00")
                {
                    hour = 18;
                }
                DateTime end = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day,
                hour, 0, 0);

                //사용가능한지 여부 체크
                Calculator(start, end);
                for (int i = 0; i < Login.VacationList.Count; i++)
                {
                    if (Login.VacationList[i].ID == Login.LoginID)
                    {
                        if (radioButton1.Checked) //병가
                        {
                            if (Login.VacationList[i].SickDay >= result)
                            {
                                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 
                                    DateTime.Now.Minute, DateTime.Now.Second);
                                request.Clear();
                                request.Add(new RequestV(Login.LoginID, name, dt, "SickDay",
                                start, end, textBox2.Text, textBox3.Text, textBox6.Text, false));

                                WbDB.Singleton.Open();
                                WbDB.Singleton.Requse_S(request);
                                Login.RequestVList.Clear();
                                WbDB.Singleton.Open();
                                WbDB.Singleton.Requse_L(Login.RequestVList);
                                SetRequestList();
                            }
                            else
                            {
                                MessageBox.Show("I don't have enough vacation days.");
                            }

                        }
                        else if (radioButton2.Checked) //연가
                        {
                            if (Login.VacationList[i].YearVacation >= result)
                            {
                                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,
                                    DateTime.Now.Minute, DateTime.Now.Second);
                                request.Clear();
                                request.Add(new RequestV(Login.LoginID, name, dt, "Vacation",
                                start, end, textBox2.Text, textBox3.Text, textBox6.Text, false));

                                WbDB.Singleton.Open();
                                WbDB.Singleton.Requse_S(request);
                                Login.RequestVList.Clear();
                                WbDB.Singleton.Open();
                                WbDB.Singleton.Requse_L(Login.RequestVList);
                                SetRequestList();
                            }
                            else
                            {
                                MessageBox.Show("I don't have enough vacation days.");
                            }
                        }
                                            
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Plese write content");
            }

        }

        private void Calculator(DateTime start, DateTime end)
        {
            int a = 0; //시작날짜시간
            int b = 0; //중간날짜시간
            int c = 0; //마지막날짜 시간
            //최종
            result = 0;

            //하루이하 사용
            if (start.Day == end.Day)
            {
                if (start.Hour == 9 && end.Hour == 18)
                {
                    result = 8;
                }
                if (start.Hour == 9 && end.Hour == 14)
                {
                    result = 4;
                }
                if (start.Hour == 14 && end.Hour == 18)
                {
                    result = 4;
                }
            }
            //하루이상 사용
            else
            {
                //시작일 계산
                if (start.Hour == 14)
                {
                    a = (18 - start.Hour);
                }
                else
                {
                    a = (17 - start.Hour);
                }

                //중간일 계산
                if (end.Day - start.Day >= 2)
                {
                    b = ((end.Day - start.Day) - 1) * 8;
                }
                result = a + b;

                //마지막일 계산
                if (end.Hour == 14)
                {
                    c = 4;
                }
                else
                {
                    c = 8;
                }
                result += c;
            }
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
            WbDB.Singleton.Close();
            this.Close();
        }
        //상단바
    }
}
