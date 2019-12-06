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
            //Creating a CMSDB object to call the ListPages(String query) function. 
            CMSDB db = new CMSDB();

            //Query that will be passed to the ListPages(String query) function.
            String query = "Select * from Page";

            //Code to get the text entered in the searchbox. 
            string searchkey = "";
            if (Page.IsPostBack)
            {
                searchkey = page_title_search.Text;
            }
            //If text is entered in the searchbox a 'Where' clause with 'like' is added to the query. 
            if (searchkey != "")
            {
                query += " WHERE PAGETITLE like '%" + searchkey + "%' ";
            }

            //Creating an List of <HTTP_Page> object to hold the List of objects returned by the 'public List<HTTP_Page> ListPages(string query)' method in CMSDB.
            List<HTTP_Page> pageList = db.ListPages(query);

            //Code to loop through pageList, which contains a List of HTTP_Page object, and get the required details which will be appeded to the table. 
            foreach (HTTP_Page page in pageList)
            {
                //Getting the required fields from each record in the table. 
                int pageid = page.GetPageId();
                string pagetitle = page.GetPageTitle();
                string pageauthor = page.GetPageAuthor();
                string pagepublishdate = page.GetPagePublishDate();
                //Creating a DateTime object to hold the Page Publish Date.
                DateTime date = Convert.ToDateTime(pagepublishdate);
                string pagepublishstatus = page.GetPagePublishStatus().ToString();

                //Creating a HtmlTableRow object trow which will be used to store a single row and eventually be inserted in the HTML markup's <table id="table1"> tag
                HtmlTableRow trow = new HtmlTableRow();

                //Creating a HtmlTableCell object which will contain individual cells that will be put into the HtmlTableRow tRow that was just created. 
                HtmlTableCell cell1 = new HtmlTableCell();
                if (pagepublishstatus.ToLower() == "true")
                {
                    cell1.InnerHtml = "<a href=\"ViewPage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a>";
                    
                }
                else
                {
                    cell1.InnerText = pagetitle;
                }
                //Adding the current HtmlTableCell (cell1) in the HttpTableRow tRow.
                trow.Controls.Add(cell1);

                //Creating and adding  HtmlTableCell (cell2) in the HttpTableRow tRow.
                HtmlTableCell cell2 = new HtmlTableCell();
                cell2.InnerText = pageauthor;
                trow.Controls.Add(cell2);

                //Creating and adding  HtmlTableCell (cell3) in the HttpTableRow tRow.
                HtmlTableCell cell3 = new HtmlTableCell();
                //Displaying the Date in the 'dd/MMM/yyyy' format in the markup by using the ToString function of dateTime.
                cell3.InnerText = date.ToString("dd/MMM/yyyy");
                trow.Controls.Add(cell3);

                //Creating and adding  HtmlTableCell (cell4) in the HttpTableRow tRow.
                HtmlTableCell cell4 = new HtmlTableCell();
                if(pagepublishstatus.ToLower()=="true")
                {
                    cell4.InnerHtml = "<p> Published </p>";
                   
                }
                else
                {
                    cell4.InnerHtml = "<p> Unpublished </p>";
               
                }
                trow.Controls.Add(cell4);

                //Creating and adding  HtmlTableCell (cell5) in the HttpTableRow tRow.
                HtmlTableCell cell5 = new HtmlTableCell();
                if (pagepublishstatus.ToLower() == "true")
                {
                    cell5.InnerHtml += "<input type=\"button\" value=\"View\" onclick=\"location.href='ViewPage.aspx?pageid=" + page.GetPageId().ToString() + "'\" class=\"btn btn-primary rowButton\"/>";
                }
                else
                {
                    cell5.InnerHtml += "<input type=\"button\" value=\"View\" onclick=\"location.href='ViewPage.aspx?pageid=" + page.GetPageId().ToString() + "'\" class=\"btn btn-primary rowButton\" disabled/>";
                }
                cell5.InnerHtml += "<input type=\"button\" value=\"Edit\" onclick=\"location.href='UpdatePage.aspx?pageid=" + page.GetPageId().ToString() + "'\" class=\"btn btn-primary rowButton\"/>";
                trow.Controls.Add(cell5);

                //Adding the current row to the Table
                table1.Rows.Add(trow);
            }
        }

        protected void Delete_Page(object sender, EventArgs e)
        {
            CMSDB db = new CMSDB();
            //Getting the pageid from the Request object.
            string pageid = Request.QueryString["pageid"];

            //If pageid is not empty perform the delete query and go to ListPages.aspx
            if (!String.IsNullOrEmpty(pageid))
            {
                db.DeletePage(Int32.Parse(pageid));
                Response.Redirect("ListPages.aspx");
            }
        }
    }
}