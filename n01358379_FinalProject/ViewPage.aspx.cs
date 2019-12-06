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
            // Creating an object of the CMSDB class to call the 'ViewPage(int pageid)' functions in the database file. 
            CMSDB db = new CMSDB();
           
            //Getting the pageid passed in the URL to select the current page from the database
            string pageid = Request.QueryString["pageid"];

            //If pageid is empty the custom error message will be written, otherwise the page details will be fetched from the database. 
            if (String.IsNullOrEmpty(pageid)) 
            {
                pageId.InnerHtml = "Error findinf the page.";
            }
            else
            {
                //Creating an object of HTTP_Page to hold the HTTP_Page object which will be returned by the db.ViewPage(pageId) funciton. 
                HTTP_Page page_record = db.ViewPage(Int32.Parse(pageid));

                //Using getters to get the values from the page_record and putting them in their respective <div> tags. 
                page_title.InnerHtml = page_record.GetPageTitle();
                page_body.InnerHtml = page_record.GetPageContent();

                //Creating a DateTime object which will hold the PUBLISHDATE received from the database. 
                DateTime date = Convert.ToDateTime(page_record.GetPagePublishDate());

                //Converting the date into the 'DD/MMM/YYYY/ format and writing them in the required div tags. 
                page_publish_date.InnerHtml += date.ToString("dd/MMM/yyyy");
            }
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