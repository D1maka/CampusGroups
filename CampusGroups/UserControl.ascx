<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="CampusGroups.UserControl" %>
<table style="width:100%; border: 2px solid black;">
    <tr>
        <td rowspan="3"><asp:Image ID="avatarImg" runat="server" /></td>
        <td><asp:Label ID="usernameLbl" runat="server" Text=""></asp:Label></td>
        <td>
            <asp:ImageButton ID="myGroupsBtn" runat="server" OnClick="myGroupsBtn_Click" AlternateText="Мої групи"/><br/>
            <asp:ImageButton ID="setAvatarBtn" runat="server"  OnClick="setAvatarBtn_Click" AlternateText="Встановити аватар"/>
        </td>
    </tr>
    <tr>
        <td><asp:Label ID="userProfileType" runat="server" Text=""></asp:Label></td>
        <td>
            <asp:ImageButton ID="viewAllGroupsBtn" runat="server" OnClick="viewAllGroupsBtn_Click" AlternateText="Всі групи"/><br/>
            <asp:ImageButton ID="newGroupBtn" runat="server" OnClick="newGroupBtn_Click" AlternateText="Створити групу"/>
        </td>
    </tr>
    <tr>
        <td><asp:Label ID="userDepartment" runat="server" Text=""></asp:Label></td>
        <td> <asp:ImageButton ID="myInvitationsButton" runat="server" OnClick="myInvitationsButton_Click" AlternateText="Мої запрошення"/></td>
    </tr>
    <br />


</table>