namespace Sachtest
{
    partial class FormNhapsach
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
            this.dvgtacgia = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgtacgia)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgtacgia
            // 
            this.dvgtacgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgtacgia.Location = new System.Drawing.Point(83, 168);
            this.dvgtacgia.Name = "dvgtacgia";
            this.dvgtacgia.RowHeadersWidth = 51;
            this.dvgtacgia.RowTemplate.Height = 24;
            this.dvgtacgia.Size = new System.Drawing.Size(591, 204);
            this.dvgtacgia.TabIndex = 0;
            this.dvgtacgia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FormNhapsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 450);
            this.Controls.Add(this.dvgtacgia);
            this.Name = "FormNhapsach";
            this.Text = "FormNhapsach";
            this.Load += new System.EventHandler(this.FormNhapsach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgtacgia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgtacgia;
    }
}