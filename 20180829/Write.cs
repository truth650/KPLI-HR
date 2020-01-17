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
    public partial class Write : Form
    {
        B_board board = null;
        public static List<Board> boards = new List<Board>();
        string filename = null;
        byte[] file = null;
        string extension = null;
        string UserID = null;


        public Write()
        {
            InitializeComponent();
        }

        public Write(B_board _Board)
        {
            InitializeComponent();
            board = _Board;
        }

        private void Write_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            byte[] FileByte = null;
            boards.Add(new Board(0, "notice", "samjasin", "a", "a", "a", "a", FileByte,"a", dateTime));
            comboBox1.Text = "일반";

            //이름찾아오기
            for (int i = 0; i < Login.UserList.Count; i++)
            {
                if (Login.UserList[i].Id == Login.LoginID)
                {
                    UserID = Login.UserList[i].Id;
                }
            }
        }

        //color 다이얼로그
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            richTextBox1.SelectionColor = cd.Color;
        }

        //font 다이얼로그
        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            richTextBox1.SelectionFont = fd.Font;
        }


        //파일열기
        private void button5_Click(object sender, EventArgs e)
        {
            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*) | *.*";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                //파일이름 띄어주기
                filename = Path.GetFileName(ofd.FileName);
                textBox2.Text = filename;
                file = File.ReadAllBytes(ofd.FileName); //파일 바이트 변환 후 보내주기
                extension = Path.GetExtension(ofd.FileName);   //파일 확장자 보내주기
            }
        }

        //게시글 작성
        private void button3_Click(object sender, EventArgs e)
        {            
            //영수증 정보담기
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,
                DateTime.Now.Minute, DateTime.Now.Second);
            string rtf = richTextBox1.Rtf;
            string sql = string.Empty;

            boards[0].Category = comboBox1.Text;
            boards[0].Id = UserID;
            boards[0].Title = textBox1.Text;
            boards[0].Contents = richTextBox1.Text;
            boards[0].Contents_Info = rtf; //글꼴정보

            if (filename == null)
            {
                filename = "";
            }
            boards[0].File_Name = filename;

            if (file == null)
            {
                byte[] b = new byte[100];
                file = b;
            }
            boards[0].File_Binary = file;

            if (extension == null)
            {
                extension = "";
            }
            boards[0].Extension = extension;
            boards[0].Time = dt;



            WbDB.Singleton.Open();
            WbDB.Singleton.Board_Insert(boards[0]);
            WbDB.Singleton.Close();

            WbDB.Singleton.Open();
            Login.BoardList.Clear();
            WbDB.Singleton.Board_L(Login.BoardList);
            board.SetBoardList();

            this.Close();
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
        //게시판
    }
}
