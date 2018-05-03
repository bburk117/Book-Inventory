using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Data.SqlClient;
using System.Configuration;

namespace FinalProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            textTitle.Focus();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            //Try catch block to handle errors
            try
            {

                lbl_error.Text = "";

                BookInventoryTableAdapters.BookTableAdapter tableAdapter = new BookInventoryTableAdapters.BookTableAdapter();

                //Program gets the input from the user and stores it into the variables below
                double Isbn;
                double.TryParse(textIsbn.Text, out Isbn);

                string Title = textTitle.Text.ToString();
                string AuthorLName = textLastName.Text.ToString();
                string AuthorFName = textFirstName.Text.ToString();
                double Rating = double.Parse(DropDownQuestNum.SelectedValue);
                string Format = rblst_format.SelectedValue;

                bool fiction = cbCategory.Items.FindByText("Fiction").Selected;
                bool children = cbCategory.Items.FindByText("Children's").Selected;
                bool foreign = cbCategory.Items.FindByText("Foreign").Selected;
                bool romance = cbCategory.Items.FindByText("Romance").Selected;
                bool suspense = cbCategory.Items.FindByText("Suspense").Selected;
                bool nonfiction = cbCategory.Items.FindByText("Non-Fiction").Selected;
                bool comedy = cbCategory.Items.FindByText("Comedy").Selected;
                bool history = cbCategory.Items.FindByText("History").Selected;
                bool sciFi = cbCategory.Items.FindByText("Sci-Fi").Selected;
                bool textbook = cbCategory.Items.FindByText("Textbook").Selected;
                bool autobiography = cbCategory.Items.FindByText("AutoBiography").Selected;
                bool drama = cbCategory.Items.FindByText("Drama").Selected;
                bool horror = cbCategory.Items.FindByText("Horror").Selected;
                bool selfHelp = cbCategory.Items.FindByText("Self-Help").Selected;
                bool thriller = cbCategory.Items.FindByText("Thriller").Selected;
                bool biography = cbCategory.Items.FindByText("Biography").Selected;
                bool fantasy = cbCategory.Items.FindByText("Fantasy").Selected;
                bool religious = cbCategory.Items.FindByText("Religious").Selected;

                //Sql statement to add a new item to the database
                string bookSql = "INSERT INTO [Table] "
                    + "(Isbn, Title, AuthorLName, AuthorFName, Rating, Format) "
                    + "VALUES(@Isbn, @Title, @AuthorLName, @AuthorFName, @Rating, @Format)";

                //Program adds a new item to the books table
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(bookSql, con))
                    {
                        cmd.Parameters.AddWithValue("Isbn", Isbn);
                        cmd.Parameters.AddWithValue("Title", Title);
                        cmd.Parameters.AddWithValue("AuthorLName", AuthorLName);
                        cmd.Parameters.AddWithValue("AuthorFName", AuthorFName);
                        cmd.Parameters.AddWithValue("Rating", Rating);
                        cmd.Parameters.AddWithValue("Format", Format);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                //Sql string to add a new item to the categories table
                string categorySql = "INSERT INTO Categories "
                    + "(Isbn, Fiction, [Children's], [Foreign], Romance, Suspense, [Non-Fiction], Comedy, History, [Sci-Fi], Textbook, Autobiography, Drama, Horror, [Self-Help], Thriller, Biography, Fantasy, Religious) "
                    + "VALUES(@Isbn, @Fiction, @Childrens, @Foreign, @Romance, @Suspense, @NonFiction, @Comedy, @History, @SciFi, @Textbook, @Autobiography, @Drama, @Horror, @SelfHelp, @Thriller, @Biography, @Fantasy, @Religious)";

                //Program adds it to the table
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(categorySql, con))
                    {
                        cmd.Parameters.AddWithValue("Isbn", Isbn);
                        cmd.Parameters.AddWithValue("Fiction", fiction);
                        cmd.Parameters.AddWithValue("Childrens", children);
                        cmd.Parameters.AddWithValue("Foreign", foreign);
                        cmd.Parameters.AddWithValue("Romance", romance);
                        cmd.Parameters.AddWithValue("Suspense", suspense);
                        cmd.Parameters.AddWithValue("NonFiction", nonfiction);
                        cmd.Parameters.AddWithValue("Comedy", comedy);
                        cmd.Parameters.AddWithValue("History", history);
                        cmd.Parameters.AddWithValue("SciFi", sciFi);
                        cmd.Parameters.AddWithValue("Textbook", textbook);
                        cmd.Parameters.AddWithValue("Autobiography", autobiography);
                        cmd.Parameters.AddWithValue("Drama", drama);
                        cmd.Parameters.AddWithValue("Horror", horror);
                        cmd.Parameters.AddWithValue("SelfHelp", selfHelp);
                        cmd.Parameters.AddWithValue("Thriller", thriller);
                        cmd.Parameters.AddWithValue("Biography", biography);
                        cmd.Parameters.AddWithValue("Fantasy", fantasy);
                        cmd.Parameters.AddWithValue("Religious", religious);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                //Display that the operation was successful
                lbl_result.Text = Title + " successfully inserted!";

            }
            catch
            {

                //Display that an error has occurred
                lbl_result.Text = "";
                lbl_error.Text = "A database error has occurred";

            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            //Program clears out the text
            cbCategory.ClearSelection();
            textTitle.Text = "";
            textFirstName.Text = "";
            textLastName.Text = "";
            DropDownQuestNum.Text = "N/A";
            textIsbn.Text = "";
            lbl_error.Text = "";
            lbl_result.Text = "";

        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["IsbnTitleString"].ConnectionString;
        }

        protected void textTitle_TextChanged(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            lbl_result.Text = "";
        }

        protected void textFirstName_TextChanged(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            lbl_result.Text = "";
        }

        protected void textLastName_TextChanged(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            lbl_result.Text = "";
        }

        protected void textIsbn_TextChanged(object sender, EventArgs e)
        {
            lbl_error.Text = "";
            lbl_result.Text = "";
        }
    }
}