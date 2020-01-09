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
    //사용자관리모드

    public partial class UserList : Form
    {
        public static int SelectedNum = 0;

        public UserList()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //PrintUserList();
        }

        public void PrintUserList()
        {
            listView1.Columns.Add("아이디", 72);
            listView1.Columns.Add("이름", 60);
            listView1.Columns.Add("나이", 50);
            listView1.Columns.Add("부서", 100);
            listView1.Columns.Add("직책", 60);
            listView1.Columns.Add("권한", 80);

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;


            for (int i = 0; i < Login.UserList.Count; i++)
            {
                //string[] arr = new string[6];
                //arr[0] = Login.UserList[i].Id;
                //arr[1] = Login.UserList[i].Name;
                //arr[2] = Login.UserList[i].Age.ToString();
                //arr[3] = Login.UserList[i].Department;
                //arr[4] = Login.UserList[i].Position;
                //if (Login.UserList[i].Level == 1)
                //{
                //    arr[5] = "일반사용자";
                //}
                //else if (Login.UserList[i].Level == 2)
                //{
                //    arr[5] = "관리자";
                //}
                //else
                //{
                //    arr[5] = "총관리자";
                //}

                //ListViewItem item = new ListViewItem(arr);

                //listView1.Items.Add(item);
            }
        }

        //계정 삭제
        private void Button1_Click(object sender, EventArgs e)
        {
            //if (Login.UserList[Login.LoginIndex].Level == 3)
            //{
            //    string username = Login.UserList[listView1.FocusedItem.Index].Name;
            //    string userid = Login.UserList[listView1.FocusedItem.Index].Id;

            //    string message = "아이디: " + userid + "  이름: " + username + " 삭제하시겟습니까?";

            //    if (MessageBox.Show(message, "경고", MessageBoxButtons.YesNo) != DialogResult.Yes)
            //    {
            //        MessageBox.Show("취소햇습니다.", "경고");
            //    }
            //    else
            //    {
            //        if(Login.UserList[listView1.FocusedItem.Index].Level != 3)
            //        {
            //            Login.UserList.RemoveAt(listView1.FocusedItem.Index);
            //            MessageBox.Show("삭제햇습니다.", "경고");
            //            listView1.Clear();
            //            PrintUserList();
            //        }
            //        else
            //        {
            //            MessageBox.Show("총관리자는 삭제할 수 없습니다.");
            //        }

            //    }
            //}
            //else
            //{
            //    MessageBox.Show("삭제권한이 없습니다.");
            //}

        }

        //회원정보변경
        private void Button2_Click(object sender, EventArgs e)
        {
            //if (Login.UserList[Login.LoginIndex].Level >= 2 && 
            //    Login.UserList[Login.LoginIndex].Level > Login.UserList[listView1.FocusedItem.Index].Level ||
            //    Login.UserList[Login.LoginIndex] == Login.UserList[listView1.FocusedItem.Index])
            //{
            //    SelectedNum = listView1.FocusedItem.Index;
            //    Correct form7 = new Correct();
            //    form7.Show();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("변경권한이 없습니다.");
            //}
        }
        //public void PrintUserList()
        //{
        //    listView1.Columns.Add("아이디", 72);
        //    listView1.Columns.Add("이름", 60);
        //    listView1.Columns.Add("나이", 50);
        //    listView1.Columns.Add("부서", 100);
        //    listView1.Columns.Add("직책", 60);
        //    listView1.Columns.Add("권한", 80);

        //    listView1.View = View.Details;
        //    listView1.FullRowSelect = true;
        //    listView1.GridLines = true;


        //    for (int i = 0; i < Login.UserList.Count; i++)
        //    {
        //        string[] arr = new string[6];
        //        arr[0] = Login.UserList[i].Id;
        //        arr[1] = Login.UserList[i].Name;
        //        arr[2] = Login.UserList[i].Age.ToString();
        //        arr[3] = Login.UserList[i].Department;
        //        arr[4] = Login.UserList[i].Position;
        //        if (Login.UserList[i].Level == 1)
        //        {
        //            arr[5] = "일반사용자";
        //        }
        //        else if (Login.UserList[i].Level == 2)
        //        {
        //            arr[5] = "관리자";
        //        }
        //        else
        //        {
        //            arr[5] = "총관리자";
        //        }

        //        ListViewItem item = new ListViewItem(arr);

        //        listView1.Items.Add(item);
        //    }
        //}

        //계정 삭제
        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    if (Login.UserList[Login.LoginIndex].Level == 3)
        //    {
        //        string username = Login.UserList[listView1.FocusedItem.Index].Name;
        //        string userid = Login.UserList[listView1.FocusedItem.Index].Id;

        //        string message = "아이디: " + userid + "  이름: " + username + " 삭제하시겟습니까?";

        //        if (MessageBox.Show(message, "경고", MessageBoxButtons.YesNo) != DialogResult.Yes)
        //        {
        //            MessageBox.Show("취소햇습니다.", "경고");
        //        }
        //        else
        //        {
        //            if(Login.UserList[listView1.FocusedItem.Index].Level != 3)
        //            {
        //                Login.UserList.RemoveAt(listView1.FocusedItem.Index);
        //                MessageBox.Show("삭제햇습니다.", "경고");
        //                listView1.Clear();
        //                PrintUserList();
        //            }
        //            else
        //            {
        //                MessageBox.Show("총관리자는 삭제할 수 없습니다.");
        //            }

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("삭제권한이 없습니다.");
        //    }

        //}

        //회원정보변경
        //    private void Button2_Click(object sender, EventArgs e)
        //    {
        //        if (Login.UserList[Login.LoginIndex].Level >= 2 && 
        //            Login.UserList[Login.LoginIndex].Level > Login.UserList[listView1.FocusedItem.Index].Level ||
        //            Login.UserList[Login.LoginIndex] == Login.UserList[listView1.FocusedItem.Index])
        //        {
        //            SelectedNum = listView1.FocusedItem.Index;
        //            Correct form7 = new Correct();
        //            form7.Show();
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("변경권한이 없습니다.");
        //        }
        //    }
        //}
    }
}
