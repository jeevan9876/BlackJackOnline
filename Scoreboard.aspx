<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Scoreboard.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="Bootstrap/css/Background.css" rel="stylesheet" />
    <div style="width: 400; border-right-width:150px" class="sans">
        
        
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
</asp:Content>

