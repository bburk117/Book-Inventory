using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Remove : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void dropDownEditSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Program gets the isbn, rating, and format
            double isbn = double.Parse(dropDownEditSearch.SelectedValue);
            double rating = 0;
            string format = "";

            //Creating objects for the table adapter and bookInventory
            BookInventoryTableAdapters.BookTableAdapter tableAdapter = new BookInventoryTableAdapters.BookTableAdapter();
            BookInventory.BookInventoryTableDataTable bookInventory = tableAdapter.GetDataByIsbn(isbn);

            //Foreach loop goes through each row of data
            foreach (BookInventory.BookInventoryTableRow br in bookInventory)
            {

                //Program sets the label text to the current record
                lblFirstName.Text = br.AuthorFName.ToString();
                lblLastName.Text = br.AuthorLName.ToString();
                lblTitle.Text = br.Title.ToString();
                lblRating.Text = br.Rating.ToString();
                rating = br.Rating;
                format = br.Format;

            }

            //Program gets the book categories
            string categorySql = "SELECT Fiction, [Children's], [Foreign], Romance, Suspense, [Non-Fiction], Comedy, History, [Sci-Fi], Textbook, Autobiography, Drama, Horror, [Self-Help], Thriller, Biography, Fantasy, Religious" +
                " FROM categories WHERE Isbn = @Isbn";

            List<string> categoryNames = new List<string>();

            //Program opens a new connection to the database
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(categorySql, con))
                {
                    
                    //Program executes the query
                    cmd.Parameters.AddWithValue("Isbn", isbn);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        //While loop adds the category names to the list of categories
                        while (reader.Read())
                        {
                            for (int i = 0; i < 18; i++)
                            {
                                if(reader.GetBoolean(i) == true)
                                {
                                    categoryNames.Add(reader.GetName(i).ToString());
                                }
                            }
                        }
                    }
                }
            }

            string cat = "";
            
            //For loop sets cat to the formatted list of categories
            for(int i = 0; i < categoryNames.Count; i++)
            {

                if(categoryNames.Count - i == 1)
                {

                    cat += categoryNames[i];

                } else
                {

                    cat += categoryNames[i] + ", ";

                }
            }

            //Program displays the categories
            lblCategories.Text = cat;
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            //Try catch block to handle errors
            try
            {

                lblError.Text = "";

                BookInventoryTableAdapters.BookTableAdapter tableAdapter = new BookInventoryTableAdapters.BookTableAdapter();

                double Isbn = double.Parse(dropDownEditSearch.SelectedValue);

                string Title = lblTitle.Text.ToString();
                string AuthorLName = lblLastName.Text.ToString();
                string AuthorFName = lblFirstName.Text.ToString();
                string Rating = lblRating.ToString();              

                //Program sets up two queries to delete from the books table, and the categories table
                string bookSql = "DELETE FROM [Table] "
                    + "WHERE Isbn = @Isbn";

                string categorySql = "DELETE FROM Categories "
                    + "WHERE Isbn = @Isbn";

                //Program executes both queries
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(bookSql, con))
                    {
                        cmd.Parameters.AddWithValue("Isbn", Isbn);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(categorySql, con))
                    {
                        cmd.Parameters.AddWithValue("Isbn", Isbn);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                //Program displays that the operation was successful
                lblResult.Text = Title + " successfully removed!";
                DataBind();

            }
            catch
            {

                //Program displays that a database error has occurred
                lblResult.Text = "";
                lblError.Text = "A database error has occurred";

            }

        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["IsbnTitleString"].ConnectionString;
        }
    }
}