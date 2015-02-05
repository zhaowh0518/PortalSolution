using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portal_BBS : BasePage
{
    /// <summary>
    /// 当前要展示菜单的Code
    /// </summary>
    public string Keyword = "BBS";

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
            PortalDocumentList = _portalDocumentBuiness.GetValidMenuPortalDocumentList(Keyword);
        }
        catch (Exception ex)
        {
            LogUtility.WritePortalDebugLog("BBS", ex);
        }
    }
}