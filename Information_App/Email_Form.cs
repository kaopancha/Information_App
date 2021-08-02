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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html;

namespace Information_App
{
    public partial class Email_Form : Form
    {
        //กำหนดตัวแปรเพื่อรองรับ command (connection, sql)
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();
        DataTable dt = new DataTable();

        public Email_Form()
        {
            InitializeComponent();
            //กำหนด connection โดยดึง path รูปแบบ string จาก C1
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;
        }

        private void Email_Form_Load(object sender, EventArgs e)
        {
            //try catch ใช้ดักจับ error
            try
            {
                //กำหนดค่า combobox กับ datetimepicker
                comboBox1.Text = "ทั้งหมด";
                to_date.Value = DateTime.Today;

                //นับจำนวนรายการ
                connection.Open();
                string query1 = "SELECT COUNT(*) as mycount FROM about_email WHERE title_type = 'E';";
                cmd.CommandText = query1;
                int record = (int)cmd.ExecuteScalar();
                count.Text = record.ToString();
                connection.Close();

                //เลือกวันที่แรกสุดของข้อมูล กำหนดค่าใน datetimepicker
                connection.Open();
                cmd2.CommandText = "SELECT MIN(getinfo_date) AS from_date FROM about_email WHERE title_type = 'E'";
                OleDbDataReader reader = cmd2.ExecuteReader();
                if (reader.Read())
                {
                    from_date.Text = reader["from_date"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
            try
            {
                //แสดงใน datagridview
                dt.Locale = new System.Globalization.CultureInfo("th-TH");
                c1.gridview("select * from about_email WHERE title_type = 'E'", dt);
                dataGridView1.DataSource = dt;
                //กำหนดหัวข้อคอลัมน์ + ปิดคอลัมน์บางส่วน
                dataGridView1.Columns["pre_name"].HeaderText = "ยศ";
                dataGridView1.Columns["th_name"].HeaderText = "ชื่อ";
                dataGridView1.Columns["th_last"].HeaderText = "นามสกุล";
                dataGridView1.Columns["eng_name"].Visible = false;
                dataGridView1.Columns["people_id"].Visible = false;
                dataGridView1.Columns["gov_id"].Visible = false;
                dataGridView1.Columns["birthdate"].Visible = false;
                dataGridView1.Columns["depart"].HeaderText = "สังกัด";
                dataGridView1.Columns["rank"].HeaderText = "ตำแหน่ง";
                dataGridView1.Columns["phone"].HeaderText = "เบอร์โทรภายใน";
                dataGridView1.Columns["email"].HeaderText = "อีเมล์";
                dataGridView1.Columns["type"].HeaderText = "ประเภท";
                dataGridView1.Columns["getinfo_date"].HeaderText = "วันที่รับเรื่อง";
                dataGridView1.Columns["sentinfo_date"].HeaderText = "วันที่แจ้งผู้ใช้";
                dataGridView1.Columns["status"].HeaderText = "สถานะ";
                dataGridView1.Columns["picture"].Visible = false;
                dataGridView1.Columns["mail_note"].HeaderText = "หมายเหตุ";
                dataGridView1.Columns["title_type"].Visible = false;

                //ปรับชิดซ้ายบางคอลัมน์
                dataGridView1.Columns["th_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns["th_last"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns["depart"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns["rank"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns["email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns["type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns["mail_note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                //ปรับขนาดคอลัมน์
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //dataGridView1.RowTemplate.Height = 200;
                dataGridView1.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            //คล้ายกับส่วน load
            try
            {
                textBox1.Text = "";
                comboBox1.Text = "ทั้งหมด";
                to_date.Value = DateTime.Today;

                //นับจำนวนรายการ
                connection.Open();
                string query1 = "SELECT COUNT(*) as mycount FROM about_email WHERE title_type = 'E';";
                cmd.CommandText = query1;
                int record = (int)cmd.ExecuteScalar();
                count.Text = record.ToString();
                connection.Close();

                connection.Open();
                cmd2.CommandText = "SELECT MIN(getinfo_date) AS from_date FROM about_email WHERE title_type = 'E'";
                OleDbDataReader reader = cmd2.ExecuteReader();
                if (reader.Read())
                {
                    from_date.Text = reader["from_date"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
            try
            {
                //เคลียค่าในตาราง
                dt.Rows.Clear();
                //แสดงใน datagridview
                dt.Locale = new System.Globalization.CultureInfo("th-TH");
                c1.gridview("select * from about_email WHERE title_type = 'E'", dt);
                dataGridView1.DataSource = dt;

                //ลบ highlight เริ่มต้น
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // auto row number
            this.dataGridView1.Rows[e.RowIndex].Cells["no"].Value = (e.RowIndex + 1).ToString();
        }

        private void Email_Form_Shown(object sender, EventArgs e)
        {
            //ลบ highlight เริ่มต้น
            dataGridView1.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //กำหนดรูปแบบ คศ สำหรับค้นหาตามช่วงเวลา
                string newfrom = from_date.Value.ToString("M/d/yyyy", new CultureInfo("en-US"));
                string newto = to_date.Value.ToString("M/d/yyyy", new CultureInfo("en-US"));
                string sql, condition;

                //ส่วนเงื่อนไขของ select
                if (textBox1.Text == "")
                {
                    condition = "where title_type = 'E' and getinfo_date between #" + newfrom + "# and #" + newto + "#";     
                }
                else
                {
                    string datatype = comboBox1.Text;
                    string stext = textBox1.Text;

                    if (datatype == "ทั้งหมด")
                    {

                        condition = "where title_type = 'E' and getinfo_date between #" + newfrom + "# and #" + newto + "#";
                        condition += "and (pre_name like '%" + stext + "%'";
                        condition += " or th_name like '%" + stext + "%'";
                        condition += " or th_last like '%" + stext + "%'";
                        condition += " or depart like '%" + stext + "%'";
                        condition += " or rank like '%" + stext + "%'";
                        condition += " or phone like '%" + stext + "%'";
                        condition += " or email like '%" + stext + "%'";
                        condition += " or type like '%" + stext + "%')";
                        
                    }

                    else
                    {
                        if (datatype == "ยศ") datatype = "pre_name";
                        else if (datatype == "ชื่อ") datatype = "th_name";
                        else if (datatype == "นามสกุล") datatype = "th_last";
                        else if (datatype == "สังกัด") datatype = "depart";
                        else if (datatype == "ตำแหน่ง") datatype = "rank";
                        else if (datatype == "อีเมล์") datatype = "email";
                        else if (datatype == "ประเภท") datatype = "type";

                        condition = "where title_type = 'E' and " + datatype + " like '%" + textBox1.Text + "%' and getinfo_date between #" + newfrom + "# and #" + newto + "#";
                    }
                }
                //เคลียค่าในตาราง
                dt.Rows.Clear();

                //แสดงใน datagridview
                sql = "SELECT * FROM about_email " + condition;
                c1.gridview(sql, dt);
                dataGridView1.DataSource = dt;

                //นับจำนวนรายการ
                connection.Open();
                string query1 = "SELECT COUNT(*) as mycount from about_email " + condition;
                cmd.CommandText = query1;
                int record = (int)cmd.ExecuteScalar();
                count.Text = record.ToString();
                connection.Close();

                //ลบ highlight เริ่มต้น
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาด " + ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_email m2 = new Add_email();
            m2.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //ส่ง number สำหรับค้นหาข้อมูลหน้าแก้ไข
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string Pid = row.Cells["number"].Value.ToString();
                Edit_email f4 = new Edit_email(Pid);
                f4.Show();
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Email เข้าใช้งานไม่ได้.pdf";        //ชื่อไฟล์เริ่มต้น
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //ตรวจสอบชื่อไฟล์ซ้ำ (save ทับหรือไม่)
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            //กำหนดตัวแปรรองรับ font แต่ละขนาด 
                            //ตั้งค่าสี
                            BaseColor greenColor = WebColors.GetRGBColor("#4e8d7c");
                            BaseColor redColor = WebColors.GetRGBColor("#f05454");
                            //ตั้งค่า font
                            BaseFont bf = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\THSarabun.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED, true);
                            BaseFont bf_bold = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\THSarabun Bold.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED, true);
                            
                            iTextSharp.text.Font ftitle = new iTextSharp.text.Font(bf_bold, 16);
                            iTextSharp.text.Font fnt = new iTextSharp.text.Font(bf_bold, 12);
                            iTextSharp.text.Font fdata = new iTextSharp.text.Font(bf, 12);
                            iTextSharp.text.Font fdata_green = new iTextSharp.text.Font(bf, 12, 1, greenColor);
                            iTextSharp.text.Font fdata_red = new iTextSharp.text.Font(bf, 12, 1, redColor);

                            Phrase p;

                            PdfPTable pdfTable = new PdfPTable(13);     //จำนวนคอลัมน์
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            //กำหนดขนาดแต่ละคอลัมน์
                            float[] colWidths = new float[13];
                            colWidths[0] = 5f;
                            colWidths[1] = 4f;
                            colWidths[2] = 10f;
                            colWidths[3] = 10f;
                            colWidths[4] = 8f;
                            colWidths[5] = 8f;
                            colWidths[6] = 6f;
                            colWidths[7] = 16f;
                            colWidths[8] = 10f;
                            colWidths[9] = 8f;
                            colWidths[10] = 8f;
                            colWidths[11] = 5f;
                            colWidths[12] = 6f;
                            pdfTable.SetWidths(colWidths);


                            PdfPCell cell;
                            //หัวกระดาษ
                            p = new Phrase("กรณี E-mail เข้าใช้งานไม่ได้", ftitle);
                            cell = new PdfPCell(p);
                            cell.Colspan = 13;          //ขนาดเท่ากับจำนวนคอลัมน์
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            string newfrom = from_date.Value.ToString("d MMMM yyyy", new CultureInfo("th-TH"));
                            string newto = to_date.Value.ToString("d MMMM yyyy", new CultureInfo("th-TH"));
                            string datetext;

                            if (newfrom == newto)
                            {
                                datetext = "วันที่ " + newfrom;
                            }
                            else
                            {
                                datetext = "ตั้งแต่วันที่ " + newfrom + " ถึง " + newto;
                            }

                            p = new Phrase(datetext, ftitle);
                            cell = new PdfPCell(p);
                            cell.Colspan = 13;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            cell.PaddingBottom = 10;
                            pdfTable.AddCell(cell);

                            //datatable header (หัวข้อ)
                            cell = new PdfPCell(new Phrase("ลำดับ", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ยศ", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ชื่อ", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("นามสกุล", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("สังกัด", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ตำแหน่ง", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("เบอร์โทร ภายใน", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("อีเมล์", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ประเภท", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("วันที่รับเรื่อง", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("วันที่แจ้งผู้ใช้", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("สถานะ", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("หมายเหตุ", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            //ส่วนเนื้อหาแต่ละคอลัมน์
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                cell = new PdfPCell(new Phrase(row.Cells["no"].Value == null ?
                                    string.Empty : row.Cells["no"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["pre_name"].Value == null ?
                                    string.Empty : row.Cells["pre_name"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["th_name"].Value == null ?
                                    string.Empty : row.Cells["th_name"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["th_last"].Value == null ?
                                    string.Empty : row.Cells["th_last"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["depart"].Value == null ?
                                    string.Empty : row.Cells["depart"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["rank"].Value == null ?
                                    string.Empty : row.Cells["rank"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["phone"].Value == null ?
                                    string.Empty : row.Cells["phone"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["email"].Value == null ?
                                    string.Empty : row.Cells["email"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["type"].Value == null ?
                                    string.Empty : row.Cells["type"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                DateTime getinfo_date = DateTime.Parse(row.Cells["getinfo_date"].Value.ToString());

                                cell = new PdfPCell(new Phrase(getinfo_date == null ?
                                    string.Empty : getinfo_date.ToString("d/M/yyyy"), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfTable.AddCell(cell);

                                if (row.Cells["sentinfo_date"].Value != DBNull.Value)
                                {
                                    //แปลงวันที่
                                    DateTime sentinfo_date = DateTime.Parse(row.Cells["sentinfo_date"].Value.ToString());
                                    cell = new PdfPCell(new Phrase(sentinfo_date == null ?
                                    string.Empty : sentinfo_date.ToString("d/M/yyyy"), fdata));
                                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    cell.PaddingBottom = 6;
                                    pdfTable.AddCell(cell);
                                }
                                else
                                {
                                    cell = new PdfPCell(new Phrase(row.Cells["sentinfo_date"].Value == null ?
                                    string.Empty : row.Cells["sentinfo_date"].Value.ToString(), fdata));
                                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    cell.PaddingBottom = 6;
                                    pdfTable.AddCell(cell);
                                }

                                //เงื่อนไขสีอักษร
                                iTextSharp.text.Font font_color;
                                if (row.Cells["status"].Value.ToString() == "Yes") font_color = fdata_green;
                                else font_color = fdata_red;

                                cell = new PdfPCell(new Phrase(row.Cells["status"].Value == null ?
                                    string.Empty : row.Cells["status"].Value.ToString(), font_color));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["mail_note"].Value == null ?
                                    string.Empty : row.Cells["mail_note"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                //foreach (DataGridViewCell cell1 in row.Cells)
                                //{
                                //    pdfTable.AddCell(cell1.Value.ToString());
                                //}
                            }


                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                //ตั้งค่ากระดาษ ระยะขอบ
                                Document pdfDoc = new Document(PageSize.A4.Rotate(), 30, 30, 20, 20);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //สีอักษรสถานะ Yes/No
            if (dataGridView1.Rows[e.RowIndex].Cells["status"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString() == "Yes")
            {
                dataGridView1.Rows[e.RowIndex].Cells["status"].Style = new DataGridViewCellStyle { ForeColor = Color.Green };
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells["status"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString() == "No")
            {
                dataGridView1.Rows[e.RowIndex].Cells["status"].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
            }
        }
    }
}
