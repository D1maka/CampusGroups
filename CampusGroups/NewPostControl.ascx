﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewPostControl.ascx.cs" Inherits="CampusGroups.NewPostControl" %>
<asp:TextBox ID="postTxtBox" runat="server" Height="120px" TextMode="MultiLine" Width="541px"></asp:TextBox>
<br />
<asp:PlaceHolder ID="PlaceHolderAtt" runat="server"></asp:PlaceHolder>
<br />
<asp:Button ID="addPostBrn" runat="server" Text="Відправити" OnClick="addPostBrn_Click" />
<asp:Button ID="addAttachmentBtn" runat="server" Text="Прикріпити файл" OnClick="addAttachmentBtn_Click" Visible="false"/>
<asp:FileUpload ID="FileUploadControl" runat="server" Visible="false"/>
<asp:Label ID="StatusLabel" runat="server" Text="" Visible="false"></asp:Label>

