using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180829
{
    public class User
    {
        private string id;
        private string pw;
        private string f_name;
        private string l_name;
        private int year;
        private int month;
        private int day;
        private string coun_phone;
        private string phone;
        private string addr1;
        private string addr2;
        private string addr_city;
        private string addr_state;
        private int addr_zip;
        private string gender;
        private string department;
        private string office;
        private DateTime join_date;
        private string position;
        private int ssn;
        private int authority; //Employee 1, Accounting Manager 2, HR Manager 3, Administrator 4
        private string question;
        private string answer;
        private string bank;
        private string account_num;
        private string routing_num;



        public User(string id, string pw, string f_name, string l_name, int year, int month, int day, string coun_phone, string phone,
            string addr1, string addr2, string addr_city, string addr_state, int addr_zip, string gender,
            string department, string office, DateTime join_date, string position, int ssn, int authority, string question, string answer,
            string bank, string account_num, string routing_num)
        {
            this.id = id;
            this.pw = pw;
            this.f_name = f_name;
            this.l_name = l_name;
            this.year = year;
            this.month = month;
            this.day = day;
            this.coun_phone = coun_phone;
            this.phone = phone;
            this.addr1 = addr1;
            this.addr2 = addr2;
            this.addr_city = addr_city;
            this.addr_state = addr_state;
            this.addr_zip = addr_zip;
            this.gender = gender;
            this.department = department;
            this.office = office;
            this.join_date = join_date;
            this.position = position;
            this.ssn = ssn;
            this.authority = authority;
            this.question = question;
            this.answer = answer;
            this.bank = bank;
            this.account_num = account_num;
            this.routing_num = routing_num;

        }

        public string Id { get { return id; } set { id = value; } }
        public string Pw { get { return pw; } set { pw = value; } }
        public string F_Name { get { return f_name; } set { f_name = value; } }
        public string L_NAME { get { return l_name; } set { l_name = value; } }
        public int Year { get { return year; } set { year = value; } }
        public int Month { get { return month; } set { month = value; } }
        public int Day { get { return day; } set { day = value; } }
        public string Coun_Phone { get { return coun_phone; } set { coun_phone = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Addr1 { get { return addr1; } set { addr1 = value; } }
        public string Addr2 { get { return addr2; } set { addr2 = value; } }
        public string Addr_City { get { return addr_city; } set { addr_city = value; } }
        public string Addr_State { get { return addr_state; } set { addr_state = value; } }
        public int Addr_Zip { get { return addr_zip; } set { addr_zip = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string Department { get { return department; } set { department = value; } }
        public string Office { get { return office; } set { office = value; } }
        public DateTime Join_Date { get { return join_date; } set { join_date = value; } }
        public string Position { get { return position; } set { position = value; } }
        public int Ssn { get { return ssn; } set { ssn = value; } }
        public int Authority { get { return authority; } set { authority = value; } }
        public string Question { get { return question; } set { question = value; } }
        public string Answer { get { return answer; } set { answer = value; } }
        public string Bank { get { return bank; } set { bank = value; } }
        public string Account_Num { get { return account_num; } set { account_num = value; } }
        public string Routing_Num { get { return routing_num; } set { routing_num = value; } }

    }
}
