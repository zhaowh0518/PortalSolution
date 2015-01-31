<%@ Page Title="" Language="C#" MasterPageFile="~/PortalSite.master" AutoEventWireup="true"
    CodeFile="Debug.aspx.cs" Inherits="Portal_Debug" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%=Application[ConstantUtility.Portal.ErrorMessageKey] %><br />
    <hr />
    <div>
        GetLeftPart:
        <%=Request.Url.GetLeftPart(UriPartial.Authority) %><br />
        UrlReferrer:
        <%=Request.UrlReferrer %><br />
        RawUrl:
        <%=Request.RawUrl %><br />
        Path:
        <%=Request.Path %><br />
        PhysicalPath:
        <%=Request.PhysicalPath %><br />
        UserHostAddress:
        <%=Request.UserHostAddress %><br />
        ApplicationPath:
        <%=Request.ApplicationPath %><br />
        <hr />
        AbsolutePath:
        <%=Request.Url.AbsolutePath %><br />
        AbsoluteUri:
        <%=Request.Url.AbsoluteUri %><br />
        Host:
        <%=Request.Url.Host %><br />
        LocalPath:
        <%=Request.Url.LocalPath %><br />
    </div>
</asp:Content>
