<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="PortalContentItem.aspx.cs" Inherits="Admin_PortalContentItem" Theme="AdminTheme"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divNavList">
        <div id="divContentInfo">
            <p>
                内容名称：<br />
                <%=CurrentPortalCuurent.Name %><br />
            </p>
            <hr />
            <p>
                内容简介：<br />
                <%=CurrentPortalCuurent.DisplayName %><br />
            </p>
            <hr />
            <p>
                创建时间：<br />
                <%=CurrentPortalCuurent.CreateDate.ToString("yyyy-MM-dd") %><br />
            </p>
        </div>
    </div>
    <div class="divContent">
        <div class="divTitle">
            内容集管理
        </div>
        <div class="divAction">
            <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="btn" OnClick="btnAdd_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="返回" CssClass="btn" OnClick="btnCancel_Click" />&nbsp;&nbsp;
        </div>
        <div class="divMessage">
            <asp:Label ID="lbMessage" runat="server"></asp:Label>
        </div>
        <div class="divEdit">
            <asp:GridView ID="gvContentItemList" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="False"
                DataKeyNames="ID" OnRowDataBound="gvContentItemList_RowDataBound" OnRowDeleting="gvContentItemList_RowDeleting"
                OnRowEditing="gvContentItemList_RowEditing">
                <Columns>
                    <asp:CommandField ShowEditButton="True" HeaderText="操作" EditText="编辑" DeleteText="删除"
                        ShowDeleteButton="true" ItemStyle-HorizontalAlign="Center"></asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="编号" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="名称" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="State" HeaderText="状态" ReadOnly="True" SortExpression="State" />
                    <asp:BoundField DataField="CreateDate" HeaderText="创建时间" SortExpression="CreateDate"
                        DataFormatString="{0:yyyy-MM-dd}" />
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
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="select">
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
                            <asp:TextBox ID="txtDesciption" TextMode="MultiLine" runat="server" Width="580px"
                                CssClass="textbox" Height="150px"></asp:TextBox>
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
                            <asp:TextBox ID="txtExtend1" runat="server" CssClass="textbox"></asp:TextBox>
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
                            &nbsp;&nbsp;集数：
                            <asp:TextBox ID="txtSeq" runat="server" Text="1" Height="20px" CssClass="textbox"
                                Width="30px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                            <asp:CheckBox ID="cbState" runat="server" Checked="true" Text="用户可见" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
