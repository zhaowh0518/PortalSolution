using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Portal_Detail : BasePage
{
    public Program CurrentProgram = new Program();

    private int userID = 0;
    private string userName = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
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
        }
        catch (Exception ex)
        {
            //txtComment.InnerText = ex.Message;
        }
    }
    protected void btnFeel_Click(object sender, EventArgs e)
    {
        btnFeel.Enabled = false;
        CurrentProgram.AddFeel(userID);
        ShowActInfo();
    }
    protected void btnFavorite_Click(object sender, EventArgs e)
    {
        btnFavorite.Enabled = false;
        CurrentProgram.AddFavorite(userID);
        ShowActInfo();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtComment.InnerText))
        {
            CurrentProgram.AddComment(userID, userName, txtComment.InnerText);
        }
    }
    private void ShowActInfo()
    {
        btnFeel.Text = string.Format("点赞  {0}", CurrentProgram.FeelCount);
        btnFavorite.Text = string.Format("收藏  {0}", CurrentProgram.FavoriteCount);
    }
}