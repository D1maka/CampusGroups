<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupMemberControl.ascx.cs" Inherits="CampusGroups.GroupMemberControl" %>
<br/>
<asp:Image ID="avatarImg" runat="server" />
&nbsp;<asp:Label ID="userNameLbl" runat="server" Text=""></asp:Label>
&nbsp;
<br />
<asp:Label ID="userProfileType" runat="server" Text=""></asp:Label>
<br />
<asp:Label ID="userDepartment" runat="server" Text=""></asp:Label>
<br />
<asp:ImageButton ID="deleteBtn" runat="server" Visible="False" OnClick="deleteBtn_Click" AlternateText="Видалити"/>
<br/>
