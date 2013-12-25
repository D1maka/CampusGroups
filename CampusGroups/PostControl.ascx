<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostControl.ascx.cs" Inherits="CampusGroups.PostControl" %>
<br/>
<table style="width:100%; border: 2px solid black">
    <tr>
        <td style="width:30%" colspan="2"><asp:Label ID="postDateLbl" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td style="width:30%"><asp:Label ID="postAuthorNameLbl" runat="server" Text=""></asp:Label></td>
        <td rowspan="2" style="width:70%"><asp:Label ID="postTextLbl" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td style="width:30%"><asp:Image ID="avatar" runat="server" Height="64" Width="64"/></td>
    </tr>

</table>
<br/>