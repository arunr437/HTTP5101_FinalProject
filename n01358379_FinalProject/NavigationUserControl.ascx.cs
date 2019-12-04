using System;
using System.Collections.Generic;

namespace n01358379_FinalProject
{
    public partial class NavigationUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CMSDB db = new CMSDB();
            search(db);
        }

        void search(CMSDB db)
        {
            //query the most popular classes (most students)

            string query = "select * from page where pagestatus=true";
            List<Dictionary<String, String>> rs = db.ListPages(query);

            UserControlHeading1.InnerHtml = "<ul class=\"nav navbar-nav\">";

            foreach (Dictionary<String, String> row in rs)
            {
                UserControlHeading1.InnerHtml += "<li><a runat=\"server\" href=\"ViewPage.aspx?pageid=" + row["pageid"] + "\">"+row["pagetitle"]+"</a></li>";
            }

            UserControlHeading1.InnerHtml += "</ul>";
        }
    }
}