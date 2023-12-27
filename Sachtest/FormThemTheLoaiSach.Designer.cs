namespace Sachtest
{
    partial class FormThemTheLoaiSach
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tb_MaTL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_TenTL = new System.Windows.Forms.TextBox();
            this.bt_Them = new System.Windows.Forms.Button();
            this.bt_sua = new System.Windows.Forms.Button();
            this.tb_Xoa = new System.Windows.Forms.Button();
            this.bt_Lammoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(247, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(530, 219);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tb_MaTL
            // 
            this.tb_MaTL.Location = new System.Drawing.Point(100, 128);
            this.tb_MaTL.Name = "tb_MaTL";
            this.tb_MaTL.Size = new System.Drawing.Size(117, 22);
            this.tb_MaTL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã TL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên Thể Loại";
            // 
            // tb_TenTL
            // 
            this.tb_TenTL.Location = new System.Drawing.Point(100, 175);
            this.tb_TenTL.Name = "tb_TenTL";
            this.tb_TenTL.Size = new System.Drawing.Size(117, 22);
            this.tb_TenTL.TabIndex = 3;
            // 
            // bt_Them
            // 
            this.bt_Them.Location = new System.Drawing.Point(12, 240);
            this.bt_Them.Name = "bt_Them";
            this.bt_Them.Size = new System.Drawing.Size(80, 30);
            this.bt_Them.TabIndex = 5;
            this.bt_Them.Text = "Thêm ";
            this.bt_Them.UseVisualStyleBackColor = true;
            this.bt_Them.Click += new System.EventHandler(this.bt_Them_Click);
            // 
            // bt_sua
            // 
            this.bt_sua.Location = new System.Drawing.Point(15, 296);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(80, 30);
            this.bt_sua.TabIndex = 6;
            this.bt_sua.Text = "Sửa";
            this.bt_sua.UseVisualStyleBackColor = true;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // tb_Xoa
            // 
            this.tb_Xoa.Location = new System.Drawing.Point(137, 240);
            this.tb_Xoa.Name = "tb_Xoa";
            this.tb_Xoa.Size = new System.Drawing.Size(80, 30);
            this.tb_Xoa.TabIndex = 7;
            this.tb_Xoa.Text = "Xóa";
            this.tb_Xoa.UseVisualStyleBackColor = true;
            this.tb_Xoa.Click += new System.EventHandler(this.tb_Xoa_Click);
            // 
            // bt_Lammoi
            // 
            this.bt_Lammoi.Location = new System.Drawing.Point(137, 296);
            this.bt_Lammoi.Name = "bt_Lammoi";
            this.bt_Lammoi.Size = new System.Drawing.Size(80, 27);
            this.bt_Lammoi.TabIndex = 8;
            this.bt_Lammoi.Text = "Làm mới";
            this.bt_Lammoi.UseVisualStyleBackColor = true;
            this.bt_Lammoi.Click += new System.EventHandler(this.bt_Lammoi_Click);
            // 
            // FormThemTheLoaiSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_Lammoi);
            this.Controls.Add(this.tb_Xoa);
            this.Controls.Add(this.bt_sua);
            this.Controls.Add(this.bt_Them);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_TenTL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_MaTL);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormThemTheLoaiSach";
            this.Text = "FormThemTheLoaiSach";
            this.Load += new System.EventHandler(this.FormThemTheLoaiSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tb_MaTL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_TenTL;
        private System.Windows.Forms.Button bt_Them;
        private System.Windows.Forms.Button bt_sua;
        private System.Windows.Forms.Button tb_Xoa;
        private System.Windows.Forms.Button bt_Lammoi;
    }
}