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
        DataTable table = new DataTable();
        public FormNhapsach()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       void loadtacgia()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from TACGIA";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dvgtacgia.DataSource = table;
        }
        private void FormNhapsach_Load(object sender, EventArgs e)
        {

        }
    }
}
