using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Information_App
{
    public partial class Asset_Form : Form
    {
        //กำหนดตัวแปรเพื่อรองรับ command (connection, sql)
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();
        DataTable dt = new DataTable();

        public Asset_Form()
        {
            InitializeComponent();
            //กำหนด connection โดยดึง path รูปแบบ string จาก C1
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;
        }

        private void Asset_Form_Load(object sender, EventArgs e)
        {
            //try catch ใช้ดักจับ error
            try
            {
                //กำหนดค่า combobox กับ datetimepicker
                comboBox1.Text = "ทั้งหมด";
                to_date.Value = DateTime.Today;

                //นับจำนวนรายการ
                connection.Open();
                string query1 = "SELECT COUNT(*) as mycount FROM it_hardware;";
                cmd.CommandText = query1;
                int record = (int)cmd.ExecuteScalar();
                count.Text = record.ToString();
                connection.Close();

                //เลือกวันที่แรกสุดของข้อมูล กำหนดค่าใน datetimepicker
                connection.Open();
                cmd2.CommandText = "SELECT MIN(res_date) AS from_date FROM it_hardware";
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
                c1.gridview("select * from it_hardware", dt);
                dataGridView1.DataSource = dt;
                //กำหนดหัวข้อคอลัมน์ + ปิดคอลัมน์บางส่วน
                dataGridView1.Columns["type"].HeaderText = "อุปกรณ์";
                dataGridView1.Columns["asset"].HeaderText = "สินทรัพย์";
                dataGridView1.Columns["mac"].HeaderText = "MAC Address ของอุปกรณ์";
                dataGridView1.Columns["sn"].HeaderText = "S/N";
                dataGridView1.Columns["cpu"].HeaderText = "CPU (รุ่น/ความเร็ว)";
                dataGridView1.Columns["brand"].HeaderText = "ยี่ห้อคอมพิวเตอร์ (รุ่น)";
                dataGridView1.Columns["com_name"].HeaderText = "ชื่อเครื่อง";
                dataGridView1.Columns["ram"].HeaderText = "Ram ความจุ";
                dataGridView1.Columns["os"].HeaderText = "OS (ระบบปฏิบัติการ)";
                dataGridView1.Columns["antivirus"].HeaderText = "AntiVirus";
                dataGridView1.Columns["location"].HeaderText = "สถานที่ติดตั้ง";
                dataGridView1.Columns["res_name"].HeaderText = "ผู้รับผิดชอบ";
                dataGridView1.Columns["res_date"].HeaderText = "วัน/เดือน/ปี";
                dataGridView1.Columns["it_note"].HeaderText = "หมายเหตุ";
                dataGridView1.Columns["picture"].Visible = false;

                //ปรับขนาดคอลัมน์
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //ปิดการเพิ่มแถวเองของ user
                dataGridView1.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }
        
        private void print_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "แบบสำรวจสินทรัพย์.pdf";    //ชื่อไฟล์เริ่มต้น
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
                            //ตั้งค่า font
                            BaseFont bf = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\tahoma.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED, true);
                            BaseFont bf_bold = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\tahoma.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED, true);
                            Font ftitle = new Font(bf_bold, 16);
                            Font ftitle_2 = new Font(bf, 16);
                            Font fnt = new Font(bf_bold, 12);
                            Font fdata = new Font(bf, 12);
                            
                            Phrase p;

                            PdfPTable pdfTable = new PdfPTable(15); //จำนวนคอลัมน์
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            //กำหนดขนาดแต่ละคอลัมน์
                            float[] colWidths = new float[15];
                            colWidths[0] = 5.5f;
                            colWidths[1] = 7f;
                            colWidths[2] = 8f;
                            colWidths[3] = 16f;
                            colWidths[4] = 23f;
                            colWidths[5] = 14f;
                            colWidths[6] = 14f;
                            colWidths[7] = 10f;
                            colWidths[8] = 6f;
                            colWidths[9] = 14f;
                            colWidths[10] = 10f;
                            colWidths[11] = 12f;
                            colWidths[12] = 10f;
                            colWidths[13] = 10f;
                            colWidths[14] = 10.5f;
                            pdfTable.SetWidths(colWidths);
                            
                            PdfPCell cell;
                            //หัวกระดาษ
                            p = new Phrase("แบบสำรวจสินทรัพย์ (อุปกรณ์) ด้านสารสนเทศโรงเรียนนายเรืออากาศนวมินทกษัตริยาธิราช", ftitle);
                            cell = new PdfPCell(p);
                            cell.Colspan = 15;     //ขนาดเท่ากับจำนวนคอลัมน์
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.Border = Rectangle.NO_BORDER;
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
                            cell.Colspan = 15;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.Border = Rectangle.NO_BORDER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            p = new Phrase("หมายเหตุ 1. ประเภทอุปกรณ์ได้แก่ Desktop (DT) = คอมพิวเตอร์, Notebook (NB) = โน๊ตบุ๊ค และ Mobile (MB) = สมาร์ทโฟน หรือ แท็บเล็ต", ftitle_2);
                            cell = new PdfPCell(p);
                            cell.Colspan = 15;
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = Rectangle.NO_BORDER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            p = new Phrase("2. ประเภทสินทรัพย์ได้แก่ Official (O) = เป็นของหน่วยงาน, Personal (P) = เป็นของส่วนตัว", ftitle_2);
                            cell = new PdfPCell(p);
                            cell.Colspan = 15;
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = Rectangle.NO_BORDER;
                            cell.PaddingBottom = 6;
                            cell.PaddingLeft = 46;
                            pdfTable.AddCell(cell);

                            p = new Phrase("3. หากสินทรัพย์เป็นของส่วนตัว ให้ระบุผู้รับผิดชอบรายบุคคล", ftitle_2);
                            cell = new PdfPCell(p);
                            cell.Colspan = 15;
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.Border = Rectangle.NO_BORDER;
                            cell.PaddingBottom = 10;
                            cell.PaddingLeft = 46;
                            pdfTable.AddCell(cell);

                            //datatable header (หัวข้อ)
                            cell = new PdfPCell(new Phrase("ลำดับ", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("อุปกรณ์", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("สินทรัพย์", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("MAC Address ของอุปกรณ์", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("S/N", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("CPU (รุ่น/ความเร็ว)", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ยี่ห้อคอมพิวเตอร์ (รุ่น)", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ชื่อเครื่อง", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("Ram ความจุ", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("OS (ระบบปฏิบัติการ)", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("AntiVirus", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("สถานที่ติดตั้ง", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ผู้รับผิดชอบ", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("วัน/เดือน/ปี", fnt));
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
                                cell = new PdfPCell(new Phrase(row.Cells["no"].Value == null?
                                    string.Empty : row.Cells["no"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["type"].Value == null?
                                    string.Empty : row.Cells["type"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["asset"].Value == null?
                                    string.Empty : row.Cells["asset"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["mac"].Value == null?
                                    string.Empty : row.Cells["mac"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["sn"].Value == null?
                                    string.Empty : row.Cells["sn"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["cpu"].Value == null?
                                    string.Empty : row.Cells["cpu"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["brand"].Value == null?
                                    string.Empty : row.Cells["brand"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["com_name"].Value == null?
                                    string.Empty : row.Cells["com_name"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["ram"].Value == null?
                                    string.Empty : row.Cells["ram"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["os"].Value == null?
                                    string.Empty : row.Cells["os"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["antivirus"].Value == null?
                                    string.Empty : row.Cells["antivirus"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["location"].Value == null?
                                    string.Empty : row.Cells["location"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["res_name"].Value == null ?
                                    string.Empty : row.Cells["res_name"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                DateTime resdate = DateTime.Parse(row.Cells["res_date"].Value.ToString());

                                cell = new PdfPCell(new Phrase(resdate == null ?
                                    string.Empty : resdate.ToString("d/M/yyyy"), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["it_note"].Value == null?
                                    string.Empty : row.Cells["it_note"].Value.ToString(), fdata));
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Asset m2 = new Add_Asset();
            m2.Show();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // auto row number
            this.dataGridView1.Rows[e.RowIndex].Cells["no"].Value = (e.RowIndex + 1).ToString();

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            //คล้ายกับส่วน load
            try
            {
                comboBox1.Text = "ทั้งหมด";
                to_date.Value = DateTime.Today;
                textBox1.Text = "";

                //นับจำนวนรายการ
                connection.Open();
                string query1 = "SELECT COUNT(*) as mycount FROM it_hardware;";
                cmd.CommandText = query1;
                int record = (int)cmd.ExecuteScalar();
                count.Text = record.ToString();
                connection.Close();

                connection.Open();
                cmd2.CommandText = "SELECT MIN(res_date) AS from_date FROM it_hardware";
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
                c1.gridview("select * from it_hardware", dt);
                dataGridView1.DataSource = dt; 

            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }

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
                    condition = "where res_date between #" + newfrom + "# and #" + newto + "#";
                }
                else
                {
                    string datatype = comboBox1.Text;
                    string stext = textBox1.Text;

                    if (datatype == "ทั้งหมด")
                    {
                        condition = "where res_date between #" + newfrom + "# and #" + newto + "#";
                        condition += "and (type like '%" + stext + "%'";
                        condition += " or asset like '%" + stext + "%'";
                        condition += " or mac like '%" + stext + "%'";
                        condition += " or sn like '%" + stext + "%'";
                        condition += " or cpu like '%" + stext + "%'";
                        condition += " or brand like '%" + stext + "%'";
                        condition += " or com_name like '%" + stext + "%'";
                        condition += " or ram like '%" + stext + "%'";
                        condition += " or os like '%" + stext + "%'";
                        condition += " or antivirus like '%" + stext + "%'";
                        condition += " or location like '%" + stext + "%'";
                        condition += " or res_name like '%" + stext + "%'";
                        condition += " or res_date like '%" + stext + "%'";
                        condition += " or it_note like '%" + stext + "%')";
                    }

                    else
                    {
                        if (datatype == "MAC Address") datatype = "mac";
                        else if (datatype == "S/N") datatype = "sn";
                        else if (datatype == "ชื่อเครื่อง") datatype = "com_name";
                        else if (datatype == "OS (ระบบปฏิบัติการ)") datatype = "os";
                        else if (datatype == "สถานที่ติดตั้ง") datatype = "location";

                        condition = "where " + datatype + " like '%" + textBox1.Text + "%' and res_date between #" + newfrom + "# and #" + newto + "#";

                    }
                }
                //เคลียค่าในตาราง
                dt.Rows.Clear();

                //แสดงใน datagridview
                sql = "SELECT * FROM it_hardware " + condition;
                c1.gridview(sql, dt);
                dataGridView1.DataSource = dt;

                //นับจำนวนรายการ
                connection.Open();
                string query1 = "SELECT COUNT(*) as mycount from it_hardware " + condition;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //ส่ง number สำหรับค้นหาข้อมูลหน้าแก้ไข
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string Pid = row.Cells["number"].Value.ToString();
                Edit_Asset f4 = new Edit_Asset(Pid);
                f4.Show();
            }
        }

        private void from_date_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Asset_Form_Shown(object sender, EventArgs e)   //ทำงานเมื่อ Form แสดง
        {
            //ลบ highlight เริ่มต้น
            dataGridView1.ClearSelection();
        }

    }
}
