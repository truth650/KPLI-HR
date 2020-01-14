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
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");


            string comtext = "select * from member";
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
            string comtext = "insert into notice values (@Category,@Id,@Title,@Contents,@Contents_Info,@File_Name,@File_Binary,@Time)";
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

        public List<Board> Write(List<Board> boardlist)
        {
            string comtext = "select * from notice";
            SqlCommand command = new SqlCommand(comtext, conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                boardlist.Add(new Board(int.Parse(reader["Idx"].ToString()), (reader["Category"].ToString()), (reader["Id"].ToString()),
                    (reader["Title"].ToString()), (reader["Contents"].ToString()), (reader["Contents_Info"].ToString()),
                    (reader["File_Name"].ToString()), (byte[])reader["File_Binary"],
                    (Convert.ToDateTime(reader["Time"].ToString()))));

            }

            reader.Close();
            command.Dispose();
            conn.Close();

            return boardlist;
        }
        #endregion


        #region 메모

        public void Memo_S(Memo memo)
        {
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");

            //=====================================================
            string comtext = "insert into memo values (@Id,@Date,@Contents)";
            SqlCommand command = new SqlCommand(comtext, conn);
            //=====================================================

           
            SqlParameter param_id = new SqlParameter("@Id", memo.ID);
            command.Parameters.Add(param_id);

            SqlParameter param_Time = new SqlParameter("@Date",memo.Date);
            command.Parameters.Add(param_Time);

            SqlParameter param_contents = new SqlParameter("@Contents", memo.Content);
            command.Parameters.Add(param_contents);         
            //=====================================================
            if (command.ExecuteNonQuery() != 1)
                throw new Exception("추가 실패");
        }

        public List<Memo> Memo_L(List<Memo> memolist)
        {
                
            string comtext = "select * from memo";
            SqlCommand command = new SqlCommand(comtext, conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                memolist.Add(new Memo((reader["Id"].ToString()), (Convert.ToDateTime(reader["Date"].ToString())),
                    (reader["Contents"].ToString())));                   
                  
            }

            reader.Close();
            command.Dispose();
            conn.Close();
            return memolist;
        }
        #endregion


        #region 휴가 부여
        public void Vacation_S(Vacation vacation)
        {
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");

            //=====================================================
            string comtext = "insert into vacation values (@Id,@Name,@Sick_Day,@Year_Vacation,@Annual)";
            SqlCommand command = new SqlCommand(comtext, conn);


            //=====================================================


            SqlParameter param_id = new SqlParameter("@Id", vacation.ID);
            command.Parameters.Add(param_id);

            SqlParameter param_Name = new SqlParameter("@Name", vacation.Name);
            command.Parameters.Add(param_Name);


            SqlParameter param_Sick = new SqlParameter("@Sick_Day", vacation.SickDay);
            param_Sick.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_Sick);
            
            SqlParameter param_Year = new SqlParameter("@Year_Vacation", vacation.YearVacation);
            param_Year.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_Year);


            SqlParameter param_acc_Annual = new SqlParameter("@Annual", vacation.Annual);
            param_acc_Annual.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(param_acc_Annual);
            
            //=====================================================
            if (command.ExecuteNonQuery() != 1)
                throw new Exception("추가 실패");



        }


        public List<Vacation> Vacation_L(List<Vacation> vacationlist)
        {
            string comtext = "select * from vacation";
            SqlCommand command = new SqlCommand(comtext, conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                vacationlist.Add(new Vacation((reader["Id"].ToString()), (reader["Name"].ToString()),
                    (int.Parse(reader["Sick_Day"].ToString())), (int.Parse(reader["Year_Vacation"].ToString())),
                    int.Parse((reader["Annual"].ToString()))));          
            }
            reader.Close();
            command.Dispose();
            conn.Close();

            return vacationlist;
        }


        public void Vacation_U(string id, string type, int result)
        {
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");

            else if (type == "SickDay")          
                {
                    string comtext = "update vacation set Sick_Day = @RESULT WHERE id = @Id";
                SqlCommand command = new SqlCommand(comtext, conn);

                    //=====================================================
                    SqlParameter param_id = new SqlParameter("@Id", id);
                    command.Parameters.Add(param_id);
                    SqlParameter param_type = new SqlParameter("@RESULT", result);
                    command.Parameters.Add(param_type);

                    //=====================================================
                    command.ExecuteNonQuery();
                }
                else if(type == "Vacation")
                {
                string comtext = "update vacation set Year_Vacation = @RESULT WHERE id = @Id";
                SqlCommand command = new SqlCommand(comtext, conn);

                //=====================================================
                SqlParameter param_id = new SqlParameter("@Id", id);
                command.Parameters.Add(param_id);
                SqlParameter param_type = new SqlParameter("@RESULT", result);
                command.Parameters.Add(param_type);

                //=====================================================
                command.ExecuteNonQuery();

                command.Dispose();
                conn.Close();
            }
        }

        //연차더해주기
        public void Annual_U(string id, int result)
        {
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");

            string comtext = "update vacation set Annual = @RESULT WHERE id = @Id";
            SqlCommand command = new SqlCommand(comtext, conn);

            //=====================================================
            SqlParameter param_id = new SqlParameter("@Id", id);
            command.Parameters.Add(param_id);
            SqlParameter param_type = new SqlParameter("@RESULT", result);
            command.Parameters.Add(param_type);

            //=====================================================
            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
            
        }




        #endregion


        #region 휴가 요청 기능

        public void Requse_S(List<RequestV> request)
        {
            //=====================================================
            string comtext = "insert into vacation_Request values (@Id,@Name,@Request_Date,@Type,@Vacation_S,@Vacation_E,@Destination,@Contact,@Agent,@Approval)";
            SqlCommand command = new SqlCommand(comtext, conn);


            //=====================================================


            SqlParameter param_id = new SqlParameter("@Id", request[0].ID);
            command.Parameters.Add(param_id);


            SqlParameter param_Name = new SqlParameter("@Name", request[0].Name);
            command.Parameters.Add(param_Name);


            SqlParameter param_Request = new SqlParameter("@Request_Date", request[0].RequestDate);
            command.Parameters.Add(param_Request);

            SqlParameter param_Type = new SqlParameter("@Type", request[0].Type);
            command.Parameters.Add(param_Type);


            SqlParameter param_start = new SqlParameter("@Vacation_S", request[0].StartVacation);
            command.Parameters.Add(param_start);

            SqlParameter param_end = new SqlParameter("@Vacation_E", request[0].EndVacation);
            command.Parameters.Add(param_end);


            SqlParameter param_des = new SqlParameter("@Destination", request[0].Destination);
            command.Parameters.Add(param_des);



            SqlParameter param_contact = new SqlParameter("@Contact", request[0].Contact);
            command.Parameters.Add(param_contact);



            SqlParameter param_agent = new SqlParameter("@Agent", request[0].Agent);
            command.Parameters.Add(param_agent);



            SqlParameter param_ap = new SqlParameter("@Approval", request[0].Approval);
            param_ap.SqlDbType = SqlDbType.Bit;
            command.Parameters.Add(param_ap);


            //=====================================================
            if (command.ExecuteNonQuery() != 1)
                throw new Exception("추가 실패");

            command.Dispose();
            conn.Close();
        }

        public List<RequestV> Requse_L(List<RequestV> request)
        {

            string comtext = "select * from vacation_Request";
            SqlCommand command = new SqlCommand(comtext, conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                request.Add(new RequestV(reader["Id"].ToString(),reader["Name"].ToString(), Convert.ToDateTime((reader["Request_Date"]).ToString()),
                    (reader["Type"].ToString()), (Convert.ToDateTime(reader["Vacation_S"].ToString())), Convert.ToDateTime(reader["Vacation_E"].ToString()),
                    (reader["Destination"].ToString()), (reader["Contact"].ToString()), (reader["Agent"].ToString()),(Convert.ToBoolean((reader["Approval"].ToString())))));             
            }

            reader.Close();
            command.Dispose();
            conn.Close();

            return request;
        }

        public void Requse_U(string id, DateTime date, bool result)
        {
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");

           
            string comtext = "update vacation_Request set Approval = @RESULT WHERE id = @Id and Request_Date = @Date";
            SqlCommand command = new SqlCommand(comtext, conn);

                //=====================================================
            SqlParameter param_id = new SqlParameter("@Id", id);
            command.Parameters.Add(param_id);
            SqlParameter param_date = new SqlParameter("@Date", date);
            command.Parameters.Add(param_date);
            SqlParameter param_type = new SqlParameter("@RESULT", result);
            param_type.SqlDbType = SqlDbType.Bit;
            command.Parameters.Add(param_type);

                //=====================================================
            command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }
        #endregion


        #region 영수증 
        //영수증 신청
        public void InsertExpense(Expense expense)
        {
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");

            //=====================================================
            string comtext = "insert into expense values (@Date, @ID, @Name, @AE, @ME, @OS, @Gift, @OE, @Advertisement, " +
                             "@ETC, @Total, @Contents, @IMG, @FileName, @Extension, @Approval)";
            SqlCommand command = new SqlCommand(comtext, conn);
            //=====================================================
            SqlParameter param_date = new SqlParameter("@Date", expense.Date);
            command.Parameters.Add(param_date);

            SqlParameter param_id = new SqlParameter("@ID", expense.ID);
            command.Parameters.Add(param_id);

            SqlParameter param_name = new SqlParameter("@Name", expense.Name);
            command.Parameters.Add(param_name);

            SqlParameter param_ae = new SqlParameter("@AE", expense.AE);
            command.Parameters.Add(param_ae);

            SqlParameter param_me = new SqlParameter("@ME", expense.ME);
            command.Parameters.Add(param_me);

            SqlParameter param_os = new SqlParameter("@OS", expense.OS);
            command.Parameters.Add(param_os);

            SqlParameter param_gift = new SqlParameter("@Gift", expense.Gift);
            command.Parameters.Add(param_gift);

            SqlParameter param_oe = new SqlParameter("@OE", expense.OE);
            command.Parameters.Add(param_oe);

            SqlParameter param_advertisment = new SqlParameter("@Advertisement", expense.Advertisment);
            command.Parameters.Add(param_advertisment);

            SqlParameter param_etc = new SqlParameter("@ETC", expense.ETC);
            command.Parameters.Add(param_etc);

            SqlParameter param_total = new SqlParameter("@Total", expense.Total);
            command.Parameters.Add(param_total);

            SqlParameter param_contents = new SqlParameter("@Contents", expense.Contents);
            command.Parameters.Add(param_contents);

            SqlParameter param_img = new SqlParameter("@IMG", expense.Image);
            command.Parameters.Add(param_img);

            SqlParameter param_filename = new SqlParameter("@FileName", expense.Filename);
            command.Parameters.Add(param_filename);

            SqlParameter param_extension = new SqlParameter("@Extension", expense.Extension);
            command.Parameters.Add(param_extension);

            SqlParameter param_approval = new SqlParameter("@Approval", expense.Approval);
            command.Parameters.Add(param_approval);
            //=====================================================

            if (command.ExecuteNonQuery() != 1)
                throw new Exception("추가 실패");
            else
            {
                MessageBox.Show("등록완료");
            }

            command.Dispose();
            conn.Close();
        }

        //영수증 정보 가져오기
        public List<Expense> LoadExpense(List<Expense> expenselist)
        {
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");

            //=====================================================
            string comtext = "select * from expense";
            SqlCommand command = new SqlCommand(comtext, conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                expenselist.Add(new Expense(Convert.ToDateTime((reader["Date"]).ToString()), (reader["Id"]).ToString(), (reader["Name"]).ToString(),
                float.Parse((reader["Ae"]).ToString()), float.Parse((reader["Me"]).ToString()), float.Parse((reader["Os"]).ToString()),
                float.Parse((reader["Gift"]).ToString()), float.Parse((reader["Oe"]).ToString()), float.Parse((reader["Advertisement"]).ToString()),
                float.Parse((reader["Etc"]).ToString()), float.Parse((reader["Total"]).ToString()), (reader["Contents"]).ToString(),
                (byte[])reader["Image"], (reader["Filename"]).ToString(),(reader["Extension"]).ToString(), (reader["Approval"]).ToString()));
            }
            reader.Close();
            command.Dispose();
            conn.Close();

            return expenselist;

        }

        //영수증 승인
        public void Expense_U(string id, DateTime date, string approval)
        {
            if (conn.State == ConnectionState.Closed)
                throw new Exception("DB 미연결상태");


            string comtext = "update Expense set Approval = @Approval WHERE id = @Id and Date = @Date";
            SqlCommand command = new SqlCommand(comtext, conn);

            //=====================================================
            SqlParameter param_id = new SqlParameter("@Id", id);
            command.Parameters.Add(param_id);
            SqlParameter param_date = new SqlParameter("@Date", date);
            command.Parameters.Add(param_date);
            SqlParameter param_approval = new SqlParameter("@Approval", approval);
            command.Parameters.Add(param_approval);

            //=====================================================
            command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }
        #endregion
    }
}








