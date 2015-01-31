using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;
using UserModel;

public partial class Portal_Detail : BasePage
{
    public Program CurrentProgram = new Program();
    public int CurrentUserID = 0;
    public string CurrentUserName = string.Empty;

    WeinxinWeb wxWeb = new WeinxinWeb();

    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request["code"];
        if (!string.IsNullOrEmpty(code)) //从微信返回来
        {
            GetWXUser(code);
        }
        GetData();
    }

    protected override void GetData()
    {
        try
        {
            if (!string.IsNullOrEmpty(Request["id"]) && !string.IsNullOrEmpty(Request["type"]))
            {
                int id = Convert.ToInt32(Request["id"]);
                int type = Convert.ToInt32(Request["type"]);
                CurrentProgram = Program.GetProgram(id, type);
                if (CurrentProgram != null)
                {
                    ShowActInfo();
                }
                else
                {
                    CurrentProgram = new Program();
                }
            }
            if (Session[ConstantUtility.Portal.UserIDKey] != null)
            {
                CurrentUserID = Convert.ToInt32(Session[ConstantUtility.Portal.UserIDKey]);
            }
            if (Session[ConstantUtility.Portal.UserNameKey] != null)
            {
                CurrentUserName = Session[ConstantUtility.Portal.UserNameKey].ToString();
            }
        }
        catch (Exception ex)
        {
            LogUtility.WritePortalDebugLog("Detail->GetData", ex);
        }
    }
    protected void btnFeel_Click(object sender, EventArgs e)
    {
        CheckUser();
        btnFeel.Enabled = false;
        try
        {
            CurrentProgram.AddFeel(CurrentUserID);
            ShowActInfo();
        }
        catch (Exception ex)
        {
            LogUtility.WritePortalDebugLog("btnFeel_Click", ex);
        }
    }
    protected void btnFavorite_Click(object sender, EventArgs e)
    {
        CheckUser();
        btnFavorite.Enabled = false;
        try
        {
            CurrentProgram.AddFavorite(CurrentUserID);
            ShowActInfo();
        }
        catch (Exception ex)
        {
            LogUtility.WritePortalDebugLog("btnFavorite_Click", ex);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        CheckUser();
        if (!string.IsNullOrEmpty(txtComment.InnerText))
        {
            try
            {
                CurrentProgram.AddComment(CurrentUserID, CurrentUserName, txtComment.InnerText);
                btnSubmit.Enabled = false;
            }
            catch (Exception ex)
            {
                LogUtility.WritePortalDebugLog("btnSubmit_Click", ex);
            }

        }
    }

    private void ShowActInfo()
    {
        btnFeel.Text = string.Format("点赞  {0}", CurrentProgram.FeelCount);
        if (CurrentProgram.IsUserFelt)
        {
            btnFeel.Enabled = false;
        }
        btnFavorite.Text = string.Format("收藏  {0}", CurrentProgram.FavoriteCount);
        if (CurrentProgram.IsUserHasFavorite)
        {
            btnFavorite.Enabled = false;
        }
    }

    private void CheckUser()
    {
        if (Session[ConstantUtility.Portal.UserIDKey] == null)
        {
            //如果用户ID为空则去做微信认证
            string redirect_url = Request.Url.AbsoluteUri;
            Response.Redirect(wxWeb.GetAuthorizeUrl(redirect_url, "auth"));
        }
    }

    private void GetWXUser(string code)
    {
        try
        {
            WXWebAccessToken accessToken = wxWeb.GetAccessToken(code);
            WXUserInfo wxUser = new WXUserInfo();
            if (accessToken != null)
            {
                wxUser = wxWeb.GetUserInfo(accessToken);
                if (wxUser != null)
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
                    //LogUtility.WriteLog("finished add", "");
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