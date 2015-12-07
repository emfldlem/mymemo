using System.Data;

namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btntoday_Modify = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btndaily_save = new System.Windows.Forms.Button();
            this.txtDaily = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.delete = new System.Windows.Forms.Button();
            this.lvList = new System.Windows.Forms.ListView();
            this.ColumnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnschedule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.today_schaduel = new System.Windows.Forms.TextBox();
            this.today_time = new System.Windows.Forms.TextBox();
            this.btntodaysave_Click = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mymemoview = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.num10 = new System.Windows.Forms.RadioButton();
            this.num9 = new System.Windows.Forms.RadioButton();
            this.num8 = new System.Windows.Forms.RadioButton();
            this.num7 = new System.Windows.Forms.RadioButton();
            this.num6 = new System.Windows.Forms.RadioButton();
            this.num5 = new System.Windows.Forms.RadioButton();
            this.num4 = new System.Windows.Forms.RadioButton();
            this.num3 = new System.Windows.Forms.RadioButton();
            this.num2 = new System.Windows.Forms.RadioButton();
            this.num1 = new System.Windows.Forms.RadioButton();
            this.lblImg = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.todayscore_confirm = new System.Windows.Forms.Button();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.mymemoview.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(212, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "My Memo";
            // 
            // dtpTime
            // 
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTime.Location = new System.Drawing.Point(444, 49);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(127, 25);
            this.dtpTime.TabIndex = 3;
            this.dtpTime.Value = new System.DateTime(2015, 12, 3, 15, 54, 4, 0);
            this.dtpTime.ValueChanged += new System.EventHandler(this.dtpTime_ValueChanged);
            // 
            // btntoday_Modify
            // 
            this.btntoday_Modify.Location = new System.Drawing.Point(475, 402);
            this.btntoday_Modify.Name = "btntoday_Modify";
            this.btntoday_Modify.Size = new System.Drawing.Size(75, 25);
            this.btntoday_Modify.TabIndex = 4;
            this.btntoday_Modify.Text = "수정";
            this.btntoday_Modify.UseVisualStyleBackColor = true;
            this.btntoday_Modify.Click += new System.EventHandler(this.btntoday_Modify_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btndaily_save);
            this.tabPage3.Controls.Add(this.txtDaily);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(556, 431);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "일기장";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btndaily_save
            // 
            this.btndaily_save.Location = new System.Drawing.Point(350, 4);
            this.btndaily_save.Name = "btndaily_save";
            this.btndaily_save.Size = new System.Drawing.Size(105, 25);
            this.btndaily_save.TabIndex = 1;
            this.btndaily_save.Text = "하루 저장";
            this.btndaily_save.UseVisualStyleBackColor = true;
            this.btndaily_save.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDaily
            // 
            this.txtDaily.Location = new System.Drawing.Point(6, 33);
            this.txtDaily.Multiline = true;
            this.txtDaily.Name = "txtDaily";
            this.txtDaily.Size = new System.Drawing.Size(547, 346);
            this.txtDaily.TabIndex = 0;
            this.txtDaily.TextChanged += new System.EventHandler(this.txtDaily_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.delete);
            this.tabPage1.Controls.Add(this.btntoday_Modify);
            this.tabPage1.Controls.Add(this.lvList);
            this.tabPage1.Controls.Add(this.today_schaduel);
            this.tabPage1.Controls.Add(this.today_time);
            this.tabPage1.Controls.Add(this.btntodaysave_Click);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(556, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "하루일정표";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(394, 402);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 25);
            this.delete.TabIndex = 20;
            this.delete.Text = "삭제";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.btntoday_Delete_Click);
            // 
            // lvList
            // 
            this.lvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnTime,
            this.columnschedule,
            this.columnno});
            this.lvList.FullRowSelect = true;
            this.lvList.GridLines = true;
            this.lvList.Location = new System.Drawing.Point(6, 34);
            this.lvList.Name = "lvList";
            this.lvList.Scrollable = false;
            this.lvList.Size = new System.Drawing.Size(544, 362);
            this.lvList.TabIndex = 19;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.View = System.Windows.Forms.View.Details;
            this.lvList.SelectedIndexChanged += new System.EventHandler(this.lvList_SelectedIndexChanged);
            this.lvList.Click += new System.EventHandler(this.lvList_Click);
            // 
            // ColumnTime
            // 
            this.ColumnTime.Text = "시  간";
            this.ColumnTime.Width = 108;
            // 
            // columnschedule
            // 
            this.columnschedule.Text = "일  정";
            this.columnschedule.Width = 427;
            // 
            // columnno
            // 
            this.columnno.Text = "번호";
            this.columnno.Width = 124;
            // 
            // today_schaduel
            // 
            this.today_schaduel.Location = new System.Drawing.Point(202, 3);
            this.today_schaduel.Name = "today_schaduel";
            this.today_schaduel.Size = new System.Drawing.Size(270, 25);
            this.today_schaduel.TabIndex = 4;
            // 
            // today_time
            // 
            this.today_time.Location = new System.Drawing.Point(50, 3);
            this.today_time.Name = "today_time";
            this.today_time.Size = new System.Drawing.Size(100, 25);
            this.today_time.TabIndex = 2;
            // 
            // btntodaysave_Click
            // 
            this.btntodaysave_Click.Location = new System.Drawing.Point(479, 4);
            this.btntodaysave_Click.Name = "btntodaysave_Click";
            this.btntodaysave_Click.Size = new System.Drawing.Size(75, 25);
            this.btntodaysave_Click.TabIndex = 5;
            this.btntodaysave_Click.Text = "입력";
            this.btntodaysave_Click.UseVisualStyleBackColor = true;
            this.btntodaysave_Click.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "일정";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "시간";
            // 
            // mymemoview
            // 
            this.mymemoview.Controls.Add(this.tabPage1);
            this.mymemoview.Controls.Add(this.tabPage3);
            this.mymemoview.Controls.Add(this.tabPage2);
            this.mymemoview.Location = new System.Drawing.Point(12, 55);
            this.mymemoview.Name = "mymemoview";
            this.mymemoview.SelectedIndex = 0;
            this.mymemoview.Size = new System.Drawing.Size(564, 460);
            this.mymemoview.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.todayscore_confirm);
            this.tabPage2.Controls.Add(this.num10);
            this.tabPage2.Controls.Add(this.num9);
            this.tabPage2.Controls.Add(this.num8);
            this.tabPage2.Controls.Add(this.num7);
            this.tabPage2.Controls.Add(this.num6);
            this.tabPage2.Controls.Add(this.num5);
            this.tabPage2.Controls.Add(this.num4);
            this.tabPage2.Controls.Add(this.num3);
            this.tabPage2.Controls.Add(this.num2);
            this.tabPage2.Controls.Add(this.num1);
            this.tabPage2.Controls.Add(this.lblImg);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(556, 431);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "오늘의 점수";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // num10
            // 
            this.num10.AutoSize = true;
            this.num10.Checked = true;
            this.num10.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num10.ImageKey = "num1.jpg";
            this.num10.Location = new System.Drawing.Point(480, 325);
            this.num10.Name = "num10";
            this.num10.Size = new System.Drawing.Size(59, 29);
            this.num10.TabIndex = 1;
            this.num10.TabStop = true;
            this.num10.Text = "10";
            this.num10.UseVisualStyleBackColor = true;
            // 
            // num9
            // 
            this.num9.AutoSize = true;
            this.num9.Checked = true;
            this.num9.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num9.ImageKey = "(없음)";
            this.num9.Location = new System.Drawing.Point(435, 325);
            this.num9.Name = "num9";
            this.num9.Size = new System.Drawing.Size(46, 29);
            this.num9.TabIndex = 1;
            this.num9.TabStop = true;
            this.num9.Text = "9";
            this.num9.UseVisualStyleBackColor = true;
            // 
            // num8
            // 
            this.num8.AutoSize = true;
            this.num8.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num8.ImageKey = "(없음)";
            this.num8.Location = new System.Drawing.Point(383, 325);
            this.num8.Name = "num8";
            this.num8.Size = new System.Drawing.Size(46, 29);
            this.num8.TabIndex = 1;
            this.num8.Text = "8";
            this.num8.UseVisualStyleBackColor = true;
            // 
            // num7
            // 
            this.num7.AutoSize = true;
            this.num7.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num7.ImageKey = "(없음)";
            this.num7.Location = new System.Drawing.Point(331, 325);
            this.num7.Name = "num7";
            this.num7.Size = new System.Drawing.Size(46, 29);
            this.num7.TabIndex = 1;
            this.num7.Text = "7";
            this.num7.UseVisualStyleBackColor = true;
            // 
            // num6
            // 
            this.num6.AutoSize = true;
            this.num6.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num6.ImageKey = "(없음)";
            this.num6.Location = new System.Drawing.Point(279, 325);
            this.num6.Name = "num6";
            this.num6.Size = new System.Drawing.Size(46, 29);
            this.num6.TabIndex = 1;
            this.num6.Text = "6";
            this.num6.UseVisualStyleBackColor = true;
            // 
            // num5
            // 
            this.num5.AutoSize = true;
            this.num5.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num5.ImageKey = "(없음)";
            this.num5.Location = new System.Drawing.Point(227, 325);
            this.num5.Name = "num5";
            this.num5.Size = new System.Drawing.Size(46, 29);
            this.num5.TabIndex = 1;
            this.num5.Text = "5";
            this.num5.UseVisualStyleBackColor = true;
            // 
            // num4
            // 
            this.num4.AutoSize = true;
            this.num4.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num4.ImageKey = "(없음)";
            this.num4.Location = new System.Drawing.Point(175, 325);
            this.num4.Name = "num4";
            this.num4.Size = new System.Drawing.Size(46, 29);
            this.num4.TabIndex = 1;
            this.num4.Text = "4";
            this.num4.UseVisualStyleBackColor = true;
            // 
            // num3
            // 
            this.num3.AutoSize = true;
            this.num3.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num3.ImageKey = "num1.jpg";
            this.num3.Location = new System.Drawing.Point(123, 325);
            this.num3.Name = "num3";
            this.num3.Size = new System.Drawing.Size(46, 29);
            this.num3.TabIndex = 1;
            this.num3.Text = "3";
            this.num3.UseVisualStyleBackColor = true;
            // 
            // num2
            // 
            this.num2.AutoSize = true;
            this.num2.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num2.ImageKey = "(없음)";
            this.num2.Location = new System.Drawing.Point(71, 325);
            this.num2.Name = "num2";
            this.num2.Size = new System.Drawing.Size(46, 29);
            this.num2.TabIndex = 1;
            this.num2.Text = "2";
            this.num2.UseVisualStyleBackColor = true;
            // 
            // num1
            // 
            this.num1.AutoSize = true;
            this.num1.Font = new System.Drawing.Font("나눔바른고딕OTF 옛한글", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num1.ImageKey = "num1.jpg";
            this.num1.Location = new System.Drawing.Point(19, 325);
            this.num1.Name = "num1";
            this.num1.Size = new System.Drawing.Size(46, 29);
            this.num1.TabIndex = 1;
            this.num1.Text = "1";
            this.num1.UseVisualStyleBackColor = true;
            // 
            // lblImg
            // 
            this.lblImg.ImageList = this.imageList;
            this.lblImg.Location = new System.Drawing.Point(114, 3);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(320, 300);
            this.lblImg.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "1.png");
            this.imageList.Images.SetKeyName(1, "2.png");
            this.imageList.Images.SetKeyName(2, "3.png");
            this.imageList.Images.SetKeyName(3, "4.png");
            this.imageList.Images.SetKeyName(4, "5.png");
            this.imageList.Images.SetKeyName(5, "6.png");
            this.imageList.Images.SetKeyName(6, "7.png");
            this.imageList.Images.SetKeyName(7, "8.png");
            this.imageList.Images.SetKeyName(8, "9.png");
            this.imageList.Images.SetKeyName(9, "10.png");
            // 
            // todayscore_confirm
            // 
            this.todayscore_confirm.Location = new System.Drawing.Point(151, 377);
            this.todayscore_confirm.Name = "todayscore_confirm";
            this.todayscore_confirm.Size = new System.Drawing.Size(209, 43);
            this.todayscore_confirm.TabIndex = 2;
            this.todayscore_confirm.Text = "오늘의 점수 주기";
            this.todayscore_confirm.UseVisualStyleBackColor = true;
            this.todayscore_confirm.Click += new System.EventHandler(this.todayscore_confirm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 556);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.mymemoview);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.mymemoview.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btntoday_Modify;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btndaily_save;
        private System.Windows.Forms.TextBox txtDaily;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lvList;
        private System.Windows.Forms.ColumnHeader ColumnTime;
        private System.Windows.Forms.ColumnHeader columnschedule;
        private System.Windows.Forms.TextBox today_schaduel;
        private System.Windows.Forms.TextBox today_time;
        private System.Windows.Forms.Button btntodaysave_Click;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl mymemoview;
        private System.Windows.Forms.ColumnHeader columnno;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton num1;
        private System.Windows.Forms.Label lblImg;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.RadioButton num10;
        private System.Windows.Forms.RadioButton num9;
        private System.Windows.Forms.RadioButton num8;
        private System.Windows.Forms.RadioButton num7;
        private System.Windows.Forms.RadioButton num6;
        private System.Windows.Forms.RadioButton num5;
        private System.Windows.Forms.RadioButton num4;
        private System.Windows.Forms.RadioButton num3;
        private System.Windows.Forms.RadioButton num2;
        private System.Windows.Forms.Button todayscore_confirm;
    }
}

