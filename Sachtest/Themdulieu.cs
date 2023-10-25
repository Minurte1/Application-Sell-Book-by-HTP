using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sachtest
{
    public partial class Themdulieu : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=ACER;Initial Catalog=QuanlyNhasach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Themdulieu()
        {
            InitializeComponent();
        }

        private void Themdulieu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            command.Connection.CreateCommand();
            command.CommandText = "insert into TACGIA values(n'" + tb_MaTG.Text + "','" + tb_TenTG.Text + "','" + tb_NamsinhTG + "')";
            command.ExecuteNonQuery();
            connection.Open();
        }
    }
}
