namespace Sachtest
{
    partial class FormTacGia
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
            this.tb_Xoa = new System.Windows.Forms.Button();
            this.bt_sua = new System.Windows.Forms.Button();
            this.bt_Them = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_TenTG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_MaTG = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Xoa
            // 
            this.tb_Xoa.Location = new System.Drawing.Point(88, 291);
            this.tb_Xoa.Name = "tb_Xoa";
            this.tb_Xoa.Size = new System.Drawing.Size(80, 30);
            this.tb_Xoa.TabIndex = 15;
            this.tb_Xoa.Text = "Xóa";
            this.tb_Xoa.UseVisualStyleBackColor = true;
            this.tb_Xoa.Click += new System.EventHandler(this.tb_Xoa_Click);
            // 
            // bt_sua
            // 
            this.bt_sua.Location = new System.Drawing.Point(12, 291);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(80, 30);
            this.bt_sua.TabIndex = 14;
            this.bt_sua.Text = "Sửa";
            this.bt_sua.UseVisualStyleBackColor = true;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // bt_Them
            // 
            this.bt_Them.Location = new System.Drawing.Point(167, 291);
            this.bt_Them.Name = "bt_Them";
            this.bt_Them.Size = new System.Drawing.Size(80, 30);
            this.bt_Them.TabIndex = 13;
            this.bt_Them.Text = "Thêm ";
            this.bt_Them.UseVisualStyleBackColor = true;
            this.bt_Them.Click += new System.EventHandler(this.bt_Them_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tên Tác Giả";
            // 
            // tb_TenTG
            // 
            this.tb_TenTG.Location = new System.Drawing.Point(106, 184);
            this.tb_TenTG.Name = "tb_TenTG";
            this.tb_TenTG.Size = new System.Drawing.Size(117, 22);
            this.tb_TenTG.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mã Tác Giả";
            // 
            // tb_MaTG
            // 
            this.tb_MaTG.Location = new System.Drawing.Point(106, 137);
            this.tb_MaTG.Name = "tb_MaTG";
            this.tb_MaTG.Size = new System.Drawing.Size(117, 22);
            this.tb_MaTG.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(253, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(530, 219);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ngày Sinh";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(106, 236);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(117, 22);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // FormTacGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Xoa);
            this.Controls.Add(this.bt_sua);
            this.Controls.Add(this.bt_Them);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_TenTG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_MaTG);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormTacGia";
            this.Text = "FormTacGia";
            this.Load += new System.EventHandler(this.FormTacGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tb_Xoa;
        private System.Windows.Forms.Button bt_sua;
        private System.Windows.Forms.Button bt_Them;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_TenTG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_MaTG;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}