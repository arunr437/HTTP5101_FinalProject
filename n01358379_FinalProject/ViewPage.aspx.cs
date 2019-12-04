using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;


namespace n01358379_FinalProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CMSDB db = new CMSDB();
            //showing the base record student information
            string pageid = Request.QueryString["pageid"];
            Debug.WriteLine("The page ID is " + pageid);

            if (!String.IsNullOrEmpty(pageid)) 
            {
                Debug.WriteLine("Viewing the page");
                HTTP_Page page_record = db.ViewPage(Int32.Parse(pageid));
 

                page_title.InnerHtml = page_record.GetPageTitle();
                page_body.InnerHtml = page_record.GetPageContent();
                DateTime date = Convert.ToDateTime(page_record.GetPagePublishDate());
                page_publish_date.InnerHtml += date.ToString("dd/MMM/yyyy");
            }
            else
            {
                pageId.InnerHtml = "There was an error finding that student.";
            }
        }

        protected void Delete_Page(object sender, EventArgs e)
        {
            CMSDB db = new CMSDB();
            string pageid = Request.QueryString["pageid"];
            if (!String.IsNullOrEmpty(pageid))
            {
                db.DeletePage(Int32.Parse(pageid));
                Response.Redirect("ListPages.aspx");
            }
        }

    }
}