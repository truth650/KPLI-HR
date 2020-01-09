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
    public partial class Correct : Form
    {
        public Correct()
        {
            InitializeComponent();
        }

        //사용자 정보 업로드
        private void Form7_Load(object sender, EventArgs e)
        {
            //textBox2.Text = Login.UserList[UserList.SelectedNum].Position; //직급

            //if(Login.UserList[UserList.SelectedNum].Level == 1) //권한
            //{
            //    textBox4.Text = "일반사용자";
            //}
            //else if (Login.UserList[UserList.SelectedNum].Level == 2)
            //{
            //    textBox4.Text = "관리자";
            //}
            //else if (Login.UserList[UserList.SelectedNum].Level == 3)
            //{
            //    textBox4.Text = "총관리자";
            //    comboBox2.Text = "변경불가";
            //}

        }

        //사용자 비밀번호 초기화
        private void Button1_Click(object sender, EventArgs e)
        {
            //if(textBox1.Text == Login.UserList[Login.LoginIndex].Pw)
            //{
            //    string message = "비밀번호를 초기화하시겟습니까?";

            //    if (MessageBox.Show(message, "경고", MessageBoxButtons.YesNo) != DialogResult.Yes)
            //    {
            //        MessageBox.Show("취소햇습니다.", "경고");
            //    }
            //    else
            //    {
            //        Login.UserList[UserList.SelectedNum].Pw = "1111";
            //        MessageBox.Show("비밀번호가 초기화 되었습니다. 비밀번호: 1111", "완료메세지");
            //        textBox1.Clear();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("비밀번호를 다시 입력해주십시오", "비밀번호 불일치");
            //}
        }

        //직급 변경
        private void Button2_Click(object sender, EventArgs e)
        {
            //if (textBox2.Text != comboBox1.Text)
            //{
            //    string message = "직급을 변경하시겟습니까?";

            //    if (MessageBox.Show(message, "경고", MessageBoxButtons.YesNo) != DialogResult.Yes)
            //    {
            //        MessageBox.Show("취소햇습니다.", "경고");
            //    }
            //    else
            //    {
            //        Login.UserList[UserList.SelectedNum].Position = comboBox1.Text;
            //        MessageBox.Show("직급이 변경되었습니다. "+ textBox2.Text + " -> " + comboBox1.Text, "완료메세지");
            //        textBox2.Text = comboBox1.Text;
            //        comboBox1.Text = "선택";
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("동일한 직급으로 변경하실 수 없습니다.");
            //}
        }

        //관리권한 변경
        private void Button3_Click(object sender, EventArgs e)
        {
            //if (textBox4.Text != comboBox2.Text)
            //{
            //    string message = "권한을 변경하시겟습니까?";

            //    if (MessageBox.Show(message, "경고", MessageBoxButtons.YesNo) != DialogResult.Yes)
            //    {
            //        MessageBox.Show("취소햇습니다.", "경고");
            //    }
            //    else
            //    {
            //        if (Login.UserList[UserList.SelectedNum].Level == 3)
            //        {
            //            MessageBox.Show("총관리자는 변경이 불가능합니다.");            
            //        }
            //        else if (comboBox2.Text == "관리자")
            //        {
            //            if(Login.UserList[Login.LoginIndex].Level == 3)
            //            {
            //                Login.UserList[UserList.SelectedNum].Level = 2;
            //            }
            //            else
            //            {
            //                MessageBox.Show("관리자 권한은 총관리자만 부여할 수 있습니다.");
            //            }
            //        }
            //        else if (comboBox2.Text == "일반사용자")
            //        {
            //            Login.UserList[UserList.SelectedNum].Level = 1;
            //        }
            //    }
            //    if (Login.UserList[UserList.SelectedNum].Level != 3)
            //    {
            //        MessageBox.Show("권한이 변경되었습니다. " + textBox4.Text + " -> " + comboBox2.Text, "완료메세지");
            //        textBox4.Text = comboBox2.Text;
            //    }
            //    comboBox2.Text = "선택";
            //}
            //else
            //{
            //    MessageBox.Show("동일한 권한으로 변경하실 수 없습니다.");
            //}
        }

        //변경창 닫을 때
        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserList form6 = new UserList();
            form6.Show();
        }
    }
}
