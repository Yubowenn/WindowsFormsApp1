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
    public partial class 团队信息 : Form
    {
        public 团队信息(string STR)
        {
            InitializeComponent();
            string connectionStr = "Data Source=MYCOMPUTER\\SQLEXPRESS;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);//创建链接对象
            string str = "SELECT tname,tkey,username from TU,Teams where Teams.tno='" + STR + "' and Teams.tno=TU.tno";
            SqlCommand cmd = new SqlCommand(str, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            string Tname = "";
            string Tkey = "";
            string username = "";
            while (sdr.Read())
            {
                Tname = (string)sdr[0];
                 Tkey= (string)sdr[1];
                 username= (string)sdr[2];
                label1.Text = Tname;
                label2.Text = Tkey;
                label3.Text = username;
            }

            sdr.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            团队首页 fm = new 团队首页();
            fm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
