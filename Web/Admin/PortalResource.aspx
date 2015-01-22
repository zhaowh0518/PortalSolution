<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="PortalResource.aspx.cs" Inherits="Admin_PortalResource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <div class="divTitle">
            资源管理
        </div>
        <div class="divAction">
            <asp:FileUpload ID="fileImage" runat="server" Height="30px" Width="400px" />&nbsp;&nbsp;
            <asp:Button ID="btnUpload" runat="server" Text="上传" CssClass="btn" 
                onclick="btnUpload_Click" />
        </div>
        <div id="divPicList">
            <%  
                if (FileList != null && FileList.Keys != null)
                {
                    foreach (var item in FileList.Keys)
                    { %>
            <div class="imgItem">
                <a href="<%: FileList[item] %>" target="_blank">
                    <img alt="<%=item%>" src='<%: FileList[item] %>' title="<%=FileList[item] %>" /></a>
                <%=item %>
            </div>
            <% }
                }%>
        </div>
    </div>
</asp:Content>
