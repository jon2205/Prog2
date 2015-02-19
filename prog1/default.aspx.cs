using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prog1
{
    public partial class _default : System.Web.UI.Page
    {
        private void insertData(string s1, string s2, string s3)
        {
            System.Data.SqlClient.SqlConnection sqlConnection1 =
                new System.Data.SqlClient.SqlConnection("Data Source=ZHENYA-PC\\SQLEXPRESS;Initial Catalog=BasaDate;Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO rashodi (data, summa, kategory) VALUES ('" + s1 + "',"+s2+","+s3+")";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery().ToString();
            sqlConnection1.Close();   
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                TextBox1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s1 = TextBox1.Text.ToString();
            string s2 = TextBox2.Text.ToString();
            string s3 = (DropDownList1.SelectedIndex+1).ToString();
            
            insertData(s1,s2,s3);
        }
    }
}