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

        /*
        *************************************************************************************************************************************************************************************  
		Christine Bittle's Github repository used as 'REFERENCE'.
		Author: Christine Bittle
		Date: 2019-09-24
		Site: https://www.oreilly.com/library/view/regular-expressions-cookbook/9781449327453/ch04s02.html
		Purpose: To get regular expressions for Canadians phone numbers
		\******************************************************************************************************************************************************************************* --%>
         */

        // Database configuration details. Private access specifier is used to protect it and implement encapsulation

        private static string ConnectionString = "server=localhost;user=root;database=contentmanagementsystem;port=3306;password=password";

        //Funciton to display all the records in the table. Below funciton returns to List of type <Dictionary<String,String>> 
        public List<Dictionary<String, String>> ListPages(string query)
        {
            Debug.WriteLine("Entered function ListPages");

            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            Debug.WriteLine("Created Connect object");
            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();
            Debug.WriteLine("After List Dictionary");

            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
                //open the db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                while (resultset.Read())
                {
                    Debug.WriteLine("Entered while loop");
                    Dictionary<String, String> row = new Dictionary<String, String>();
                    Debug.WriteLine("Reading from the result Set");
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Debug.WriteLine(resultset.GetName(i));
                        row.Add(resultset.GetName(i), resultset.GetString(i));
                    }

                    ResultSet.Add(row);
                    Debug.WriteLine(row);
                }
                resultset.Close();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
            Debug.WriteLine("Database Connection Terminated.");
            return ResultSet;
        }

        public HTTP_Page ViewPage(int id)
        {
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //create a "blank" student so that our method can return something if we're not successful catching student data
            HTTP_Page result_page = new HTTP_Page();

            //we will try to grab student data from the database, if we fail, a message will appear in Debug>Windows>Output dialogue
            try
            {
                //Build a custom query with the id information provided
                string query = "select * from PAGE where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Create a list of students (although we're only trying to get 1)
                List<HTTP_Page> pages = new List<HTTP_Page>();

                //read through the result set
                while (resultset.Read())
                {
                    //information that will store a single student
                    HTTP_Page currentstudent = new HTTP_Page();

                    //Look at each column in the result set row, add both the column name and the column value to our Student dictionary
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        //can't just generically put data into a dictionary anymore
                        //must go through each column one by one to insert data into the right property
                        switch (key)
                        {
                            case "pagetitle":
                                currentstudent.SetPageTitle(value);
                                break;
                            case "pagebody":
                                currentstudent.SetPageContent(value);
                                break;
                            case "pageauthor":
                                currentstudent.SetPageAuthor(value);
                                break;  
                            case "pagedate":
                                currentstudent.SetPagePublishDate(value);
                                break;
                        }

                    }
                    //Add the student to the list of students
                    pages.Add(currentstudent);
                }

                result_page = pages[0]; //get the first student

            }
            catch (Exception ex)
            {
                //If something (anything) goes wrong with the try{} block, this block will execute
                Debug.WriteLine("Something went wrong in the find teacher method!");
                Debug.WriteLine(ex.ToString());
            }

            finally
            {
                Connect.Close();
            }
            Debug.WriteLine("Database Connection Terminated.");

            return result_page;
        }


        public void AddPage(HTTP_Page new_page)
        {
            //slightly better way of injecting data into strings

            string query = "insert into PAGE (PAGETITLE,PAGEBODY,PAGEDATE,PAGESTATUS,PAGEAUTHOR,PAGEMAINCONTENT1,PAGEMAINCONTENT2) values ('{0}','{1}',now(),'{2}','{3}','{4}','{5}')";
            int page_publish_value = 0; 
            if(new_page.GetPagePublishStatus())
            {
                page_publish_value = 1;
            }
            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageContent(),page_publish_value,new_page.GetPageAuthor(),new_page.GetPageMainContent1(),new_page.GetPageMainContent2());

            //This technique is still sensitive to SQL injection
            //

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the AddStudent Method!");
                Debug.WriteLine(ex.ToString());
            }

            finally
            {
                Connect.Close();
            }
        }


        public void DeletePage(int pageid)
        {
 

            //DELETING ON THE PRIMARY KEY OF STUDENTS
            string removepage = "delete from page where pageid = {0}";
            removepage = String.Format(removepage, pageid);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            //This command removes the particular student from the table
            MySqlCommand cmd_removepage = new MySqlCommand(removepage, Connect);
            try
            {
                //try to execute both commands!
                Connect.Open();
                //remember to remove the relational element first
                cmd_removepage.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removepage);
                //then delete the main record
                cmd_removepage.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removepage);
            }
            catch (Exception ex)
            {
                //if this isn't working as intended, you can check debug>windows>output for the error message.
                Debug.WriteLine("Something went wrong in the delete Student Method!");
                Debug.WriteLine(ex.ToString());
            }

            finally
            {
                Connect.Close();
            }
        }

        public void UpdatePage(int pageid, HTTP_Page new_page)
        {
            //slightly better way of injecting data into strings
            //the below technique is known as string formatting. It allows us to make strings without "" + ""
            string query = "update PAGE set PAGETITLE='{0}', PAGEBODY='{1}', PAGEAUTHOR='{2}', PAGESTATUS='{3}' where PAGEID = '{4}'";


            //The above technique is still sensitive to SQL injection
            //we will learn about parameterized queries in the 2nd semester
            int page_publish_value = 0;
            if (new_page.GetPagePublishStatus())
            {
                page_publish_value = 1;
            }

            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageContent(), new_page.GetPageAuthor(), page_publish_value, pageid);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                //Try to update a student with the information provided to us.
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                //If that doesn't seem to work, check Debug>Windows>Output for the below message
                Debug.WriteLine("Something went wrong in the UpdateStudent Method!");
                Debug.WriteLine(ex.ToString());
            }

 
                Connect.Close();
        }

    }
}

