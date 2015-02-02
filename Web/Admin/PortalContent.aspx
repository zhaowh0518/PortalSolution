<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="PortalContent.aspx.cs" Inherits="Admin_PortalContent" Theme="AdminTheme"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript" src="../Scripts/admin.js"></script>
    <div class="divNavList">
        <asp:TreeView ID="tvCategoryList" runat="server">
        </asp:TreeView>
    </div>
    <div class="divContent">
        <div class="divTitle">
            内容管理<div class="selectNodeInfo">
                <%=Request["name"] %></div>
        </div>
        <div class="divAction">
            <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="btn" OnClick="btnAdd_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnPush" runat="server" Text="推荐" CssClass="btn" OnClientClick="openDivDialog();return false;" />&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="返回" CssClass="btn" OnClick="btnCancel_Click" />&nbsp;&nbsp;
        </div>
        <div class="divMessage">
            <asp:Label ID="lbMessage" runat="server"></asp:Label>
        </div>
        <div class="divEdit">
            <asp:GridView ID="gvContentList" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="False"
                DataKeyNames="ID" OnRowDataBound="gvContentList_RowDataBound" OnRowDeleting="gvContentList_RowDeleting"
                OnRowEditing="gvContentList_RowEditing">
                <Columns>
                    <asp:TemplateField HeaderText="选择" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" HeaderText="操作" EditText="编辑" DeleteText="删除"
                        ShowDeleteButton="true" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="编号" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="名称" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="State" HeaderText="状态" ReadOnly="True" SortExpression="State" />
                    <asp:BoundField DataField="CreateDate" HeaderText="创建时间" SortExpression="CreateDate"
                        DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="IsSeries" HeaderText="是否是系列" SortExpression="IsSeries" />
                    <asp:HyperLinkField DataNavigateUrlFields="ID,Name" DataNavigateUrlFormatString="PortalContentItem.aspx?id={0}"
                        HeaderText="内容集" Text="设置内容集" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
            <asp:Panel ID="panelEdit" runat="server">
                <table>
                    <tr>
                        <td>
                            名称：
                        </td>
                        <td>
                            <asp:HiddenField ID="hiddenID" runat="server" />
                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            简介：
                        </td>
                        <td>
                            <asp:TextBox ID="txtDisplayName" runat="server" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            类型：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="select" Width="585px">
                                <asp:ListItem Selected="True" Text="视频" Value="0"></asp:ListItem>
                                <asp:ListItem Text="音频" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            描述：
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesciption" TextMode="MultiLine" runat="server" CssClass="textbox"
                                Height="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            图片：
                        </td>
                        <td>
                            <asp:FileUpload ID="fileImage" runat="server" CssClass="file" />&nbsp;&nbsp; <a href=""
                                target="_blank" id="linkViewImage" runat="server">查看</a>
                            <asp:HiddenField ID="hiddenImageURL" runat="server" />
                        </td>
                    </tr>
                    <tr class="hidden">
                        <td>
                            图2：
                        </td>
                        <td>
                            <asp:FileUpload ID="fileImage2" runat="server" CssClass="file" />&nbsp;&nbsp; <a
                                href="" target="_blank" id="linkViewImage2" runat="server">查看</a>
                            <asp:HiddenField ID="hiddenImageURL2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            代码：
                        </td>
                        <td>
                            <asp:TextBox ID="txtExtend1" runat="server" CssClass="textbox" Width="500px"></asp:TextBox>
                            &nbsp;&nbsp; <a href="Demo.aspx" target="_blank" runat="server">代码示例</a>
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
                            其他：
                        </td>
                        <td>
                            <asp:CheckBox ID="cbState" runat="server" Checked="true" Text="用户可见" />&nbsp;&nbsp;
                            <asp:CheckBox ID="cbBizStatus" runat="server" Text="作品完成" />&nbsp;&nbsp;
                            <asp:CheckBox ID="cbIsSeries" runat="server" Text="有内容集" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div id="divBackgroundLayer">
        </div>
        <div id="divDialog">
            <div id="divDialogContent">
                <h2>
                    请选择要推荐的菜单：</h2>
                <hr />
                <!--
                <div class="message">
                    * 推荐到文档类菜单（蓝色）为复制内容 * 推荐到内容类菜单（绿色）为引用内容
                    <hr />
                </div>
                -->
                <div id="divSelectMenuList">
                    <asp:TreeView ID="tvMenuList" runat="server">
                    </asp:TreeView>
                </div>
                <div id="divAction">
                    <asp:Button ID="btnSaveMenuItem" runat="server" Text="确定" CssClass="btn" OnClick="btnSaveMenuItem_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnClose" runat="server" Text="取消" CssClass="btn" OnClientClick="closeDivDialog();return false;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
