using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Portal_Index : BasePage
{
    public string Keyword = "Index";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetData();
            if (!string.IsNullOrEmpty(Request["keyword"]))
            {
                Keyword = Request["keyword"];
            }
        }
    }
    /// <summary>
    /// 获取页面所需的数据
    /// </summary>
    protected override void GetData()
    {
        PortalMenuList = _portalMenuBuiness.GetValidPortalMenuList(Keyword);
        PortalDocumentList = _portalDocumentBuiness.GetValidMenuPortalDocumentList(Keyword);
    }
}