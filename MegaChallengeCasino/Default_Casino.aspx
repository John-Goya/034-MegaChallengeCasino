<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default_Casino.aspx.cs" Inherits="MegaChallengeCasino.Default_Casino" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 40px;
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div aria-orientation="horizontal">
            <asp:Image ID="slot1Image" runat="server" Height="150px" Width="150px" />
            <asp:Image ID="slot2Image" runat="server" Height="150px" Width="150px" />
            <asp:Image ID="slot3Image" runat="server" Height="150px" Width="150px" />
            <br />
            <br />
            Your Bet:
            <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="pullLeverButton" runat="server" OnClick="pullLeverButton_Click" Text="Pull The Lever!" />
            <br />
            <br />
            <asp:Label ID="winLosePayoutLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="playerMoneyLabel" runat="server"></asp:Label>
            <br />
            <br />
            <img alt="" class="auto-style3" src="Images/Cherry.png" /> - 2x Your Bet<br />
            <img alt="" class="auto-style3" src="Images/Cherry.png" /><img alt="" class="auto-style3" src="Images/Cherry.png" /> - 3x Your Bet <br />
            <img alt="" class="auto-style3" src="Images/Cherry.png" /><img alt="" class="auto-style3" src="Images/Cherry.png" /><img alt="" class="auto-style3" src="Images/Cherry.png" /> - 4x Your Bet<br />
            <img alt="" class="auto-style3" src="Images/Seven.png" /><img alt="" class="auto-style3" src="Images/Seven.png" /><img alt="" class="auto-style3" src="Images/Seven.png" /> - Jackpot - x100 Your Bet <br />
            However... if there is even ONE <img alt="" class="auto-style3" src="Images/Bar.png" /> - You lose </div>
    </form>
</body>
</html>
