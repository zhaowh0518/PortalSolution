using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Admin_PortalMenu : System.Web.UI.Page
{
    private PortalMenuBusiness _portalMenuBusiness = new PortalMenuBusiness();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                Bind(Convert.ToInt32(Request["id"]));
            }
            BindControlsUtility.BindMenuTree(null, tvMenuList, null, Request.Path);
            tvMenuList.ExpandAll();
        }
    }

    private void Bind(int id)
    {
        PortalMenu menu = _portalMenuBusiness.GetPortalMenu(id);
        txtName.Text = menu.Name;
        txtSeq.Text = menu.Seq.ToString();
        txtCode.Text = menu.Code;
        txtURL.Text = menu.URL;
        ddlMenuType.SelectedValue = menu.Type.ToString();
        cbState.Checked = (bool)menu.State;
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
            PortalMenu menu = new PortalMenu();
            menu.Name = txtName.Text;
            menu.Code = txtCode.Text;
            menu.URL = txtURL.Text;
            menu.Seq = Convert.ToInt32(txtSeq.Text);
            menu.State = cbState.Checked;
            menu.ParentID = parentID;
            menu.Type = Convert.ToInt32(ddlMenuType.SelectedValue);
            _portalMenuBusiness.AddPortalMenu(menu);
            BindControlsUtility.BindMenuTree(null, tvMenuList, null, Request.Path);
            tvMenuList.ExpandAll();
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
            PortalMenu menu = _portalMenuBusiness.GetPortalMenu(Convert.ToInt32(Request["id"]));
            menu.Name = txtName.Text;
            menu.Code = txtCode.Text;
            menu.URL = txtURL.Text;
            menu.Seq = Convert.ToInt32(txtSeq.Text);
            menu.State = cbState.Checked;
            menu.Type = Convert.ToInt32(ddlMenuType.SelectedValue);
            _portalMenuBusiness.UpdatePortalMenu(menu);
            BindControlsUtility.BindMenuTree(null, tvMenuList, null, Request.Path);
            tvMenuList.ExpandAll();
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
            _portalMenuBusiness.DeletePortalMenu(Convert.ToInt32(Request["id"]));
            BindControlsUtility.BindMenuTree(null, tvMenuList, null, Request.Path);
            tvMenuList.ExpandAll();
            lbMessage.Text = "删除成功！";
        }
        catch (Exception ex)
        {
            lbMessage.Text = "删除失败，错误信息：" + ex.Message;
        }
    }
}