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
            command = new SqlCommand();
            command.Connection = connection;
        }

        private void Themdulieu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
          
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
            // Create a parameterized query
           

            // Execute the query
      
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
         

            // Execute the query
         

            // Close the connection
        
        }

        private void button3_Click(object sender, EventArgs e)

        {
            connection.Open();
            command.CommandText = "INSERT INTO TACGIA VALUES (@MaTG, @TenTG, @NamsinhTG)";
            command.Parameters.Add("@MaTG", SqlDbType.NVarChar).Value = tb_MaTG.Text;
            command.Parameters.Add("@TenTG", SqlDbType.NVarChar).Value = tb_TenTG.Text;
            command.Parameters.Add("@NamsinhTG", SqlDbType.Int).Value = tb_NamsinhTG.Text;
            command.CommandText = "INSERT INTO THELOAISACH VALUES (@MaTL, @TenTL)";
            command.Parameters.Add("@MaTL", SqlDbType.NVarChar).Value = tb_MaTL.Text;
            command.Parameters.Add("@TenTL", SqlDbType.NVarChar).Value = tb_TenTL.Text;
            command.CommandText = "INSERT INTO THELOAISACH VALUES (@MaNXB, @TenNXB)";
            command.Parameters.Add("@MaNXB", SqlDbType.NVarChar).Value = tb_MaNXB.Text;
            command.Parameters.Add("@TenNXB", SqlDbType.NVarChar).Value = tb_TenNXB.Text;


            // Execute the query
            command.ExecuteNonQuery();

            // Close the connection
            connection.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormNhapsach formNhapsach = new FormNhapsach();
            formNhapsach.ShowDialog();
        }
    }
}
