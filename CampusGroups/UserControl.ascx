<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="CampusGroups.UserControl" %>

<asp:Image ID="avatarImg" runat="server" />
&nbsp;<asp:Label ID="usernameLbl" runat="server" Text=""></asp:Label>
&nbsp;
<br />
<asp:ImageButton ID="myGroupsBtn" runat="server" OnClick="myGroupsBtn_Click" />
<asp:ImageButton ID="setAvatarBtn" runat="server" />
<asp:ImageButton ID="newGroupBtn" runat="server" />
<asp:Label ID="userProfileType" runat="server" Text=""></asp:Label>
<br />
<asp:Label ID="userDepartment" runat="server" Text=""></asp:Label>


