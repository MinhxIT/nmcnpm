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
namespace Phần_Mềm_QLHTTT_Cửa_Hàng_Pizza_Hut
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }
        string ConStr = @"Data Source=DESKTOP-89VADTR\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // kiểm tra có ấn nút hiện mật khẩu không 
            if (chkShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnLogin = new SqlConnection(ConStr))
            {
                cnLogin.Open();
                using (SqlCommand cmLogin = new SqlCommand())
                {
                    cmLogin.Connection = cnLogin;
                    cmLogin.CommandType = CommandType.StoredProcedure;
                    cmLogin.CommandText = "sp_login";
                    cmLogin.Parameters.AddWithValue("@sUsername", txtUsername.Text);
                    cmLogin.Parameters.AddWithValue("@sPassword", txtPassword.Text);
                    SqlDataReader readerUser = cmLogin.ExecuteReader();
                    if (readerUser.Read())
                    {
                        MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        FormMenu menu = new FormMenu(txtUsername.Text); // truyền username vào form menu 
                        menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                        txtUsername.Focus();
                    }

                }
                cnLogin.Close();// đóng kết nối


            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }

    }
}
