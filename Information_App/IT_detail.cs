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
    public partial class IT_detail : Form
    {
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();

        public IT_detail(string strcom_name)
        {
            InitializeComponent();
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;

            com_name.Text = strcom_name;
        }

        private void IT_detail_Load(object sender, EventArgs e)
        {
            byte[] getImg = new byte[0];

            connection.Open();

            string query1 = "SELECT * FROM it_hardware where com_name = '" + com_name.Text + "';";
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
                if (reader["res_date"] != DBNull.Value)
                {
                    res_date.Text = DateTime.Parse(reader["res_date"].ToString()).ToShortDateString();
                }
                it_note.Text = reader["it_note"].ToString();

                if (reader["picture"] != DBNull.Value)
                {
                    getImg = (byte[])reader["picture"];
                    MemoryStream stream = new MemoryStream(getImg);
                    pictureBox1.Image = Image.FromStream(stream);
                }

            }
            else 
            { 
                MessageBox.Show("ไม่พบข้อมูล");
            }

            connection.Close();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
