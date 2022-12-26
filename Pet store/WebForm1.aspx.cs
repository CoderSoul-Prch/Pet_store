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


namespace Pet_store
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


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


            protected void Button1_Click(object sender, EventArgs e)
        {

            string CS = ConfigurationManager.ConnectionStrings["PET_VET"].ConnectionString;
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_Useraccount", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter username = new SqlParameter("@user_name", usernameTextBox1.Text);

                SqlParameter mobileno = new SqlParameter("@mobile_number", mnoTextBox1.Text);

                SqlParameter email = new SqlParameter("@email_id", emailTextBox1.Text);

                SqlParameter password = new SqlParameter("@password", Encrypt(passTextBox1.Text));

                cmd.Parameters.Add(username);
                cmd.Parameters.Add(mobileno);
                cmd.Parameters.Add(email);
                cmd.Parameters.Add(password);



                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                if (ReturnCode == -1)
                {
                    conformationLabel6.Text = "User Name Taken";
                }
                else
                {
                    Response.Redirect("~/Contact.aspx");
                }
            }
        }
    }
}




