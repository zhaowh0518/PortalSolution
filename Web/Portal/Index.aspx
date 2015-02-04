<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Portal_Index" %>

<%@ OutputCache Location="Any" Duration="30" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">         /*         VIEWPORT BUG FIX         iOS viewport scaling bug fix, by @mathias, @cheeaun and @jdalton         */
        (function (doc) { var addEvent = 'addEventListener', type = 'gesturestart', qsa = 'querySelectorAll', scales = [1, 1], meta = qsa in doc ? doc[qsa]('meta[name=viewport]') : []; function fix() { meta.content = 'width=device-width,minimum-scale=' + scales[0] + ',maximum-scale=' + scales[1]; doc.removeEventListener(type, fix, true); } if ((meta = meta[meta.length - 1]) && addEvent in doc) { fix(); scales = [.25, 1.6]; doc[addEvent](type, fix, true); } } (document));     </script>
    <div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="3000">
        <!-- 轮播（Carousel）指标 -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>
        <!-- 轮播（Carousel）项目 -->
        <div class="carousel-inner">
            <%
                List<PortalModel.PortalDocument> adList = PortalDocumentList.Where(p => p.PortalMenuCode == "Index_AD").ToList();
                bool isActive = true;
                foreach (var item in adList)
                {

            %>
            <div class="item <%=isActive?"active":"" %>">
                <img src="<%=ImageURL + item.ImageURL %>" alt="<%=item.Name %>">
            </div>
            <%
                isActive = false;
                }
            %>
        </div>
        <!-- 轮播（Carousel）导航 -->
        <a class="carousel-control left" href="#myCarousel" data-slide="prev">&lsaquo;</a>
        <a class="carousel-control right" href="#myCarousel" data-slide="next">&rsaquo;</a>
    </div>
    <script>         $(function () {
    // 初始化轮播
    $(".start-slide").click(function () {
        $("#myCarousel").carousel('cycle');
    });
});             </script>
    <script src="js/audioplayer.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row" id="thumbnails_container">
        <%               
                foreach (var menu in PortalMenuList)
                {
                    if(menu.Style >0)
                    {
        %>
        <div class="col-md-12 ">
            <h3>
                <%=menu.Name %>
            </h3>
        </div>
        <div class="row">
            <%
                    List<PortalModel.PortalDocument> documentList = PortalDocumentList.Where(p => p.PortalMenuID == menu.ID).ToList();
                    foreach (var item in documentList)
                    {
                        if(menu.Style == 1)
                        {
            %>
            <div class="col-xs-6 col-sm-3 col-md-3">
                <a href="<%=item.URL.Replace("{id}",item.ID.ToString()) %>" class="thumbnail">
                    <img src="<%=ImageURL + item.ImageURL %>" alt="<%=item.Name %>" class="img-responsive">
                    <p>
                        <%=item.Name %></p>
                </a>
            </div>
            <%
                }
                else if(menu.Style == 2)
                {
            %>
            <a href="<%=item.URL %>">
                <div class="row thumbnail mgb10">
                    <div class="col-xs-4 col-sm-2 col-md-2 ">
                        <img src="<%=ImageURL + item.ImageURL %>" alt="<%=item.Name %>" class="img-responsive">
                    </div>
                    <div class="col-xs-8 col-sm-9 col-md-9 ">
                        <div>
                            <h4>
                                <%=item.Name %></h4>
                            <p class="text-left font11 ">
                                <%=item.DisplayName %></p>
                        </div>
                        <div class="pdtop10">
                            <p class="text-left font12 fontred ">
                                <span></span><span class=" right"></span>
                            </p>
                        </div>
                    </div>
                </div>
            </a>
            <%
                }
               }
            %>
        </div>
        <%
            }
                }
        %>
    </div>
    <!-- thumbnail area -->
</asp:Content>
