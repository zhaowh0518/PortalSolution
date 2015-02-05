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
    /// 当前系统中所有可见的内容分类
    /// </summary>
    public List<PortalCategory> CategoryList = new List<PortalCategory>();
    /// <summary>
    /// 当前分类下的所有内容
    /// </summary>
    public List<PortalContent> ContentList = new List<PortalContent>();

    /// <summary>
    /// 当前选中的根分类的ID
    /// </summary>
    public int CurrentCategoryID = 0;

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
            CategoryList = _portalCategoryBusiness.GetValidPortalCategoryList();
            if (!string.IsNullOrEmpty(Request["code"]))
            {
                ContentList = _portalContentBusiness.GetPortalContentList(Request["code"]);
                CurrentCategoryID = CategoryList.SingleOrDefault(p => p.Code == Request["code"]).ID;
            }
        }
        catch (Exception ex)
        {
            LogUtility.WritePortalDebugLog("Category", ex);
        }
    }
}