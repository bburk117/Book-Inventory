using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class ViewBookshelf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["IsbnTitleString"].ConnectionString;
        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //Program gets the current isbn
                double isbn = double.Parse(e.Row.Cells[0].Text);

                //Program selects the categories
                string categorySql = "SELECT Fiction, [Children's], [Foreign], Romance, Suspense, [Non-Fiction], Comedy, History, [Sci-Fi], Textbook, Autobiography, Drama, Horror, [Self-Help], Thriller, Biography, Fantasy, Religious" +
                " FROM categories WHERE Isbn = @Isbn";

                //Program stores the categories in a list
                List<string> categoryNames = new List<string>();

                //Creating a new connection to the database
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(categorySql, con))
                    {
                        //Program executes the command
                        cmd.Parameters.AddWithValue("Isbn", isbn);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            //While data is being read
                            while (reader.Read())
                            {

                                //For loop goes through the contents and adds the categories to the string
                                for (int i = 0; i < 18; i++)
                                {
                                    if (reader.GetBoolean(i) == true)
                                    {
                                        categoryNames.Add(reader.GetName(i).ToString());
                                    }
                                }

                                string cat = "";

                                //For loop creates the formatted category list
                                for (int i = 0; i < categoryNames.Count; i++)
                                {

                                    if (categoryNames.Count - i == 1)
                                    {

                                        cat += categoryNames[i];

                                    }
                                    else
                                    {

                                        cat += categoryNames[i] + ", ";

                                    }
                                }

                                //Program sets the text to the new string
                                ((Label)e.Row.FindControl("categorylbl")).Text = cat;

                            }
                        }
                    }
                }

            }
        }
    }
}