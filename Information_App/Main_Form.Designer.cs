namespace Information_App
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.prob_submenu = new System.Windows.Forms.Panel();
            this.btn_Allemail = new System.Windows.Forms.Button();
            this.btn_internet = new System.Windows.Forms.Button();
            this.btn_mail = new System.Windows.Forms.Button();
            this.btn_change = new System.Windows.Forms.Button();
            this.btn_newmail = new System.Windows.Forms.Button();
            this.btn_prob = new System.Windows.Forms.Button();
            this.btn_it = new System.Windows.Forms.Button();
            this.btn_asset = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.prob_submenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Controls.Add(this.prob_submenu);
            this.panel1.Controls.Add(this.btn_prob);
            this.panel1.Controls.Add(this.btn_it);
            this.panel1.Controls.Add(this.btn_asset);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 536);
            this.panel1.TabIndex = 0;
            // 
            // btn_exit
            // 
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(0, 482);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_exit.Size = new System.Drawing.Size(230, 40);
            this.btn_exit.TabIndex = 8;
            this.btn_exit.Text = "ออกจากโปรแกรม";
            this.btn_exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // prob_submenu
            // 
            this.prob_submenu.Controls.Add(this.btn_Allemail);
            this.prob_submenu.Controls.Add(this.btn_internet);
            this.prob_submenu.Controls.Add(this.btn_mail);
            this.prob_submenu.Controls.Add(this.btn_change);
            this.prob_submenu.Controls.Add(this.btn_newmail);
            this.prob_submenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.prob_submenu.Location = new System.Drawing.Point(0, 234);
            this.prob_submenu.Name = "prob_submenu";
            this.prob_submenu.Size = new System.Drawing.Size(230, 248);
            this.prob_submenu.TabIndex = 1;
            // 
            // btn_Allemail
            // 
            this.btn_Allemail.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_Allemail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Allemail.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Allemail.FlatAppearance.BorderSize = 0;
            this.btn_Allemail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Allemail.Font = new System.Drawing.Font("TH SarabunPSK", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Allemail.Location = new System.Drawing.Point(0, 200);
            this.btn_Allemail.Name = "btn_Allemail";
            this.btn_Allemail.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_Allemail.Size = new System.Drawing.Size(230, 40);
            this.btn_Allemail.TabIndex = 10;
            this.btn_Allemail.Text = "E-mail ที่รับแจ้งทั้งหมด";
            this.btn_Allemail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Allemail.UseVisualStyleBackColor = false;
            this.btn_Allemail.Click += new System.EventHandler(this.btn_Allemail_Click);
            // 
            // btn_internet
            // 
            this.btn_internet.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_internet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_internet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_internet.FlatAppearance.BorderSize = 0;
            this.btn_internet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_internet.Font = new System.Drawing.Font("TH SarabunPSK", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_internet.Location = new System.Drawing.Point(0, 120);
            this.btn_internet.Name = "btn_internet";
            this.btn_internet.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_internet.Size = new System.Drawing.Size(230, 80);
            this.btn_internet.TabIndex = 9;
            this.btn_internet.Text = "(I) Internet Authentication เข้าใช้งานไม่ได้";
            this.btn_internet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_internet.UseVisualStyleBackColor = false;
            this.btn_internet.Click += new System.EventHandler(this.btn_internet_Click);
            // 
            // btn_mail
            // 
            this.btn_mail.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_mail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_mail.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_mail.FlatAppearance.BorderSize = 0;
            this.btn_mail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mail.Font = new System.Drawing.Font("TH SarabunPSK", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mail.Location = new System.Drawing.Point(0, 80);
            this.btn_mail.Name = "btn_mail";
            this.btn_mail.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_mail.Size = new System.Drawing.Size(230, 40);
            this.btn_mail.TabIndex = 8;
            this.btn_mail.Text = "(E) E-mail เข้าใช้งานไม่ได้";
            this.btn_mail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_mail.UseVisualStyleBackColor = false;
            this.btn_mail.Click += new System.EventHandler(this.btn_mail_Click);
            // 
            // btn_change
            // 
            this.btn_change.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_change.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_change.FlatAppearance.BorderSize = 0;
            this.btn_change.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_change.Font = new System.Drawing.Font("TH SarabunPSK", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_change.Location = new System.Drawing.Point(0, 40);
            this.btn_change.Name = "btn_change";
            this.btn_change.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_change.Size = new System.Drawing.Size(230, 40);
            this.btn_change.TabIndex = 7;
            this.btn_change.Text = "(C) ข้าราชการย้ายสังกัด";
            this.btn_change.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_change.UseVisualStyleBackColor = false;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // btn_newmail
            // 
            this.btn_newmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_newmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_newmail.FlatAppearance.BorderSize = 0;
            this.btn_newmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_newmail.Font = new System.Drawing.Font("TH SarabunPSK", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newmail.Location = new System.Drawing.Point(0, 0);
            this.btn_newmail.Name = "btn_newmail";
            this.btn_newmail.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.btn_newmail.Size = new System.Drawing.Size(230, 40);
            this.btn_newmail.TabIndex = 6;
            this.btn_newmail.Text = "(N) สมัคร E-mail ใหม่";
            this.btn_newmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_newmail.UseVisualStyleBackColor = true;
            this.btn_newmail.Click += new System.EventHandler(this.btn_newmail_Click_1);
            // 
            // btn_prob
            // 
            this.btn_prob.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_prob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_prob.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_prob.FlatAppearance.BorderSize = 0;
            this.btn_prob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prob.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prob.Location = new System.Drawing.Point(0, 194);
            this.btn_prob.Name = "btn_prob";
            this.btn_prob.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_prob.Size = new System.Drawing.Size(230, 40);
            this.btn_prob.TabIndex = 5;
            this.btn_prob.Text = "เกี่ยวกับ E-mail  >";
            this.btn_prob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_prob.UseVisualStyleBackColor = false;
            this.btn_prob.Click += new System.EventHandler(this.btn_prob_Click);
            // 
            // btn_it
            // 
            this.btn_it.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_it.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_it.FlatAppearance.BorderSize = 0;
            this.btn_it.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_it.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_it.Location = new System.Drawing.Point(0, 154);
            this.btn_it.Name = "btn_it";
            this.btn_it.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_it.Size = new System.Drawing.Size(230, 40);
            this.btn_it.TabIndex = 2;
            this.btn_it.Text = "แจ้งข้อขัดข้อง IT";
            this.btn_it.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_it.UseVisualStyleBackColor = true;
            this.btn_it.Click += new System.EventHandler(this.btn_it_Click);
            // 
            // btn_asset
            // 
            this.btn_asset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_asset.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_asset.FlatAppearance.BorderSize = 0;
            this.btn_asset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_asset.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_asset.Location = new System.Drawing.Point(0, 114);
            this.btn_asset.Name = "btn_asset";
            this.btn_asset.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btn_asset.Size = new System.Drawing.Size(230, 40);
            this.btn_asset.TabIndex = 1;
            this.btn_asset.Text = "แบบสำรวจสินทรัพย์";
            this.btn_asset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_asset.UseVisualStyleBackColor = true;
            this.btn_asset.Click += new System.EventHandler(this.btn_asset_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 114);
            this.panel2.TabIndex = 1;
            // 
            // panelChildForm
            // 
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(230, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(954, 536);
            this.panelChildForm.TabIndex = 1;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1184, 536);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panel1);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ระบบการจัดการข้อมูลภายในกองเทคโนโลยีสารสนเทศและการสื่อสาร";
            this.panel1.ResumeLayout(false);
            this.prob_submenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_it;
        private System.Windows.Forms.Button btn_asset;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_prob;
        private System.Windows.Forms.Panel prob_submenu;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btn_newmail;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Button btn_mail;
        private System.Windows.Forms.Button btn_internet;
        private System.Windows.Forms.Button btn_Allemail;
    }
}

