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
            <iframe class="iframevd top20" height="500" width="500" src="http://player.youku.com/embed/XNzgwNDc2OTc2"
                frameborder="0" allowfullscreen></iframe>
        </div>
        <div>
            &nbsp;</div>
        <div id="divAudioShow" runat="server">
            <div class="bot20">
                <audio preload="auto" controls>
                <source src="http://app.yuantengfei.org/ytf/upload/mp3/zhg/4.mp3">
              </audio>
                <script src="../Portal/js/jquery.js" type="text/javascript"></script>
                <script src="../Portal/js/audioplayer.js" type="text/javascript"></script>
                <script type="text/javascript">
                    $(function () { $('audio').audioPlayer(); });</script>
            </div>
        </div>
        <div>
            <asp:TextBox ID="txtCode" TextMode="MultiLine" runat="server" Width="650px" Height="50px"></asp:TextBox>
        </div>
    </div>
</asp:Content>
