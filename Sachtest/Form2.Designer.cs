namespace Sachtest
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Checkkhosach = new System.Windows.Forms.Button();
            this.btn_Taothanhvien = new System.Windows.Forms.Button();
            this.btn_Xuathoadon = new System.Windows.Forms.Button();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.btn_Tinhtien = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.panel_Left.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-2, 499);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "THOÁT";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Checkkhosach
            // 
            this.btn_Checkkhosach.BackColor = System.Drawing.Color.White;
            this.btn_Checkkhosach.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Checkkhosach.Image = ((System.Drawing.Image)(resources.GetObject("btn_Checkkhosach.Image")));
            this.btn_Checkkhosach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Checkkhosach.Location = new System.Drawing.Point(-2, 292);
            this.btn_Checkkhosach.Name = "btn_Checkkhosach";
            this.btn_Checkkhosach.Size = new System.Drawing.Size(164, 70);
            this.btn_Checkkhosach.TabIndex = 3;
            this.btn_Checkkhosach.Text = "THÊM SÁCH";
            this.btn_Checkkhosach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Checkkhosach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Checkkhosach.UseVisualStyleBackColor = false;
            this.btn_Checkkhosach.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Taothanhvien
            // 
            this.btn_Taothanhvien.BackColor = System.Drawing.Color.White;
            this.btn_Taothanhvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Taothanhvien.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Taothanhvien.Image = ((System.Drawing.Image)(resources.GetObject("btn_Taothanhvien.Image")));
            this.btn_Taothanhvien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Taothanhvien.Location = new System.Drawing.Point(-2, 223);
            this.btn_Taothanhvien.Name = "btn_Taothanhvien";
            this.btn_Taothanhvien.Size = new System.Drawing.Size(164, 70);
            this.btn_Taothanhvien.TabIndex = 4;
            this.btn_Taothanhvien.Text = "THÀNH VIÊN";
            this.btn_Taothanhvien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Taothanhvien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Taothanhvien.UseVisualStyleBackColor = false;
            this.btn_Taothanhvien.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_Xuathoadon
            // 
            this.btn_Xuathoadon.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Xuathoadon.Image = ((System.Drawing.Image)(resources.GetObject("btn_Xuathoadon.Image")));
            this.btn_Xuathoadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xuathoadon.Location = new System.Drawing.Point(-2, 154);
            this.btn_Xuathoadon.Name = "btn_Xuathoadon";
            this.btn_Xuathoadon.Size = new System.Drawing.Size(164, 70);
            this.btn_Xuathoadon.TabIndex = 5;
            this.btn_Xuathoadon.Text = "HÓA ĐƠN";
            this.btn_Xuathoadon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Xuathoadon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Xuathoadon.UseVisualStyleBackColor = true;
            this.btn_Xuathoadon.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel_Left
            // 
            this.panel_Left.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_Left.Controls.Add(this.btn_Checkkhosach);
            this.panel_Left.Controls.Add(this.btn_Tinhtien);
            this.panel_Left.Controls.Add(this.button7);
            this.panel_Left.Controls.Add(this.button6);
            this.panel_Left.Controls.Add(this.btn_Xuathoadon);
            this.panel_Left.Controls.Add(this.btn_Taothanhvien);
            this.panel_Left.Controls.Add(this.button1);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 0);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(161, 609);
            this.panel_Left.TabIndex = 6;
            // 
            // btn_Tinhtien
            // 
            this.btn_Tinhtien.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Tinhtien.Image = ((System.Drawing.Image)(resources.GetObject("btn_Tinhtien.Image")));
            this.btn_Tinhtien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Tinhtien.Location = new System.Drawing.Point(-2, 85);
            this.btn_Tinhtien.Name = "btn_Tinhtien";
            this.btn_Tinhtien.Size = new System.Drawing.Size(164, 70);
            this.btn_Tinhtien.TabIndex = 7;
            this.btn_Tinhtien.Text = "THANH TOÁN";
            this.btn_Tinhtien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Tinhtien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Tinhtien.UseVisualStyleBackColor = true;
            this.btn_Tinhtien.Click += new System.EventHandler(this.btn_Tinhtien_Click);
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(-2, 430);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(164, 70);
            this.button7.TabIndex = 9;
            this.button7.Text = "CHỨC NĂNG";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(-2, 361);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(164, 70);
            this.button6.TabIndex = 8;
            this.button6.Text = "KHÁCH HÀNG";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_Top.Controls.Add(this.label1);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(161, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(981, 65);
            this.panel_Top.TabIndex = 7;
            this.panel_Top.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Top_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // panel_Body
            // 
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(161, 65);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(981, 544);
            this.panel_Body.TabIndex = 8;
            this.panel_Body.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Body_Paint_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 609);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.panel_Top);
            this.Controls.Add(this.panel_Left);
            this.Name = "Form2";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel_Left.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Checkkhosach;
        private System.Windows.Forms.Button btn_Taothanhvien;
        private System.Windows.Forms.Button btn_Xuathoadon;
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_Body;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_Tinhtien;
    }
}