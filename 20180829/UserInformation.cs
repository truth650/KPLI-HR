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
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox13.Clear();
            textBox23.Clear();
            textBox25.Clear();
            textBox16.Clear();
            textBox24.Clear();
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
                        textBox6.Text = Login.UserList[i].Addr1 + " " + Login.UserList[i].Addr2 + Login.UserList[i].Addr_City;
                        textBox7.Text = Login.UserList[i].Addr_Zip.ToString();
                        textBox8.Text = Login.UserList[i].Gender;
                        textBox20.Text = Login.UserList[i].Office;
                        textBox22.Text = Login.UserList[i].Department;
                        textBox24.Text = Login.UserList[i].Position;
                        textBox25.Text = Login.UserList[i].Join_Date.ToString("yyyy-mm-dd HH:mm:ss");
                        textBox13.Text = Login.UserList[i].Ssn.ToString();
                        textBox23.Text = Login.UserList[i].Bank;
                        textBox21.Text = Login.UserList[i].Routing_Num.ToString();
                        textBox19.Text = Login.UserList[i].Account_Num.ToString();
                        textBox17.Text = Login.UserList[i].Question;
                        textBox18.Text = Login.UserList[i].Answer;
                        if(Login.UserList[i].Authority == 1)
                        {
                            comboBox2.Text = "Employee";
                        }
                        if (Login.UserList[i].Authority == 2)
                        {
                            comboBox2.Text = "Accounting Manager";
                        }
                        if (Login.UserList[i].Authority == 3)
                        {
                            comboBox2.Text = "HR Manager";
                        }
                        if (Login.UserList[i].Authority == 4)
                        {
                            comboBox2.Text = "Administrator";
                        }

                        id = Login.UserList[i].Id;
                    }
                }

            }
        }

        //권한 변경
        private void button1_Click(object sender, EventArgs e)
        {
            int authority = 1;

            if (comboBox2.Text == "Employee")
            {
                authority = 1;
            }
            if (comboBox2.Text == "Accounting Manager")
            {
                authority = 2;
            }
            if (comboBox2.Text == "HR Manager")
            {
                authority = 3;
            }
            if (comboBox2.Text == "Administrator")
            {
                authority = 4;
            }

            try 
            {
                WbDB.Singleton.Open();
                WbDB.Singleton.Authority_U(id, authority);
                MessageBox.Show("보안권한을 " + comboBox2.Text + "로 변경했습니다.");
                SetUserList();
            }
            catch
            {
                MessageBox.Show("실패했습니다.");
            }

        }

        //회원삭제
        private void button3_Click(object sender, EventArgs e)
        {
            //다이얼로그 박스
            DialogResult res = MessageBox.Show(textBox3.Text + " 유저를 삭제하시겠습니까.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                for (int i = 0; i < Login.UserList.Count; i++)
                {
                    if (Login.UserList[i].Id == id)
                    {
                        WbDB.Singleton.Open();
                        WbDB.Singleton.DeleteMem(Login.UserList[i].Id);

                        WbDB.Singleton.Open();
                        WbDB.Singleton.DeleteVacation(Login.UserList[i].Id);
                        SetUserList();
                    }
                }
            }
            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("You have clicked Cancel Button");
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.White;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }
        //상단바

        //이벤트
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }
        //이벤트
    }
}
