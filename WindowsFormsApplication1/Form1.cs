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
        string stryear = DateTime.Now.Year.ToString();
        private string StrSQL = "Data Source=localhost;Database=mymemo;User Id=root;Password=apmsetup; CHARSET=utf8"; //데이터베이스 연결 문자열
        private string Data_Num;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lvList_MySqlClient_View();
            daily_MySqlClient_View();

        }

        private void lvList_MySqlClient_View()
        {
            this.lvList.Items.Clear();
            var MConn = new MySqlConnection(StrSQL);
            MConn.Open();
            DateTime datTim2 = this.dtpTime.Value;
            String datTim1 = datTim2.ToString("yyyy-MM-dd");
            var Comm = new MySqlCommand("Select * From today Order By time", MConn);
            var myRead = Comm.ExecuteReader();
            while (myRead.Read())
            {
                var strArray = new String[] { myRead["time"].ToString(),
                    myRead["schedule"].ToString(),myRead["no"].ToString()};
          
                var lvt = new ListViewItem(strArray);
                //MessageBox.Show(myRead["date1"].ToString());
                if (datTim1 == myRead["date1"].ToString())
                {
                    this.lvList.Items.Add(lvt);
                }
                    
            }
            myRead.Close();
        }
       

        //
        //하루일정표 입력 버튼
        //
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.today_time.Text != "" && this.today_schaduel.Text != "")
            {
                var Conn = new MySqlConnection(StrSQL);
                Conn.Open();

                string Sql = "insert into today(time, schedule,date1) values('";
                //Sql += this.today_time.Text + "','" + this.today_schaduel.Text + "')";
                //Sql += this.today_time.Text + "','" + this.today_schaduel.Text + "','" + datTim2.ToString() + "')";
                Sql += this.today_time.Text + "','" + this.today_schaduel.Text + "','" + this.dtpTime.Value.ToString("yyyy-MM-dd") + "')";

                var Comm = new MySqlCommand(Sql, Conn);
                int i = Comm.ExecuteNonQuery();
                Conn.Close();
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
            this.today_schaduel.Clear();
            this.txtDaily.Clear();
        }

        //
        //리스트 클릭시 데이터 입력
        //
        private void lvList_Click(object sender, EventArgs e)
        {
            Data_Num = this.lvList.SelectedItems[0].SubItems[2].Text;
            
            this.today_time.Text = this.lvList.SelectedItems[0].SubItems[0].Text;
            this.today_schaduel.Text = this.lvList.SelectedItems[0].SubItems[1].Text;

            //MessageBox.Show(this.lvList.SelectedItems[0].SubItems[2].Text);
        }

        //
        //하루 일정표 수정 버튼
        //
        private void btntoday_Modify_Click(object sender, EventArgs e)
        {
            if (this.today_time.Text != "" && this.today_schaduel.Text != "")
            {

                var Conn = new MySqlConnection(StrSQL);
                Conn.Open();

                var MySqlAdapter = new MySqlDataAdapter("select * from today", Conn);

                var ds = new DataSet();
                MySqlAdapter.Fill(ds, "dsTable");
                var dt = ds.Tables["dsTable"].Select("no =" + Convert.ToInt32(this.Data_Num),null, DataViewRowState.CurrentRows);
                DataRow drTemp;
                drTemp = dt[0];
                drTemp["time"] = this.today_time.Text;
                drTemp["schedule"] = this.today_schaduel.Text;


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
        private void btntoday_Delete_Click(object sender, EventArgs e)
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
            DateTime datTim2 = this.dtpTime.Value;
            String datTim1 = datTim2.ToString("yyyy-MM-dd");
            var Comm = new MySqlCommand("Select * From daily", MConn);
            var myRead = Comm.ExecuteReader();
            while (myRead.Read())
            {
                string strArray = myRead["d_contents"].ToString();

                //var lvt = new ListViewItem(strArray);

                if (datTim1 == myRead["d_date"].ToString())
                {
                    this.txtDaily.AppendText(strArray);
                    // this.lvList.Items.Add(lvt);
                }

            }
            myRead.Close();
        }


        //
        //일기장 저장 버튼
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtDaily.Text != "")
            {
                var Conn = new MySqlConnection(StrSQL);
                Conn.Open();
                DateTime datTim2 = this.dtpTime.Value;
                String datTim1 = datTim2.ToString("yyyy-MM-dd");
                string sql1;
                int confirm = 0;
                int i = 0;

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
                MessageBox.Show("confirm");
                if (confirm == 1)
                {
                    sql1 = "update daily set d_contents ='" + this.txtDaily.Text + "' where d_date ='" + this.dtpTime.Value.ToString("yyyy-MM-dd") + "'";
                    Comm1 = new MySqlCommand(sql1, Conn);
                    i = Comm1.ExecuteNonQuery();
                }

                else
                {
                    sql1 = "insert into daily(d_contents, d_date) values('";
                    sql1 += this.txtDaily.Text + "','" + this.dtpTime.Value.ToString("yyyy-MM-dd") + "')";
                    Comm1 = new MySqlCommand(sql1, Conn);
                    i = Comm1.ExecuteNonQuery();
                }
                Conn.Close();
                if (i == 1)
                {
                    MessageBox.Show("정상적으로 데이터가 저장되었습니다.", "알림",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //lvList_MySqlClient_View();
                    //Control_Clear();
                }
                else
                {
                    MessageBox.Show("정상적으로 데이터가 저장되지 않았습니다.", "에러",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                /*
                if (datTim1 == myRead["d_date"].ToString())
                {
                    sql1 = "update daily set d_contents ='"+ this.txtDaily.Text +"' where d_date ='" + this.dtpTime.Value.ToString("yyyy-MM-dd") + "'";
                    var Comm2 = new MySqlCommand(sql1, Conn);
                    int j = Comm2.ExecuteNonQuery();
                }

                else
                {
                    string Sql = "insert into daily(d_contents, d_date) values('";
                    Sql += this.txtDaily.Text + "','" + this.dtpTime.Value.ToString("yyyy-MM-dd") + "')";
                    var Comm = new MySqlCommand(Sql, Conn);
                    int i = Comm.ExecuteNonQuery();
                    Conn.Close();
                    if (i == 1)
                    {
                        MessageBox.Show("정상적으로 데이터가 저장되었습니다.", "알림",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //lvList_MySqlClient_View();
                        //Control_Clear();
                    }
                    else
                    {
                        MessageBox.Show("정상적으로 데이터가 저장되지 않았습니다.", "에러",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }*/

            }

        }

   
        private void todaydatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //
        //날짜 바꿈 
        //
        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            lvList_MySqlClient_View();
            daily_MySqlClient_View();
        }

        

        private void txtDaily_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
