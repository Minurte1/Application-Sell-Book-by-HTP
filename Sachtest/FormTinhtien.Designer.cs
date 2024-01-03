namespace Sachtest
{
    partial class FormTinhtien
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTinhtien));
            this.cb_MaNV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_MaKhachhang = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tb_Soluong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.qlnS3DataSet1 = new Sachtest.QLNS3DataSet();
            this.cb_Sach = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_GiaMua = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_Tongtien = new System.Windows.Forms.Label();
            this.bt_XacNhan = new System.Windows.Forms.Button();
            this.bt_Lammoi = new System.Windows.Forms.Button();
            this.lb_TextGiatien = new System.Windows.Forms.Label();
            this.lb_d = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlnS3DataSet1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_MaNV
            // 
            this.cb_MaNV.FormattingEnabled = true;
            this.cb_MaNV.Location = new System.Drawing.Point(207, 81);
            this.cb_MaNV.Name = "cb_MaNV";
            this.cb_MaNV.Size = new System.Drawing.Size(177, 24);
            this.cb_MaNV.TabIndex = 0;
            this.cb_MaNV.SelectedIndexChanged += new System.EventHandler(this.cb_MaNV_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "NHÂN VIÊN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "KHÁCH HÀNG";
            // 
            // cb_MaKhachhang
            // 
            this.cb_MaKhachhang.FormattingEnabled = true;
            this.cb_MaKhachhang.Location = new System.Drawing.Point(207, 111);
            this.cb_MaKhachhang.Name = "cb_MaKhachhang";
            this.cb_MaKhachhang.Size = new System.Drawing.Size(177, 24);
            this.cb_MaKhachhang.TabIndex = 2;
            this.cb_MaKhachhang.SelectedIndexChanged += new System.EventHandler(this.cb_MaKhachhang_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(68, 312);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(744, 214);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tb_Soluong
            // 
            this.tb_Soluong.Location = new System.Drawing.Point(577, 125);
            this.tb_Soluong.Name = "tb_Soluong";
            this.tb_Soluong.Size = new System.Drawing.Size(140, 22);
            this.tb_Soluong.TabIndex = 5;
            this.tb_Soluong.TextChanged += new System.EventHandler(this.cb_Soluong_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "SỐ LƯỢNG";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // qlnS3DataSet1
            // 
            this.qlnS3DataSet1.DataSetName = "QLNS3DataSet";
            this.qlnS3DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cb_Sach
            // 
            this.cb_Sach.FormattingEnabled = true;
            this.cb_Sach.Location = new System.Drawing.Point(574, 77);
            this.cb_Sach.Name = "cb_Sach";
            this.cb_Sach.Size = new System.Drawing.Size(143, 24);
            this.cb_Sach.TabIndex = 7;
            this.cb_Sach.SelectedIndexChanged += new System.EventHandler(this.cb_Sach_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "SÁCH";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lb_GiaMua
            // 
            this.lb_GiaMua.AutoSize = true;
            this.lb_GiaMua.Location = new System.Drawing.Point(741, 81);
            this.lb_GiaMua.Name = "lb_GiaMua";
            this.lb_GiaMua.Size = new System.Drawing.Size(0, 16);
            this.lb_GiaMua.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tổng tiền";
            // 
            // lb_Tongtien
            // 
            this.lb_Tongtien.AutoSize = true;
            this.lb_Tongtien.Location = new System.Drawing.Point(200, 224);
            this.lb_Tongtien.Name = "lb_Tongtien";
            this.lb_Tongtien.Size = new System.Drawing.Size(0, 16);
            this.lb_Tongtien.TabIndex = 11;
            // 
            // bt_XacNhan
            // 
            this.bt_XacNhan.Location = new System.Drawing.Point(69, 258);
            this.bt_XacNhan.Name = "bt_XacNhan";
            this.bt_XacNhan.Size = new System.Drawing.Size(100, 27);
            this.bt_XacNhan.TabIndex = 12;
            this.bt_XacNhan.Text = "XÁC NHẬN ";
            this.bt_XacNhan.UseVisualStyleBackColor = true;
            this.bt_XacNhan.Click += new System.EventHandler(this.bt_XacNhan_Click);
            // 
            // bt_Lammoi
            // 
            this.bt_Lammoi.Location = new System.Drawing.Point(186, 258);
            this.bt_Lammoi.Name = "bt_Lammoi";
            this.bt_Lammoi.Size = new System.Drawing.Size(100, 27);
            this.bt_Lammoi.TabIndex = 14;
            this.bt_Lammoi.Text = "LÀM MỚI";
            this.bt_Lammoi.UseVisualStyleBackColor = true;
            this.bt_Lammoi.Click += new System.EventHandler(this.bt_Lammoi_Click);
            // 
            // lb_TextGiatien
            // 
            this.lb_TextGiatien.AutoSize = true;
            this.lb_TextGiatien.Location = new System.Drawing.Point(676, 47);
            this.lb_TextGiatien.Name = "lb_TextGiatien";
            this.lb_TextGiatien.Size = new System.Drawing.Size(0, 16);
            this.lb_TextGiatien.TabIndex = 15;
            // 
            // lb_d
            // 
            this.lb_d.AutoSize = true;
            this.lb_d.Location = new System.Drawing.Point(812, 80);
            this.lb_d.Name = "lb_d";
            this.lb_d.Size = new System.Drawing.Size(0, 16);
            this.lb_d.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(324, 28);
            // 
            // xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem
            // 
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem.Name = "xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem";
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem.Size = new System.Drawing.Size(323, 24);
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem.Text = "XEM THÔNG TIN CHI TIẾT HÓA ĐƠN";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1
            // 
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1.Image")));
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1.Name = "xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1";
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1.Size = new System.Drawing.Size(288, 24);
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1.Text = "XEM THÔNG TIN CHI TIẾT HÓA ĐƠN";
            this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1.Click += new System.EventHandler(this.xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(12, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 47);
            this.label7.TabIndex = 21;
            this.label7.Text = "THANH TOÁN";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 27);
            this.button1.TabIndex = 22;
            this.button1.Text = "Xem Danh Sách";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // FormTinhtien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 584);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lb_d);
            this.Controls.Add(this.lb_TextGiatien);
            this.Controls.Add(this.bt_Lammoi);
            this.Controls.Add(this.bt_XacNhan);
            this.Controls.Add(this.lb_Tongtien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_GiaMua);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_Sach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Soluong);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_MaKhachhang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_MaNV);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTinhtien";
            this.Text = "FormTinhtien";
            this.Load += new System.EventHandler(this.FormTinhtien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlnS3DataSet1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_MaNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_MaKhachhang;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tb_Soluong;
        private System.Windows.Forms.Label label3;
        private QLNS3DataSet qlnS3DataSet1;
        private System.Windows.Forms.ComboBox cb_Sach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_GiaMua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_Tongtien;
        private System.Windows.Forms.Button bt_XacNhan;
        private System.Windows.Forms.Button bt_Lammoi;
        private System.Windows.Forms.Label lb_TextGiatien;
        private System.Windows.Forms.Label lb_d;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}