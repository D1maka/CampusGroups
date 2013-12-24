<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="CampusGroups.UserControl" %>
<div style="border: 2px solid black;">
<asp:Image ID="avatarImg" runat="server" />
&nbsp;<asp:Label ID="usernameLbl" runat="server" Text=""></asp:Label>
&nbsp;<br />
<asp:Label ID="userProfileType" runat="server" Text=""></asp:Label>
<br />
<asp:Label ID="userDepartment" runat="server" Text=""></asp:Label>
<br />
<asp:ImageButton ID="myGroupsBtn" runat="server" OnClick="myGroupsBtn_Click" AlternateText="Мої групи"/>
<asp:ImageButton ID="setAvatarBtn" runat="server"  OnClick="setAvatarBtn_Click" AlternateText="Встановити аватар"/>
<asp:ImageButton ID="viewAllGroupsBtn" runat="server" OnClick="viewAllGroupsBtn_Click" AlternateText="Всі групи"/>
<asp:ImageButton ID="newGroupBtn" runat="server" OnClick="newGroupBtn_Click" AlternateText="Створити групу"/>
<asp:ImageButton ID="myInvitationsButton" runat="server" OnClick="myInvitationsButton_Click" AlternateText="Мої запрошення"/>
</div>

