<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttachmentControl.ascx.cs" Inherits="CampusGroups.AttachmentControl" %>
<asp:Label ID="attachmentNameLbl" runat="server" Text=""></asp:Label><asp:ImageButton ID="downloadAttachmentBtn" runat="server" OnClick="downloadAttachmentBtn_Click" AlternateText="Зкачати" />
<asp:ImageButton ID="deleteAttachmentBtn" runat="server" OnClick="deleteAttachmentBtn_Click" />
