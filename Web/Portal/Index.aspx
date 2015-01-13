<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Portal_Index" %>

<%@ OutputCache Location="Any" Duration="30" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row" id="thumbnails_container">
        <div class="col-md-12 ">
            <h3>
                <%=PortalMenuList.Single(p=>p.Code=="Index_NewWorks").Name %>
            </h3>
        </div>
        <div class="row">
            <%
                List<PortalModel.PortalDocument> newWorksList = PortalDocumentList.Where(p => p.PortalMenuCode == "Index_NewWorks").ToList();
                foreach (var item in newWorksList)
                {

            %>
            <div class="col-xs-6 col-sm-3 col-md-3">
                <a href="<%=item.URL %>" class="thumbnail">
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
                <%=PortalMenuList.Single(p => p.Code == "Index_FinishedAlbum").Name%></h3>
        </div>
        <div class="row">
            <%
                List<PortalModel.PortalDocument> finishedAlbumList = PortalDocumentList.Where(p => p.PortalMenuCode == "Index_FinishedAlbum").ToList();
                foreach (var item in finishedAlbumList)
                {

            %>
            <div class="col-xs-6 col-sm-3 col-md-3">
                <a href="<%=item.URL %>" class="thumbnail">
                    <img src="<%=ImageURL + item.ImageURL %>" alt="<%=item.Name %>" class="img-responsive">
                    <p class="tzzt">
                        <%=item.Name %></p>
                </a>
            </div>
            <%
                }
            %>
        </div>
        <div class="col-md-9 clear0">
            <%
                List<PortalModel.PortalDocument> bbsList = PortalDocumentList.Where(p => p.PortalMenuCode == "Index_BBS").ToList();
                foreach (var item in bbsList)
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
            %>
        </div>
    </div>
    <!-- thumbnail area -->
</asp:Content>
