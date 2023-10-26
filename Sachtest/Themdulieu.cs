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
        DataTable tableTacgia = new DataTable();
        DataTable tableTheloaisach = new DataTable();
        DataTable tableNhaxuatban = new DataTable();

        public Themdulieu()
        {
            InitializeComponent();
            command = new SqlCommand();
            command.Connection = connection;
        }
        void loadtacgia()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from TACGIA";
            adapter.SelectCommand = command;
            tableTacgia.Clear();
            adapter.Fill(tableTacgia);
            dgv_Tacgia.DataSource = tableTacgia;
        }
        void loadTheloai()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from THELOAISACH";
            adapter.SelectCommand = command;
            tableTheloaisach.Clear();
            adapter.Fill(tableTheloaisach);
            dgv_Theloaisach.DataSource = tableTheloaisach;
        }
        void loadNhaxuatban()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from NHAXUATBAN";
            adapter.SelectCommand = command;
            tableNhaxuatban.Clear();
            adapter.Fill(tableNhaxuatban);
            dgv_Nhaxuatban.DataSource = tableNhaxuatban;
        }

        private void Themdulieu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
             loadtacgia();
             loadNhaxuatban();
             loadTheloai();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            //using (SqlConnection connection = new SqlConnection(str))
            //{
            //    connection.Open();

            //    SqlCommand command = new SqlCommand();
            //    command.Connection = connection;

            //    command.CommandText = "INSERT INTO TACGIA VALUES (@MaTG, @TenTG, @NamsinhTG)";

            //    command.Parameters.Add("@MaTG", SqlDbType.Char).Value = tb_MaTG.Text;
            //    command.Parameters.Add("@TenTG", SqlDbType.NVarChar).Value = tb_TenTG.Text;
            //    command.Parameters.Add("@NamsinhTG", SqlDbType.Date).Value = tb_NamsinhTG.Text;
            //    command.CommandText = "INSERT INTO THELOAISACH VALUES (@MaTL, @TenTL)";
            //    command.Parameters.Add("@MaTL", SqlDbType.NVarChar).Value = tb_MaTL.Text;
            //    command.Parameters.Add("@TenTL", SqlDbType.NVarChar).Value = tb_TenTL.Text;
            //    command.CommandText = "INSERT INTO NHAXUATBAN VALUES (@MaNXB, @TenNXB)";
            //    command.Parameters.Add("@MaNXB", SqlDbType.NVarChar).Value = tb_MaNXB.Text;
            //    command.Parameters.Add("@TenNXB", SqlDbType.NVarChar).Value = tb_TenNXB.Text;

            //    command.ExecuteNonQuery();

            //    loadtacgia();

            //    loadNhaxuatban();
            //    loadTheloai();
            //    connection.Close();
            //}
            //try
            //{
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO TACGIA VALUES (@MaTG, @TenTG, @NamsinhTG)";
                        command.Parameters.Add("@MaTG", SqlDbType.Char).Value = tb_MaTG.Text;
                        command.Parameters.Add("@TenTG", SqlDbType.NVarChar).Value = tb_TenTG.Text;
                        command.Parameters.Add("@NamsinhTG", SqlDbType.Date).Value = tb_NamsinhTG.Text;
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO THELOAISACH VALUES (@MaTL, @TenTL)";
                        command.Parameters.Add("@MaTL", SqlDbType.NVarChar).Value = tb_MaTL.Text;
                        command.Parameters.Add("@TenTL", SqlDbType.NVarChar).Value = tb_TenTL.Text;
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO NHAXUATBAN VALUES (@MaNXB, @TenNXB)";
                        command.Parameters.Add("@MaNXB", SqlDbType.NVarChar).Value = tb_MaNXB.Text;
                        command.Parameters.Add("@TenNXB", SqlDbType.NVarChar).Value = tb_TenNXB.Text;
                        command.ExecuteNonQuery();
                    }
                    loadtacgia();
                    loadTheloai();
                    loadNhaxuatban();
                    connection.Close();
                    MessageBox.Show("Dữ liệu đã được thêm vào");
                
                }
                this.Hide();
                Themdulieu a = new Themdulieu();
                FormNhapsach FormNhapsach = new FormNhapsach();
                a.Closed += (s, args) => this.Close();
                FormNhapsach.Show();


            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("Lỗi nhập liệu, vui lòng nhập lại");
            //}
            
           



        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormNhapsach formNhapsach = new FormNhapsach();
            formNhapsach.ShowDialog();
        }

        private void dgv_Tacgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Nhaxuatban_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
