<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Bootstrap/css/Welcome.css" rel="stylesheet" />
    <div class="container">
        <div class="jumbotron">
        </div>
        <div class="row">
            <div class="col-sm-4">
            </div>
            <div class="col-sm-4">

                <h1 style="width: 533px"><span style="font-style: italic; font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif; font: 700; color: antiquewhite">Welcome to Black Jack Mania ! </span></h1>

            </div>
            <div class="col-sm-4">
            </div>
        </div>
    </div>


    <div class="form-group sans">
        <label class="control-label col-sm-2 sans" for="email">Username:</label>
        <div class="col-sm-10">
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="form-group sans">
        <label class="control-label col-sm-2 sans" for="pwd">Password:</label>
        <div class="col-sm-10 sans">
            <asp:TextBox ID="pwd" runat="server" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <div class="form-group sans">
        <div class="col-sm-offset-2 col-sm-10 sans">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Login" runat="server" Text="Login" OnClick="Login_Click" />
            <br />
            <br />

            &nbsp;

            <asp:Label ID="Label1" runat="server" Text="New User ???" Font-Underline="True" ForeColor="#33CCFF"></asp:Label>
            <br />
                    
                
                &nbsp;&nbsp;
                    
                
                <asp:Button ID="SignUp" runat="server" Text="SignUp" OnClick="SignUp_Click" />
        </div>
    </div>
    <br />
    <asp:Label ID="Label3" runat="server" Text="" CssClass="sans"></asp:Label>




</asp:Content>

