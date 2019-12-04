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
                
                //this connection instance is for showing data
                CMSDB db = new CMSDB();
                ShowPageInfo(db);
            }
        }

        protected void Update_Page(object sender, EventArgs e)
        {

            //this connection instance is for editing data
            CMSDB db = new CMSDB();
            string pageid = Request.QueryString["pageid"];
            if (!String.IsNullOrEmpty(pageid))
            {
                HTTP_Page new_page = new HTTP_Page();
                //set that student data
                new_page.SetPageTitle(page_title.Text);
                new_page.SetPageContent(page_content.Text);
                new_page.SetPageAuthor(page_author.Text);

                if (page_publish_box.Checked)
                {
                    new_page.SetPagePublishStatus(true);
                }
                else
                {
                    new_page.SetPagePublishStatus(false);
                }


                //add the student to the database
                try
                {
                    db.UpdatePage(Int32.Parse(pageid), new_page);
                    Response.Redirect("ListPages.aspx");
                }
                catch (Exception ex)
                {
                    
                    Debug.WriteLine("Something went wrong in the UpdateStudent Method!");
                    Debug.WriteLine(ex.ToString());
                }

            }
            else
            {
                page_update.InnerHtml = "There was an error updating that student.";
            }

        }

        protected void Cancel_Page(object sender, EventArgs e)
        {
            string pageid = Request.QueryString["pageid"];
            Response.Redirect("ListPages.aspx");
        }

        protected void ShowPageInfo(CMSDB db)
        {

            string pageid = Request.QueryString["pageid"];
            if (!String.IsNullOrEmpty(pageid))
            { 
                HTTP_Page page_record = db.ViewPage(Int32.Parse(pageid));
                page_update.InnerHtml = page_record.GetPageTitle();
                page_title.Text = page_record.GetPageTitle();
                page_content.Text = page_record.GetPageContent();
                page_author.Text = page_record.GetPageAuthor();
                page_publish_date.Text = page_record.GetPagePublishDate();
            }
            else
            {
                page_update.InnerHtml = "There was an error finding that student.";
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