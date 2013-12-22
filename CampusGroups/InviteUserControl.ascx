<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InviteUserControl.ascx.cs" Inherits="CampusGroups.InviteUserControl" %>
<asp:Image ID="avatarImg" runat="server" />
&nbsp;<asp:Label ID="usernameLbl" runat="server" Text=""></asp:Label>
&nbsp;
<br />
<asp:Label ID="userProfileType" runat="server" Text=""></asp:Label>
<br />
<asp:Label ID="userDepartment" runat="server" Text=""></asp:Label>
<br />
<asp:ImageButton ID="inviteBtn" runat="server" />
<asp:DropDownList ID="DropDownListRoles" runat="server"></asp:DropDownList>