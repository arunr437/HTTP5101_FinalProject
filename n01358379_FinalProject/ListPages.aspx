<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="n01358379_FinalProject.ListPages" %>
<asp:Content ID="Pages_list" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container well" id="pageContainer">
            <div>
                <div>
                    <asp:label for="page_title_search" runat="server">Search Page Title:</asp:label>
                    <asp:TextBox ID="page_title_search" runat="server"></asp:TextBox>
                    <Button class="btn btn-primary btn-sm" runat="server">
                        <span class="glyphicon glyphicon-search"></span> Search 
                    </Button>
                </div>
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
            <div>
                <a class="btn btn-primary" id="createBtn" href="CreatePage.aspx">Create Page </a>
            </div>
        </div>
</asp:Content>
