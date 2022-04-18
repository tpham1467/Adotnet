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

namespace Adotnet
{
    class SinhVien
    {
        public string ID_SinhVien { get; set; }
        public string Name { get; set; }
        public Double DTB { get; set; }
        public string ID_Lop { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-55EQFV2\SQLEXPRESS07;Initial Catalog=QLSV;Integrated Security=True";
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            //MessageBox.Show(cn.State.ToString());
            string query = "Select * from SinhVien where NameSv Like 'P%' ";
            SqlCommand cm = new SqlCommand(query, cn);
            SqlDataReader reader = cm.ExecuteReader();
            List<SinhVien> db = new List<SinhVien>();
            DataTable tb = new DataTable();
            tb.Columns.AddRange(new DataColumn[]
            {
                new DataColumn{ColumnName = "MSSV", DataType = typeof(string)},
                new DataColumn{ColumnName = "NameSV", DataType = typeof(string)},
                new DataColumn{ColumnName = "DTB", DataType = typeof(float)},
                new DataColumn{ColumnName = "ID_Lop", DataType = typeof(string)},
            });
            while (reader.Read())
            {
                SinhVien sv = new SinhVien
                {
                    ID_SinhVien = reader["Id_SinhVien"].ToString(),
                    Name = reader["NameSv"].ToString(),
                    DTB = Convert.ToDouble( reader["DTB"] ) ,
                    ID_Lop = reader["ID_Lop"].ToString()
                };
                tb.Rows.Add(reader["Id_SinhVien"].ToString(), reader["NameSv"].ToString(), Convert.ToDouble(reader["DTB"]),
                    reader["ID_Lop"].ToString());
                db.Add(sv);
            }
            dataGridView1.DataSource = tb; 
            // cn.Close();

        }
    }
}
 