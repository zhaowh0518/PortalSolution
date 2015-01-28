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
    /// 当前分类的编码
    /// </summary>
    public string CategoryCode = string.Empty;
    /// <summary>
    /// 当前分类下的所有内容
    /// </summary>
    public List<PortalContent> ContentList = new List<PortalContent>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CategoryCode = Request["code"];
            if (!string.IsNullOrEmpty(CategoryCode))
            {
                ContentList = _portalContentBusiness.GetPortalContentList(CategoryCode);
            }
        }
    }
}