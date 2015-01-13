<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Portal_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row" id="thumbnails_container">
        <div class="col-md-12 clear0">
            <h3>
                <%=PortalMenuList.Single(p=>p.Code==Keyword).Name %></h3>
        </div>
        <%
            foreach (var item in PortalDocumentList)
            {

        %>
        <a href="<%=item.URL %>">
            <div class="row thumbnail mgb10">
                <div class="col-xs-5 col-sm-3 col-md-3 ">
                    <img src="<%=ImageURL + item.ImageURL %>" alt="<%=item.Name %>" class="img-responsive">
                </div>
                <div class="col-xs-7 col-sm-9 col-md-9 ">
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
</asp:Content>
