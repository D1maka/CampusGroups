<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="CampusGroups.WebUserControl1" %>
<asp:Label ID="loginLbl" runat="server" Text="Логін"></asp:Label>
<asp:TextBox ID="loginTxtBox" runat="server"></asp:TextBox>
<p>
    <asp:Label ID="passwdLbl" runat="server" Text="Пароль"></asp:Label>
    <asp:TextBox ID="passwdTxtBox" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
</p>
<asp:Button ID="loginBrn" runat="server" Text="Увійти" OnClick="loginBtn_Click" />

