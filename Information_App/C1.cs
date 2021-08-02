using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Globalization;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Drawing;

namespace Information_App
{
    class C1
    {
        OleDbConnection connection = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public C1()
        {
            connection.ConnectionString = con_sring();
            cmd.Connection = connection;
        }


        public string con_sring()
        {
            //string สำหรับใช้ในการ connection
            string c = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Notified_Info.accdb;OLE DB Services=-1;Persist Security Info=False;";
            return c;
        }
        public void gridview(string sql, DataTable dt)
        {
            //สำหรับเพิ่มข้อมูลลงตาราง datagridview
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, connection);
            connection.Open();
            ad.Fill(dt);
            connection.Close();

        }

        //เลือกรูปภาพ
        public void selectpic(PictureBox pictureBox1)
        {
            try
            {
                OpenFileDialog ofdOpen = new OpenFileDialog();

                ofdOpen.Title = "Select Picture";
                ofdOpen.Filter = "Image Files(*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png";
                ofdOpen.ShowDialog();
                if (ofdOpen.FileName != "")
                {

                    pictureBox1.Image = new Bitmap(ofdOpen.FileName.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(" ผิดพลาด " + ex);
            }
        }

        //แปลงรูปภาพเป็น byte ถูกเรียกใช้ในปุ่มเพิ่ม
        public byte[] ImagetoByte(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (System.IO.MemoryStream memstream = new System.IO.MemoryStream())
            {
                image.Save(memstream, format);
                return memstream.ToArray();
            }
        }

        //เคลียร์รูปภาพ
        public void clearpic(PictureBox pictureBox1, Button add_pic)
        {
            pictureBox1.Image = null;
            add_pic.Enabled = true;
        }

        //กำหนดค่ารูปใส่ param
        public object addpictoparam(PictureBox pictureBox1)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                byte[] pic = ImagetoByte(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
                return pic;
            }
            else
            {
                return DBNull.Value;
            }
        }
        //เอาค่าวันที่ใส่ parameter
        public object addsenttoparam(DateTimePicker sentinfo_date, CheckBox checkBox1)
        {
            if (checkBox1.Checked == true)
            {
                var newsentinfo_date = sentinfo_date.Value.ToString();
                return newsentinfo_date;
            }
            else
            {
                return DBNull.Value;
            }
        }
    }
}


























// Developer : Praphan Katukan PNRU CS60
