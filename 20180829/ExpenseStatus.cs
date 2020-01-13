using System;
using System.Collections;
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
    public partial class ExpenseStatus : Form
    {
        string name;

        public ExpenseStatus()
        {
            InitializeComponent();
        }

        private void ExpenseStatus_Load(object sender, EventArgs e)
        {
            SetExpenseList();
        }

        private void SetExpenseList()
        {
            Login.ExpenseList.Clear();
            WbDB.Singleton.Open();
            WbDB.Singleton.LoadExpense(Login.ExpenseList);
            WbDB.Singleton.Close();

            dataGridView1.Rows.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Data";
            dataGridView1.Columns[1].Name = "ID";
            dataGridView1.Columns[2].Name = "Name";
            dataGridView1.Columns[3].Name = "Total";
            dataGridView1.Columns[4].Name = "Contents";
            dataGridView1.Columns[5].Name = "Approval"; //승인여부

            //신청자 이름조회
            for (int i = 0; i < Login.UserList.Count; i++)
            {
                if (Login.UserList[i].Id == Login.LoginID)
                {
                    name = Login.UserList[i].F_Name + " " + Login.UserList[i].L_NAME;
                }
            }

            for (int i = 0; i < Login.ExpenseList.Count; i++)
            {
                if (Login.LoginID == Login.ExpenseList[i].ID)
                {
                    ArrayList row = new ArrayList();
                    row.Add(Login.ExpenseList[i].Date.ToString("yyyy-MM-dd HH:mm"));
                    row.Add(Login.ExpenseList[i].ID);
                    row.Add(Login.ExpenseList[i].Name);
                    row.Add(Login.ExpenseList[i].Total);
                    row.Add(Login.ExpenseList[i].Contents);
                    row.Add(Login.ExpenseList[i].Approval);
                    dataGridView1.Rows.Add(row.ToArray());
                }
            }
        }
    }
}
