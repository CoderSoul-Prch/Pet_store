using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Pet_store.authencation
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (AuthencaticateUser(usernameTextBox1.Text, passwordTextBox2.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(usernameTextBox1.Text, CheckBox1.Checked);
            }
            else
            {
                lblMessage.Text = "Invalid User Name and/or Password";
            }
        }

        private bool AuthencaticateUser(string username, string password)
        {
            string CS = ConfigurationManager.ConnectionStrings["PET_VET"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter user_name = new SqlParameter("@username", usernameTextBox1.Text);
                SqlParameter Password = new SqlParameter("@password", Encrypt(passwordTextBox2.Text));

                cmd.Parameters.Add(user_name);
                cmd.Parameters.Add(Password);

                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                return ReturnCode == 1;

            }
        }
        private static string Key = "Rohit[Dogs{Dik}]Rahul[Fish{Sap}]";
        private static string IV = "Rohit[Dogs{Dik}]";
        private static string Encrypt(string text)
        {
            Byte[] plaintextbytes = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            AesCryptoServiceProvider Aes = new AesCryptoServiceProvider();
            Aes.BlockSize = 128;
            Aes.KeySize = 256;
            Aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(Key);
            Aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            Aes.Padding = PaddingMode.PKCS7;
            Aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = Aes.CreateEncryptor(Aes.Key, Aes.IV);
            Byte[] encrypted = crypto.TransformFinalBlock(plaintextbytes, 0, plaintextbytes.Length);
            return Convert.ToBase64String(encrypted);
        }
    
    }
}