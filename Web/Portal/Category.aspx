<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.master" AutoEventWireup="true"
    CodeFile="Category.aspx.cs" Inherits="Portal_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row " id="thumbnails_container">
        <div class="col-md-6 col-xs-6 top20" id="divCategory">
            <%
                //一级分类
                List<PortalModel.PortalCategory> rootCategoryList = CategoryList.Where(p => p.ParentID == 0).ToList();
                foreach (var item in rootCategoryList)
                {

            %>
            <a href="Category.aspx?code=<%=item.Code %>" class="btn btn-default">
                <%=item.Name %></a>&nbsp;&nbsp;
            <%
                }
            %>
        </div>
    </div>
    <div class="row" id="thumbnails_container">
        <%
            //二级分类
            List<PortalModel.PortalCategory> childCategoryList = CategoryList.Where(p => p.ParentID == CurrentCategoryID).ToList();
            foreach (var item in childCategoryList)
            {

        %>
        <div class="col-md-12 ">
            <h3>
                <%=item.Name %></h3>
        </div>
        <div class="row">
            <%
                List<PortalModel.PortalContent> categoryContentList = ContentList.Where(p => p.CategoryID == item.ID).ToList();
                foreach (var content in categoryContentList)
                {

            %>
            <div class="col-xs-6 col-sm-3 col-md-3">
                <a href="<%=content.URL.Replace("{id}",item.ID.ToString())  %>" class="thumbnail">
                    <img src="<%=ImageURL + content.ImageURL %>" alt="<%=content.Name %>" class="img-responsive">
                    <p>
                        <%=content.Name%></p>
                </a>
            </div>
            <%
                }
            %>
        </div>
        <%
            }
        %>
    </div>
    <script type="text/javascript">
        setActiveTabMenu("divCategory", "btn btn-primary", "btn btn-default"); //选中导航菜单
    </script>
</asp:Content>
