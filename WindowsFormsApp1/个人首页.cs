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
            dataGridView1.ReadOnly = true;                //禁用单元格编辑功能
            string connectionStr = "Data Source=MYCOMPUTER\\SQLEXPRESS;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);//创建链接对象
            string str = "SELECT username,name,key1,key2,key3,key4 from Users where team is null";
            SqlDataAdapter adp = new SqlDataAdapter(str, conn);
            DataSet thisdataset = new DataSet();
            adp.Fill(thisdataset, "table");
            DataTable dt = thisdataset.Tables["table"];
            this.dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            MessageBox.Show(e.ColumnIndex.ToString());//点击的单元格的列索引
        }
    }
}
