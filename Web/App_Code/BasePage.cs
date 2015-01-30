using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
    protected PortalMenuBusiness _portalMenuBuiness = new PortalMenuBusiness();
    protected PortalDocumentBusiness _portalDocumentBuiness = new PortalDocumentBusiness();
    protected PortalContentBusiness _portalContentBusiness = new PortalContentBusiness();
    protected PortalContentItemBusiness _portalContentItemBusiness = new PortalContentItemBusiness();
    protected PortalMenuItemBusiness _portalMenuItemBusiness = new PortalMenuItemBusiness();


    /// <summary>
    /// 当前页面的菜单
    /// </summary>
    public List<PortalMenu> PortalMenuList { get; set; }
    /// <summary>
    /// 当前页面的所有文档
    /// </summary>
    public List<PortalDocument> PortalDocumentList { get; set; }
    /// <summary>
    /// 图片路径的前半部分URL
    /// </summary>
    public string ImageURL { get { return ConstantUtility.Site.ImageURLPath; } }

    public BasePage()
    {

    }
    /// <summary>
    /// 加载菜单PortalMenuList和文档PortalDocumentList
    /// </summary>
    protected virtual void GetData()
    {
        PortalMenuList = new List<PortalMenu>();
        PortalDocumentList = new List<PortalDocument>();
    }
    /// <summary>
    /// 提取异常信息
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    protected string GetErrorMessage(Exception ex)
    {
        return ex.InnerException == null ? ex.Message : ex.InnerException.Message;
    }
}