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
    public partial class 个人信息 : Form
    {
        public 个人信息(string STR)
        {
            InitializeComponent();
            string connectionStr = "Data Source=MYCOMPUTER\\SQLEXPRESS;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);//创建链接对象
            string str = "SELECT name,email,key1,key2,key3,key4 from Users where username='" + STR + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string Name = (string)sdr[0];
                string Email = (string)sdr[1];
                string Key0 = (string)sdr[2];
                string Key1 = (string)sdr[3];
                string Key2 = (string)sdr[4];
                string Key3 = (string)sdr[5];
                label4.Text = Name;
                label5.Text = Email;
                label6.Text = Key0 + Key1 + Key2 + Key3;





            }

            sdr.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            个人首页 fm = new 个人首页();
            fm.Show();
            this.Hide();
        }
    }
}
