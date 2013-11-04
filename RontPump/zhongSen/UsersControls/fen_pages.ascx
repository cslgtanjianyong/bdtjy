<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="fen_pages.ascx.cs" Inherits="BkShop.UsersControls.fen_pages" %>
<div style="text-align:center; font-size:13px; width:700px; height:30px; margin:0 auto;">
    
    <asp:LinkButton ID="likFirst" runat="server" CommandName="First" 
        onclick="OPerate_Click">首页</asp:LinkButton>&nbsp;
    <asp:LinkButton ID="likUp" runat="server" onclick="OPerate_Click" CommandName="Up">上一页</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="likNext" runat="server" onclick="OPerate_Click" CommandName="Next">下一页</asp:LinkButton>&nbsp;
    <asp:LinkButton ID="likEnd" runat="server" CommandName="End" 
        onclick="OPerate_Click">尾页</asp:LinkButton>&nbsp;
    跳转到
        <asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
        AutoPostBack="True"></asp:DropDownList>
        页&nbsp;&nbsp;共<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>页&nbsp;
        第<asp:Label ID="Label1" runat="server" Text="0"><%=PagesIndex %></asp:Label>页&nbsp;
</div>
