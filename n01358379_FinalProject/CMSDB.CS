using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace n01358379_FinalProject
{
    public class CMSDB
    {

        
        // Connection string is stored in the below line. Private access modifier is used to protect it from being accessed outside the class. 
        private static string ConnectionString = "server=localhost;user=root;database=contentmanagementsystem;port=3306;password=password";

        //ListPages function returns a 'List of HTTP_Page objects'. Using these page objects the records are dynamically displayed. 
        public List<HTTP_Page> ListPages(string query)
        { 
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
           
            // Creating a List of HTTP_Page objects, which will be modified and returned by the function. 
            List<HTTP_Page> pageList = new List<HTTP_Page>();

            try
            {
                //The below lines opens a connection, passes query to the connection and gets the result set after executing the query. 
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Looping through the resultset to get the details needed to display in listPages.
                while (resultset.Read())
                {
                    //Creating page object which will hold  individual record details. This will be added to the list ('pageList').
                    HTTP_Page page = new HTTP_Page();
                    Debug.WriteLine("Reading from the result Set");
                    //Code to get individual record details.
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);

                        if(key=="pageid")
                        {
                            page.SetPageId(Int32.Parse(value)); 
                        }
                        if(key=="pagetitle")
                        {
                            page.SetPageTitle(value);
                        }   
                        if(key=="pagebody")
                        {
                            page.SetPageContent(value);
                        }              
                        if(key=="pageauthor")
                        {
                            page.SetPageAuthor(value);
                        }             
                        if(key=="pagedate")
                        {
                            page.SetPagePublishDate(value);
                        }
                        if(key=="pagestatus")
                        {
                            page.SetPagePublishStatus(bool.Parse(value));
                        }
                    }
                    //Adding an individual page record to the pageList. 
                    pageList.Add(page);
                }
                resultset.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An exception occured in the ListPages(String query) method! ");
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                //Closing the connection
                Connect.Close();
            }
            Debug.WriteLine("Database Connection Closed.");
            //Returning pageList which has a list of HTTP_Page objects.
            return pageList;
        }

        public HTTP_Page ViewPage(int id)
        {
            //Creating an object of class connect using the connectionString 
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //Creating an object of HTTP_Page which will be returned by the function
            HTTP_Page page = new HTTP_Page();

            //Try block to catch exceptions that may arise from the code. 
            try
            {
                //Below query will select the record  with the pageid passed in the parameter. 
                string query = "select * from PAGE where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");

                //Below lines open the connection, run the query against the db and get the resultset
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                MySqlDataReader resultset = cmd.ExecuteReader();

                //read through the result set
                while (resultset.Read())
                {
                    //To loop across each column in the PAGE table
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);

                        if (key == "pagetitle")
                        {
                            page.SetPageTitle(value);
                        }
                        if (key == "pagebody")
                        {
                            page.SetPageContent(value);
                        }
                        if (key == "pageauthor")
                        {
                            page.SetPageAuthor(value);
                        }
                        if (key == "pagedate")
                        {
                            page.SetPagePublishDate(value);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //Writing the error in order to debug
                Debug.WriteLine("Exception in ViewPage(int id) method!");
                Debug.WriteLine(ex.ToString());
            }
            //Below block will execute even when there's an exception. 
            finally
            {
                
                Connect.Close();
                Debug.WriteLine("Database connection closed.");

            }
            //Returning the required page
            return page;
        }


        public void AddPage(HTTP_Page new_page)
        {           
            //SQL query to insert data into the PAGE table       
            string query = "insert into PAGE (PAGETITLE,PAGEBODY,PAGEDATE,PAGESTATUS,PAGEAUTHOR) values ('{0}','{1}',now(),'{2}','{3}')";
            
            //To insert values for PAGESTATUS field which is of type boolean. 0 is inserted if PAGESTATUS is false, 1 if true.
            int page_publish_value = 0; 
            if(new_page.GetPagePublishStatus())
            {
                page_publish_value = 1;
            }

            //Getting data from 'new_page' object which is passed in the parameter of the function during the function call. ('db.AddPage(new_page)')
            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageContent(),page_publish_value,new_page.GetPageAuthor());

            //Creating a new connection object using the connection string and Creating an object for a MySqlCommand using query and the connect object.
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);

            //try catch and finally for exception handling
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in the AddPage(HTTP_Page new_page) method");
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }


        public void DeletePage(int pageid)
        {
            //Query to delete record from the PAGE table based on the pageid
            string query = "delete from page where pageid = {0}";

            // Creating connection object with the connection string and creating a MySqLCommand with the query and the connection object. 
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            query = String.Format(query, pageid);
            MySqlCommand cmd_removepage = new MySqlCommand(query, Connect);

            //try,catch and finally for exception handling
            try
            {
                // Code to open the connection and to execute the query on the database.
                Connect.Open();
                cmd_removepage.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //if this isn't working as intended, you can check debug>windows>output for the error message.
                Debug.WriteLine("Exception in the DeletPage(int pageid) method");
                Debug.WriteLine(ex.ToString());
            }

            finally
            {
                //Closing the connection.
                Connect.Close();
            }
        }

        public void UpdatePage(int pageid, HTTP_Page new_page)
        {
            //SQL query to update the PAGE table with the new values.
            string query = "update PAGE set PAGETITLE='{0}', PAGEBODY='{1}', PAGEAUTHOR='{2}', PAGESTATUS='{3}' where PAGEID = '{4}'";


            //To update values for PAGESTATUS field which is of type boolean. 0 is inserted if PAGESTATUS is false, 1 if true.
            int page_publish_value = 0;
            if (new_page.GetPagePublishStatus())
            {
                page_publish_value = 1;
            }

            //Getting data from 'new_page' object which is passed in the parameter of the function during the function call. ('db.AddPage(new_page)')
            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageContent(), new_page.GetPageAuthor(), page_publish_value, pageid);

            //Creating a new connection object using the connection string and Creating an object for a MySqlCommand using query and the connect object.  
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                //Opening the connection and executing the query on the database. 
                Connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine("Exception in the updatePage(int pageId, HTTP_Page page) method!");
                Debug.WriteLine(ex.ToString());
            }

            finally
            {
                //Database connection is closed.
                Connect.Close();
            }
        }

    }
}

