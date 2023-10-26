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
    public partial class FormNhapsach : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=ACER;Initial Catalog=QuanlyNhasach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tablesach = new DataTable();
        public FormNhapsach()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
       void loadSach()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from SACH";
            adapter.SelectCommand = command;
           tablesach.Clear();
            adapter.Fill(tablesach);
            dvg_Sach.DataSource = tablesach;
        }
        private void FormNhapsach_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadSach();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO SACH VALUES (@MaSach, @TenSach, @MaTG, @MaTL, @GiaMua, @GiaBia, @LanTaiBan, @MaNXB, @NamXuatBan)";
                    command.Parameters.Add("@MaSach", SqlDbType.NVarChar).Value = tb_Masach1.Text;
                    command.Parameters.Add("@TenSach", SqlDbType.NVarChar).Value = tb_Tensach1.Text;
                    command.Parameters.Add("@MaTG", SqlDbType.Char).Value = tb_Matg1.Text;
                    command.Parameters.Add("@MaTL", SqlDbType.NVarChar).Value = tb_Matl1.Text;
                    command.Parameters.Add("@GiaMua", SqlDbType.Int).Value = tb_Giamua1.Text;
                    command.Parameters.Add("@GiaBia", SqlDbType.Int).Value = tb_GiaBia1.Text;
                    command.Parameters.Add("@LanTaiBan", SqlDbType.Int).Value = tb_Lantaiban1.Text;
                    command.Parameters.Add("@MaNXB", SqlDbType.NVarChar).Value = tb_Manxb1.Text;
                    command.Parameters.Add("@NamXuatBan", SqlDbType.Int).Value = tb_Namxb1.Text;

                    command.ExecuteNonQuery();
                }
            }
    }
    }
}
