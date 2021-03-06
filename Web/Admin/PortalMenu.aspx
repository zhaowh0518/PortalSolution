﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="PortalMenu.aspx.cs" Inherits="Admin_PortalMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divNavList">
        <asp:TreeView ID="tvMenuList" runat="server">
        </asp:TreeView>
    </div>
    <div class="divContent">
        <div class="divTitle">
            栏目管理<div class="selectNodeInfo">
                <%=Request["name"] %></div>
        </div>
        <div class="divAction">
            <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" CssClass="btn" />&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" Text="更新" OnClick="btnUpdate_Click" CssClass="btn" />&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" CssClass="btn" />&nbsp;&nbsp;
        </div>
        <div class="divEdit">
            <table>
                <tr>
                    <td>
                        名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName"
                            runat="server" Text="*" CssClass="required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        编码：
                    </td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCode"
                            runat="server" Text="*" CssClass="required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        类型：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMenuType" runat="server" CssClass="select">
                            <asp:ListItem Selected="True" Value="0">父菜单</asp:ListItem>
                            <asp:ListItem Value="1">内容菜单</asp:ListItem>
                            <asp:ListItem Value="2">文档菜单</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        风格：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStyle" runat="server" CssClass="select">
                            <asp:ListItem Selected="True" Value="0">目录类</asp:ListItem>
                            <asp:ListItem Value="1">内容类</asp:ListItem>
                            <asp:ListItem Value="2">社区类</asp:ListItem>
                        </asp:DropDownList>
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
