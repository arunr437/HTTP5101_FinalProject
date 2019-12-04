using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Web.UI.HtmlControls;
using System.Windows;

namespace n01358379_FinalProject
{
    public partial class ListPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CMSDB db = new CMSDB();
            String query = "Select * from Page";

            string searchkey = "";
            if (Page.IsPostBack)
            {
                searchkey = page_title_search.Text;
            }

            if (searchkey != "")
            {
                query += " WHERE PAGETITLE like '%" + searchkey + "%' ";
            }

            Debug.WriteLine("Before List Dictionary");
            List<Dictionary<String, String>> rs = db.ListPages(query);
            Debug.WriteLine("After List Dictionary");
            foreach (Dictionary<String, String> row in rs)
            {
                string pageid = row["pageid"];
                string pagetitle = row["pagetitle"];
                string pageauthor = row["pageauthor"];
                string pagepublishdate = row["pagedate"];
                DateTime date = Convert.ToDateTime(pagepublishdate);
                string pagepublishstatus = row["pagestatus"];
                Debug.WriteLine(pageid + pagetitle + pagepublishdate + pagepublishstatus);
                HtmlTableRow trow = new HtmlTableRow();

                HtmlTableCell tb1 = new HtmlTableCell();
                if (pagepublishstatus.ToLower() == "true")
                {
                    tb1.InnerHtml = "<a href=\"ViewPage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a>";
                    
                }
                else
                {
                    tb1.InnerText = pagetitle;
                }
                trow.Controls.Add(tb1);

                HtmlTableCell tb2 = new HtmlTableCell();
                tb2.InnerText = pageauthor;
                trow.Controls.Add(tb2); 
                
                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = date.ToString("dd/MMM/yyyy");
                trow.Controls.Add(tb3);

                HtmlTableCell tb4 = new HtmlTableCell();

                if(pagepublishstatus.ToLower()=="true")
                {
                    tb4.InnerHtml = "<p> Published </p>";
                   
                }
                else
                {
                    tb4.InnerHtml = "<p> Unpublished </p>";
               
                }
                trow.Controls.Add(tb4);
                
                HtmlTableCell tb5 = new HtmlTableCell();

                if (pagepublishstatus.ToLower() == "true")
                {
                    tb5.InnerHtml += "<input type=\"button\" value=\"View\" onclick=\"location.href='ViewPage.aspx?pageid=" + row["pageid"] + "'\" class=\"btn btn-primary rowButton\"/>";
                }
                else
                {
                    tb5.InnerHtml += "<input type=\"button\" value=\"View\" onclick=\"location.href='ViewPage.aspx?pageid=" + row["pageid"] + "'\" class=\"btn btn-primary rowButton\" disabled/>";
                }

                tb5.InnerHtml += "<input type=\"button\" value=\"Edit\" onclick=\"location.href='UpdatePage.aspx?pageid=" + row["pageid"] + "'\" class=\"btn btn-primary rowButton\"/>";
                trow.Controls.Add(tb5);
                table1.Rows.Add(trow);

            }
        }

        protected void Delete_Page(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello Bro");
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