<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupItemControl.ascx.cs" Inherits="CampusGroups.GroupItemControl" %>
<br />
<asp:Image ID="groupAvatar" runat="server" />
<asp:Label ID="groupNameLbl" runat="server" Text=""></asp:Label>

<asp:ImageButton ID="leaveGroupButton" runat="server" OnClick="leaveGroupButton_Click" style="height: 16px" />


