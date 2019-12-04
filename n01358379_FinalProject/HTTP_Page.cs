using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace n01358379_FinalProject
{
    public class HTTP_Page
    {
        /* Creating page title and page content fields with private access specifier which cannot be accessed 
         * without getters and setters. */
        private String PageTitle;
        private String PageContent;
        private String PagePublishDate;
        private Boolean PagePublishStatus;
        private String PageAuthor;
        private String PageMainContent1;
        private String PageMainContent2;

        /* Creating Getters with public access modifiers for encapsulation. These functions will be used get values.  */
        public string GetPageTitle()
        {
            return PageTitle;
        }
        public string GetPageContent()
        {
            return PageContent;
        }

        public string GetPagePublishDate()
        {
            return PagePublishDate;
        }

        public Boolean GetPagePublishStatus()
        {
            return PagePublishStatus;
        }   
        public string GetPageAuthor()
        {
            return PageAuthor;
        }       
        public string GetPageMainContent1()
        {
            return PageMainContent1;
        }      
        public string GetPageMainContent2()
        {
            return PageMainContent2;
        }


        /*Creating Setters with public access modifiers for encapsulation. These functions will be used to set values.*/
        public void SetPageTitle(string value)
        {
            PageTitle = value;
        }

        public void SetPageContent(string value)
        {
            PageContent = value;
        }

        public void SetPagePublishDate(string value)
        {
            PagePublishDate = value;
        }

        public void SetPagePublishStatus(Boolean value)
        {
            PagePublishStatus = value;
        }

        public void SetPageAuthor(string value)
        {
            PageAuthor = value;
        }

        public void SetPageMainContent1(string value)
        {
            PageMainContent1 = value;
        }
        
        public void SetPageMainContent2(string value)
        {
            PageMainContent2 = value;
        }
    }
}