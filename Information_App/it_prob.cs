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
    public partial class it_prob : Form
    {
        //กำหนดตัวแปรเพื่อรองรับ command (connection, sql)
        OleDbConnection connection = new OleDbConnection();
        C1 c1 = new C1();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();
        DataTable dt = new DataTable();

        public it_prob()
        {
            InitializeComponent();
            //กำหนด connection โดยดึง path รูปแบบ string จาก C1
            connection.ConnectionString = c1.con_sring();
            cmd.Connection = connection;
            cmd2.Connection = connection;
        }

        private void it_prob_Load(object sender, EventArgs e)
        {
            //try catch ใช้ดักจับ error
            try
            {
                //กำหนดค่า combobox กับ datetimepicker
                comboBox1.Text = "ทั้งหมด";
                to_date.Value = DateTime.Today;

                //นับจำนวนรายการ
                connection.Open();
                string query1 = "SELECT COUNT(*) as mycount FROM it_prob;";
                cmd.CommandText = query1;
                int record = (int)cmd.ExecuteScalar();
                count.Text = record.ToString();
                connection.Close();

                //เลือกวันที่แรกสุดของข้อมูล กำหนดค่าใน datetimepicker
                connection.Open();
                cmd2.CommandText = "SELECT MIN(getinfo_date) AS from_date FROM it_prob";
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
                c1.gridview("select * from it_prob", dt);
                dataGridView1.DataSource = dt;
                //กำหนดหัวข้อคอลัมน์ + ปิดคอลัมน์บางส่วน
                dataGridView1.Columns["getinfo_date"].HeaderText = "วัน/เดือน/ปี";
                dataGridView1.Columns["info"].HeaderText = "ข้อขัดข้อง";
                dataGridView1.Columns["com_name"].HeaderText = "ชื่อเครื่อง";
                dataGridView1.Columns["sent_name"].HeaderText = "ชื่อผู้แจ้ง";
                dataGridView1.Columns["location"].HeaderText = "ที่อยู่อุปกรณ์";
                dataGridView1.Columns["get_name"].HeaderText = "ผู้รับแจ้ง";
                dataGridView1.Columns["howto"].HeaderText = "แก้ปัญหาข้อขัดข้อง";
                dataGridView1.Columns["picture"].Visible = false;
                dataGridView1.Columns["it_detail"].DisplayIndex = 10;
                
                //คอลัมน์รูปภาพ
                //DataGridViewImageColumn imagecolumn = new DataGridViewImageColumn();
                //imagecolumn = (DataGridViewImageColumn)dataGridView1.Columns["picture"];
                //imagecolumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                //ปรับขนาดคอลัมน์
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //dataGridView1.RowTemplate.Height = 200;
                dataGridView1.AllowUserToAddRows = false;

                //ปรับชิดซ้ายบางคอลัมน์
                dataGridView1.Columns["info"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns["howto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
            
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // auto row number + ปุ่มตรวจสอบ
            this.dataGridView1.Rows[e.RowIndex].Cells["no"].Value = (e.RowIndex + 1).ToString();
            this.dataGridView1.Rows[e.RowIndex].Cells["it_detail"].Value = "ตรวจสอบ";
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
                string query1 = "SELECT COUNT(*) as mycount FROM it_prob;";
                cmd.CommandText = query1;
                int record = (int)cmd.ExecuteScalar();
                count.Text = record.ToString();
                connection.Close();

                connection.Open();
                cmd2.CommandText = "SELECT MIN(getinfo_date) AS from_date FROM it_prob";
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
                c1.gridview("select * from it_prob", dt);
                dataGridView1.DataSource = dt;

                //ลบ highlight เริ่มต้น
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void it_prob_Shown(object sender, EventArgs e)
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
                    condition = "where getinfo_date between #" + newfrom + "# and #" + newto + "#";
                }
                else
                {
                    string datatype = comboBox1.Text;
                    string stext = textBox1.Text;

                    if (datatype == "ทั้งหมด")
                    {
                        condition = "where getinfo_date between #" + newfrom + "# and #" + newto + "#";
                        condition += "and (info like '%" + stext + "%'";
                        condition += " or sent_name like '%" + stext + "%'";
                        condition += " or location like '%" + stext + "%'";
                        condition += " or get_name like '%" + stext + "%'";
                        condition += " or howto like '%" + stext + "%')";
                    }

                    else
                    {
                        if (datatype == "ข้อขัดข้อง") datatype = "info";
                        else if (datatype == "ชื่อเครื่อง") datatype = "location";
                        else if (datatype == "ที่อยู่อุปกรณ์") datatype = "location";

                        condition = "where " + datatype + " like '%" + textBox1.Text + "%' and getinfo_date between #" + newfrom + "# and #" + newto + "#";
                    }
                }
                //เคลียค่าในตาราง
                dt.Rows.Clear();

                //แสดงใน datagridview
                sql = "SELECT * FROM it_prob " + condition;
                c1.gridview(sql, dt);
                dataGridView1.DataSource = dt;

                //นับจำนวนรายการ
                connection.Open();
                string query1 = "SELECT COUNT(*) as mycount from it_prob " + condition;
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

        private void print_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "แจ้งข้อขัดข้อง IT.pdf";     //ชื่อไฟล์เริ่มต้น
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
                            BaseFont bf = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\THSarabun.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED, true);
                            BaseFont bf_bold = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\THSarabun Bold.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED, true);
                            Font ftitle = new Font(bf_bold, 18);
                            Font ftitle_2 = new Font(bf, 18);
                            Font fnt = new Font(bf_bold, 16);
                            Font fdata = new Font(bf, 16);

                            Phrase p;

                            PdfPTable pdfTable = new PdfPTable(8);      //จำนวนคอลัมน์
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            //กำหนดขนาดแต่ละคอลัมน์
                            float[] colWidths = new float[8];
                            colWidths[0] = 5f;
                            colWidths[1] = 7f;
                            colWidths[2] = 20f;
                            colWidths[3] = 8f;
                            colWidths[4] = 8f;
                            colWidths[5] = 10f;
                            colWidths[6] = 8f;
                            colWidths[7] = 20f;
                            pdfTable.SetWidths(colWidths);


                            PdfPCell cell;
                            //หัวกระดาษ
                            p = new Phrase("แจ้งข้อขัดข้อง IT", ftitle);
                            cell = new PdfPCell(p);
                            cell.Colspan = 8;           //ขนาดเท่ากับจำนวนคอลัมน์
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
                            cell.Colspan = 8;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.Border = Rectangle.NO_BORDER;
                            cell.PaddingBottom = 10;
                            pdfTable.AddCell(cell);

                            //datatable header (หัวข้อ)
                            cell = new PdfPCell(new Phrase("ลำดับ", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("วันที่", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ข้อขัดข้อง", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ชื่อเครื่อง", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ชื่อผู้แจ้ง", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ที่อยู่อุปกรณ์", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ผู้รับแจ้ง", fnt));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.PaddingBottom = 6;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("แก้ปัญหาข้อขัดข้อง", fnt));
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

                                DateTime getinfo_date = DateTime.Parse(row.Cells["getinfo_date"].Value.ToString());

                                cell = new PdfPCell(new Phrase(getinfo_date == null ?
                                    string.Empty : getinfo_date.ToString("d/M/yyyy"), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["info"].Value == null ?
                                    string.Empty : row.Cells["info"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["com_name"].Value == null ?
                                    string.Empty : row.Cells["com_name"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["sent_name"].Value == null ?
                                    string.Empty : row.Cells["sent_name"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["location"].Value == null ?
                                    string.Empty : row.Cells["location"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["get_name"].Value == null ?
                                    string.Empty : row.Cells["get_name"].Value.ToString(), fdata));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 6;
                                pdfTable.AddCell(cell);

                                cell = new PdfPCell(new Phrase(row.Cells["howto"].Value == null ?
                                    string.Empty : row.Cells["howto"].Value.ToString(), fdata));
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
            Add_IT m2 = new Add_IT();
            m2.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != 1)
            {
                //ส่ง number สำหรับค้นหาข้อมูลหน้าแก้ไข
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string Pid = row.Cells["number"].Value.ToString();
                Edit_IT f4 = new Edit_IT(Pid);
                f4.Show();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ส่ง ชื่อเครื่อง เพื่อค้นหารายละเอียดเครื่อง
                if (e.ColumnIndex == 1)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    string com_name = row.Cells["com_name"].Value.ToString();
                    IT_detail f4 = new IT_detail(com_name);
                    f4.Show();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("ผิดพลาด " + ex);
            }
        }
    }
}
