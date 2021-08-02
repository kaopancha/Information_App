using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Information_App
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void customizeDesign()
        {
            prob_submenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (prob_submenu.Visible == true)
            {
                prob_submenu.Visible = false;

            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
                btn_prob.Text = "เกี่ยวกับ E-mail  v";
                
            }
            else
            {
                subMenu.Visible = false;
                btn_prob.Text = "เกี่ยวกับ E-mail  >";
            }
        }

        private void btn_prob_Click(object sender, EventArgs e)
        {
            showSubMenu(prob_submenu);
        }
        //สำหรับเปิดหน้าแสดงข้อมูลด้านข้าง
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_asset_Click(object sender, EventArgs e)
        {
            openChildForm(new Asset_Form());
            //เปลี่ยนสี highlight
            btn_asset.BackColor = Color.PapayaWhip;
            btn_it.BackColor = Color.PowderBlue;
            btn_newmail.BackColor = Color.PowderBlue;
            btn_change.BackColor = Color.PowderBlue;
            btn_mail.BackColor = Color.PowderBlue;
            btn_internet.BackColor = Color.PowderBlue;
            btn_Allemail.BackColor = Color.PowderBlue;
        }

        private void btn_it_Click(object sender, EventArgs e)
        {
            openChildForm(new it_prob());
            //เปลี่ยนสี highlight
            btn_asset.BackColor = Color.PowderBlue;
            btn_it.BackColor = Color.PapayaWhip;
            btn_newmail.BackColor = Color.PowderBlue;
            btn_change.BackColor = Color.PowderBlue;
            btn_mail.BackColor = Color.PowderBlue;
            btn_internet.BackColor = Color.PowderBlue;
            btn_Allemail.BackColor = Color.PowderBlue;
        }

        private void btn_newmail_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Newmail_Form());
            //เปลี่ยนสี highlight
            btn_asset.BackColor = Color.PowderBlue;
            btn_it.BackColor = Color.PowderBlue;
            btn_newmail.BackColor = Color.PapayaWhip;
            btn_change.BackColor = Color.PowderBlue;
            btn_mail.BackColor = Color.PowderBlue;
            btn_internet.BackColor = Color.PowderBlue;
            btn_Allemail.BackColor = Color.PowderBlue;
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            openChildForm(new Changedepart_Form());
            //เปลี่ยนสี highlight
            btn_asset.BackColor = Color.PowderBlue;
            btn_it.BackColor = Color.PowderBlue;
            btn_newmail.BackColor = Color.PowderBlue;
            btn_change.BackColor = Color.PapayaWhip;
            btn_mail.BackColor = Color.PowderBlue;
            btn_internet.BackColor = Color.PowderBlue;
            btn_Allemail.BackColor = Color.PowderBlue;
        }

        private void btn_mail_Click(object sender, EventArgs e)
        {
            openChildForm(new Email_Form());
            //เปลี่ยนสี highlight
            btn_asset.BackColor = Color.PowderBlue;
            btn_it.BackColor = Color.PowderBlue;
            btn_newmail.BackColor = Color.PowderBlue;
            btn_change.BackColor = Color.PowderBlue;
            btn_mail.BackColor = Color.PapayaWhip;
            btn_internet.BackColor = Color.PowderBlue;
            btn_Allemail.BackColor = Color.PowderBlue;
        }

        private void btn_internet_Click(object sender, EventArgs e)
        {
            openChildForm(new Internet_Form());
            //เปลี่ยนสี highlight
            btn_asset.BackColor = Color.PowderBlue;
            btn_it.BackColor = Color.PowderBlue;
            btn_newmail.BackColor = Color.PowderBlue;
            btn_change.BackColor = Color.PowderBlue;
            btn_mail.BackColor = Color.PowderBlue;
            btn_internet.BackColor = Color.PapayaWhip;
            btn_Allemail.BackColor = Color.PowderBlue;
        }

        private void btn_Allemail_Click(object sender, EventArgs e)
        {
            openChildForm(new Allemail_Form());
            //เปลี่ยนสี highlight
            btn_asset.BackColor = Color.PowderBlue;
            btn_it.BackColor = Color.PowderBlue;
            btn_newmail.BackColor = Color.PowderBlue;
            btn_change.BackColor = Color.PowderBlue;
            btn_mail.BackColor = Color.PowderBlue;
            btn_internet.BackColor = Color.PowderBlue;
            btn_Allemail.BackColor = Color.PapayaWhip;
        }

    }
}
