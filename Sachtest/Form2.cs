using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sachtest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form ChildForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None; 
            ChildForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(ChildForm);
            panel_Body.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();       
        }
        private void Form2_Load(object sender, EventArgs e)
        {
          
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCheckkhosach());
           

        }

        private void panel_Body_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhanvien());
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormXuathoadon());
            
        }

        private void panel_Body_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btn_Tinhtien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTinhtien());
        }

        private void btn_Nhacungcap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhacungcap());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new formKhachHang());
        }

        private void panel_Top_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
