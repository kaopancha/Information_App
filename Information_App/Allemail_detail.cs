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
    public partial class Allemail_detail : Form
    {
        //กำหนดตัวแปรเพื่อรองรับ command (connection, sql)
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();
        DataTable dt = new DataTable();

        public Allemail_detail(string string_mail)
        {
            InitializeComponent();
            //กำหนด connection โดยดึง path รูปแบบ string จาก C1
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;

            mail.Text = string_mail;
        }

        private void Allemail_detail_Load(object sender, EventArgs e)
        {
            try
            {
                string string_mail = mail.Text;

                connection.Open();

                string query1 = "SELECT * FROM about_email where email = '" + string_mail + "' ORDER BY getinfo_date, title_type;";
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
                    if (reader["birthdate"] != DBNull.Value)
                    {
                        birthdate.Text = DateTime.Parse(reader["birthdate"].ToString()).ToShortDateString();
                    }
                    depart.Text = reader["depart"].ToString();
                    rank.Text = reader["rank"].ToString();
                    phone.Text = reader["phone"].ToString();
                    email.Text = reader["email"].ToString();
                    type.Text = reader["type"].ToString();
                }
                else { MessageBox.Show("ไม่พบข้อมูล"); }

                //แสดงใน datagridview

                dt.Locale = new System.Globalization.CultureInfo("th-TH");
                c1.gridview(query1, dt);
                dataGridView1.DataSource = dt;

                //กำหนดหัวข้อคอลัมน์ + ปิดคอลัมน์บางส่วน
                dataGridView1.Columns["number"].Visible = false;
                dataGridView1.Columns["pre_name"].Visible = false;
                dataGridView1.Columns["th_name"].Visible = false;
                dataGridView1.Columns["th_last"].Visible = false;
                dataGridView1.Columns["eng_name"].Visible = false;
                dataGridView1.Columns["people_id"].Visible = false;
                dataGridView1.Columns["gov_id"].Visible = false;
                dataGridView1.Columns["birthdate"].Visible = false;
                dataGridView1.Columns["depart"].Visible = false;
                dataGridView1.Columns["rank"].Visible = false;
                dataGridView1.Columns["phone"].Visible = false;
                dataGridView1.Columns["email"].Visible = false;
                dataGridView1.Columns["type"].Visible = false;
                dataGridView1.Columns["getinfo_date"].HeaderText = "วันที่รับเรื่อง";
                dataGridView1.Columns["sentinfo_date"].HeaderText = "วันที่แจ้งผู้ใช้";
                dataGridView1.Columns["status"].HeaderText = "สถานะ";
                dataGridView1.Columns["mail_note"].HeaderText = "หมายเหตุ";
                dataGridView1.Columns["picture"].Visible = false;
                dataGridView1.Columns["title_type"].HeaderText = "แจ้งเกี่ยวกับ";

                //ปรับขนาดคอลัมน์
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //dataGridView1.RowTemplate.Height = 200;
                dataGridView1.AllowUserToAddRows = false;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาด " + ex);
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //กำหนดสีสถานะ Yes/No
            if (dataGridView1.Rows[e.RowIndex].Cells["status"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString() == "Yes")
            {
                dataGridView1.Rows[e.RowIndex].Cells["status"].Style = new DataGridViewCellStyle { ForeColor = Color.Green };
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells["status"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString() == "No")
            {
                dataGridView1.Rows[e.RowIndex].Cells["status"].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
