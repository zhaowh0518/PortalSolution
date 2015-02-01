<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="Manager.aspx.cs" Inherits="Admin_Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divContent" style="width: 870px; overflow: auto">
        <div>
            <asp:TextBox ID="txtSqlText" runat="server" Width="700px"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnExcute" runat="server" Text="执行" OnClick="btnExcute_Click" />
        </div>
        <div class="message">
            <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
