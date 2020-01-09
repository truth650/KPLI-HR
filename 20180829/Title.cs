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
    public partial class Title : Form
    {
        public static List<Board> boards = new List<Board>();
        DateTime dateTime = DateTime.Now;
        string filePath;
        
        string fileName;
        string fileFullName;
       
       
        byte[] FileByte;

        public Title()
        {
            InitializeComponent();
        }

        private void Title_Load(object sender, EventArgs e)
        {
            
            boards.Add(new Board("notice", "samjasin", "abc", "abc", "a", "abc", FileByte, dateTime));

        }


        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            richTextBox1.SelectionFont = fd.Font;
            //if(fd.ShowDialog()==DialogResult.OK)
            //{
            //    richTextBox1.Font = fd.Font;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            richTextBox1.SelectionColor = cd.Color;
        }

    

        private void button3_Click(object sender, EventArgs e)
        {
            
        string rtf = richTextBox1.Rtf;
            string sql = string.Empty;

            boards[0].Category = comboBox1.Text;
            boards[0].Title = textBox1.Text;
            boards[0].File_Name = fileName;
            boards[0].File_Binary = FileByte;
            boards[0].Time = dateTime;
            boards[0].Contents = richTextBox1.Text;
            boards[0].Contents_Info = rtf;
           
            

            WbDB.Singleton.Open();
            WbDB.Singleton.Notice(boards[0]);
            WbDB.Singleton.Close();


            this.Close();
            

        }

        public void selectfile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "파일 오픈";
            //ofd.FileName = "test";
            ofd.Filter = " 텍스트 파일 (*.txt, *.rtf) | *.txt; *.rtf; | 모든 파일 (*.*) | *.*";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                //File명과 확장자를 가지고 온다.
                 fileName = ofd.SafeFileName;
                //File경로와 File명을 모두 가지고 온다.
                 fileFullName = ofd.FileName;
                //File경로만 가지고 온다.
                filePath = fileFullName.Replace(fileName, "");

                //출력 예제용 로직
                //label1.Text = "File Name  : " + fileName;
                //label2.Text = "Full Name  : " + fileFullName;
                //label3.Text = "File Path  : " + filePath;
                ////File경로 + 파일명 리턴
                //return fileFullName;
            }
            //취소버튼 클릭시 또는 ESC키로 파일창을 종료 했을경우
            else if (dr == DialogResult.Cancel)
            {
                ofd.Dispose();
            }

            
            //return "";

        }


        private void button5_Click(object sender, EventArgs e)
        {

            selectfile();
            
                
        }


        public byte[] File_IO(string path)
        {
           

           // road = fileFullName;
           FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            int length = Convert.ToInt32(stream.Length);
            BinaryReader br = new BinaryReader(stream);
            byte[] buff = br.ReadBytes(length);
            stream.Close();
            return buff;






           // BinaryReader reader = new BinaryReader(stream);

           //file = reader.ReadBytes((int)stream.Length);
           // reader.Close();
           // stream.Close();
            //return file;

        }

        private void button6_Click(object sender, EventArgs e)
        {

            FileByte = File_IO(fileFullName);

            

            //MessageBox.Show(road);
        }
    }
}
