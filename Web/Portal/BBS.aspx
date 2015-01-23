<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.master" AutoEventWireup="true"
    CodeFile="BBS.aspx.cs" Inherits="Portal_BBS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row" id="thumbnails_container">
        <div class="col-md-12 clear0">
            <h3>
                社区</h3>
        </div>
        <div class="col-md-9 clear0">
            <%
                foreach (var item in PortalDocumentList)
                {

            %>
            <a href="<%=item.URL %>">
                <div class="row thumbnail mgb10">
                    <div class="col-xs-4 col-sm-2 col-md-2 ">
                        <img src="<%=ImageURL + item.ImageURL %>" alt="<%=item.Name %>" class="img-responsive">
                    </div>
                    <div class="col-xs-8 col-sm-9 col-md-9 ">
                        <h4>
                            <%=item.Name %></h4>
                        <p class="text-left font11 ">
                            <%=item.DisplayName %></p>
                    </div>
                </div>
            </a>
            <%
                }
            %>
        </div>
        <!-- preview_footer_container -->
    </div>
</asp:Content>
