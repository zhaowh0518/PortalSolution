using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Portal_Index : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetData();
        }
    }
    /// <summary>
    /// 获取页面所需的数据
    /// </summary>
    private void GetData()
    {
        PortalMenuList = _portalMenuBuiness.GetPortalMenuList();
        PortalDocumentList = _portalDocumentBuiness.GetMenuPortalDocumentList("Index");
    }
}