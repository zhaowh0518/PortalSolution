<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="PortalDocument.aspx.cs" Inherits="Admin_PortalDocument" ValidateRequest="false"
    Theme="AdminTheme" %>

<%@ Register Src="../UserControl/wucCategoryList.ascx" TagName="wucCategoryList"
    TagPrefix="uc1" %>
<%@ Register Src="../UserControl/wucMenuList.ascx" TagName="wucMenuList" TagPrefix="uc2" %>
<%@ Register Assembly="eWebEditorControl" Namespace="eWebEditorControl" TagPrefix="eWebEditorControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divNavList">
        <uc2:wucMenuList ID="wucMenuList1" runat="server" />
    </div>
    <div class="divContent">
        <div class="divTitle">
            内容管理
        </div>
        <div class="divAction">
            <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="返回" OnClick="btnCancel_Click" />&nbsp;&nbsp;
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
                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox" Width="530px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            描述：
                        </td>
                        <td>
                            <eWebEditorControl:eWebEditor ID="eWebEditor1" runat="server" Skin="office2003" Width="550px"
                                Height="220px" BasePath="../ewebeditor/">
                            </eWebEditorControl:eWebEditor>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            图片：
                        </td>
                        <td>
                            <asp:FileUpload ID="fileImage" runat="server" Height="30px" Width="400px" />&nbsp;&nbsp;<asp:LinkButton
                                ID="lbtnViewImage" runat="server">查看</asp:LinkButton>
                            <asp:HiddenField ID="hiddenImageURL" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            链接：
                        </td>
                        <td>
                            <asp:TextBox ID="txtURL" runat="server" CssClass="textbox" Width="530px"></asp:TextBox>
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
        <div class="divMessage">
            <asp:Label ID="lbMessage" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
