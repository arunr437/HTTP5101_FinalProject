using System;
using System.Collections.Generic;

namespace n01358379_FinalProject
{
    public partial class NavigationUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Creating an object for the CMSDB file to call its functions. 
            CMSDB db = new CMSDB();

            //Query to select the pages which are published
            string query = "select * from page where pagestatus=true";

            //Creating an List of <HTTP_Page> object to hold the List of objects returned by the 'public List<HTTP_Page> ListPages(string query)' method in CMSDB.
            List<HTTP_Page> pageList = db.ListPages(query);

            //Code to insert the HTML markup using the 'InnerHtml' property of the 'UserControlHeading1' div tag
            UserControlHeading1.InnerHtml = "<ul class=\"nav navbar-nav\">";
            foreach (HTTP_Page page in pageList)
            {
                UserControlHeading1.InnerHtml += "<li><a runat=\"server\" href=\"ViewPage.aspx?pageid=" + page.GetPageId().ToString() + "\">" + page.GetPageTitle() + "</a></li>";
            }
            UserControlHeading1.InnerHtml += "</ul>";
        }
    }
}