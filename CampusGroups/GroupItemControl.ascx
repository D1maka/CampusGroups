<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupItemControl.ascx.cs" Inherits="CampusGroups.GroupItemControl" %>
<br />
<asp:Image ID="groupAvatar" runat="server" />
<asp:LinkButton ID="groupNameBtn" runat="server" OnClick="groupNameBtn_Click"></asp:LinkButton>

<asp:ImageButton ID="leaveGroupButton" runat="server" OnClick="leaveGroupButton_Click" style="height: 16px" ImageUrl="~\icons\close.png"/>


