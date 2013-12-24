<%@ Page Title="" Language="C#" MasterPageFile="~/CampusGroupsMasterPage.Master" AutoEventWireup="true" CodeBehind="GroupUsersPage.aspx.cs" Inherits="CampusGroups.GroupUsersPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="PlaceHolderGroupControl" runat="server"></asp:PlaceHolder><br />
    <asp:PlaceHolder ID="PlaceHolderUsers" runat="server"></asp:PlaceHolder>
</asp:Content>
