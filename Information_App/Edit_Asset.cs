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
    public partial class Edit_Asset : Form
    {
        //กำหนดตัวแปรเพื่อรองรับ command (connection, sql)
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();

        public Edit_Asset(string Pid)
        {
            InitializeComponent();
            //กำหนด connection โดยดึง path รูปแบบ string จาก C1
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;
            
            id.Text = Pid;

        }

        private void Edit_Asset_Load(object sender, EventArgs e)
        {
            //ค้นหาข้อมูลด้วย number แล้วแสดงข้อมูลในช่องกรอกข้อมูล 
            try
            {
                int number = int.Parse(id.Text);
                byte[] getImg = new byte[0];
                
                connection.Open();
                string query1 = "SELECT * FROM it_hardware where number = " + number + ";";
                cmd.CommandText = query1;
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //ประเภท
                    if (reader["type"].ToString() == "DT")
                    {
                        type.Text = "Desktop";
                    }
                    else if (reader["type"].ToString() == "NB")
                    {
                        type.Text = "Notebook";
                    }
                    else
                    {
                        type.Text = "Mobile";
                    }

                    //สินทรัพย์
                    if (reader["asset"].ToString() == "O")
                    {
                        asset.Text = "เป็นของหน่วยงาน";
                    }
                    else
                    {
                        asset.Text = "เป็นของส่วนตัว";
                    }

                    mac.Text = reader["mac"].ToString();
                    sn.Text = reader["sn"].ToString();
                    cpu.Text = reader["cpu"].ToString();
                    brand.Text = reader["brand"].ToString();
                    com_name.Text = reader["com_name"].ToString();
                    ram.Text = reader["ram"].ToString();
                    os.Text = reader["os"].ToString();
                    antivirus.Text = reader["antivirus"].ToString();
                    location.Text = reader["location"].ToString();
                    res_name.Text = reader["res_name"].ToString();
                    res_date.Text = reader["res_date"].ToString();
                    it_note.Text = reader["it_note"].ToString();

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
                int number = int.Parse(id.Text);

                    DialogResult dialog = MessageBox.Show("ยืนยันการแก้ไขข้อมูล", "แก้ไขข้อมูล", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        //ตรวจค่าว่างในช่อง mac กับ com_name
                        if (mac.Text != "" && com_name.Text != "")
                        {
                            string Mac = mac.Text, Com_name = com_name.Text;

                            connection.Open();
                            cmd2.CommandText = "SELECT number, mac, com_name FROM it_hardware WHERE NOT number = " + number + "and (mac = '" + Mac + "' or com_name = '" + Com_name + "')";
                            OleDbDataReader reader = cmd2.ExecuteReader();

                            //ตรวจค่าซ้ำ
                            if (reader.Read())
                            {
                                MessageBox.Show("Mac Address หรือ ชื่อเครื่องซ้ำกับที่มีอยู่");
                            }
                            else
                            {
                                //กำหนดค่า param
                                cmd.Parameters.AddWithValue("@pic", c1.addpictoparam(pictureBox1));

                                var newdate = res_date.Value.Date.ToString();
                                string newasset, newtype;
                                //สินทรัพย์
                                if (asset.Text == "เป็นของหน่วยงาน")
                                {
                                    newasset = "O";
                                }
                                else
                                {
                                    newasset = "P";
                                }

                                //ประเภท
                                if (type.Text == "Desktop")
                                {
                                    newtype = "DT";
                                }
                                else if (type.Text == "Notebook")
                                {
                                    newtype = "NB";
                                }
                                else
                                {
                                    newtype = "MB";
                                }
                                //แก้ไขข้อมูล
                                string query = "UPDATE it_hardware SET type = '" + newtype;
                                query += "',asset = '" + newasset;
                                query += "',mac = '" + mac.Text;
                                query += "',sn = '" + sn.Text;
                                query += "',cpu = '" + cpu.Text;
                                query += "',brand = '" + brand.Text;
                                query += "',com_name = '" + com_name.Text;
                                query += "',ram = '" + ram.Text;
                                query += "',os = '" + os.Text;
                                query += "',antivirus = '" + antivirus.Text;
                                query += "',location = '" + location.Text;
                                query += "',res_name = '" + res_name.Text;
                                query += "',res_date = '" + res_date.Text;
                                query += "',it_note = '" + it_note.Text;
                                query += "',picture = @pic WHERE number = " + number + ";";

                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();

                                MessageBox.Show(" แก้ไขข้อมูล สำเร็จ ");

                                this.Hide();
                            }
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("กรุณาใส่ Mac Address และ ชื่อเครื่อง");
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
                    string query = "DELETE FROM it_hardware WHERE number = " + number + ";";
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
    }
}
