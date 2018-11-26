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

namespace WindowsFormsApp1
{
    public partial class 个人首页 : Form
    { 
        public 个人首页()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;     //禁用最后一行空白。
            dataGridView1.AllowUserToDeleteRows = false;  //禁用‘delete’键的删除功能。
            dataGridView1.ReadOnly = true;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btnModify";
            btn.HeaderText = "查看";
            btn.DefaultCellStyle.NullValue = "查看信息";
            dataGridView1.Columns.Add(btn);
            string connectionStr = "Data Source=MYCOMPUTER\\SQLEXPRESS;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);//创建链接对象
            string str = "SELECT username,name,key1,key2,key3,key4 from Users where tno is null";
            SqlDataAdapter adp = new SqlDataAdapter(str, conn);
            DataSet thisdataset = new DataSet();
            adp.Fill(thisdataset, "table");
            DataTable dt = thisdataset.Tables["table"];
            this.dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnModify" && e.RowIndex >= 0)
            {
                string str = Convert.ToString(dataGridView1.CurrentRow.Cells[1]. Value);
                个人信息 fm = new 个人信息(str);
                fm.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            主页 fm = new 主页();
            fm.Show();
            this.Hide();
        }
    }
}
