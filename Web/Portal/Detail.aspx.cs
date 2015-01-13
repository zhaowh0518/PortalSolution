using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Portal_Detail : BasePage
{
    public PortalMenu CurrentPortalMenu = new PortalMenu();
    public PortalDocument CurrentPortalDocument = new PortalDocument();
    public List<PortalComment> CurrentPortalCommentList = new List<PortalComment>();

    private PortalCommentBusiness _portalCommentBusiness = new PortalCommentBusiness();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetData();
        }
    }

    protected override void GetData()
    {
        try
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                CurrentPortalDocument = _portalDocumentBuiness.GetPortalDocument(Convert.ToInt32(Request["id"]));
                if (CurrentPortalDocument != null)
                {
                    CurrentPortalMenu = _portalMenuBuiness.GetPortalMenu(CurrentPortalDocument.PortalMenuID);
                    CurrentPortalCommentList = _portalCommentBusiness.GetPortalCommentList(CurrentPortalDocument.ID);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            PortalComment comment = new PortalComment();
            comment.Comment = txtComment.InnerText;
            comment.ContentID = Convert.ToInt32(Request["id"]);
            if (Session["UserID"] != null)
            {
                comment.UserID = Convert.ToInt32(Session["UserID"]);
            }
            if (Session["UserName"] != null)
            {
                comment.UserName = Session["UserName"].ToString();
            }
            else
            {
                comment.UserName = "匿名";
            }
            _portalCommentBusiness.AddPortalComment(comment);
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {

        }
    }
}