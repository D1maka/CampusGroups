<%@ Page Title="" Language="C#" MasterPageFile="~/CampusGroupsMasterPage.Master" AutoEventWireup="true" CodeBehind="AllGroupsPage.aspx.cs" Inherits="CampusGroups.AllGroupsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    
        <asp:PlaceHolder ID="PlaceHolderUserControl" runat="server"></asp:PlaceHolder><br/>
        <asp:PlaceHolder ID="PlaceHolderAllGroups" runat="server"></asp:PlaceHolder>
    
    </div>
</asp:Content>

