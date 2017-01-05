<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddFunds.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="Bootstrap/css/Background.css" rel="stylesheet" />
    <div class="sans">
        <asp:Label ID="Label1" runat="server" Text="Enter Fund Amount : "></asp:Label>
        <asp:TextBox ID="funds" runat="server" Height="16px" ></asp:TextBox>
    </div>
    <div class="sans">
        <asp:Button ID="Button1" runat="server" Text="Add Funds"  Height="52px" OnClick="Button1_Click" Width="189px" />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </div>
    
</asp:Content>

