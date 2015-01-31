using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserModel;

public partial class Portal_i : BasePage
{
    private UserBusiness _userBusiness = new UserBusiness();

    public UserInfo CurrentUserInfo = new UserInfo();
    public List<UserFavorite> CurrentUserFavoriteList = new List<UserFavorite>();
    public List<UserFeel> CurrentUserFeelList = new List<UserFeel>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session[ConstantUtility.Portal.UserIDKey] != null)
            {

                GetData();
            }
        }
    }

    protected override void GetData()
    {
        try
        {
            int userID = Convert.ToInt32(Session[ConstantUtility.Portal.UserIDKey]);
            CurrentUserInfo = _userBusiness.GetUserInfo(userID);
            CurrentUserFeelList = _userBusiness.GetFeelList(userID);
            CurrentUserFavoriteList = _userBusiness.GetFavoriteList(userID);
        }
        catch (Exception ex)
        {
            LogUtility.WritePortalDebugLog("Portal_i->GetData", ex);
        }
    }
}