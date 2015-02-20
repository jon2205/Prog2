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
        private void vivod(List<double> ld,  List<string> ls)
        {
            
            for (int i = 0; i < ld.Count - 1; i++)
            {
                for (int j = i + 1; j < ld.Count; j++)
                {
                    if (ld[i] < ld[j])
                    {
                        double k = ld[i];
                        ld[i] = ld[j];
                        ld[j] = k;

                        string s = ls[i];
                        ls[i] = ls[j];
                        ls[j] = s;
                    }
                }
            }
            
            ListBox1.Items.Clear();

            for (int i = 0; i < ld.Count; i++)
            {
                ListBox1.Items.Add(ls[i]+" : "+ld[i].ToString());
            }
            
        }

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

            
            List<double> ld = new List<double>();
            List<string> ls = new List<string>();
            
            while (myXmlReader.Read())
            {
                if (myXmlReader.HasAttributes)
                {
                    string s1 = myXmlReader.GetAttribute("su");
                    s1 = s1.Replace('.', ',');
                    s1 = (Math.Floor(Convert.ToDouble(s1) * 100) / 100).ToString();
                    string s2 = myXmlReader.GetAttribute("name");
                    ld.Add(Convert.ToDouble(s1));
                    ls.Add(s2);
                }
            }

            myXmlReader.Close();
            sqlConnection1.Close();

            vivod(ld,ls);
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
                case 2: getData(DateTime.Now.ToString("01-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy")); break;
                case 3: getData(DateTime.Now.AddMonths(-1).ToString("01-MM-yyyy"), DateTime.Now.AddMonths(-1).ToString((DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month).ToString()+"-MM-yyyy"))); break;
                case 4: getData("01-01-1900", DateTime.Now.ToString("dd-MM-yyyy")); break;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");   
        }

    }
}