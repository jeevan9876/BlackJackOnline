<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="Bootstrap/css/Background.css" rel="stylesheet" />

<div style="height: 137px; width: 319px; margin-left: 118px; margin-top: 94px" class="sans">
 <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="UserName: " CssClass="sans"></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password: " CssClass="sans"></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="sans"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Password(retype):" CssClass="sans"></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
    </table>
    <br />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" Width="163px" CssClass="sans" />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label4" runat="server" Text=""></asp:Label>

</div>

   
</asp:Content>


