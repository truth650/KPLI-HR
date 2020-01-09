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
    //회원탈퇴 창
    public partial class DeleteMem : Form
    {
        public static int num; // 몇번째 회원이었는지 담을 변수

        public DeleteMem()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int Index = 0;   //로그인 된 유저의 인덱스 순서
            int ErrorType = 0; // 1. 아이디가 없을경우 2. 아이디는 맞지만 비밀번호가 틀린 경우 3. 로그인 성공

            for (int i = 0; i < Login.UserList.Count; i++) //아이디개수만큼 반복
            {
                if (textBox1.Text == Login.UserList[i].Id)   //아이디가 맞을경우
                {
                    Index = i;
                    ErrorType = 1;
                    break;
                }
                else
                {
                    ErrorType = 2;
                }
            }
            if(ErrorType == 1)
            {
                //textBox2.Text = Login.UserList[Index].Name;
                //textBox3.Text = Login.UserList[Index].Age.ToString();
                //textBox4.Text = Login.UserList[Index].Department;
                //textBox5.Text = Login.UserList[Index].Position;
                //textBox6.Text = Login.UserList[Index].Level.ToString();
                //num = Index;
            }
            else
            {
                MessageBox.Show("가입되지 않은 회원정보입니다.");
            }
        }

        //비밀번호 입력창
        private void Button2_Click(object sender, EventArgs e)
        {
            DeleteMem2 form5 = new DeleteMem2();

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            form5.Show();     
        }
    }
}
