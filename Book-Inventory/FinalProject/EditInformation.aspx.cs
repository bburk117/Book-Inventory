using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class EditInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            textEditTitle.Focus();

        }

        protected void btnEditSubmit_Click(object sender, EventArgs e)
        {

            //Try catch block to handle errors
            try
            {

                lbl_error.Text = "";

                //Program gets and stores the values entered by the user
                double isbn = double.Parse(dropDownEditSearch.SelectedValue);
                string title = textEditTitle.Text;
                string lastname = textEditLastName.Text;
                string firstname = textEditFirstName.Text;
                double rating = double.Parse(DropDownQuestNum.SelectedValue);
                string format = rblst_format.SelectedValue;
                double newIsbn = double.Parse(textEditIsbn.Text);

                //Program updates the book table below
                BookInventoryTableAdapters.BookTableAdapter tableAdapter = new BookInventoryTableAdapters.BookTableAdapter();
                tableAdapter.UpdateBookTable(newIsbn, title, lastname, firstname, rating, format);

                //Program gets the selected categories
                bool fiction = cbEditCategory.Items.FindByText("Fiction").Selected;
                bool children = cbEditCategory.Items.FindByText("Children's").Selected;
                bool foreign = cbEditCategory.Items.FindByText("Foreign").Selected;
                bool romance = cbEditCategory.Items.FindByText("Romance").Selected;
                bool suspense = cbEditCategory.Items.FindByText("Suspense").Selected;
                bool nonfiction = cbEditCategory.Items.FindByText("Non-Fiction").Selected;
                bool comedy = cbEditCategory.Items.FindByText("Comedy").Selected;
                bool history = cbEditCategory.Items.FindByText("History").Selected;
                bool sciFi = cbEditCategory.Items.FindByText("Sci-Fi").Selected;
                bool textbook = cbEditCategory.Items.FindByText("Textbook").Selected;
                bool autobiography = cbEditCategory.Items.FindByText("AutoBiography").Selected;
                bool drama = cbEditCategory.Items.FindByText("Drama").Selected;
                bool horror = cbEditCategory.Items.FindByText("Horror").Selected;
                bool selfHelp = cbEditCategory.Items.FindByText("Self-Help").Selected;
                bool thriller = cbEditCategory.Items.FindByText("Thriller").Selected;
                bool biography = cbEditCategory.Items.FindByText("Biography").Selected;
                bool fantasy = cbEditCategory.Items.FindByText("Fantasy").Selected;
                bool religious = cbEditCategory.Items.FindByText("Religious").Selected;

                //Program updates the categories
                tableAdapter.UpdateCategories(fiction, children, foreign, romance, suspense, nonfiction, comedy, history,
                    sciFi, textbook, autobiography, drama, horror, selfHelp, thriller, biography, fantasy, religious, isbn);

                //Program displays that the operation was successful
                lbl_result.Text = "Record successfully updated for " + title;

                dropDownEditSearch.DataBind();

            }
            catch
            {

                //Program displays that an error has occurred
                lbl_error.Text = "A database error has occurred.";

            }

        }

        protected void dropDownEditSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Program clears out the current text
            lbl_result.Text = "";
            lbl_error.Text = "";

            double isbn = double.Parse(dropDownEditSearch.SelectedValue);
            double rating = 0;
            string format = "";

            BookInventoryTableAdapters.BookTableAdapter tableAdapter = new BookInventoryTableAdapters.BookTableAdapter();
            BookInventory.BookInventoryTableDataTable bookInventory = tableAdapter.GetDataByIsbn(isbn);

            //Foreach loop goes through the rows
            foreach(BookInventory.BookInventoryTableRow br in bookInventory)
            {

                //Program updates each item with the current information from the database
                textEditIsbn.Text = br.Isbn.ToString();
                textEditFirstName.Text = br.AuthorFName.ToString();
                textEditLastName.Text = br.AuthorLName.ToString();
                textEditTitle.Text = br.Title.ToString();

                cbEditCategory.Items.FindByText("Fiction").Selected = (bool)br.Fiction;
                cbEditCategory.Items.FindByText("Children's").Selected = (bool)br._Children_s;
                cbEditCategory.Items.FindByText("Foreign").Selected = (bool)br.Foreign;
                cbEditCategory.Items.FindByText("Romance").Selected = (bool)br.Romance;
                cbEditCategory.Items.FindByText("Suspense").Selected = (bool)br.Suspense;
                cbEditCategory.Items.FindByText("Non-Fiction").Selected = (bool)br._Non_Fiction;
                cbEditCategory.Items.FindByText("Comedy").Selected = (bool)br.Comedy;
                cbEditCategory.Items.FindByText("History").Selected = (bool)br.History;
                cbEditCategory.Items.FindByText("Sci-Fi").Selected = (bool)br._Sci_Fi;
                cbEditCategory.Items.FindByText("Textbook").Selected = (bool)br.Textbook;
                cbEditCategory.Items.FindByText("AutoBiography").Selected = (bool)br.Autobiography;
                cbEditCategory.Items.FindByText("Drama").Selected = (bool)br.Drama;
                cbEditCategory.Items.FindByText("Horror").Selected = (bool)br.Horror;
                cbEditCategory.Items.FindByText("Self-Help").Selected = (bool)br._Self_Help;
                cbEditCategory.Items.FindByText("Thriller").Selected = (bool)br.Thriller;
                cbEditCategory.Items.FindByText("Biography").Selected = (bool)br.Biography;
                cbEditCategory.Items.FindByText("Fantasy").Selected = (bool)br.Fantasy;
                cbEditCategory.Items.FindByText("Religious").Selected = (bool)br.Religious;

                rating = br.Rating;
                format = br.Format;

            }

            int index = DropDownQuestNum.Items.IndexOf(DropDownQuestNum.Items.FindByValue(rating.ToString()));
            DropDownQuestNum.SelectedIndex = index;

            int rbindex = rblst_format.Items.IndexOf(rblst_format.Items.FindByValue(format));
            rblst_format.SelectedIndex = rbindex;
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Program resets the form
            textEditIsbn.Text = "";
            textEditFirstName.Text = "";
            textEditLastName.Text = "";
            textEditTitle.Text = "";

            cbEditCategory.Items.FindByText("Fiction").Selected = false;
            cbEditCategory.Items.FindByText("Children's").Selected = false;
            cbEditCategory.Items.FindByText("Foreign").Selected = false;
            cbEditCategory.Items.FindByText("Romance").Selected = false;
            cbEditCategory.Items.FindByText("Suspense").Selected = false;
            cbEditCategory.Items.FindByText("Non-Fiction").Selected = false;
            cbEditCategory.Items.FindByText("Comedy").Selected = false;
            cbEditCategory.Items.FindByText("History").Selected = false;
            cbEditCategory.Items.FindByText("Sci-Fi").Selected = false;
            cbEditCategory.Items.FindByText("Textbook").Selected = false;
            cbEditCategory.Items.FindByText("AutoBiography").Selected = false;
            cbEditCategory.Items.FindByText("Drama").Selected = false;
            cbEditCategory.Items.FindByText("Horror").Selected = false;
            cbEditCategory.Items.FindByText("Self-Help").Selected = false;
            cbEditCategory.Items.FindByText("Thriller").Selected = false;
            cbEditCategory.Items.FindByText("Biography").Selected = false;
            cbEditCategory.Items.FindByText("Fantasy").Selected = false;
            cbEditCategory.Items.FindByText("Religious").Selected = false;

            DropDownQuestNum.SelectedIndex = 0;
            rblst_format.SelectedIndex = 0;

            lbl_result.Text = "";
            lbl_error.Text = "";

        }

        protected void textEditTitle_TextChanged(object sender, EventArgs e)
        {
            lbl_error.Text = "";
        }

        protected void textEditFirstName_TextChanged(object sender, EventArgs e)
        {
            lbl_error.Text = "";
        }

        protected void textEditLastName_TextChanged(object sender, EventArgs e)
        {
            lbl_error.Text = "";
        }
    }
}