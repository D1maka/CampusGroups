<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangeAvatarControl.ascx.cs" Inherits="CampusGroups.ChangeAvatarControl" %>
<asp:Image ID="Avatar" runat="server" />
<asp:FileUpload ID="FileUploadControl" runat="server" />
<asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label>
<asp:Button ID="changeAvatarBtn" runat="server" Text="Змінити" OnClick="changeAvatarBtn_Click" />