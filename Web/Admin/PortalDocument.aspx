<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="PortalDocument.aspx.cs" Inherits="Admin_PortalDocument" ValidateRequest="false"
    EnableEventValidation="false" Theme="AdminTheme" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divNavList">
        <ucML:wucMenuList ID="wucMenuList1" runat="server" />
    </div>
    <div class="divContent">
        <div class="divTitle">
            内容管理
        </div>
        <div class="divAction">
            <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" CssClass="btn" />&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" CssClass="btn" />&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="返回" OnClick="btnCancel_Click" CssClass="btn" />&nbsp;&nbsp;
        </div>
        <div class="divMessage">
            <asp:Label ID="lbMessage" runat="server"></asp:Label>
        </div>
        <div class="divEdit">
            <asp:GridView ID="gvDocumentList" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="false"
                DataKeyNames="ID" OnRowEditing="gvDocumentList_RowEditing" OnRowDeleting="gvDocumentList_RowDeleting"
                OnRowDataBound="gvDocumentList_RowDataBound">
                <Columns>
                    <asp:CommandField ShowEditButton="True" HeaderText="操作" EditText="编辑" DeleteText="删除"
                        ShowDeleteButton="true" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Name" HeaderText="名称" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="Seq" HeaderText="序号" SortExpression="Seq" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="State" HeaderText="状态" SortExpression="State" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="CreateDate" HeaderText="创建时间" SortExpression="CreateDate"
                        ItemStyle-HorizontalAlign="Center" />
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
                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox" Width="580px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            简介：
                        </td>
                        <td>
                            <asp:TextBox ID="txtDisplayName" runat="server" CssClass="textbox" Width="580px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            描述：
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="richEditor" runat="server" BasePath="../Library/ckeditor/"
                                Width="600px" Skin="office2003">
                            </CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            图片：
                        </td>
                        <td>
                            <asp:FileUpload ID="fileImage" runat="server" Height="30px" Width="500px" />&nbsp;&nbsp;
                            <a href="" target="_blank" id="linkViewImage" runat="server">查看</a>
                            <asp:HiddenField ID="hiddenImageURL" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            链接：
                        </td>
                        <td>
                            <asp:TextBox ID="txtURL" runat="server" CssClass="textbox" Width="580px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            顺序：
                        </td>
                        <td>
                            <asp:TextBox ID="txtSeq" runat="server" Text="100" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                            状态：&nbsp;&nbsp;
                            <asp:CheckBox ID="cbState" runat="server" Checked="true" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
