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
    public partial class VacationAdministration : Form
    {
        static public string RequestDate = "";
        static public string RequestName = "";
        static public string[] RequestID = new string[200];
        static public bool State = false;

        public VacationAdministration()
        {
            InitializeComponent();
        }


        private void VacationAdministration_Load(object sender, EventArgs e)
        {
            if (Login.VacationList.Count == 0)
            {
                //8시간당 하루, 4시간은 반차
                Login.VacationList.Add(new Vacation("truth650", "김영종", 20, 40, 0));
                Login.VacationList.Add(new Vacation("samjasin", "성호영", 24, 48, 0));
                Login.VacationList.Add(new Vacation("leechangjae", "이창재", 24, 48, 0));
            }

            if (Login.RequestVList.Count == 0)
            {
                //DateTime rq = new DateTime(2020, 1, 9, 9, 12, 3);
                //DateTime dt1 = new DateTime(2020, 1, 10, 9, 0, 0);
                //DateTime dt2 = new DateTime(2020, 1, 10, 14, 0, 0);
                //DateTime dt3 = new DateTime(2020, 1, 11, 14, 0, 0);
                //DateTime dt4 = new DateTime(2020, 1, 12, 18, 0, 0);

                //임시, 원래는 프로그램 구동시에 DB에서 가져와 리스트에 담아줌 
                //Login.RequestVList.Add(new RequestV("truth650", "김영종", rq, "SickDay", dt1, dt2,
                //    "NewYork", "618-723-1234", "이창재", false));
                //Login.RequestVList.Add(new RequestV("truth650", "김영종", rq.AddHours(1), "Vacation", dt1, dt3,
                //    "NewYork", "618-723-1234", "이창재", false));
                //Login.RequestVList.Add(new RequestV("samjasin", "성호영", rq.AddHours(3), "Vacation", dt3, dt4,
                //    "NewYork", "618-723-1234", "이창재", false));
            }
            SetVacationList();
            SetRequestList();
        }

        #region 휴가정보
        //휴가정보 리스트 띄어주기
        public void SetVacationList()
        {
            listView1.Clear();
            listView1.Columns.Add("ID", 60);
            listView1.Columns.Add("Name", 70);
            listView1.Columns.Add("SickDay", 80);
            listView1.Columns.Add("Vacation", 80);
            listView1.Columns.Add("Annual", 70);

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            //리스트뷰에 사용자 휴가정보 추가
            for (int i = 0; i < Login.VacationList.Count; i++)
            {
                string sickday; 
                string yearvacation; 
                string[] arr = new string[5];
                arr[0] = Login.VacationList[i].ID;
                arr[1] = Login.VacationList[i].Name;
                //병가 계산
                if (Login.VacationList[i].SickDay % 8 == 0)
                {
                    sickday = (Login.VacationList[i].SickDay / 8).ToString() + "일";
                }
                else
                {
                    sickday =  ((Login.VacationList[i].SickDay / 8).ToString()) + "일 " + ((Login.VacationList[i].SickDay % 8).ToString()) + "시간";
                }
                arr[2] = sickday;
                //연가 계산
                if (Login.VacationList[i].YearVacation % 8 == 0)
                {
                    yearvacation = (Login.VacationList[i].YearVacation / 8).ToString() + "일";
                }
                else
                {
                    yearvacation = ((Login.VacationList[i].YearVacation / 8).ToString()) + "일 " + ((Login.VacationList[i].YearVacation % 8).ToString()) + "시간";
                }
                arr[3] = yearvacation;
                //연차(휴가가 더해지는)
                arr[4] = Login.VacationList[i].Annual.ToString();
              
                ListViewItem item = new ListViewItem(arr);
                item.UseItemStyleForSubItems = false;
                //추가
                listView1.Items.Add(item);
            }        
        }

        //휴가정보 리스트 뷰 클릭
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();
            if (listView1.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                ListViewItem lvItem = items[0];
                textBox1.Text = lvItem.SubItems[1].Text;
                for(int i = 0; i < Login.VacationList.Count; i++)
                {
                    if(Login.VacationList[i].Name == textBox1.Text)
                    {
                        if(Login.VacationList[i].SickDay % 8 == 0)
                        {
                            textBox2.Text = (Login.VacationList[i].SickDay / 8).ToString();
                        }
                        else
                        {
                            textBox2.Text = (Login.VacationList[i].SickDay / 8).ToString();
                            textBox5.Text = (Login.VacationList[i].SickDay % 8).ToString();
                        }
                    }                       
                }
                for (int i = 0; i < Login.VacationList.Count; i++)
                {
                    if (Login.VacationList[i].Name == textBox1.Text)
                    {
                        if (Login.VacationList[i].YearVacation % 8 == 0)
                        {
                            textBox4.Text = (Login.VacationList[i].YearVacation / 8).ToString();
                        }
                        else
                        {
                            textBox4.Text = (Login.VacationList[i].YearVacation / 8).ToString();
                            textBox6.Text = (Login.VacationList[i].YearVacation % 8).ToString();
                        }
                    }
                }
                textBox3.Text = lvItem.SubItems[0].Text;
                textBox7.Text = lvItem.SubItems[4].Text;
            }
        }

        //휴가정보 수정
        private void button1_Click(object sender, EventArgs e)
        {
            int sickday = 0;
            int vacation = 0;
            //예외처리
            if (textBox1.Text == "")
            {
                MessageBox.Show("수정할 사용자를 선택해주세요.");
            }
            else
            {
                try
                {
                    if (textBox2.Text != "" && textBox4.Text != "")
                    {
                        for (int i = 0; i < Login.VacationList.Count; i++)
                        {
                            //계산
                            if (textBox5.Text == "")
                            {
                                textBox5.Text = "0";
                            }
                            sickday = (int.Parse(textBox2.Text) * 8) + int.Parse(textBox5.Text);
                            if (textBox6.Text == "")
                            {
                                textBox6.Text = "0";
                            }
                            vacation = (int.Parse(textBox4.Text) * 8) + int.Parse(textBox6.Text);

                            //리스트 수정
                            if (Login.VacationList[i].ID == textBox3.Text)
                            {
                                Login.VacationList[i].SickDay = sickday;
                                Login.VacationList[i].YearVacation = vacation;
                                //DB 수정코드
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("휴가를 확인해주십시오");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("올바르게 입력해주십시오");
                }            
            }
            SetVacationList();
        }
        #endregion

        #region 휴가승인관리
        public void SetRequestList()
        {
            listView2.Clear();
            listView2.Columns.Add("Date", 120);
            listView2.Columns.Add("Name", 60);
            listView2.Columns.Add("Type", 65);
            listView2.Columns.Add("Start", 90);
            listView2.Columns.Add("End", 90);
            listView2.Columns.Add("Approval", 70);

            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;

            //리스트뷰에 휴가신청내역 추가
            for (int i = 0; i < Login.RequestVList.Count; i++)
            {
                //리스트뷰 업데이트
                string[] arr = new string[6];
                arr[0] = Login.RequestVList[i].RequestDate.ToString("yyyy-MM-dd HH:mm:ss");
                arr[1] = Login.RequestVList[i].Name;
                arr[2] = Login.RequestVList[i].Type;
                arr[3] = Login.RequestVList[i].StartVacation.ToString("yyyy-MM-dd HH");
                arr[4] = Login.RequestVList[i].EndVacation.ToString("yyyy-MM-dd HH");
                RequestID[i] = Login.RequestVList[i].ID;
                if (Login.RequestVList[i].Approval == false)
                {
                    arr[5] = "승인대기";
                }
                else if (Login.RequestVList[i].Approval == true)
                {
                    arr[5] = "승인";
                }
                ListViewItem item = new ListViewItem(arr);
                item.UseItemStyleForSubItems = false;
                //추가
                listView2.Items.Add(item);
            }
        }

        //리스트 아이템 클릭
        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView2.SelectedItems;
                ListViewItem lvItem = items[0];
                
                RequestDate = lvItem.SubItems[0].Text;
                RequestName = lvItem.SubItems[1].Text;

                if (lvItem.SubItems[5].Text == "승인대기")
                {
                    State = false;
                }

            }
        }

        //휴가 상세보기 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 1)
            {
                MessageBox.Show("휴가를 선택해주십시오");
            }
            else
            {
                ListView.SelectedListViewItemCollection items = listView2.SelectedItems;
                ListViewItem lvItem = items[0];
                if (lvItem.SubItems[5].Text == "승인대기")
                {
                    Approval approval = new Approval(this);
                    approval.Show();
                }
                else
                {
                    MessageBox.Show("이미 승인되었습니다.");
                }
          
            }
        }
        #endregion


    }
}
