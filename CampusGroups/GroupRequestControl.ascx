﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupRequestControl.ascx.cs" Inherits="CampusGroups.GroupRequestControl" %>
<asp:Image ID="avatarImg" runat="server" />
&nbsp;<asp:Label ID="usernameLbl" runat="server" Text=""></asp:Label>
&nbsp;
<br />
<asp:Label ID="userProfileType" runat="server" Text=""></asp:Label>
<br />
<asp:Label ID="userDepartment" runat="server" Text=""></asp:Label>
<br />
<asp:ImageButton ID="acceptRequest" runat="server" OnClick="acceptRequest_Click" ImageUrl="~\icons\button_ok_8132.png" Height="20px" Width="20px"/>
<asp:ImageButton ID="declineRequest" runat="server" OnClick="declineRequest_Click" ImageUrl="~\icons\close.png" Height="20px" Width="20px"/>
