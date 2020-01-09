﻿using System;
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
    public partial class Approval : Form
    {
        VacationAdministration va;
        DateTime start;
        DateTime end;
        string id;
        string type;
        bool state;

        int result; //빼야할 휴가

        public Approval()
        {
            InitializeComponent();
        }

        public Approval(VacationAdministration _va)
        {
            InitializeComponent();
            va = _va;
        }



        private void Approval_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
            SetData();
        }

        //상세정보 셋팅
        private void SetData()
        {
            for (int i = 0; i < Login.RequestVList.Count; i++)
            {
                if (Login.RequestVList[i].RequestDate.ToString("yyyy-MM-dd HH:mm:ss") == VacationAdministration.RequestDate &&
                    Login.RequestVList[i].Name == VacationAdministration.RequestName && Login.RequestVList[i].Approval ==
                    VacationAdministration.State)
                {
                    id = Login.RequestVList[i].ID;
                    textBox1.Text = Login.RequestVList[i].RequestDate.ToString("yyyy-MM-dd HH:mm");
                    textBox2.Text = Login.RequestVList[i].Name;
                    textBox3.Text = Login.RequestVList[i].Type;
                    textBox4.Text = Login.RequestVList[i].StartVacation.ToString("yyyy-MM-dd HH");
                    textBox5.Text = Login.RequestVList[i].EndVacation.ToString("yyyy-MM-dd HH");
                    textBox6.Text = Login.RequestVList[i].Destination;
                    textBox7.Text = Login.RequestVList[i].Contact;
                    textBox8.Text = Login.RequestVList[i].Agent;

                    start = Login.RequestVList[i].StartVacation;
                    end = Login.RequestVList[i].EndVacation;
                    type = Login.RequestVList[i].Type;
                    break;
                }
            }
        }

        //휴가 승인
        private void button1_Click(object sender, EventArgs e)
        {
            string name = VacationAdministration.RequestName;
            //다이얼로그 박스
            DialogResult res = MessageBox.Show("휴가를 승인하시겠습니까?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                Calculator();
                for(int i = 0; i < Login.VacationList.Count; i++)
                {
                    if(Login.VacationList[i].ID == id)
                    {
                        if(textBox3.Text == "SickDay")
                        {
                            //휴가연산
                            Login.VacationList[i].SickDay -= result;
                        }
                        else if(textBox3.Text == "Vacation")
                        {
                            Login.VacationList[i].YearVacation -= result;
                        }
                        //휴가상태 변경
                        for (int j = 0; j < Login.RequestVList.Count; j++)
                        {
                            if (Login.RequestVList[j].ID == id && Login.RequestVList[j].RequestDate.ToString("yyyy-MM-dd HH:mm:ss") == 
                                VacationAdministration.RequestDate)
                            {
                                Login.RequestVList[j].Approval = true;
                            }
                        }
                    }
                }
                va.SetVacationList();
                va.SetRequestList();
                this.Close();

            }
            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("You have clicked Cancel Button");
            }
        }

        private void Calculator()
        {
            int a = 0; //시작날짜시간
            int b = 0; //중간날짜시간
            int c = 0; //마지막날짜 시간
            //최종
            result = 0;

            //하루이하 사용
            if(start.Day == end.Day)
            {
                result = end.Hour - start.Hour;
            }
            //하루이상 사용
            else
            {               
                //시작일 계산
                if(start.Hour == 14)
                {
                    a = (18 - start.Hour);
                }
                else
                {
                    a = (17 - start.Hour);
                }   
                
                //중간일 계산
                if(end.Day - start.Day >= 2)
                {
                    b = ((end.Day - start.Day) - 1) * 8;
                }
                result = a + b;

                //마지막일 계산
                if (end.Hour == 14)
                {
                    c = 4;
                }
                else
                {
                    c = 8;
                }
                result += c;
            }
        }
    }

}