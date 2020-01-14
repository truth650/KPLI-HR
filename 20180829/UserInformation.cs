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
    public partial class UserInformation : Form
    {
        string id = null;

        public UserInformation()
        {
            InitializeComponent();
        }

        private void UserInformation_Load(object sender, EventArgs e)
        {
            SetUserList();
        }

        private void SetUserList()
        {
            listView1.Clear();
            Login.UserList.Clear();
            WbDB.Singleton.Open();
            WbDB.Singleton.Member(Login.UserList);
            listView1.Columns.Add("Name", 120);
            listView1.Columns.Add("ID", 70);
            listView1.Columns.Add("Birth", 100);
            listView1.Columns.Add("Office", 60);
            listView1.Columns.Add("Department", 90);
            listView1.Columns.Add("Position", 80);

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            //리스트뷰에 사용자 휴가정보 추가
            for (int i = 0; i < Login.UserList.Count; i++)
            {
                string[] arr = new string[6];
                arr[0] = Login.UserList[i].F_Name + " "+ Login.UserList[i].L_NAME;
                arr[1] = Login.UserList[i].Id;
                arr[2] = Login.UserList[i].Year + "-" + Login.UserList[i].Month + "-" + Login.UserList[i].Day;
                arr[3] = Login.UserList[i].Office;
                arr[4] = Login.UserList[i].Department;
                arr[5] = Login.UserList[i].Position;


                ListViewItem item = new ListViewItem(arr);
                item.UseItemStyleForSubItems = false;
                //추가
                listView1.Items.Add(item);
            }
        }

        //리스트뷰 클릭
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox17.Clear();
            textBox18.Clear();

            if (listView1.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                ListViewItem lvItem = items[0];

                for (int i = 0; i < Login.UserList.Count; i++)
                {
                    if (lvItem.SubItems[1].Text == Login.UserList[i].Id) 
                    {
                        textBox1.Text = Login.UserList[i].Id;
                        textBox2.Text = Login.UserList[i].Pw;
                        textBox3.Text = Login.UserList[i].F_Name + " " + Login.UserList[i].L_NAME;
                        textBox4.Text = Login.UserList[i].Year.ToString() + "-" + Login.UserList[i].Month.ToString() + "-" + Login.UserList[i].Day.ToString();
                        textBox5.Text = Login.UserList[i].Phone.ToString();
                        textBox6.Text = Login.UserList[i].Addr1 + " " + Login.UserList[i].Addr2;
                        textBox7.Text = Login.UserList[i].Addr_Zip.ToString();
                        textBox8.Text = Login.UserList[i].Gender;
                        textBox9.Text = Login.UserList[i].Office;
                        textBox10.Text = Login.UserList[i].Department;
                        textBox11.Text = Login.UserList[i].Position;
                        textBox12.Text = Login.UserList[i].Join_Date.ToString("yyyy-mm-dd HH:mm:ss");
                        textBox13.Text = Login.UserList[i].Ssn.ToString();
                        textBox14.Text = Login.UserList[i].Bank;
                        textBox15.Text = Login.UserList[i].Routing_Num.ToString();
                        textBox16.Text = Login.UserList[i].Account_Num.ToString();
                        textBox17.Text = Login.UserList[i].Question;
                        textBox18.Text = Login.UserList[i].Answer;
                        if(Login.UserList[i].Authority == 1)
                        {
                            comboBox1.Text = "Employee";
                        }
                        if (Login.UserList[i].Authority == 2)
                        {
                            comboBox1.Text = "Accounting Manager";
                        }
                        if (Login.UserList[i].Authority == 3)
                        {
                            comboBox1.Text = "HR Manager";
                        }
                        if (Login.UserList[i].Authority == 4)
                        {
                            comboBox1.Text = "Administrator";
                        }

                        id = Login.UserList[i].Id;
                    }
                }

            }
        }

        //권한 변경
        private void button1_Click(object sender, EventArgs e)
        {
            int authority = 0;

            if (comboBox1.Text == "Employee")
            {
                authority = 1;
            }
            if (comboBox1.Text == "Accounting Manager")
            {
                authority = 2;
            }
            if (comboBox1.Text == "HR Manager")
            {
                authority = 3;
            }
            if (comboBox1.Text == "Administrator")
            {
                authority = 4;
            }

            try 
            {
                WbDB.Singleton.Open();
                WbDB.Singleton.Authority_U(id, authority);
                MessageBox.Show("보안권한을 " + comboBox1.Text + "로 변경했습니다.");
                SetUserList();
            }
            catch
            {
                MessageBox.Show("실패했습니다.");
            }

        }
    }
}
