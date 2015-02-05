using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;
using UserModel;

/// <summary>
///BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
    protected PortalMenuBusiness _portalMenuBuiness = new PortalMenuBusiness();
    protected PortalDocumentBusiness _portalDocumentBuiness = new PortalDocumentBusiness();
    protected PortalCategoryBusiness _portalCategoryBusiness = new PortalCategoryBusiness();
    protected PortalContentBusiness _portalContentBusiness = new PortalContentBusiness();
    protected PortalContentItemBusiness _portalContentItemBusiness = new PortalContentItemBusiness();
    protected PortalMenuItemBusiness _portalMenuItemBusiness = new PortalMenuItemBusiness();

    WeinxinWeb wxWeb = new WeinxinWeb();

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
    /// <summary>
    /// 当前请求URL的根路径
    /// </summary>
    public string HttpUrlBase
    {
        get
        {
            string url = Request.Url.GetLeftPart(UriPartial.Authority);
            if (Request.ApplicationPath != null && Request.ApplicationPath != "/")
                url = url + Request.ApplicationPath;
            return url;
        }
    }

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


    protected void CheckUser()
    {
        if (Session[ConstantUtility.Portal.UserIDKey] == null)
        {
            //如果用户ID为空则去做微信认证
            string redirect_url = Request.Url.AbsoluteUri;
            Response.Redirect(wxWeb.GetAuthorizeUrl(redirect_url, "auth"));
        }
    }

    protected void GetWXUser(string code)
    {
        try
        {
            WXWebAccessToken accessToken = wxWeb.GetAccessToken(code);
            WXUserInfo wxUser = new WXUserInfo();
            if (accessToken != null)
            {
                wxUser = wxWeb.GetUserInfo(accessToken);
                if (wxUser != null & !string.IsNullOrEmpty(wxUser.openid))
                {
                    //保存用户到数据库
                    UserInfo userInfo = new UserInfo();
                    userInfo.City = wxUser.city;
                    userInfo.Country = wxUser.country;
                    userInfo.HeadImgUrl = wxUser.headimgurl;
                    userInfo.NickName = wxUser.nickname;
                    userInfo.OpenID = wxUser.openid;
                    userInfo.province = wxUser.province;
                    userInfo.Sex = string.IsNullOrEmpty(wxUser.sex) ? 0 : Convert.ToInt32(wxUser.sex);
                    userInfo.UnionID = wxUser.unionid;
                    userInfo.Summary = string.Empty;
                    int userID = new UserBusiness().AddSycUser(userInfo);

                    //在Session中记录用户信息
                    Session[ConstantUtility.Portal.UserIDKey] = userID;
                    Session[ConstantUtility.Portal.UserNameKey] = userInfo.NickName;
                }
            }
        }
        catch (Exception ex)
        {
            LogUtility.WritePortalDebugLog("GetWXUser", ex);
        }
    }
}