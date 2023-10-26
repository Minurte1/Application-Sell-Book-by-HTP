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
            command = connection.CreateCommand();
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
            
           Themdulieu themdulieu = new Themdulieu();
            themdulieu.ShowDialog();

            //command.connection.createcommand();
            //command.commandtext = "insert into sach values(n'" + tb_masach.text + "','" + tb_tensach.text + "','" + tb_matg.text + "','" + tb_matl.text + "','" + tb_giamua.text + "','" + tb_giaban.text + "', '" + tb_lantaiban.text + "','" + tb_manxb.text + "','" + tb_namxb.text + "')";
            //command.executenonquery();
            //connection.open();
            //DataRow dongmoi = table.NewRow();
            //dongmoi["MaSach"] = tb_Masach.Text;
            //dongmoi[""]




        }

        private void lb_Tensach_Click(object sender, EventArgs e)
        {

        }

        private void dgvKhosach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


//    --Tạo bảng TG 
//-- Tạo bảng NXB
//-- Tạo bảng sách
}
