using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sachtest
{
    public partial class FormCheckkhosach : Form
    {
        public FormCheckkhosach()
        {
            InitializeComponent();

        }
        
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=ACER;Initial Catalog=QuanlyNhasach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddatasach()
        {
            command  = connection.CreateCommand();
            command.CommandText = "select * from SACH";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvKhosach.DataSource = table;
        }
        private void FormCheckkhosach_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddatasach();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void thêmDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
       

            
                command.Connection.CreateCommand();
                command.CommandText = "insert into SACH values(N'" + tb_Masach.Text + "','" + tb_Tensach.Text + "','" + tb_Matg.Text + "','"+ tb_Matl.Text + "','" + tb_Giamua.Text + "','" + tb_Giaban.Text + "', '"+ tb_Lantaiban.Text +"','"+ tb_Manxb.Text + "','" + tb_Namxb.Text + "')";
                command.ExecuteNonQuery();
                  
            
       
           

        }

        private void lb_Tensach_Click(object sender, EventArgs e)
        {

        }
    }
}
