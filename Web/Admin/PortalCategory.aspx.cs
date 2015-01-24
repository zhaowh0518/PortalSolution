using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Admin_PortalCategory : System.Web.UI.Page
{
    private PortalCategoryBusiness _portalCategoryBusiness = new PortalCategoryBusiness();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                Bind(Convert.ToInt32(Request["id"]));
            }
            BindControlsUtility.BindCategoryTree(null, tvCategoryList, null, Request.Path);
        }
    }

    private void Bind(int id)
    {
        PortalCategory category = _portalCategoryBusiness.GetPortalCategory(id);
        txtName.Text = category.Name;
        txtSeq.Text = category.Seq.ToString();
        cbState.Checked = (bool)category.State;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            int parentID = 0;
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                parentID = Convert.ToInt32(Request["id"]);
            }
            PortalCategory category = new PortalCategory();
            category.Name = txtName.Text;
            category.Seq = Convert.ToInt32(txtSeq.Text);
            category.State = cbState.Checked;
            category.ParentID = parentID;
            _portalCategoryBusiness.AddPortalCategory(category);
            BindControlsUtility.BindCategoryTree(null, tvCategoryList, null, Request.Path);
            tvCategoryList.ExpandAll();
            lbMessage.Text = "添加成功！";
        }
        catch (Exception ex)
        {
            lbMessage.Text = "添加失败，错误信息：" + ex.Message;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            PortalCategory category = _portalCategoryBusiness.GetPortalCategory(Convert.ToInt32(Request["id"]));
            category.Name = txtName.Text;
            category.Seq = Convert.ToInt32(txtSeq.Text);
            category.State = cbState.Checked;
            _portalCategoryBusiness.UpdatePortalCategory(category);
            BindControlsUtility.BindCategoryTree(null, tvCategoryList, null, Request.Path);
            tvCategoryList.ExpandAll();
            lbMessage.Text = "更新成功！";
        }
        catch (Exception ex)
        {
            lbMessage.Text = "更新失败，错误信息：" + ex.Message;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            _portalCategoryBusiness.DeletePortalCategory(Convert.ToInt32(Request["id"]));
            BindControlsUtility.BindCategoryTree(null, tvCategoryList, null, Request.Path);
            tvCategoryList.ExpandAll();
            lbMessage.Text = "删除成功！";
        }
        catch (Exception ex)
        {
            lbMessage.Text = "删除失败，错误信息：" + ex.Message;
        }
    }
}