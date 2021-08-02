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
    public partial class Add_IT : Form
    {
        //กำหนดตัวแปรเพื่อรองรับ command (connection, sql)
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();

        public Add_IT()
        {
            InitializeComponent();
            //กำหนด connection โดยดึง path รูปแบบ string จาก C1
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;
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

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                if (com_name.Text != "")
                {
                    //กำหนดค่า param
                    cmd.Parameters.AddWithValue("@pic", c1.addpictoparam(pictureBox1));

                    var newdate = getinfo_date.Value.Date.ToShortDateString();

                    connection.Open();
                    //เพิ่มข้อมูล
                    cmd.CommandText = "INSERT INTO it_prob (getinfo_date, info, com_name, sent_name, location, get_name, howto, picture) values('" + newdate + "','" + info.Text + "','" + com_name.Text + "','" + sent_name.Text + "','" + location.Text + "','" + get_name.Text + "','" + howto.Text + "', @pic)";

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("บันทึกข้อมูลสำเร็จ");
                    connection.Close();

                    // Clear ค่าใน textbox
                    info.Text = "";
                    com_name.Text = "";
                    sent_name.Text = "";
                    location.Text = "";
                    get_name.Text = "";
                    howto.Text = "";
                    getinfo_date.Text = DateTime.Today.ToString();
                    pictureBox1.Image = null;
                }
                else
                {
                    MessageBox.Show("กรุณาใส่ชื่อเครื่อง");
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

        private void Add_IT_Load(object sender, EventArgs e)
        {
            //กำหนดค่าเริ่มต้น
            getinfo_date.Value = DateTime.Today;
        }
    }
}
