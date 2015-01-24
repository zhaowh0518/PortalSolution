<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="PortalMenuItem.aspx.cs" Inherits="Admin_PortalMenuItem" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divNavList">
        <asp:TreeView ID="tvMenuList" runat="server">
        </asp:TreeView>
    </div>
    <div class="divContent">
        <div class="divTitle">
            菜单内容<div class="selectNodeInfo">
                <%=Request["name"] %></div>
        </div>
        <div class="divAction">
            序号：<asp:TextBox ID="txtSeq" runat="server" CssClass="textbox" Width="60px" Height="25px"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="btnSeq" runat="server" Text="设置序号" Width="80px" CssClass="btn" OnClick="btnSeq_Click" />
            &nbsp;&nbsp;| &nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="移出" CssClass="btn" OnClick="btnDelete_Click" />
        </div>
        <div class="divMessage">
            <asp:Label ID="lbMessage" runat="server"></asp:Label>
        </div>
        <div class="divEdit">
            <asp:GridView ID="gvMenuItemList" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="False"
                DataKeyNames="ID">
                <Columns>
                    <asp:TemplateField HeaderText="选择" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" HeaderText="操作" EditText="编辑" ItemStyle-HorizontalAlign="Center">
                    </asp:CommandField>
                    <asp:BoundField DataField="ContentName" HeaderText="名称" ReadOnly="True" SortExpression="ContentName" />
                    <asp:BoundField DataField="Seq" HeaderText="序号" ReadOnly="False" SortExpression="Seq" />
                    <asp:BoundField DataField="CreateDate" HeaderText="创建时间" SortExpression="CreateDate" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
