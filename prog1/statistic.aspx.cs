using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace prog1
{
    public partial class statistic : System.Web.UI.Page
    {
        private void getData(string s_start, string s_finish)
        {
            System.Data.SqlClient.SqlConnection sqlConnection1 =
                new System.Data.SqlClient.SqlConnection("Data Source=ZHENYA-PC\\SQLEXPRESS;Initial Catalog=BasaDate;Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT SUM(rashodi.summa) AS su, kategorys.name FROM rashodi JOIN kategorys ON kategorys.id=rashodi.kategory WHERE rashodi.data>= '"+s_start+"' and rashodi.data<= '"+s_finish+"' GROUP BY kategorys.name FOR XML AUTO";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            XmlReader myXmlReader = cmd.ExecuteXmlReader();

            ListBox1.Items.Clear();

            while (myXmlReader.Read())
            {
                if (myXmlReader.HasAttributes)
                {
                    string s1 = myXmlReader.GetAttribute("su");
                    s1 = s1.Replace('.', ',');
                    s1 = (Math.Floor(Convert.ToDouble(s1) * 100) / 100).ToString();
                    string s2 = myXmlReader.GetAttribute("name");
                    ListBox1.Items.Add(s1+" : "+s2);
                }
            }

            myXmlReader.Close();
            sqlConnection1.Close();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int n = DropDownList1.SelectedIndex;
            switch (n) {
                case 0: getData(DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy")); break;
                case 1: getData(DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy"), DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy")); break;
            }
            //getData("01-01-1900", DateTime.Now.ToString("dd-MM-yyyy"));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");   
        }

    }
}