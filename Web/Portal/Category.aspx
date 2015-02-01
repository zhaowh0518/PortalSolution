<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.master" AutoEventWireup="true"
    CodeFile="Category.aspx.cs" Inherits="Portal_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row " id="thumbnails_container">
        <div class="col-md-6 col-xs-6 top20" id="divCategory">
            <a href="Category.aspx?code=Video" class="btn btn-primary">视频</a>&nbsp;&nbsp;<a href="Category.aspx?code=Audio"
                class="btn btn-default"> 音频</a></div>
    </div>
    <div class="row" id="thumbnails_container">
        <div class="col-md-12 ">
            <h3>
                连载中的作品</h3>
        </div>
        <div class="row">
            <%
                List<PortalModel.PortalContent> inProcessContentList = ContentList.Where(p => p.BizStatus == 0).ToList();
                foreach (var item in inProcessContentList)
                {

            %>
            <div class="col-xs-6 col-sm-3 col-md-3">
                <a href="<%=item.URL.Replace("{id}",item.ID.ToString())  %>" class="thumbnail">
                    <img src="<%=ImageURL + item.ImageURL %>" alt="<%=item.Name %>" class="img-responsive">
                    <p>
                        <%=item.Name %></p>
                </a>
            </div>
            <%
                }
            %>
        </div>
        <div class="col-md-12">
            <h3>
                已完结节的作品</h3>
        </div>
        <div class="row">
            <%
                List<PortalModel.PortalContent> finishedContentList = ContentList.Where(p => p.BizStatus == 1).ToList();
                foreach (var item in finishedContentList)
                {

            %>
            <div class="col-xs-6 col-sm-3 col-md-3">
                <a href="<%=item.URL.Replace("{id}",item.ID.ToString())  %>" class="thumbnail">
                    <img src="<%=ImageURL + item.ImageURL %>" alt="<%=item.Name %>" class="img-responsive">
                    <p>
                        <%=item.Name %></p>
                </a>
            </div>
            <%
                }
            %>
        </div>
    </div>
    <script type="text/javascript">
        setActiveTabMenu("divCategory", "btn btn-primary", "btn btn-default"); //选中导航菜单
    </script>
</asp:Content>
