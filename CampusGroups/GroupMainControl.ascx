<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupMainControl.ascx.cs" Inherits="CampusGroups.GroupMainControl" %>
<div style="border: 2px solid black;"><br />
<asp:Image ID="groupAvatar" runat="server" />
<asp:Label ID="groupNameLabel" runat="server" Text=""></asp:Label><br/>
<asp:Label ID="groupDescriptionLabel" runat="server" Text=""></asp:Label><br />
<asp:ImageButton ID="viewMembersBtn" runat="server" AlternateText="Учасники" OnClick="viewMembersBtn_Click"/>
<asp:ImageButton ID="viewRequestBtn" runat="server" OnClick="viewRequestBtn_Click" AlternateText="Заявки"/>
<asp:ImageButton ID="sendInvitationsBtn" runat="server" OnClick="sendInvitationsBtn_Click" AlternateText="Запросити" />
<asp:ImageButton ID="viewPostsBtn" runat="server" AlternateText="Переглянути повідомлення" OnClick="viewPostsBtn_Click"/>
<br /></div>