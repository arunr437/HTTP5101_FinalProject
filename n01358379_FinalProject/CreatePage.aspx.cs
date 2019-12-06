using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01358379_FinalProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // The below section of code is used to get the List of Authors from the Page table and display them in a dropdown box. 

            CMSDB db = new CMSDB();
            List<HTTP_Page> pageList = new List<HTTP_Page>();

            //Query to select  distinct Authors from the table to be displayed in the dropdown box.
            pageList = db.ListPages("select distinct pageauthor from page;");

            //Code to insert the list of Authors in the dropdown menu 'page_author_list' present in CreatePage.aspx. ***Not a part of the initial wireframe***
            //Using the foreach loop Authors are retrieved from the pageList object and stored in 'ListItem' which will be added to the drop down list. 
            foreach (HTTP_Page page in pageList)
            {
                ListItem item = new ListItem();
                item.Text = page.GetPageAuthor();
                item.Value = page.GetPageAuthor();
                page_author_list.Items.Add(item);
            }

            //Adding a final List Item which will be used to 'add new authors' into the table. Clicking this will show another textbox in which new author can be added. 
            ListItem newAuthorItem = new ListItem();
            newAuthorItem.Text = "-------------- Add a new Author --------------";
            newAuthorItem.Value = "New";
            page_author_list.Items.Add(newAuthorItem);
        }

        protected void Add_Page(object sender, EventArgs e)
        {
            // Creating a CMSDB object to use the AddPage(HTTP_Page page) method.
            CMSDB db = new CMSDB();

            //Creating a new HTTP_Page object which store the values retrieved from the form. s
            HTTP_Page new_page = new HTTP_Page();

            //Code to get the values from the form and set it to the 'new_page' object.
            new_page.SetPageTitle(page_title.Text);

            //if page_publish_box is checked true will be stored in pagePublishStatus which is of Boolean type
            new_page.SetPageContent(page_content.Text);
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

            //Calling the AddPage function to insert the page details into the database. 
            db.AddPage(new_page);

            //Going back to ListPages.aspx after inserting the data. 
            Response.Redirect("ListPages.aspx");
        }

    }
}