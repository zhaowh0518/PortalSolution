<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="SysConfig.aspx.cs" Inherits="Admin_SysConfig" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        DataSourceID="EntityDataSource1" AllowPaging="True" AllowSorting="True" CellPadding="4"
        SkinID="gridviewSkin">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="编号" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Code" HeaderText="编码" ReadOnly="True" SortExpression="Code" />
            <asp:BoundField DataField="Name" HeaderText="名称" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Value" HeaderText="值" SortExpression="Value" />
            <asp:BoundField DataField="Description" HeaderText="描述" SortExpression="Description" />
        </Columns>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=PortalEntities"
        DefaultContainerName="PortalEntities" EnableFlattening="False" EnableUpdate="True"
        EntitySetName="SysConfig" EntityTypeFilter="SysConfig">
    </asp:EntityDataSource>
</asp:Content>
