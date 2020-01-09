using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _20180829
{
    class WbDB
    {
        #region 싱글톤
        public static WbDB Singleton { get; private set; }

        static WbDB()
        {
            Singleton = new WbDB();
        }

        private WbDB() { }
        #endregion


        SqlConnection conn = new SqlConnection();

        public void Open()
        {
            if (conn.State == ConnectionState.Open)
                throw new Exception("이미 연결된 상태입니다.");
            conn.ConnectionString = @"Server=67.231.26.149;database=
                                   kapli;uid=kapli;pwd=tjd1gh2dud3!;";


            conn.Open();    //  데이터베이스 연결

        }

        public void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

        }

    



        #region 회원가입기능
        public void AddMember(User user)
        {
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");



            //=====================================================
            string comtext = "insert into member values (@ID,@PW,@F_Name,@L_Name,@Year,@Month,@Day,@Coun_Phone,@Phone,@Addr_1,@Addr_2,@Addr_City" +
               ",@Addr_State,@Addr_ZipCode,@Gender,@Department,@Office,@Join_Date,@Position,@SSN,@Authority,@Question,@Answer,@Bank,@Acc_Num,@Rou_Num)";
            SqlCommand command = new SqlCommand(comtext, conn);

            //=====================================================





            //=====================================================
            SqlParameter param_id = new SqlParameter("@ID", user.Id);
            command.Parameters.Add(param_id);

            SqlParameter param_pw = new SqlParameter("@PW", user.Pw);
            command.Parameters.Add(param_pw);

            SqlParameter param_f_name = new SqlParameter("@F_Name", user.F_Name);
            command.Parameters.Add(param_f_name);

            SqlParameter param_l_name = new SqlParameter("@L_Name", user.L_NAME);
            command.Parameters.Add(param_l_name);

            SqlParameter param_year = new SqlParameter("@Year", user.Year);
            param_year.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_year);

            SqlParameter param_month = new SqlParameter("@Month", user.Month);
            param_month.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_month);

            SqlParameter param_day = new SqlParameter("@Day", user.Day);
            param_day.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_day);

            var param_coun_phone = new SqlParameter("@Coun_Phone", user.Coun_Phone);
            command.Parameters.Add(param_coun_phone);

            SqlParameter param_phone = new SqlParameter("@Phone", user.Phone);
            param_phone.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_phone);



            SqlParameter param_addr1 = new SqlParameter("@Addr_1", user.Addr1);
            command.Parameters.Add(param_addr1);

            SqlParameter param_addr2 = new SqlParameter("@Addr_2", user.Addr2);
            command.Parameters.Add(param_addr2);

            SqlParameter param_addr_city = new SqlParameter("@Addr_City", user.Addr_City);
            command.Parameters.Add(param_addr_city);

            SqlParameter param_addr_state = new SqlParameter("@Addr_State", user.Addr_State);
            command.Parameters.Add(param_addr_state);

            SqlParameter param_addr_zip = new SqlParameter("@Addr_ZipCode", user.Addr_Zip);
            param_addr_zip.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_addr_zip);


            SqlParameter param_gender = new SqlParameter("@Gender", user.Gender);
            command.Parameters.Add(param_gender);

            SqlParameter param_department = new SqlParameter("@Department", user.Department);
            command.Parameters.Add(param_department);

            SqlParameter param_office = new SqlParameter("@Office", user.Office);
            command.Parameters.Add(param_office);

            SqlParameter param_join = new SqlParameter("@Join_Date", user.Join_Date);
            command.Parameters.Add(param_join);

            SqlParameter param_position = new SqlParameter("@Position", user.Position);
            command.Parameters.Add(param_position);

            SqlParameter param_ssn = new SqlParameter("@SSN", user.Ssn);
            param_ssn.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_ssn);

            SqlParameter param_authority = new SqlParameter("@Authority", user.Authority);
            param_authority.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_authority);

            SqlParameter param_question = new SqlParameter("@Question", user.Question);
            command.Parameters.Add(param_question);

            SqlParameter param_answer = new SqlParameter("@Answer", user.Answer);
            command.Parameters.Add(param_answer);

            SqlParameter param_bank = new SqlParameter("@Bank", user.Bank);
            command.Parameters.Add(param_bank);

            SqlParameter param_acc_num = new SqlParameter("@Acc_Num", user.Account_Num);
            param_acc_num.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_acc_num);


            SqlParameter param_rou_num = new SqlParameter("@Rou_Num", user.Routing_Num);
            param_rou_num.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_rou_num);


            //=====================================================
            if (command.ExecuteNonQuery() != 1)
                throw new Exception("추가 실패");
        }

        #endregion


        #region 회원 정보 초기 로드
        public List<User> Member(List<User> userlist)
        {
            string comtext = "select * from Member";
            SqlCommand command = new SqlCommand(comtext, conn);


            SqlDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                userlist.Add(new User(reader["ID"].ToString(), reader["PW"].ToString(), reader["F_Name"].ToString(), reader["L_Name"].ToString(),
                int.Parse(reader["Year"].ToString()), int.Parse(reader["Month"].ToString()), int.Parse(reader["Day"].ToString()), reader["Coun_Phone"].ToString(),
                int.Parse(reader["Phone"].ToString()), reader["Addr_1"].ToString(), reader["Addr_2"].ToString(), reader["Addr_City"].ToString(),
                reader["Addr_State"].ToString(), int.Parse(reader["Addr_ZipCode"].ToString()), reader["Gender"].ToString(), reader["Department"].ToString(),
                reader["Office"].ToString(), Convert.ToDateTime(reader["Join_Date"]), reader["Position"].ToString(), int.Parse(reader["SSN"].ToString()),
                int.Parse(reader["Authority"].ToString()), reader["Question"].ToString(), reader["Answer"].ToString(), reader["Bank"].ToString(),
                int.Parse(reader["Acc_Num"].ToString()), int.Parse(reader["Rou_Num"].ToString())));
            }

            reader.Close();
            command.Dispose();
            conn.Close();

            return userlist;
        }

        #endregion



        #region 게시판 기능
        public void Notice(Board board)
        {
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");



            //=====================================================
            string comtext = "insert into Notice values (@Category,@Id,@Title,@Contents,@Contents_Info,@File_Name,@File_Binary,@Time)";
            SqlCommand command = new SqlCommand(comtext, conn);


            //=====================================================

            SqlParameter param_category = new SqlParameter("@Category", board.Category);
            command.Parameters.Add(param_category);

            SqlParameter param_id = new SqlParameter("@Id", board.Id);
            command.Parameters.Add(param_id);

            SqlParameter param_title = new SqlParameter("@Title", board.Title);
            command.Parameters.Add(param_title);

            SqlParameter param_contents = new SqlParameter("@Contents", board.Contents);
            command.Parameters.Add(param_contents);

            SqlParameter param_contents_info = new SqlParameter("@Contents_Info", board.Contents_Info);
            command.Parameters.Add(param_contents_info);


            SqlParameter param_File_name = new SqlParameter("@File_Name", board.File_Name);
            command.Parameters.Add(param_File_name);

            SqlParameter param_File_binary = new SqlParameter("@File_Binary", board.File_Binary);
            param_File_binary.SqlDbType = SqlDbType.Binary;
            command.Parameters.Add(param_File_binary);


            SqlParameter param_Time = new SqlParameter("@Time", board.Time);
            command.Parameters.Add(param_Time);

            //SqlParameter param_Read_Num = new SqlParameter("@Read_Num", board.Read_Num);
            //param_Read_Num.SqlDbType = SqlDbType.Int;
            //command.Parameters.Add(param_Read_Num);


            //=====================================================
            if (command.ExecuteNonQuery() != 1)
                throw new Exception("추가 실패");



        }
    }
}
#endregion