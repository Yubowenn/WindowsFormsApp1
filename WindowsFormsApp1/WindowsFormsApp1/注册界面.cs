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
    public partial class 注册界面 : Form
    {
        public 注册界面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = textBox1.Text.Trim();
                string PassWord = textBox2.Text.Trim();
                string TEL = textBox3.Text.Trim();
                string Email = textBox4.Text.Trim();
                string Name = textBox9.Text.Trim();
                string Key1 = textBox5.Text.Trim();
                string Key2 = textBox6.Text.Trim();
                string Key3 = textBox7.Text.Trim();
                string Key4 = textBox8.Text.Trim();
                if (UserName == "")
                {
                    MessageBox.Show("用户名为空，请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (PassWord == "")
                {
                    MessageBox.Show("密码为空，请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (TEL == "")
                {
                    MessageBox.Show("电话号码为空，请输入电话号码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Email == "")
                {
                    MessageBox.Show("电子邮箱为空，请输入电子邮箱", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Name == "")
                {
                    MessageBox.Show("姓名为空，请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Key1 == "")
                {
                    MessageBox.Show("缺少个人标签，请输入个人标签", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string str = "INSERT into Users values('" + UserName + "','" + PassWord + "','" + TEL + "','" + Email + "','" + Name + "','" + Key1 + "','" + Key2 + "','" + Key3 + "','" + Key4 + "',null)";
                    string str1 = "SELECT username from Users where username = '" + UserName + "'";
                    string str2 = "SELECT tel from Users where tel = '" + TEL + "'";
                    string str3 = "SELECT email from Users where email = '" + Email + "'";

                    string connectionStr = "Data Source=MYCOMPUTER\\SQLEXPRESS;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(connectionStr);//创建链接对象
                    conn.Open(); //如果一个连接对象打开，那么必须在try最后关闭它
                    Console.WriteLine("数据连接成功打开");
                    SqlCommand cmd1 = new SqlCommand(str1, conn);
                    SqlCommand cmd2 = new SqlCommand(str2, conn);
                    SqlCommand cmd3 = new SqlCommand(str3, conn);


                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    bool a1 = dr1.HasRows;
                    dr1.Close();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    bool a2 = dr2.HasRows;
                    dr2.Close();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    bool a3 = dr3.HasRows;

                    dr3.Close();
                    if (a1)
                    {
                        MessageBox.Show("已存在该用户名！", "提示");
                        textBox1.Focus();
                    }


                    else if (a2)
                    {
                        MessageBox.Show("已存在该电话号码！", "提示");
                        textBox3.Focus();
                    }


                    else if (a3)
                    {
                        MessageBox.Show("已存在该邮箱号码！", "提示");
                        textBox4.Focus();
                    }

                    else
                    {
                        SqlCommand cmd = new SqlCommand(str, conn);//创建命令对象
                        int ret = (int)cmd.ExecuteNonQuery();
                        //创建数据读取器对象
                        if (ret > 0)
                        {
                            MessageBox.Show("注册成功！");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("注册失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);//密码错误
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//打印异常
            }
        }

    }
}
