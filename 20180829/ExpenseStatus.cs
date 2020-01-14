using System;
using System.Collections;
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
    public partial class ExpenseStatus : Form
    {
        string name;

        public ExpenseStatus()
        {
            InitializeComponent();
        }

        private void ExpenseStatus_Load(object sender, EventArgs e)
        {
            SetExpenseList();
        }

        private void SetExpenseList()
        {
            Login.ExpenseList.Clear();
            WbDB.Singleton.Open();
            WbDB.Singleton.LoadExpense(Login.ExpenseList);
            WbDB.Singleton.Close();

            listView1.Clear();
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("ID", 70);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Total", 70);
            listView1.Columns.Add("Contents", 100);
            listView1.Columns.Add("Approval", 70);

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

            for (int i = 0; i < Login.ExpenseList.Count; i++)
            {
                if (Login.LoginID == Login.ExpenseList[i].ID)
                {
                    string[] arr = new string[6];
                    arr[0] = Login.ExpenseList[i].Date.ToString("yyyy-MM-dd HH:mm:ss");
                    arr[1] = Login.ExpenseList[i].ID;
                    arr[2] = name;
                    arr[3] = Login.ExpenseList[i].Total.ToString();
                    arr[4] = Login.ExpenseList[i].Contents;
                    arr[5] = Login.ExpenseList[i].Approval;

                    ListViewItem item = new ListViewItem(arr);
                    item.UseItemStyleForSubItems = false;
                    //추가
                    listView1.Items.Add(item);
                }
            }
        }
        
        //상단바
        bool TagMove;
        int MValX, MValY;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
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
        //상단바


    }
}
