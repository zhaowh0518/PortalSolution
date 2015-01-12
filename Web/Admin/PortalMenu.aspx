<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="PortalMenu.aspx.cs" Inherits="Admin_PortalMenu" %>

<%@ Register Src="../UserControl/wucCategoryList.ascx" TagName="wucCategoryList"
    TagPrefix="uc1" %>
<%@ Register Src="../UserControl/wucMenuList.ascx" TagName="wucMenuList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divNavList">
        <uc2:wucMenuList ID="wucMenuList1" runat="server" />
    </div>
    <div class="divContent">
        <div class="divTitle">
            栏目管理
        </div>
        <div class="divAction">
            <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" Text="更新" OnClick="btnUpdate_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" Style="height: 21px" />&nbsp;&nbsp;
        </div>
        <div class="divEdit">
            <table>
                <tr>
                    <td>
                        名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        编码：
                    </td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        链接：
                    </td>
                    <td>
                        <asp:TextBox ID="txtURL" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        顺序：
                    </td>
                    <td>
                        <asp:TextBox ID="txtSeq" runat="server" Text="100" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        状态：
                    </td>
                    <td>
                        <asp:CheckBox ID="cbState" runat="server" Checked="true" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="divMessage">
            <asp:Label ID="lbMessage" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
