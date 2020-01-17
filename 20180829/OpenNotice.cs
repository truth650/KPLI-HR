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
    public partial class OpenNotice : Form
    {
        B_board board = null;
        int idx = 0;

        public OpenNotice()
        {
            InitializeComponent();
        }

        public OpenNotice(B_board _board)
        {
            InitializeComponent();
            board = _board;
        }

        private void OpenNotice_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label5;
            SetNotice();
        }

        private void SetNotice()
        {
            for (int i = 0; i < Login.BoardList.Count; i++)
            {
                if (B_board.NoticeIDX == Login.BoardList[i].Idx)
                {
                    textBox1.Text = Login.BoardList[i].Title;
                    textBox2.Text = Login.BoardList[i].Id;
                    textBox3.Text = Login.BoardList[i].Time.ToString("yyyy-mm-dd HH:mm:ss");
                    textBox4.Text = Login.BoardList[i].File_Name;
                    textBox5.Text = Login.BoardList[i].Category;

                    idx = Login.BoardList[i].Idx;
                    richTextBox1.SelectedRtf = Login.BoardList[i].Contents_Info;
                    richTextBox1.Text = Login.BoardList[i].Contents;
                }
            }
        }

        //다운로드 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Login.BoardList.Count; i++)
            {
                if (B_board.NoticeIDX == Login.BoardList[i].Idx)
                {
                    //파일담기
                    byte[] file = Login.BoardList[i].File_Binary;

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = Login.BoardList[i].File_Name;
                    saveFileDialog.DefaultExt = Login.BoardList[i].Extension;

                    saveFileDialog.Title = "Please specify a storage path.";
                    saveFileDialog.OverwritePrompt = true;
                    saveFileDialog.Filter = "All files (*.*) | *.*";

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
            pictureBox4.BackColor = Color.FromArgb(228, 249, 224);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(228, 249, 224);
        }



        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }
        //상단바

        //게시글삭제
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == Login.LoginID)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete the post?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    for (int i = 0; i < Login.BoardList.Count; i++)
                    {
                        if (Login.BoardList[i].Id == Login.LoginID)
                        {
                            WbDB.Singleton.Open();
                            WbDB.Singleton.DeleteNotice(Login.BoardList[i].Id, idx);
                        }
                    }
                    MessageBox.Show("Delete Complete");
                    Login.BoardList.Clear();
                    WbDB.Singleton.Open();
                    WbDB.Singleton.Board_L(Login.BoardList);
                    board.SetBoardList();

                }
                if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("You have clicked Cancel Button");
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to delete.");
            }            
        }

    }
}
