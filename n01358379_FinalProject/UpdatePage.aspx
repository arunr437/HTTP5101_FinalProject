
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="n01358379_FinalProject.UpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageupdate" class="container well" runat="server">                    
        <h2>Updating <span id="page_update" runat="server"></span></h2>

        <div class="form-group">
            <label>Page Title</label>
            <asp:TextBox class="form-control" runat="server" ID="page_title"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="page_title" ForeColor="Red" ErrorMessage="Please enter the Page Title" runat="server"></asp:RequiredFieldValidator>

        </div>

        <div class="form-group">
            <label>Page Content</label>
            <asp:TextBox class="form-control" runat="server" ID="page_content"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="page_content" ForeColor="Red" ErrorMessage="Please enter the Page Content" runat="server"></asp:RequiredFieldValidator>
        </div>     
        <div class="form-group">
            <label>Page Author</label>
            <asp:TextBox class="form-control" runat="server" ID="page_author"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="page_author" ForeColor="Red" ErrorMessage="Please enter the Page Author" runat="server"></asp:RequiredFieldValidator>
        </div>      
        
        <div class="form-group">
            <label>Publish Date</label>
            <asp:TextBox class="form-control" runat="server" ID="page_publish_date" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <label class="form-check-label" for="form-check-box">Publish?</label>
            <asp:CheckBox class="form-check-label" runat="server" ID="page_publish_box" name="page_publish_box"/>
        </div>
        <div>
            <asp:ValidationSummary id="validationSummary"  DisplayMode="BulletList" runat="server" HeaderText="Incomplete form submitted!" ForeColor="Red"/>
        </div>
        <asp:Button Text="Cancel Page" OnClick="Cancel_Page"  CssClass="btn btn-primary" runat="server" />
        <asp:Button Text="Update Page" OnClick="Update_Page"  CssClass="btn btn-success" runat="server" />
        <asp:LinkButton OnClientClick="if(!confirm('Are you sure you want to delete this?')) return false;" OnClick="Delete_Page" CssClass="btn btn-danger" Text="Delete" runat="server">
            <span aria-hidden="true" class="glyphicon glyphicon-trash">Delete</span>
        </asp:LinkButton>         
    </div>
</asp:Content>
