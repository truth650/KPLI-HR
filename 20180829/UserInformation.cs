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

    }
}
