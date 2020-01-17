using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20180829
{
    public partial class B_board : Form
    {
        //상단바
        bool TagMove;
        int MValX, MValY;
        public static List<Board> board = new List<Board>();
        static Label[] label = new Label[5];
        static Panel[] PanelPage = new Panel[100];
        static Panel[] PanelLine = new Panel[100];
        public static int NoticeIDX = 0;
        Button[] button = new Button[5];
        int X = 0;
        int Y = 0;


        public B_board()
        {
            InitializeComponent();
        }

        private void B_board_Load(object sender, EventArgs e)
        {
            SetBoardList();
        }

        //내 정보
        private void button8_Click(object sender, EventArgs e)
        {
            MyInfo my_form = new MyInfo();
            my_form.ShowDialog();
        }

        //상단바
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
            Environment.Exit(0);
        }
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Black;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Black;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }
        //상단바


        //이벤트
        //메인
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m_form = new Main();
            m_form.ShowDialog();
            this.Close();
        }
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.Image = Properties.Resources.home_32px;
            button2.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //일정관리
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Schedule sch_form = new Schedule();
            sch_form.ShowDialog();
            this.Close();
        }
        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button5.Image = Properties.Resources.schedule_32px;
            button5.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //급여관리
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payroll p_form = new Payroll();
            p_form.ShowDialog();
            this.Close();
        }
        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button6.Image = Properties.Resources.check_32px;
            button6.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //관리자모드
        private void button3_Click(object sender, EventArgs e)
        {
            if (Login.UserList[Login.LoginIndex].Authority == 1)
            {
                MessageBox.Show("관리자 권한이 없습니다.");
            }
            else
            {
                this.Hide();
                Administrator a_form = new Administrator();
                a_form.ShowDialog();
                this.Close();
            }
        }
        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.Image = Properties.Resources.administrator_32px;
            button3.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            form1.Visible = true; //로그인창 보이기
            Login.IsLogin = false; //로그아웃 상태로 변경
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Write write = new Write();
            write.ShowDialog();
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.Font = new Font("Noto Sans KR Medium", 14, FontStyle.Underline);
        }
        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.Font = new Font("Noto Sans KR Medium", 14, FontStyle.Bold);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Font = new Font("Noto Sans KR Medium", 14, FontStyle.Underline);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font("Noto Sans KR Medium", 14, FontStyle.Bold);
        }

        public void SetBoardList()
        {
            int Category_X = 0;
            int Category_Y = 0;
            int num1 = 1;

            //카테고리 셋팅
            for (int i = 0; i < 5; i++)
            {
                Label label = new Label();
                switch (num1)
                {
                    case 1:
                        label.Text = " Number";
                        label.Size = new Size(60, 40);
                        break;

                    case 2:
                        label.Text = " Category";
                        label.Size = new Size(100, 40);
                        break;

                    case 3:
                        label.Text = " Title";
                        label.Size = new Size(290, 40);
                        break;

                    case 4:
                        label.Text = "Writer";
                        label.Size = new Size(100, 40);
                        break;

                    case 5:
                        label.Text = "Date";
                        label.Size = new Size(150, 40);
                        break;
                }
                label.Location = new Point(Category_X, Category_Y);
                label.Visible = true;
                label.AutoSize = false;
                label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                label.TextAlign = ContentAlignment.MiddleCenter;

                panel6.Controls.Add(label);
                Category_X += label.Size.Width;
                num1++;
            }

            int num = 1;
            int pagenum = 0;
            int Panel_Y = 0;

            //페이지 계산
            if((Login.BoardList.Count % 10 ) == 0)
            {
                pagenum = Login.BoardList.Count / 10;
            }
            else if ((Login.BoardList.Count % 10) != 0)
            {
                pagenum = (Login.BoardList.Count / 10) +1;
            }

            int pagebutton_x = 0;
            //페이지 버튼 제작
            for(int i = 0; i < pagenum; i++)
            {
                Button[] b = new Button[100];
                b[i] = new Button();
                b[i].Name = (i + 1).ToString();
                b[i].Text = (i + 1).ToString();
                b[i].Size = new Size(30, 20);
                b[i].Location = new Point(pagebutton_x, 0);
                b[i].Visible = true;
                b[i].AutoSize = false;
                b[i].TextAlign = ContentAlignment.MiddleCenter;
                b[i].Click += new EventHandler(b_Click);

                panel8.Controls.Add(b[i]);
                pagebutton_x += 30;
                num1++;
            }


            //게시글 셋팅
            for(int i = 0; i < 10; i++)
            {
                Panel[] panel = new Panel[200];

                panel[i] = new Panel(); 
                panel[i].Name = Login.BoardList[i].Idx.ToString();
                panel[i].Location = new Point(0, Panel_Y);
                panel[i].Size = new Size(700, 50);

                int Button_X = 0;
                int Button_Y = 0;
                int count = 0;

                for (int j = 0; j < 5; j++)
                {                    
                    int width = 60;
                    int height = 30;
                    //버튼객체 생성
                    button[j] = new Button();
                    if(count == 0)
                    {
                        Button_X += 0;
                        button[j].Text = Login.BoardList[i].Idx.ToString();
                        button[j].Size = new Size(60, 50);
                        button[j].Enabled = false;
                    }
                    if (count == 1)
                    {
                        Button_X += 60;
                        button[j].Text = Login.BoardList[i].Category;
                        button[j].Size = new Size(100, 50);
                        button[j].Enabled = false;
                    }
                    if (count == 2)
                    {
                        Button_X += 100;
                        button[j].Text = Login.BoardList[i].Title;
                        button[j].Size = new Size(290, 50);
                        button[j].Enabled = true;
                    }
                    if (count == 3)
                    {
                        Button_X += 290;
                        button[j].Text = Login.BoardList[i].Id;
                        button[j].Size = new Size(100, 50);
                        button[j].Enabled = false;
                    }
                    if (count == 4)
                    {
                        Button_X += 100;
                        button[j].Text = Login.BoardList[i].Time.ToString("yyyy-MM-dd HH:mm:ss");
                        button[j].Size = new Size(150, 50);
                        button[j].Enabled = false;

                    }
                    button[j].Font = new Font("Noto Sans KR", 9, FontStyle.Regular);
                    button[j].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button[j].TextAlign = ContentAlignment.MiddleCenter;
                    button[j].Location = new Point(Button_X, Button_Y);
                    button[j].Visible = true;
                    panel[i].Controls.Add(button[j]);
                    button[j].Click += new EventHandler(button_Click);
                    count++;
                }

                panel7.Controls.Add(panel[i]);
                Panel_Y += 50;
            }
        }

        //페이지 번호 선택시
        private void b_Click(object sender, EventArgs e)
        {
            try
            {
                Control ctl = sender as Control;
                if (ctl != null)
                {
                    int num = int.Parse(ctl.Text);
                    panel7.Controls.Clear();
                    //게시글 셋팅
                    int Panel_Y = 0;
                    for (int i = ((num * 10)-10); i < Login.BoardList.Count; i++)
                    {
                        Panel[] panel = new Panel[200];

                        panel[i] = new Panel();
                        panel[i].Name = Login.BoardList[i].Idx.ToString();
                        panel[i].Location = new Point(0, Panel_Y);
                        panel[i].Size = new Size(700, 50);

                        int Button_X = 0;
                        int Button_Y = 0;
                        int count = 0;

                        for (int j = 0; j < 5; j++)
                        {
                            int width = 60;
                            int height = 30;
                            //버튼객체 생성
                            button[j] = new Button();
                            if (count == 0)
                            {
                                Button_X += 0;
                                button[j].Text = Login.BoardList[i].Idx.ToString();
                                button[j].Size = new Size(60, 50);
                                button[j].Enabled = false;
                            }
                            if (count == 1)
                            {
                                Button_X += 60;
                                button[j].Text = Login.BoardList[i].Category;
                                button[j].Size = new Size(100, 50);
                                button[j].Enabled = false;
                            }
                            if (count == 2)
                            {
                                Button_X += 100;
                                button[j].Text = Login.BoardList[i].Title;
                                button[j].Size = new Size(290, 50);
                                button[j].Enabled = true;
                            }
                            if (count == 3)
                            {
                                Button_X += 290;
                                button[j].Text = Login.BoardList[i].Id;
                                button[j].Size = new Size(100, 50);
                                button[j].Enabled = false;
                            }
                            if (count == 4)
                            {
                                Button_X += 100;
                                button[j].Text = Login.BoardList[i].Time.ToString("yyyy-MM-dd HH:mm:ss");
                                button[j].Size = new Size(150, 50);
                                button[j].Enabled = false;
                            }
                            button[j].Font = new Font("Noto Sans KR", 9, FontStyle.Regular);
                            button[j].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                            button[j].TextAlign = ContentAlignment.MiddleCenter;
                            button[j].Location = new Point(Button_X, Button_Y);
                            button[j].Visible = true;
                            panel[i].Controls.Add(button[j]);
                            button[j].Click += new EventHandler(button_Click);
                            count++;
                        }

                        panel7.Controls.Add(panel[i]);
                        Panel_Y += 50;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("게시글을 불러오는데 오류가 발생했습니다.");
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                Control ctl = sender as Control;
                if (ctl != null)
                {
                    NoticeIDX = int.Parse(ctl.Parent.Name);
                    OpenNotice opennotice = new OpenNotice(this);
                    opennotice.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("실패했습니다.");
            }
        }
    }
}
