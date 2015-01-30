using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Portal_Category : BasePage
{
    /// <summary>
    /// 当前分类下的所有内容
    /// </summary>
    public List<PortalContent> ContentList = new List<PortalContent>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["code"]))
            {
                ContentList = _portalContentBusiness.GetPortalContentList(Request["code"]);
            }
        }
    }
}