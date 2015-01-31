<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.master" AutoEventWireup="true"
    CodeFile="i.aspx.cs" Inherits="Portal_i" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row" id="thumbnails_container">
        <div class="col-md-12">
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-9 clear0">
            <div class="row  mgb10">
                <div class="col-xs-4 col-sm-3 col-md-3 " style="padding-left: 0">
                    <a href="#">
                        <img src="<%=CurrentUserInfo.HeadImgUrl%>" class="img-responsive">
                    </a>
                </div>
                <div class="col-xs-8 col-sm-9 col-md-9 ">
                    <div>
                        <h3>
                            <a href="#">
                                <%=CurrentUserInfo.NickName %></a></h3>
                        <p class="text-left font11 ">
                            <a href="#">
                                <%=CurrentUserInfo.Summary %></a></p>
                    </div>
                </div>
            </div>
            <div class="row  mgb10">
                <div class="col-xs-12 col-sm-12 col-md-12 clear0 ">
                    <div class="pdtop10 " id="divMenu">
                        <p class="text-left font12 fontred ">
                            <a href="i.aspx?type=2" class="btn btn-primary wh100">收藏</a><a href="i.aspx?type=3"
                                class="btn btn-default wh100">关注</a></p>
                    </div>
                </div>
            </div>
        </div>
        <%
            if (string.IsNullOrEmpty(Request["type"]) || Request["type"] == "2")
            {
                foreach (var item in CurrentUserFavoriteList)
                {

        %>
        <a href="<%=item.ContentURL%>">
            <div class="row thumbnail mgb10">
                <div class="col-xs-5 col-sm-3 col-md-3 ">
                    <img src="<%=ImageURL + item.ContentImageURL %>" alt="<%=item.ContentName %>" class="img-responsive">
                </div>
                <div class="col-xs-7 col-sm-9 col-md-9 ">
                    <h4>
                        <%=item.ContentName%></h4>
                    <p class="text-left font11 ">
                        <%=item.ContentSummary%></p>
                </div>
            </div>
        </a>
        <%
                }
            }
            else if (Request["type"] == "3")
            {
                foreach (var item in CurrentUserFeelList)
                {
        %>
        <a href="<%=item.ContentURL%>">
            <div class="row thumbnail mgb10">
                <div class="col-xs-5 col-sm-3 col-md-3 ">
                    <img src="<%=ImageURL + item.ContentImageURL %>" alt="<%=item.ContentName %>" class="img-responsive">
                </div>
                <div class="col-xs-7 col-sm-9 col-md-9 ">
                    <h4>
                        <%=item.ContentName%></h4>
                    <p class="text-left font11 ">
                        <%=item.ContentSummary%></p>
                </div>
            </div>
        </a>
        <%
                }
            }
        %>
    </div>
    <script type="text/javascript">
        setActiveTabMenu("divMenu", "btn btn-primary wh100", "btn btn-default wh100"); //选中导航菜单
    </script>
</asp:Content>
