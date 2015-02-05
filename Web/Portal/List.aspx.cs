using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Portal_List : BasePage
{
    /// <summary>
    /// 当前要展示菜单的Code
    /// </summary>
    public string Keyword = string.Empty;

    //内容名称
    public string ContentName = string.Empty;
    /// <summary>
    /// 内容集列表
    /// </summary>
    public List<PortalContentItem> ContentItemList = new List<PortalContentItem>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Keyword = Request["Keyword"];
            GetData();
        }
    }

    protected override void GetData()
    {
        try
        {
            //文档列表
            if (!string.IsNullOrEmpty(Keyword))
            {
                PortalMenuList = _portalMenuBuiness.GetValidPortalMenuList(Keyword);
                PortalDocumentList = _portalDocumentBuiness.GetValidMenuPortalDocumentList(Keyword);
            }
            //内容集列表
            else
            {
                int contentID = Convert.ToInt32(Request["contentid"]);
                ContentItemList = new PortalContentItemBusiness().GetPortalContentItemList(contentID);
                ContentName = new PortalContentBusiness().GetPortalContent(contentID).Name;
            }
        }
        catch (Exception ex)
        {
            LogUtility.WritePortalDebugLog("BBS", ex);
        }
    }
}