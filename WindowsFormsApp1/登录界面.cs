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
    public partial class 登录界面 : Form
    {
        public 登录界面()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            string UserName = textBox1.Text.Trim();
            string PassWord = textBox2.Text.Trim();
            if (UserName == "")
            {
                MessageBox.Show("用户名为空，请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (PassWord == "")
            {
                MessageBox.Show("密码为空，请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string str = "SELECT count(*) from Users WHERE username= '" + UserName + "' and password= '" + PassWord + "'";
                string connectionStr = "Data Source=MYCOMPUTER\\SQLEXPRESS;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionStr);//创建链接对象
                SqlCommand cmd = new SqlCommand(str, conn);//创建命令对象
                conn.Open();//如果一个连接对象打开，那么必须在try最后关闭它
                Console.WriteLine("数据连接成功打开");
                    SqlDataReader sdr = cmd.ExecuteReader();//创建数据读取器对象
                    sdr.Read();
                    sdr.Close();
                    int n = (int)cmd.ExecuteScalar();//传回第一行，赋给n
                    if(n>=1)
                    {
                        主页 fm = new 主页();
                        fm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误", "警告",MessageBoxButtons.OK, MessageBoxIcon.Warning);//密码错误
                    }
            }
        }
        catch(Exception ex)
            {
            MessageBox.Show(ex.Message);//打印异常
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            注册界面 fm = new 注册界面();
            fm.Show();
            
        }
    }

}
