using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

namespace Information_App
{
    public partial class Add_newmail : Form
    {
        //กำหนดตัวแปรเพื่อรองรับ command (connection, sql)
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();

        public Add_newmail()
        {
            InitializeComponent();
            //กำหนด connection โดยดึง path รูปแบบ string จาก C1
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;
        }

        private void Add_newmail_Load(object sender, EventArgs e)
        {
            //กำหนดค่าเริ่มต้น
            getinfo_date.Value = DateTime.Today;
            birthdate.Value = DateTime.Today;
            type.Text = "ประเภท";
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                if (people_id.Text != "")
                {
                    string Pid = people_id.Text;

                    connection.Open();
                    cmd2.CommandText = "SELECT people_id FROM about_email WHERE title_type = 'N' and people_id = '" + Pid + "'";
                    OleDbDataReader reader = cmd2.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("หมายเลขประชาชนซ้ำกับที่มีอยู่");
                    }
                    else
                    {
                        //กำหนดค่า param
                        cmd.Parameters.AddWithValue("@pic", c1.addpictoparam(pictureBox1));

                        var newbirthdate = birthdate.Value.Date.ToShortDateString();
                        var newdate = getinfo_date.Value.Date.ToShortDateString();

                        //เงื่อนไขประเภท
                        string str_type = type.Text;
                        if (str_type == "ประเภท")
                        {
                            str_type = "";
                        }
                        else if (str_type == "อื่น ๆ (ระบุ)")
                        {
                            str_type = other_type.Text;
                        }

                        //เพิ่มข้อมูล
                        cmd.CommandText = "INSERT INTO about_email (pre_name, th_name, th_last, eng_name, people_id, gov_id, birthdate, depart, rank, phone, email, type, getinfo_date, mail_note, picture, title_type) values('" + pre_name.Text + "','" + th_name.Text + "','" + th_last.Text + "','" + eng_name.Text + "','" + people_id.Text + "','" + gov_id.Text + "','" + newbirthdate + "','" + depart.Text + "','" + rank.Text + "','" + phone.Text + "','" + email.Text + "','" + str_type + "','" + newdate + "','" + mail_note.Text + "', @pic, 'N')";

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("บันทึกข้อมูลสำเร็จ");

                        // Clear ค่าใน textbox
                        pre_name.Text = "";
                        th_name.Text = "";
                        th_last.Text = "";
                        eng_name.Text = "";
                        people_id.Text = "";
                        gov_id.Text = "";
                        birthdate.Text = DateTime.Today.ToString();
                        depart.Text = "";
                        rank.Text = "";
                        phone.Text = "";
                        email.Text = "";
                        type.Text = "ประเภท";
                        other_type.Text = "";
                        mail_note.Text = "";
                        getinfo_date.Text = DateTime.Today.ToString();
                        pictureBox1.Image = null;
                    }

                    connection.Close();
                }
                else 
                {
                    MessageBox.Show("กรุณาใส่หมายเลขประชาชน");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(" ผิดพลาด " + ex);
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //เพิ่มรูป
        private void add_pic_Click(object sender, EventArgs e)
        {
            c1.selectpic(pictureBox1);
        }
        //เคลียรูปในช่องรูปภาพ
        private void clear_pic_Click(object sender, EventArgs e)
        {
            c1.clearpic(pictureBox1, add_pic);
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type.Text == "อื่น ๆ (ระบุ)") other_type.Enabled = true;
            else other_type.Enabled = false;
        }
    }
}
