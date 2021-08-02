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
    public partial class Add_Asset : Form
    {
        //กำหนดตัวแปรเพื่อรองรับ command (connection, sql)
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();

        public Add_Asset()
        {
            InitializeComponent();
            //กำหนด connection โดยดึง path รูปแบบ string จาก C1
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;
        }

        private void add_Click(object sender, EventArgs e)
        {
            
        }

        private void reset_Click(object sender, EventArgs e)
        {
            
        }

        private void Add_Asset_Load(object sender, EventArgs e)
        {
            //กำหนดค่าเริ่มต้น
            res_date.Value = DateTime.Today;
            asset.Text = "เป็นของหน่วยงาน";
            type.Text = "Desktop";
        }

        private void add_Click_1(object sender, EventArgs e)
        {
            try
            {
                //ตรวจค่าว่างในช่อง mac กับ com_name
                if (mac.Text != "" && com_name.Text != "")
                {
                    string Mac = mac.Text, Com_name = com_name.Text;

                    //ตรวจค่าซ้ำ
                    connection.Open();
                    cmd2.CommandText = "SELECT mac, com_name FROM it_hardware WHERE mac = '" + Mac + "' or com_name = '"+ Com_name +"'";
                    OleDbDataReader reader = cmd2.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Mac Address หรือ ชื่อเครื่องซ้ำกับที่มีอยู่");
                    }
                    else
                    {
                        //กำหนดค่า param
                        cmd.Parameters.AddWithValue("@pic", c1.addpictoparam(pictureBox1));

                        var newdate = res_date.Value.Date.ToShortDateString();
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
                        
                        //เพิ่มข้อมูล
                        cmd.CommandText = "INSERT INTO it_hardware (type,asset,mac,sn,cpu,brand,com_name,ram,os,antivirus,location,res_name,res_date,it_note,picture) values('" + newtype + "','" + newasset + "','" + mac.Text + "','" + sn.Text + "','" + cpu.Text + "','" + brand.Text + "','" + com_name.Text + "','" + ram.Text + "','" + os.Text + "','" + antivirus.Text + "','" + location.Text + "','" + res_name.Text + "','" + newdate + "','" + it_note.Text + "', @pic)";

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("บันทึกข้อมูลสำเร็จ");
                        

                        // Clear ค่าใน textbox
                        type.Text = "";
                        asset.Text = "";
                        mac.Text = "";
                        sn.Text = "";
                        cpu.Text = "";
                        brand.Text = "";
                        com_name.Text = "";
                        ram.Text = "";
                        os.Text = "";
                        antivirus.Text = "";
                        location.Text = "";
                        res_name.Text = "";
                        res_date.Text = DateTime.Today.ToString();
                        it_note.Text = "";
                        pictureBox1.Image = null;
                    }
                    connection.Close();
                } 
                else
                {
                    MessageBox.Show("กรุณาใส่ Mac Address และ ชื่อเครื่อง");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" ผิดพลาด " + ex);
            }
        }

        private void reset_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void res_date_ValueChanged(object sender, EventArgs e)
        {
            
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
