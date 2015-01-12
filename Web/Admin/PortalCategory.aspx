<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="PortalCategory.aspx.cs" Inherits="Admin_PortalCategory" %>

<%@ Register Src="../UserControl/wucCategoryList.ascx" TagName="wucCategoryList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divNavList">
        <uc1:wucCategoryList ID="wucCategoryList1" runat="server" />
    </div>
    <div class="divContent">
        <div class="divTitle">
            内容分类管理
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
