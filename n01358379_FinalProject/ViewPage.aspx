<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="n01358379_FinalProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageId" runat="server" class="container well">

        <%--Below button will change the Style of the page when clicked. The button calls a JS function. A JQuery command in the function will select the body element and change the style!**Not a part of the inital wireframe**--%>
        <button type="button" class="btn btn-primary" id="clickMe">Change Page Look</button>

        <%--Code to display the 'Title','Page body' and the 'Publish Date'--%> 
        <h1 class="text-center"><span id="page_title" runat="server"></span></h1>
        <h2><span id="page_body" runat="server"></span></h2>
        <p id="page_publish_date" class="publish_date" runat="server">Published on: </p>

        <%--Code to display the 'Back','Update' and 'Delete' buttons. 'Back' will go back to the ListPages page. 'Update' will go to the update page for the current pageId and 'Delete' will delete the current page--%>
        <div>
            <a href="ListPages.aspx" class="btn btn-primary">Back</a>
            <a href="UpdatePage.aspx?pageid=<%= Request.QueryString["pageid"] %>" class="btn btn-success">Update</a>
            <asp:LinkButton OnClientClick="if(!confirm('Are you sure you want to delete this?')) return false;" OnClick="Delete_Page" CssClass="btn btn-danger" Text="Delete" runat="server">
                <span aria-hidden="true" class="glyphicon glyphicon-trash">Delete</span>
            </asp:LinkButton>         
        </div>
    </div>
</asp:Content>
