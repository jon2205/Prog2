﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace prog1
{
    public partial class _default : System.Web.UI.Page
    {
        //получить название категории по номеру
        private string getKategory(string s)
        {
            System.Data.SqlClient.SqlConnection sqlConnection1 =
                new System.Data.SqlClient.SqlConnection("Data Source=ZHENYA-PC\\SQLEXPRESS;Initial Catalog=BasaDate;Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM kategorys WHERE id="+s+" FOR XML AUTO";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            XmlReader myXmlReader = cmd.ExecuteXmlReader();

            myXmlReader.Read();
            string s1 = myXmlReader.GetAttribute("name");
            
            myXmlReader.Close();
            sqlConnection1.Close();
            
            return s1;
        }

        //вывод самых последних изменений
        private void outputData() 
        {
            System.Data.SqlClient.SqlConnection sqlConnection1 =
                new System.Data.SqlClient.SqlConnection("Data Source=ZHENYA-PC\\SQLEXPRESS;Initial Catalog=BasaDate;Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT TOP 30 * FROM rashodi ORDER BY data DESC FOR XML AUTO";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            XmlReader myXmlReader = cmd.ExecuteXmlReader();

            ListBox1.Items.Clear();
            
            while (myXmlReader.Read())
            {
                if (myXmlReader.HasAttributes)
                {
                    string s1 = myXmlReader.GetAttribute("data");
                    s1 = "" + s1[8] + s1[9] + "-" + s1[5] + s1[6] + "-" + s1[0] + s1[1] + s1[2] + s1[3];
                    string s2 = myXmlReader.GetAttribute("summa");
                    s2=s2.Replace('.', ',');
                    s2 = (Math.Floor(Convert.ToDouble(s2) * 100) / 100).ToString();
                    string s3 = myXmlReader.GetAttribute("kategory");
                    s3 = getKategory(s3);
                    ListBox1.Items.Add(s1 + " : " + s2 + " : " + s3);
                }
            }

            myXmlReader.Close();
            sqlConnection1.Close();
        } 

        //добавление данных в БД
        private void insertData(string s1, string s2, string s3)
        {
            System.Data.SqlClient.SqlConnection sqlConnection1 =
                new System.Data.SqlClient.SqlConnection("Data Source=ZHENYA-PC\\SQLEXPRESS;Initial Catalog=BasaDate;Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO rashodi (data, summa, kategory) VALUES ('"+s1+"',"+s2+","+s3+")";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();   
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                TextBox1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
            if (TextBox2.Text == "")
            {
                TextBox2.Text = "0,00";
            }
            outputData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s1 = TextBox1.Text.ToString();
            string s2 = TextBox2.Text.ToString();
            string s3 = (DropDownList1.SelectedIndex+1).ToString();
            s2 = s2.Replace('.', ',');

            DateTime data;
            if (DateTime.TryParse(s1, out data))
            {
                Label1.Text = "";
                for (int i = 0; i < s1.Length; i++)
                {
                    if (Char.IsDigit(s1[i]) == false)
                    {
                        s1=s1.Remove(i, 1).Insert(i, "-");
                    }
                }
            }
            else
            {
                Label1.Text = "Не правильно введена дата";
                return;
            }

            if (DateTime.Now.CompareTo(data)>=0)
            {
                Label1.Text = "";
            }
            else
            {
                Label1.Text = "Введите более ранюю дату";
                return;
            }
            
            
            double summa;
            if (Double.TryParse(s2, out summa))
            {
                Label2.Text = "";
                s2 = (Math.Floor(Convert.ToDouble(s2) * 100) / 100).ToString();
                s2 = s2.Replace(',', '.');
            }
            else
            {
                Label2.Text="Не правильно введена сумма";
                return;
            }

            insertData(s1,s2,s3);
            outputData();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("statistic.aspx");   
        }
    }
}