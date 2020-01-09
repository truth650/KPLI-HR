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
    public partial class DeleteMem2 : Form
    {
        public DeleteMem2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Login.UserList[DeleteMem.num].Pw)
            {
                Login.UserList.RemoveAt(DeleteMem.num);
                MessageBox.Show("정상적으로 탈퇴되었습니다.");

                this.Close();
            }
            else
            {
                MessageBox.Show("비밀번호를 다시 입력해주십시오");
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Button1_Click(sender, e);
            }
        }
    }
}
