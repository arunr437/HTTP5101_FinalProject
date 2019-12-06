using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace n01358379_FinalProject
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //If the page is not being loaded in response to a postBack the ShowPage()
                CMSDB db = new CMSDB();

                // The below section of code is used to get the List of Authors from the Page table and display them in a dropdown box. Similar to CreatePage.aspx.cs
                List<HTTP_Page> pageList = new List<HTTP_Page>();
                pageList = db.ListPages("select distinct pageauthor from page;");
                foreach (HTTP_Page page in pageList)
                {
                    ListItem item = new ListItem();
                    item.Text = page.GetPageAuthor();
                    item.Value = page.GetPageAuthor();
                    page_author_list.Items.Add(item);
                }
                ListItem newAuthorItem = new ListItem();
                newAuthorItem.Text = "-------------- Add a new Author --------------";
                newAuthorItem.Value = "New";
                page_author_list.Items.Add(newAuthorItem);


                //Getting the pageid from the Request object
                string pageid = Request.QueryString["pageid"];

                //If pageid is empty the custom error message will be written, otherwise the page details will be fetched from the database and shown in the input fields. 
                if (String.IsNullOrEmpty(pageid))
                {
                    page_update.InnerHtml = "There was an error finding that student.";
                }
                else
                {
                    HTTP_Page page_record = db.ViewPage(Int32.Parse(pageid));
                    page_update.InnerHtml = page_record.GetPageTitle();
                    page_title.Text = page_record.GetPageTitle();
                    page_content.Text = page_record.GetPageContent();
                    page_author_list.SelectedValue = page_record.GetPageAuthor();
                    page_publish_date.Text = page_record.GetPagePublishDate();
                }
            }
        }

        protected void Update_Page(object sender, EventArgs e)
        {

            //This section of the code will get the updated details from the form and call the UpdatePage method. 

            // Creating a CMSDB object to use the AddPage(HTTP_Page page) method.
            CMSDB db = new CMSDB();

            //Getting the pageid from the Request object.
            string pageid = Request.QueryString["pageid"];

            //If pageid is empty the custom error message will be written, otherwise the updated data in the form will be inserted into the database.
            if (String.IsNullOrEmpty(pageid))
            {
                page_update.InnerHtml = "There was an error updating that student.";
            }
            else
            {
                //Creating a new HTTP_Page object which store the values retrieved from the form.
                HTTP_Page new_page = new HTTP_Page();

                //Code to get the values from the form and set it to the 'new_page' object.
                new_page.SetPageTitle(page_title.Text);
                new_page.SetPageContent(page_content.Text);

                //if page_publish_box is checked true will be stored in pagePublishStatus which is of Boolean type
                if (page_publish_box.Checked)
                {
                    new_page.SetPagePublishStatus(true);
                }
                else
                {
                    new_page.SetPagePublishStatus(false);
                }

                // If 'Add new author' option in selected in the drop down, the data entered in the 'page_author' textbox will be inserted into the db.
                if (page_author_list.SelectedItem.Value == "New")
                {
                    new_page.SetPageAuthor(page_author.Text);
                }
                else
                {
                    new_page.SetPageAuthor(page_author_list.SelectedItem.Value);

                }

                //Calling the UpdatePage function to update the page details into the database using try catch blocks. 
                try
                {
                    db.UpdatePage(Int32.Parse(pageid), new_page);
                    //After update the LispPages.aspx will be loaded. 
                    Response.Redirect("ListPages.aspx");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Something went wrong in the UpdateStudent Method!");
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        protected void Cancel_Page(object sender, EventArgs e)
        {
            //Page will be redirected to ListPage.aspx
            Response.Redirect("ListPages.aspx");
        }


        protected void Delete_Page(object sender, EventArgs e)
        {
            //Creating an object for the CMSDB file to execute its functions. 
            CMSDB db = new CMSDB();

            //Getting the pageId from the HTTPRequest object. 
            string pageid = Request.QueryString["pageid"];
            if (!String.IsNullOrEmpty(pageid))
            {
                //Calling the function to delete the record with the specified pageid
                db.DeletePage(Int32.Parse(pageid));
                //Redirecting back to ListPages.aspx
                Response.Redirect("ListPages.aspx");
            }
        }
    }
}