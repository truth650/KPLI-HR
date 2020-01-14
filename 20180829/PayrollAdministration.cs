using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20180829
{
    public partial class PayrollAdministration : Form
    {
        string id = null;
        string date = null;

        public PayrollAdministration()
        {
            InitializeComponent();
        }

        private void PayrollAdministration_Load(object sender, EventArgs e)
        {
            SetParollList();
        }

        private void SetParollList()
        {
            listView1.Clear();
            listView1.Columns.Add("Date", 110);
            listView1.Columns.Add("ID", 70);
            listView1.Columns.Add("Requested by", 100);
            listView1.Columns.Add("Total", 60);
            listView1.Columns.Add("Approval", 80); //승인여부

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            for (int i = 0; i < Login.ExpenseList.Count; i++)
            {
                string[] arr = new string[5];
                arr[0] = Login.ExpenseList[i].Date.ToString("yyyy-MM-dd HH:mm:ss");
                arr[1] = Login.ExpenseList[i].ID;
                arr[2] = Login.ExpenseList[i].Name;
                arr[3] = Login.ExpenseList[i].Total.ToString();
                arr[4] = Login.ExpenseList[i].Approval;

                ListViewItem item = new ListViewItem(arr);
                item.UseItemStyleForSubItems = false;
                //추가
                listView1.Items.Add(item);
            }
        }

        // 리스트 클릭시 영수증 상세정보 출력
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

            if (listView1.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                ListViewItem lvItem = items[0];

                for (int i = 0; i < Login.ExpenseList.Count; i++)
                {
                    if (lvItem.SubItems[0].Text == Login.ExpenseList[i].Date.ToString("yyyy-MM-dd HH:mm:ss") &&
                        lvItem.SubItems[1].Text == Login.ExpenseList[i].ID)
                    {
                        textBox1.Text = Login.ExpenseList[i].Date.ToString("yyyy-MM-dd HH:mm");
                        textBox2.Text = Login.ExpenseList[i].ID;
                        textBox3.Text = Login.ExpenseList[i].Name;
                        textBox4.Text = Login.ExpenseList[i].AE.ToString();
                        textBox5.Text = Login.ExpenseList[i].ME.ToString();
                        textBox6.Text = Login.ExpenseList[i].OS.ToString();
                        textBox7.Text = Login.ExpenseList[i].Gift.ToString();
                        textBox8.Text = Login.ExpenseList[i].OE.ToString();
                        textBox9.Text = Login.ExpenseList[i].Advertisment.ToString();
                        textBox10.Text = Login.ExpenseList[i].ETC.ToString();
                        textBox11.Text = Login.ExpenseList[i].Total.ToString();
                        textBox12.Text = Login.ExpenseList[i].Contents;
                        textBox13.Text = Login.ExpenseList[i].Filename;

                        id = Login.ExpenseList[i].ID;
                        date = Login.ExpenseList[i].Date.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }

            }
        }

        //다운로드 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < Login.ExpenseList.Count; i++)
            {
                if(Login.ExpenseList[i].ID == id && Login.ExpenseList[i].Date.ToString("yyyy-MM-dd HH:mm:ss") == date)
                {
                    //파일담기
                    byte[] file = Login.ExpenseList[i].Image;

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = Login.ExpenseList[i].Filename;
                    saveFileDialog.DefaultExt = Login.ExpenseList[i].Extension;
                    
                    saveFileDialog.Title = "저장경로 지정하세요";
                    saveFileDialog.OverwritePrompt = true;
                    saveFileDialog.Filter = "모든 파일 (*.*) | *.*";

                    try
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, file);
                            MessageBox.Show("Download Complete");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Download Fail");
                    }

                }
            }
        }

        //영수증 결제승인
        private void button2_Click(object sender, EventArgs e)
        {
            //다이얼로그 박스
            DialogResult res = MessageBox.Show("영수증을 승인하시겠습니까?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                //영수증 상태변경
                for (int i = 0; i < Login.ExpenseList.Count; i++)
                {
                    if (Login.ExpenseList[i].ID == id && Login.ExpenseList[i].Date.ToString("yyyy-MM-dd HH:mm:ss") == date)
                    {
                        WbDB.Singleton.Open();
                        WbDB.Singleton.Expense_U(Login.ExpenseList[i].ID,Login.ExpenseList[i].Date, "승인");
                    }
                }
                Login.ExpenseList.Clear();
                WbDB.Singleton.Open();
                WbDB.Singleton.LoadExpense(Login.ExpenseList);
                SetParollList();           

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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //상단바
    }
}
