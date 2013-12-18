<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="CampusGroups.UserControl" %>

<asp:Image ID="avatarImg" runat="server" />
&nbsp;<asp:Label ID="usernameLbl" runat="server" Text=""></asp:Label>
&nbsp;
<br />
<asp:Label ID="userProfileType" runat="server" Text=""></asp:Label>
<asp:ImageButton ID="myGroupsBtn" runat="server" OnClick="myGroupsBtn_Click" ImageUrl="~\icons\group.png"/>
<asp:ImageButton ID="setAvatarBtn" runat="server" Height="16px" OnClick="setAvatarBtn_Click" />
<asp:ImageButton ID="viewAllGroupsBtn" runat="server" OnClick="viewAllGroupsBtn_Click" />
<asp:ImageButton ID="newGroupBtn" runat="server" OnClick="newGroupBtn_Click" />
<br />
<asp:Label ID="userDepartment" runat="server" Text=""></asp:Label>
<br />
<asp:PlaceHolder ID="PlaceHolderNestedControl" runat="server"></asp:PlaceHolder>



