<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupItemControl.ascx.cs" Inherits="CampusGroups.GroupItemControl" %>
<br />
<asp:Image ID="groupAvatar" runat="server" />
<asp:LinkButton ID="groupNameBtn" runat="server" OnClick="groupNameBtn_Click"></asp:LinkButton>

<asp:ImageButton ID="leaveGroupButton" runat="server" OnClick="leaveGroupButton_Click" Height="20px" Width="20px" ImageUrl="~\icons\close.png"/>


<asp:ImageButton ID="sendRequestButton" runat="server" ImageUrl="~\icons\edit_add_9180.png" Height="20px" Width="20px"  OnClick="sendRequestButton_Click"/>

<asp:ImageButton ID="acceptInvitationbutton" runat="server" ImageUrl="~\icons\button_ok_8132.png" Height="20px" Width="20px" OnClick="acceptInvitationbutton_Click"/> 




