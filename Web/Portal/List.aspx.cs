using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portal_List : BasePage
{
    /// <summary>
    /// 当前要展示菜单的Code
    /// </summary>
    public string Keyword = string.Empty;

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
        PortalMenuList = _portalMenuBuiness.GetValidPortalMenuList();
        PortalDocumentList = _portalDocumentBuiness.GetMenuPortalDocumentList(Keyword);
    }
}