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


    protected void Page_Load(object sender, EventArgs e)
    {
        //从微信返回来
        string code = Request["code"];
        if (!string.IsNullOrEmpty(code))
        {
            GetWXUser(code);
        }
        GetData();
    }

    protected override void GetData()
    {
        try
        {
            int id = 0;
            int mold = -1;
            //防止微信返回来的url中少参数
            if (!string.IsNullOrEmpty(Request["id"]) && !string.IsNullOrEmpty(Request["mold"]))
            {
                id = Convert.ToInt32(Request["id"]);
                mold = Convert.ToInt32(Request["mold"]);
                Session["ProgramID"] = id;
                Session["PogramMold"] = mold;
            }
            else
            {
                id = Session["ProgramID"] == null ? 0 : Convert.ToInt32(Session["ProgramID"]);
                mold = Session["ProgramID"] == null ? -1 : Convert.ToInt32(Session["PogramMold"]);
            }
            if (id != 0 && mold != -1)
            {
                CurrentProgram = Program.GetProgram(id, (ConstantUtility.Site.Mold)mold);
            }
            if (CurrentProgram != null)
            {
                ShowActInfo();
            }
            else
            {
                CurrentProgram = new Program();
                //当出现内容取不到的情况，记录下参数，供后续调查
                string msg = string.Format("URL:{0}\tUser:{1}\t{2}", Request.Url.AbsoluteUri,
                    Session[ConstantUtility.Portal.UserIDKey], Session[ConstantUtility.Portal.UserNameKey]);
                LogUtility.WriteLog("Portal->Detail->CurrentProgram", msg);
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
            if (CurrentProgram.ID != 0)
            {
                CurrentProgram.AddFeel(CurrentUserID);
                ShowActInfo();
            }
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
            if (CurrentProgram.ID != 0)
            {
                CurrentProgram.AddFavorite(CurrentUserID);
                ShowActInfo();
            }
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
                if (CurrentProgram.ID != 0)
                {
                    CurrentProgram.AddComment(CurrentUserID, CurrentUserName, txtComment.InnerText);
                    btnSubmit.Enabled = false;
                }
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
        if (CurrentProgram.ID == 0)
        {
            btnFavorite.Enabled = false;
            btnFeel.Enabled = false;
            btnSubmit.Enabled = false;
        }
    }

}