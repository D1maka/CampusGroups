<%@ Page Title="" Language="C#" MasterPageFile="~/CampusGroupsMasterPage.Master" AutoEventWireup="true" CodeBehind="PostsPage.aspx.cs" Inherits="CampusGroups.PostsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="PlaceHolderGroupControl" runat="server"></asp:PlaceHolder>
    <asp:ImageButton ID="newPostBtn" runat="server" AlternateText="Нове повідомлення" OnClick="newPostBtn_Click"/>
    <asp:PlaceHolder ID="PlaceHolderPosts" runat="server"></asp:PlaceHolder>
</asp:Content>
