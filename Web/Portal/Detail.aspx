<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.master" AutoEventWireup="true"
    CodeFile="Detail.aspx.cs" Inherits="Portal_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="Form1" runat="server">
    <div class="row" id="thumbnails_container">
        <div class="col-md-12 clear0">
            <h3>
                <%=CurrentProgram.ParentName%></h3>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 clear0">
            <div class="preview_footer_container">
                <div class="footer_item section_box2 col-xs-12 col-sm-12 col-md-12">
                    <div class="  time01 bot10">
                        发表于:<%=CurrentProgram.CreateDate%><span class="right"></span></div>
                    <div class="col-xs-12 col-sm-12 col-md-12  clear0 fontxiao bot20 ">
                        <div class="col-xs-6 col-sm-8 col-md-8 clear0 fontbt">
                            <%=CurrentProgram.Name%></div>
                        <div class="right">
                            <asp:Button runat="server" Text="点攒" CssClass="btn btn-default" ID="btnFeel" OnClick="btnFeel_Click" />
                            <asp:Button runat="server" Text="收藏" CssClass="btn btn-default" ID="btnFavorite"
                                OnClick="btnFavorite_Click" />
                        </div>
                    </div>
                    <div class="clear">
                        &nbsp;<input id="txtImagUrl" type="hidden" value=" <%=HttpUrlBase + "/Resources/Images/" + CurrentProgram.ImageURL%>" />
                    </div>
                    <div>
                        <%=CurrentProgram.ContentType ==2 ? string.Empty : CurrentProgram.Code%></div>
                    <div id="divDescription">
                        <%=Server.HtmlDecode(CurrentProgram.Description)%>
                    </div>
                    <div class="col-xs-12 col-md-12 clear0 bot30">
                        <a class="zf001 sm0">转发：</a>
                        <div class="bdsharebuttonbox">
                            <a href="#" class="bds_more" data-cmd="more"></a><a href="#" class="bds_qzone" data-cmd="qzone"
                                title="分享到QQ空间"></a><a href="#" class="bds_tsina" data-cmd="tsina" title="分享到新浪微博">
                            </a><a href="#" class="bds_tqq" data-cmd="tqq" title="分享到腾讯微博"></a><a href="#" class="bds_renren"
                                data-cmd="renren" title="分享到人人网"></a><a href="#" class="bds_weixin" data-cmd="weixin"
                                    title="分享到微信"></a>
                        </div>
                        <script type="text/javascript">
                            var text = document.getElementById("divDescription").innerHTML;
                            var imgUrl = document.getElementById("txtImagUrl").value;

                            window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": text, "bdMini": "2", "bdMiniList": false, "bdPic": imgUrl, "bdStyle": "0", "bdSize": "32" }, "share": {} };
                            with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];           
                        </script>
                    </div>
                </div>
                <div class="col-md-12 clear0">
                    <h3>
                        评论</h3>
                </div>
                <div class="form-group left-inner-addon bot60">
                    <span class="glyphicon glyphicon-comment"></span>
                    <textarea name="message" runat="server" rows="6" class="form-control" id="txtComment"
                        placeholder="请输入评论..."></textarea>
                    <br>
                    <asp:Button runat="server" Text="发表" CssClass="btn btn-primary right" ID="btnSubmit"
                        OnClick="btnSubmit_Click" />
                </div>
                <%
                    int counter = 0;
                    foreach (var item in CurrentProgram.CommentList)
                    {
                        counter++;

                %>
                <div class="footer_item section_box2 box2color col-xs-12 col-sm-12 col-md-12">
                    <div>
                        <h4>
                            <%=item.UserName %></h4>
                        <div class="time01">
                            发表于:
                            <%=item.CreateDate %><span class="right"><%=counter%>楼</span></div>
                    </div>
                    <p>
                        <%=item.Comment %></p>
                </div>
                <%
                    }
                %>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
