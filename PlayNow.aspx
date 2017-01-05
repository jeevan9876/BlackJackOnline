<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PlayNow.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Bootstrap/css/Background.css" rel="stylesheet" />

    <br />
    <div style="margin-left: 178px; width: 1109px; height: 325px" class="sans">
        <p style="color: lightcyan">Dealer Cards</p>
        <div class="col-sm-2">
            <asp:Image ID="Image2" runat="server" Height="130px" Width="120px" />
        </div>        
        <div style="height: 171px; width: 860px; margin-left: 175px; margin-top: 0px; top: -131px; left: -28px;" class="col-sm-7">
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <asp:Image ID="Image3" runat="server" Height="130px" Width="120px" />
                <asp:Image ID="Image19" runat="server" Height="130px" Width="120px" Visible="False" />
                <asp:Image ID="Image20" runat="server" Height="130px" Width="120px" Visible="False" />
                <asp:Image ID="Image21" runat="server" Height="130px" Width="120px" Visible="False" />
                <asp:Image ID="Image22" runat="server" Height="130px" Width="120px" Visible="False" />
                <asp:Image ID="Image23" runat="server" Height="130px" Width="120px" Visible="False" />
                <br />
                &nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Dealer Score : "></asp:Label>
            <asp:Label ID="dealerscore" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>       

        <div style="width: 281px; height: 83px; margin-left: 878px; margin-top: 0px; top: -124px; left: -485px;" class="sans col-sm-3">
            <!-- Game state-->
            <asp:Label ID="game_state" runat="server" Text=""></asp:Label><br />
            Total money with User:            
            <asp:Label ID="money" runat="server" Text=""></asp:Label><br />
            User bet amount :<!--Bet money---><asp:Label ID="bet_money" runat="server" Text=""></asp:Label><br />
            <!--Pot Amount--->
            Pot Amount :<asp:Label ID="potamount" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-sm-12 sans" style="margin-left: 200px; width: 1060px; top: 0px; left: 0px;">
            <div>
                <p style="color: lightcyan">Player Cards</p>
                <asp:Image ID="Image4" runat="server" Height="150px" Width="120px" />
                <asp:Image ID="Image5" runat="server" Height="150px" Width="120px" />
                &nbsp;<asp:Image ID="Image16" runat="server" Height="150px" Width="120px" Visible="False" />
                &nbsp;<asp:Image ID="Image17" runat="server" Height="150px" Width="120px" Visible="False" />
                &nbsp;<asp:Image ID="Image18" runat="server" Height="150px" Width="120px" Visible="False" />
                <asp:Image ID="Image24" runat="server" Height="150px" Width="120px" Visible="False" />
                <asp:Image ID="Image25" runat="server" Height="150px" Width="120px" Visible="False" />
            </div>
            <div>
                <div style="height: 34px; width: 234px; margin-left: 218px; margin-top: 19px">
                    <asp:Label ID="Label2" runat="server" Text="Player Score : "></asp:Label>
                    <asp:Label ID="playerscore" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row" style="margin-top: 4px">

        <div class="col-sm-6" style="margin-bottom: 400px; top: 90px; left: 163px; height: 48px; width: 806px;">
            <div class="btn-group">
                <asp:Panel ID="buttonpanel" runat="server">
                    <asp:Button ID="Surrender" runat="server" Text="Surrender" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" BorderColor="#003300" Height="30px" Width="140px" OnClick="Surrender_Click" />
                
                <asp:Button ID="Stand" runat="server" Text="  Stand  " Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" BorderColor="#003300" Height="30px" Width="140px" OnClick="Stand_Click" />
                <asp:Button ID="Hit" runat="server" Text="   Hit   " Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" BorderColor="#003300" Height="30px" Width="140px" OnClick="Hit_Click" />
                </asp:Panel>
                
            </div>

        </div>
        <div class="col-sm-2 sans" style="margin-bottom: 400px; top: -391px; left: 909px; height: 66px; width: 806px;">
            <div class="btn-group">
                <!-- bet adding buttons-->
                <asp:Panel ID="Panel2" runat="server">
                    <asp:Button ID="bet5" runat="server" Text="Add 5$" Font-Bold="True" Font-Italic="True" Font-Names="Arial Black" Font-Overline="False" Font-Underline="False" ForeColor="#66FF33" OnClick="bet5_Click" /><br />
                <asp:Button ID="bet10" runat="server" Text="Add 10$" Font-Bold="True" Font-Italic="True" Font-Names="Arial Black" Font-Overline="False" Font-Underline="False" ForeColor="#66FF33" OnClick="bet10_Click" /><br />
                <asp:Button ID="bet25" runat="server" Text="Add 25$" Font-Bold="True" Font-Italic="True" Font-Names="Arial Black" Font-Size="Small" Font-Underline="False" ForeColor="#66FF33" OnClick="bet25_Click" /><br />
                </asp:Panel>
                
                <br />

            </div>

        </div>
        <div class="col-sm-4" style="margin-bottom: 7px; top: -739px; left: 442px; height: 90px; width: 136px">
            <asp:Button ID="Deal" runat="server" Text="   Deal  " Height="29px" Font-Bold="True" Font-Names="Bernard MT Condensed" Font-Strikeout="True" Font-Underline="False" ForeColor="Red" Width="120px" OnClick="Button6_Click" />
            <br />
            <br />
           <asp:Button ID="NewGame" runat="server" Text="   New Game  " Height="29px" Font-Bold="True" Font-Names="Bernard MT Condensed" Font-Strikeout="True" Font-Underline="False" ForeColor="Lime" Width="120px" Enabled="False" OnClick="NewGame_Click" Visible="False" />
                 
        </div>
</asp:Content>

