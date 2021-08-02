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
using System.IO;

namespace Information_App
{
    public partial class Edit_IT : Form
    {
        //กำหนดตัวแปรเพื่อรองรับ command (connection, sql)
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();

        public Edit_IT(string Pid)
        {
            InitializeComponent();
            //กำหนด connection โดยดึง path รูปแบบ string จาก C1
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;

            id.Text = Pid;
        }

        private void Edit_IT_Load(object sender, EventArgs e)
        {
            //ค้นหาข้อมูลด้วย number แล้วแสดงข้อมูลในช่องกรอกข้อมูล 
            try
            {
                int number = int.Parse(id.Text);
                byte[] getImg = new byte[0];

                connection.Open();
                string query1 = "SELECT * FROM it_prob where number = " + number + ";";
                cmd.CommandText = query1;
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    sent_name.Text = reader["sent_name"].ToString();
                    get_name.Text = reader["get_name"].ToString();
                    info.Text = reader["info"].ToString();
                    com_name.Text = reader["com_name"].ToString();
                    howto.Text = reader["howto"].ToString();
                    location.Text = reader["location"].ToString();
                    getinfo_date.Text = reader["getinfo_date"].ToString();
                    if (reader["picture"] != DBNull.Value)
                    {
                        getImg = (byte[])reader["picture"];
                        MemoryStream stream = new MemoryStream(getImg);
                        pictureBox1.Image = Image.FromStream(stream);
                    }

                }
                else { MessageBox.Show("ไม่พบข้อมูล"); }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาด " + ex);
            }
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

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(id.Text);

                DialogResult dialog = MessageBox.Show("ยืนยันการแก้ไขข้อมูล", "แก้ไขข้อมูล", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    if (com_name.Text != "")
                    {
                        //กำหนดค่า param
                        cmd.Parameters.AddWithValue("@pic", c1.addpictoparam(pictureBox1));

                        var newdate = getinfo_date.Value.Date.ToString();

                        connection.Open();
                        //แก้ไขข้อมูล
                        string query = "UPDATE it_prob SET getinfo_date = '" + newdate;
                        query += "',info = '" + info.Text;
                        query += "',com_name = '" + com_name.Text;
                        query += "',sent_name = '" + sent_name.Text;
                        query += "',location = '" + location.Text;
                        query += "',get_name = '" + get_name.Text;
                        query += "',howto = '" + howto.Text;
                        query += "',picture = @pic WHERE number = " + number + ";";

                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(" แก้ไขข้อมูล สำเร็จ ");
                        connection.Close();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่ชื่อเครื่อง");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" ผิดพลาด " + ex);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(id.Text);

                DialogResult dialog = MessageBox.Show("ยืนยันการลบข้อมูล?", "ลบข้อมูล", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    connection.Open();
                    //ลบข้อมูล
                    string query = "DELETE FROM it_prob WHERE number = " + number + ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" ลบข้อมูล สำเร็จ ");
                    connection.Close();

                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาด" + ex);
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
