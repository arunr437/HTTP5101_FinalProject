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

        }

        protected void Add_Page(object sender, EventArgs e)
        {
            //create connection
            CMSDB db = new CMSDB();

            //create a new particular student
            HTTP_Page new_page = new HTTP_Page();
            //set that student data
            new_page.SetPageTitle(page_title.Text);
            new_page.SetPageContent(page_content.Text);
            if (page_publish_box.Checked)
            {
                new_page.SetPagePublishStatus(true);
            }
            else
            {
                new_page.SetPagePublishStatus(false);
            }
            new_page.SetPageAuthor(page_author.Text);
            new_page.SetPageMainContent1(page_main_column_1.Text);
            new_page.SetPageMainContent2(page_main_column_2.Text);


            //add the student to the database
            db.AddPage(new_page);
            Response.Redirect("ListPages.aspx");
        }

    }
}