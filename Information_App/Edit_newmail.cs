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
    public partial class Edit_newmail : Form
    {
        //กำหนดตัวแปรเพื่อรองรับ command (connection, sql)
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();

        public Edit_newmail(string Pid)
        {
            InitializeComponent();
            //กำหนด connection โดยดึง path รูปแบบ string จาก C1
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;

            id.Text = Pid;
        }

        private void Edit_newmail_Load(object sender, EventArgs e)
        {
            //ค้นหาข้อมูลด้วย number แล้วแสดงข้อมูลในช่องกรอกข้อมูล 
            try
            {
                int number = int.Parse(id.Text);
                byte[] getImg = new byte[0];
                sentinfo_date.Value = DateTime.Today;

                connection.Open();
                string query1 = "SELECT * FROM about_email where title_type = 'N' and number = " + number + ";";
                cmd.CommandText = query1;
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    pre_name.Text = reader["pre_name"].ToString();
                    th_name.Text = reader["th_name"].ToString();
                    th_last.Text = reader["th_last"].ToString();
                    eng_name.Text = reader["eng_name"].ToString();
                    people_id.Text = reader["people_id"].ToString();
                    gov_id.Text = reader["gov_id"].ToString();
                    birthdate.Text = reader["birthdate"].ToString();
                    depart.Text = reader["depart"].ToString();
                    rank.Text = reader["rank"].ToString();
                    phone.Text = reader["phone"].ToString();
                    email.Text = reader["email"].ToString();
                    mail_note.Text = reader["mail_note"].ToString();

                    //เงื่อนไขประเภท
                    string str_type = reader["type"].ToString();
                    if (reader["type"].ToString() == "")
                    {
                        type.Text = "ประเภท";
                    }
                    else if (str_type != "นักเรียนทหาร" && str_type != "นายทหารประทวน" && str_type != "นายทหารสัญญาบัตร")
                    {
                        other_type.Text = str_type;
                        type.Text = "อื่น ๆ (ระบุ)";
                        other_type.Enabled = true;
                    }
                    else type.Text = str_type;

                    getinfo_date.Text = reader["getinfo_date"].ToString();

                    //เงื่อนไขวันที่แจ้งผู้ใช้
                    if (reader["sentinfo_date"] != DBNull.Value)
                    {
                        checkBox1.Checked = true;
                        sentinfo_date.Enabled = true;
                        yesno.Enabled = true;
                        sentinfo_date.Text = reader["sentinfo_date"].ToString();
                        yesno.Text = reader["status"].ToString();
                    }

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

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                string number = id.Text;

                DialogResult dialog = MessageBox.Show("ยืนยันการแก้ไขข้อมูล", "แก้ไขข้อมูล", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    //กำหนดค่า param
                    cmd.Parameters.AddWithValue("@pic", c1.addpictoparam(pictureBox1));

                    //เอาค่าวันที่ใส่ parameter
                    cmd.Parameters.AddWithValue("@sentinfo", c1.addsenttoparam(sentinfo_date, checkBox1));

                    var newdate = getinfo_date.Value.Date.ToString();
                    var newbirthdate = birthdate.Value.Date.ToString();
                    var status = yesno.Text;
                    //DateTime newsentinfo_date = sentinfo_date.Value;
                    //cmd.Parameters.AddWithValue("@sentinfo", DBNull.Value);

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

                    connection.Open();
                    //แก้ไขข้อมูล
                    string query = "UPDATE about_email SET pre_name = '" + pre_name.Text;
                    query += "',th_name = '" + th_name.Text;
                    query += "',th_last = '" + th_last.Text;
                    query += "',eng_name = '" + eng_name.Text;
                    query += "',people_id = '" + people_id.Text;
                    query += "',gov_id = '" + gov_id.Text;
                    query += "',birthdate = '" + newbirthdate;
                    query += "',depart = '" + depart.Text;
                    query += "',rank = '" + rank.Text;
                    query += "',phone = '" + phone.Text;
                    query += "',email = '" + email.Text;
                    query += "',type = '" + str_type;
                    query += "',getinfo_date = '" + newdate;
                    query += "',status = '" + status;
                    query += "',mail_note = '" + mail_note.Text;
                    query += "', picture = @pic";
                    query += ", sentinfo_date = @sentinfo WHERE title_type = 'N' and number = " + number + ";";

                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(" แก้ไขข้อมูล สำเร็จ ");
                    connection.Close();

                    this.Hide();
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
                string number = id.Text;

                DialogResult dialog = MessageBox.Show("ยืนยันการลบข้อมูล?", "ลบข้อมูล", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    connection.Open();
                    //ลบข้อมูล
                    string query = "DELETE FROM about_email WHERE title_type = 'N' and number = " + number;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                sentinfo_date.Enabled = true;
                yesno.Enabled = true;
                yesno.Text = "Yes";
            }
            else
            {
                sentinfo_date.Enabled = false;
                yesno.Enabled = false;
                yesno.Text = null;
            }
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type.Text == "อื่น ๆ (ระบุ)") other_type.Enabled = true;
            else other_type.Enabled = false;
        }
    }
}
