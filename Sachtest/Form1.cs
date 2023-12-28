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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tk = textBox1.Text;
            string pass = textBox2.Text;
            string tktest = "";
            string passtest = "";
            if (tk == tktest)
            {
                if (pass == passtest)
                {
                    this.Hide();
                    Form1 a = new Form1();
                    Form2 FDangnhap = new Form2();
                    a.Closed += (s, args) => this.Close();
                    FDangnhap.Show();
                }
                else
                {
                    MessageBox.Show("Mật khẩu đăng nhập không đúng !!");
                }
            }
            else
            {
                MessageBox.Show("Tài khoản đăng nhập không đúng !!");

            }
          
         

        }

        private void lblSaimatkhau_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            Form3 FForgetpass = new Form3();
            a.Closed += (s, args) => this.Close();
            FForgetpass.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void TextCLick1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
