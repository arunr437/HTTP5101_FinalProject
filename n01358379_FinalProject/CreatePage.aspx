<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePage.aspx.cs" Inherits="n01358379_FinalProject.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>New Page</h2>
        <div id="pageId" runat="server" class="container well">
            <div class="fontButton"><input id="clickMe" type="button" value="Change Font" runat="server" class="btn btn-primary"  onclick="changeFont()"/></div>
            <div class="form-group">
                <label>Page Title</label>
                <asp:TextBox class="form-control" ID="page_title" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="page_title" ForeColor="Red" ErrorMessage="Please enter the Page Title" runat="server"></asp:RequiredFieldValidator>
            </div> 
            <div class="form-group">
                <label>Page Author</label>
                <asp:TextBox class="form-control" ID="page_author" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="page_author" ForeColor="Red" ErrorMessage="Please enter the Page Author" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Page Content</label>
                <asp:TextBox class="form-control" runat="server" ID="page_content"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="page_content" ForeColor="Red" ErrorMessage="Please enter the Page Content" runat="server"></asp:RequiredFieldValidator>
            </div> 
            <div class="form-group">
                <label>Page Content- Main Column 1</label>
                <asp:TextBox class="form-control" runat="server" ID="page_main_column_1"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="page_main_column_1" ForeColor="Red" ErrorMessage="Please enter the column 1 content" runat="server"></asp:RequiredFieldValidator>
            </div>  
            <div class="form-group">
                <label>Page Content- Main Column 2</label>
                <asp:TextBox class="form-control" runat="server" ID="page_main_column_2"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="page_main_column_2" ForeColor="Red" ErrorMessage="Please enter the column 2 content" runat="server"></asp:RequiredFieldValidator>
            </div>  
            <div class="form-group">
                <label class="form-check-label" for="form-check-box">Publish?</label>
                <asp:CheckBox class="form-check-label" runat="server" ID="page_publish_box" name="page_publish_box"/>
            </div>
            <div>
            <asp:ValidationSummary id="validationSummary"  DisplayMode="BulletList" runat="server" HeaderText="Incomplete form submitted!" ForeColor="Red"/>
            </div>
            <asp:Button OnClick="Add_Page" class="btn btn-success btn-space" Text="Create Page" runat="server" />
            <a href="ListPages.aspx" class="btn btn-danger">Cancel</a>
        </div>
</asp:Content>
