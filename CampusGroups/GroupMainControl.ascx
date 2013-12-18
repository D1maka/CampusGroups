<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupMainControl.ascx.cs" Inherits="CampusGroups.GroupMainControl" %>
<asp:Image ID="groupAvatar" runat="server" />
<asp:Label ID="groupNameLabel" runat="server" Text=""></asp:Label><br/>
<asp:Label ID="groupDescriptionLabel" runat="server" Text=""></asp:Label><br />
<asp:ImageButton ID="viewMembersBtn" runat="server" />
<asp:ImageButton ID="viewRequestBtn" runat="server" />
<asp:ImageButton ID="sendInvitationsBtn" runat="server" />
<asp:ImageButton ID="viewPostsBtn" runat="server" />