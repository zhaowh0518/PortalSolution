<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.master" AutoEventWireup="true"
    CodeFile="Demo.aspx.cs" Inherits="Admin_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divNavList">
        <asp:TreeView ID="tvList" runat="server">
            <Nodes>
                <asp:TreeNode Text="视频代码示例" NavigateUrl="~/Admin/Demo.aspx?type=0"></asp:TreeNode>
                <asp:TreeNode Text="音频代码示例" NavigateUrl="~/Admin/Demo.aspx?type=1"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    </div>
    <div class="divContent">
        <div class="divTitle">
            示例</div>
        <div id="divVideoShow" runat="server">
            <embed src="http://player.youku.com/player.php/sid/XODUzNjk2NzUy/v.swf" allowfullscreen="true"
                quality="high" width="480" height="400" align="middle" allowscriptaccess="always"
                type="application/x-shockwave-flash"></embed>
        </div>
        <div>
            &nbsp;</div>
        <div id="divAudioShow" runat="server">
            <embed src="http://app.yuantengfei.org/ytf/upload/mp3/zhg/4.mp3" width="480" height="40"
                volume="0" loop="-1" autostart="0"> </embed>
        </div>
        <div>
            <asp:TextBox ID="txtCode" TextMode="MultiLine" runat="server" Width="650px" Height="50px"></asp:TextBox>
        </div>
    </div>
</asp:Content>
