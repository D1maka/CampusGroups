﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateGroupControl.ascx.cs" Inherits="CampusGroups.CreateGroupControl" %>
<asp:Label ID="groupNameLbl" runat="server" Text="Назва групи"></asp:Label>
<asp:TextBox ID="groupNameTxtBox" runat="server"></asp:TextBox>
<br />
<asp:Label ID="groupDescriptionLbl" runat="server" Text="Опис"></asp:Label>
<asp:TextBox ID="groupDescriptionTxtBox" runat="server" Height="120px" TextMode="MultiLine" Width="541px"></asp:TextBox>

<asp:Button ID="createGroupBtn" runat="server" Text="Створити" OnClick="createGroupBtn_Click" />




