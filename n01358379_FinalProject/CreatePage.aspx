<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePage.aspx.cs" Inherits="n01358379_FinalProject.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>New Page</h2>
        <div id="pageId" runat="server" class="container well">
            <%--Below button will change the Style of the page when clicked. The button calls a JS function. A JQuery command in the function will select the body element and change the style!**Not a part of the inital wireframe**--%>
            <button type="button" class="btn btn-primary" id="clickMe">Change Page Look Style</button>

            <%--Below code will create a text box with required field validation for Page Title--%>
            <div class="form-group">
                <label>Page Title</label>
                <asp:TextBox class="form-control" ID="page_title" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="page_title" ForeColor="Red" ErrorMessage="Please enter the Page Title" runat="server"></asp:RequiredFieldValidator>
            </div> 

            <%--Below code will give the option to 'Choose an Existing Author from the Current list of Authors in the database'. For new Authors 'Others' option should be selected--%>
            <div class="form-group">
                <label>Authors List</label>
                <asp:DropDownList ID="page_author_list" CssClass="form-control formAuthorList" runat="server">
                    <asp:ListItem Enabled="true" Text="Choose an Author" Value="-1"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="page_author_list" ForeColor="Red" ErrorMessage="Please choose an author" InitialValue="-1"></asp:RequiredFieldValidator>
            </div>

            <%--The below div element will be hidden by default using a Jquery statement in '/Scripts/script.js'. 
                When the user clicks the 'Others' option in the above Drop Down List(page_author_list), this div tag will slide down and show a textbox to enter a new Author Name. This is again done using Jquery in the same file.--%>
            <div class="form-group formHide">
                <label>Page Author</label>
                <asp:TextBox class="form-control"  runat="server" ID="page_author"></asp:TextBox>
            </div>

            <%--Below code is used to enter the Page Body--%>
            <div class="form-group">
                <label>Page Content</label>
                <asp:TextBox class="form-control" runat="server" ID="page_content"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="page_content" ForeColor="Red" ErrorMessage="Please enter the Page Content" runat="server"></asp:RequiredFieldValidator>
            </div>  

            <%--Below code will display a radio button giving the user an option to either publish or unpublish a page--%>
            <div class="form-group">
                <label class="form-check-label" for="form-check-box">Publish?</label>
                <asp:CheckBox class="form-check-label" runat="server" ID="page_publish_box" name="page_publish_box"/>
            </div>

            <%--Code to show the Validation Summary. --%>
            <div>
                <asp:ValidationSummary id="validationSummary"  DisplayMode="BulletList" runat="server" HeaderText="Incomplete form submitted!" ForeColor="Red"/>
            </div>

            <%--Button to submit and create the page. It calls the 'Add_Page' function which will insert the values into the database--%>
            <asp:Button OnClick="Add_Page" class="btn btn-success btn-space" Text="Create Page" runat="server" />
            <%--Code to go back to ListPages--%>
            <a href="ListPages.aspx" class="btn btn-danger">Cancel</a>
        </div>
</asp:Content>
