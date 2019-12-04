<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="n01358379_FinalProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageId" runat="server" class="container well">
        <h1 class="text-center"><span id="page_title"  runat="server"></span></h1>
        <h2><span id="page_body" runat="server"></span></h2>
        <p id="page_publish_date" class="publish_date" runat="server">Published on: </p>

    <div>
        <a href="ListPages.aspx" class="btn btn-primary">Back</a>
        <a href="UpdatePage.aspx?pageid=<%= Request.QueryString["pageid"] %>" class="btn btn-success">Update</a>
        <asp:LinkButton OnClientClick="if(!confirm('Are you sure you want to delete this?')) return false;" OnClick="Delete_Page" CssClass="btn btn-danger" Text="Delete" runat="server">
            <span aria-hidden="true" class="glyphicon glyphicon-trash">Delete</span>
        </asp:LinkButton>         
    </div>
    </div>
</asp:Content>
