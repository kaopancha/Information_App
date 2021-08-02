namespace Information_App
{
    partial class Add_changedepart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reset = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.clear_pic = new System.Windows.Forms.Button();
            this.add_pic = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pre_name = new System.Windows.Forms.TextBox();
            this.th_name = new System.Windows.Forms.TextBox();
            this.th_last = new System.Windows.Forms.TextBox();
            this.depart = new System.Windows.Forms.TextBox();
            this.rank = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.other_type = new System.Windows.Forms.TextBox();
            this.getinfo_date = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.mail_note = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reset.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.reset.Location = new System.Drawing.Point(138, 496);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(85, 38);
            this.reset.TabIndex = 276;
            this.reset.Text = "ปิด";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.PaleGreen;
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.add.Location = new System.Drawing.Point(20, 496);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(85, 38);
            this.add.TabIndex = 275;
            this.add.Text = "เพิ่ม";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // clear_pic
            // 
            this.clear_pic.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear_pic.Location = new System.Drawing.Point(452, 466);
            this.clear_pic.Name = "clear_pic";
            this.clear_pic.Size = new System.Drawing.Size(73, 27);
            this.clear_pic.TabIndex = 274;
            this.clear_pic.Text = "ลบรูปภาพ";
            this.clear_pic.UseVisualStyleBackColor = true;
            this.clear_pic.Click += new System.EventHandler(this.clear_pic_Click);
            // 
            // add_pic
            // 
            this.add_pic.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_pic.Location = new System.Drawing.Point(363, 466);
            this.add_pic.Name = "add_pic";
            this.add_pic.Size = new System.Drawing.Size(73, 27);
            this.add_pic.TabIndex = 273;
            this.add_pic.Text = "เลือกรูปภาพ";
            this.add_pic.UseVisualStyleBackColor = true;
            this.add_pic.Click += new System.EventHandler(this.add_pic_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBox1.Location = new System.Drawing.Point(363, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(627, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 272;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(13, 376);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 28);
            this.label10.TabIndex = 270;
            this.label10.Text = "วันที่รับเรื่อง";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(13, 261);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 28);
            this.label7.TabIndex = 266;
            this.label7.Text = "อีเมล์";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(15, 207);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 28);
            this.label6.TabIndex = 264;
            this.label6.Text = "เบอร์โทรภายใน";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(13, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 28);
            this.label5.TabIndex = 262;
            this.label5.Text = "ตำแหน่ง";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(13, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 28);
            this.label4.TabIndex = 260;
            this.label4.Text = "สังกัด";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(361, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 28);
            this.label2.TabIndex = 258;
            this.label2.Text = "นามสกุล";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(126, 52);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 28);
            this.label13.TabIndex = 256;
            this.label13.Text = "ชื่อ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(15, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 28);
            this.label1.TabIndex = 254;
            this.label1.Text = "ยศ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(15, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 28);
            this.label9.TabIndex = 253;
            this.label9.Text = "เพิ่มรายการข้าราชการย้ายสังกัด";
            // 
            // pre_name
            // 
            this.pre_name.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pre_name.Location = new System.Drawing.Point(52, 49);
            this.pre_name.Name = "pre_name";
            this.pre_name.Size = new System.Drawing.Size(65, 35);
            this.pre_name.TabIndex = 279;
            // 
            // th_name
            // 
            this.th_name.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.th_name.Location = new System.Drawing.Point(163, 49);
            this.th_name.Name = "th_name";
            this.th_name.Size = new System.Drawing.Size(189, 35);
            this.th_name.TabIndex = 280;
            // 
            // th_last
            // 
            this.th_last.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.th_last.Location = new System.Drawing.Point(430, 49);
            this.th_last.Name = "th_last";
            this.th_last.Size = new System.Drawing.Size(203, 35);
            this.th_last.TabIndex = 281;
            // 
            // depart
            // 
            this.depart.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.depart.Location = new System.Drawing.Point(147, 100);
            this.depart.Name = "depart";
            this.depart.Size = new System.Drawing.Size(205, 35);
            this.depart.TabIndex = 282;
            // 
            // rank
            // 
            this.rank.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rank.Location = new System.Drawing.Point(147, 152);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(203, 35);
            this.rank.TabIndex = 283;
            // 
            // phone
            // 
            this.phone.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.phone.Location = new System.Drawing.Point(147, 204);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(205, 35);
            this.phone.TabIndex = 284;
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.email.Location = new System.Drawing.Point(147, 258);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(205, 35);
            this.email.TabIndex = 285;
            // 
            // type
            // 
            this.type.BackColor = System.Drawing.SystemColors.Window;
            this.type.DisplayMember = "ประเภท";
            this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "ประเภท",
            "นักเรียนทหาร",
            "นายทหารประทวน",
            "นายทหารสัญญาบัตร",
            "อื่น ๆ (ระบุ)"});
            this.type.Location = new System.Drawing.Point(12, 317);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(131, 36);
            this.type.TabIndex = 286;
            this.type.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
            // 
            // other_type
            // 
            this.other_type.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.other_type.Location = new System.Drawing.Point(149, 317);
            this.other_type.Name = "other_type";
            this.other_type.Size = new System.Drawing.Size(203, 35);
            this.other_type.TabIndex = 288;
            // 
            // getinfo_date
            // 
            this.getinfo_date.CustomFormat = "d/M/yyyy";
            this.getinfo_date.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.getinfo_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.getinfo_date.Location = new System.Drawing.Point(149, 371);
            this.getinfo_date.Name = "getinfo_date";
            this.getinfo_date.Size = new System.Drawing.Size(203, 35);
            this.getinfo_date.TabIndex = 289;
            this.getinfo_date.Value = new System.DateTime(2020, 7, 31, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(15, 428);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 28);
            this.label8.TabIndex = 291;
            this.label8.Text = "หมายเหตุ";
            // 
            // mail_note
            // 
            this.mail_note.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.mail_note.Location = new System.Drawing.Point(149, 425);
            this.mail_note.Name = "mail_note";
            this.mail_note.Size = new System.Drawing.Size(203, 35);
            this.mail_note.TabIndex = 290;
            // 
            // Add_changedepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1002, 545);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mail_note);
            this.Controls.Add(this.getinfo_date);
            this.Controls.Add(this.other_type);
            this.Controls.Add(this.type);
            this.Controls.Add(this.email);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.rank);
            this.Controls.Add(this.depart);
            this.Controls.Add(this.th_last);
            this.Controls.Add(this.th_name);
            this.Controls.Add(this.pre_name);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.add);
            this.Controls.Add(this.clear_pic);
            this.Controls.Add(this.add_pic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Name = "Add_changedepart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เพิ่มรายการข้าราชการย้ายสังกัด";
            this.Load += new System.EventHandler(this.Add_changedepart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button clear_pic;
        private System.Windows.Forms.Button add_pic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox pre_name;
        private System.Windows.Forms.TextBox th_name;
        private System.Windows.Forms.TextBox th_last;
        private System.Windows.Forms.TextBox depart;
        private System.Windows.Forms.TextBox rank;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.TextBox other_type;
        private System.Windows.Forms.DateTimePicker getinfo_date;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox mail_note;
    }
}