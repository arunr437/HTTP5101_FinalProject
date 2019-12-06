<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="n01358379_FinalProject.ListPages" %>
<asp:Content ID="Pages_list" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container well" id="pageContainer">
            <div>
                <div>
                    <%--Below button will change the Style of the page when clicked. The button calls a JS function. A JQuery command in the function will select the body element and change the style!**Not a part of the inital wireframe**--%>
                    <button type="button" class="btn btn-primary" id="clickMe">Change Page Look</button>

                    <%--Below code will create a search box with a button which will be used to search for Page Title--%>
                    <asp:label for="page_title_search" runat="server">Search Page Title:</asp:label>
                    <asp:TextBox ID="page_title_search" runat="server"></asp:TextBox>
                    <Button class="btn btn-primary btn-sm" runat="server">
                        <span class="glyphicon glyphicon-search"></span> Search 
                    </Button>
                </div>

                <%--Code to create the header of the table(table1). Redering content (Looping through data and putting it in markup) will be added to this table from CodeBehind--%>
                <div class="h3">Manage Pages</div>
                <table id="table1" class="table table-striped table-bordered table-hover" runat="server">
                    <thead>
                        <tr>
                            <th>Page Title</th>
                            <th>Page Author</th>
                            <th>Publish Date</th>
                            <th>Page Status</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                </table>   
            </div>

            <%--Link to create a new page. Link will appear like a button due to bootstrap styling--%>
            <div>
                <a class="btn btn-primary" id="createBtn" href="CreatePage.aspx">Create Page </a>
            </div>
        </div>
</asp:Content>
