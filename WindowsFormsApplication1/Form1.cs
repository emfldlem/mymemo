using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        private string StrSQL = "Data Source=localhost;Database=mymemo;User Id=root;Password=apmsetup; CHARSET=utf8"; //데이터베이스 연결 문자열
        private string Data_Num;        //하루일정표 리스트 선택 번호
        public int todayscore;          //오늘의 점수 번호 체크
        

        public Form1()
        {
            InitializeComponent();
            dtpTime.Value = DateTime.Now;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lvList_MySqlClient_View();
            daily_MySqlClient_View();
            todayscore_MySqlClient_View();

        }

        //
        //날짜 바뀔 때 실행 되야 되는 함수 목록, 하루일정표, 일기장, 오늘의 점수 갱신 
        //
        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            lvList_MySqlClient_View();
            daily_MySqlClient_View();
            todayscore_MySqlClient_View();
        }


        //
        //하루일정표 출력
        //
        private void lvList_MySqlClient_View()
        {
            this.lvList.Items.Clear();
            var MConn = new MySqlConnection(StrSQL);    //MySql 연결을 위한 MySqlConnection 객체 생성
            MConn.Open();       //데이터 베이스 open
            var Comm = new MySqlCommand("Select * From today Order By t_time", MConn);        //today 테이블의 데이터를 time 칼럼으로 정렬
            var myRead = Comm.ExecuteReader();  // 쿼리문 실행

            String datTim1 = this.dtpTime.Value.ToString("yyyy-MM-dd");     //현재 날짜
            
           
            while (myRead.Read())
            {
                var strArray = new String[] { myRead["t_time"].ToString(),myRead["t_schedule"].ToString(),myRead["t_no"].ToString()};   
                //strArray string 배열에 myRead 객체를 이용하여 각 각의 데이터를 저장

                var lvt = new ListViewItem(strArray);   //strArray에 저장된 값을 lvt 객체에 저장
                
                if (datTim1 == myRead["t_date"].ToString())  //현재 날짜와 db에 날짜가 일치하면 lvList에 출력
                {
                    this.lvList.Items.Add(lvt);
                }
                    
            }
            myRead.Close();
        }
       

        //
        //하루일정표 입력 버튼
        //
        private void btn_todayschadule_save(object sender, EventArgs e)
        {
            if (this.today_time.Text != "" && this.today_schadule.Text != "")       // 시간, 일정 칸 빈칸 여부 검사
            {
                var Conn = new MySqlConnection(StrSQL);
                Conn.Open();

                string Sql = "insert into today(t_time, t_schedule,t_date) values('";
                Sql += this.today_time.Text + "','" + this.today_schadule.Text + "','" + this.dtpTime.Value.ToString("yyyy-MM-dd") + "')";
                // 입력 받은 시간과 일정을 데이터에 insert

                var Comm = new MySqlCommand(Sql, Conn);
                int i = Comm.ExecuteNonQuery();
                Conn.Close();

                // i는 쿼리 문을 실행 한 후 true 값이면 1, false 값이면 0을 반환
                if (i == 1)
                {
                    MessageBox.Show("정상적으로 데이터가 저장되었습니다.", "알림",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lvList_MySqlClient_View();
                    Control_Clear();
                    
                }
                else
                {
                    MessageBox.Show("정상적으로 데이터가 저장되지 않았습니다.", "에러",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        //
        //입력 후 text 초기화
        //
        private void Control_Clear()
        {
            this.today_time.Clear();
            this.today_schadule.Clear();
            this.txtDaily.Clear();
        }

        //
        //lvList 클릭시 데이터 입력
        //
        private void lvList_Click(object sender, EventArgs e)
        {
            Data_Num = this.lvList.SelectedItems[0].SubItems[2].Text;       //lvList의 몇번째 아이템을 클릭했는지 불러옴
            
            this.today_time.Text = this.lvList.SelectedItems[0].SubItems[0].Text;       
            this.today_schadule.Text = this.lvList.SelectedItems[0].SubItems[1].Text;

           
        }

        //
        //하루 일정표 수정 버튼
        //
        private void btn_todayschadule_modify(object sender, EventArgs e)
        {
            if (this.today_time.Text != "" && this.today_schadule.Text != "")
            {

                var Conn = new MySqlConnection(StrSQL);
                Conn.Open();

                var MySqlAdapter = new MySqlDataAdapter("select * from today", Conn);

                var ds = new DataSet();
                MySqlAdapter.Fill(ds, "dsTable");   //가상의 테이블 ds에 db에서 불러온 데이터를 채움
                var dt = ds.Tables["dsTable"].Select("t_no =" + Convert.ToInt32(this.Data_Num),null, DataViewRowState.CurrentRows); //lvList의 item을 db의 t_no와 비교하여 db를 찾음 
                DataRow drTemp; 
                drTemp = dt[0];
                drTemp["time"] = this.today_time.Text;
                drTemp["schedule"] = this.today_schadule.Text;
                //dateRow 객체에 today의 몇번째 db 인지 대입 후 수정하려는 데이터를 입력.

                var cmdBuild = new MySqlCommandBuilder(MySqlAdapter);
                MySqlAdapter.UpdateCommand = cmdBuild.GetUpdateCommand();
                MySqlAdapter.Update(ds, "dsTable");
                cmdBuild.Dispose();


                MessageBox.Show("정상적으로 데이터가 수정되었습니다.", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lvList_MySqlClient_View();
                Control_Clear();

            }
        }

        //
        //하루일정표 삭제 버튼
        //
        private void btn_todayschadule_delete(object sender, EventArgs e)
        {
            var Conn = new MySqlConnection(StrSQL);
            Conn.Open();

            string Sql = "DELETE FROM today WHERE no =" + this.Data_Num;

            var Comm = new MySqlCommand(Sql, Conn);
            int i = Comm.ExecuteNonQuery();
            Conn.Close();
            if (i == 1)
            {
                MessageBox.Show("정상적으로 데이터가 삭제되었습니다.", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lvList_MySqlClient_View();
                Control_Clear();
            }
            else
            {
                MessageBox.Show("정상적으로 데이터가 삭제되지 않았습니다.", "에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //
        //일기장 불러오기
        //
        private void daily_MySqlClient_View()
        {
            this.txtDaily.Clear();
            var MConn = new MySqlConnection(StrSQL);
            MConn.Open();

            String datTim1 = this.dtpTime.Value.ToString("yyyy-MM-dd");
            var Comm = new MySqlCommand("Select * From daily", MConn);
            var myRead = Comm.ExecuteReader();
            while (myRead.Read())
            {
                string strArray = myRead["d_contents"].ToString();


                if (datTim1 == myRead["d_date"].ToString())
                {
                    this.txtDaily.AppendText(strArray);
                    
                }

            }
            myRead.Close();
        }


        //
        //일기장 저장 버튼
        //
        private void btn_daily_save(object sender, EventArgs e)
        {
            if (this.txtDaily.Text != "")
            {
                var Conn = new MySqlConnection(StrSQL);
                Conn.Open();

                String datTim1 = this.dtpTime.Value.ToString("yyyy-MM-dd");
                string Sql;
                int confirm = 0;        //오늘 날짜의 일기가 있는지 확인하기 위한 변수 일기 있을시 1, 없을시 0;
                int i = 0;              //쿼리가 정상적으로 실행됬는지 여부 확인

                var Comm1 = new MySqlCommand("Select * From daily", Conn);
                var myRead = Comm1.ExecuteReader();
                while (myRead.Read())
                {
                    if (datTim1 == myRead["d_date"].ToString())
                    {
                        confirm = 1;
                        break;
                    }
                }
                myRead.Close();
                
                if (confirm == 1)       //일기가 존재할 시 update문 실행하여 해당 날짜의 일기 내용을 변경
                {
                    Sql = "update daily set d_contents ='" + this.txtDaily.Text + "' where d_date ='" + this.dtpTime.Value.ToString("yyyy-MM-dd") + "'";
                    Comm1 = new MySqlCommand(Sql, Conn);
                    i = Comm1.ExecuteNonQuery();
                }

                else
                {
                        //일기가 존재하지 않을 시 insert문 실행하여 DB 입력
                }
                {
                    Sql = "insert into daily(d_contents, d_date) values('";
                    Sql += this.txtDaily.Text + "','" + this.dtpTime.Value.ToString("yyyy-MM-dd") + "')";
                    Comm1 = new MySqlCommand(Sql, Conn);
                    i = Comm1.ExecuteNonQuery();
                }
                Conn.Close();
                if (i == 1)
                {
                    MessageBox.Show("정상적으로 데이터가 저장되었습니다.", "알림",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("정상적으로 데이터가 저장되지 않았습니다.", "에러",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }
 

        //
        //오늘의 점수 표시
        //
        private void todayscore_MySqlClient_View()
        {

            var MConn = new MySqlConnection(StrSQL);
            MConn.Open();

            String datTim1 = this.dtpTime.Value.ToString("yyyy-MM-dd");
            var Comm = new MySqlCommand("Select * From score", MConn);
            var myRead = Comm.ExecuteReader();
            
            while (myRead.Read())
            {
                if (datTim1 == myRead["s_date"].ToString())     //오늘 날짜 점수 DB 존재 시 몇점인지 todayscore에 입력
                {
                    todayscore = Convert.ToInt32(myRead["s_score"]);
                    break;
                }
                else            //오늘 점수가 없으시 점수 입력하라는 그림 표시
                {
                    todayscore = 0;
                    break;
                }
            }
            myRead.Close();

            if (todayscore == 1)
                this.num1.Checked = true;
            else if (todayscore == 2)
                this.num2.Checked = true;
            else if (todayscore == 3)
                this.num3.Checked = true;
            else if (todayscore == 4)
                this.num4.Checked = true;
            else if (todayscore == 5)
                this.num5.Checked = true;
            else if (todayscore == 6)
                this.num6.Checked = true;
            else if (todayscore == 7)
                this.num7.Checked = true;
            else if (todayscore == 8)
                this.num8.Checked = true;
            else if (todayscore == 9)
                this.num9.Checked = true;
            else if (todayscore == 10)
                this.num10.Checked = true;
            else
            {
                this.lblImg.ImageIndex = 10;
                this.num1.Checked = false; this.num2.Checked = false; this.num3.Checked = false; this.num4.Checked = false; this.num5.Checked = false; this.num6.Checked = false;
                this.num7.Checked = false; this.num8.Checked = false; this.num9.Checked = false; this.num10.Checked = false;
            }
               

            todayscorechanged();

        }

        //
        //점수에 따라 그림 표시
        //
        public void todayscorechanged()
        {
            if (this.num1.Checked == true) { 
                this.lblImg.ImageIndex = 0;
                todayscore = 1;
            }
            else if (this.num2.Checked == true) { 
                this.lblImg.ImageIndex = 1;
                todayscore = 2;
            }
            else if (this.num3.Checked == true)
            {
                this.lblImg.ImageIndex = 2;
                todayscore = 3;
            }
            else if (this.num4.Checked == true)
            {
                this.lblImg.ImageIndex = 3;
                todayscore = 4;
            }
            else if (this.num5.Checked == true)
            {
                this.lblImg.ImageIndex = 4;
                todayscore = 5;
            }
            else if (this.num6.Checked == true)
            {
                this.lblImg.ImageIndex = 5;
                todayscore = 6;
            }
            else if (this.num7.Checked == true)
            {
                this.lblImg.ImageIndex = 6;
                todayscore = 7;
            }
            else if (this.num8.Checked == true)
            {
                this.lblImg.ImageIndex = 7;
                todayscore = 8;
            }
            else if (this.num9.Checked == true)
            {
                this.lblImg.ImageIndex = 8;
                todayscore = 9;
            }
            else if (this.num10.Checked == true)
            {
                this.lblImg.ImageIndex = 9;
                todayscore = 10;
            }
            
        }

        private void btn_todayscore_save(object sender, EventArgs e)
        {
            if (this.num1.Checked == true || this.num2.Checked == true || this.num3.Checked == true || this.num4.Checked == true || this.num5.Checked == true ||
                 this.num6.Checked == true || this.num7.Checked == true || this.num8.Checked == true || this.num9.Checked == true || this.num10.Checked == true)
            {       //1~10점의 버튼중 하나라도 true 일때 
                
                todayscorechanged();
                
                var Conn = new MySqlConnection(StrSQL);
                Conn.Open();
                DateTime datTim2 = this.dtpTime.Value;
                String datTim1 = datTim2.ToString("yyyy-MM-dd");
                string Sql;
                int confirm = 0;
                int i = 0;

                var Comm1 = new MySqlCommand("Select * From score", Conn);
                var myRead = Comm1.ExecuteReader();
                while (myRead.Read())
                {
                    if (datTim1 == myRead["s_date"].ToString())
                    {
                        confirm = 1;
                        break;
                    }
                }
                myRead.Close();

                if (confirm == 1)
                {
                    Sql = "update score set s_score ='" + todayscore + "' where s_date ='" + this.dtpTime.Value.ToString("yyyy-MM-dd") + "'";
                    Comm1 = new MySqlCommand(Sql, Conn);
                    i = Comm1.ExecuteNonQuery();
                }

                else
                {
                    Sql = "insert into score(s_score, s_date) values('";
                    Sql += todayscore + "','" + this.dtpTime.Value.ToString("yyyy-MM-dd") + "')";
                    Comm1 = new MySqlCommand(Sql, Conn);
                    Comm1.ExecuteNonQuery();
                }
                Conn.Close();

            }
            

        }
    }
}
