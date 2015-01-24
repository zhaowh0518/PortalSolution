using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Admin_PortalMenuItem : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindControlsUtility.BindMenuTree(null, tvMenuList, null, Request.Path);
            BindData();
        }
    }

    private void BindData()
    {
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            List<PortalMenuItem> menuItemList = _portalMenuItemBusiness.GetPortalMenuItemList(Convert.ToInt32(Request["id"]));
            gvMenuItemList.DataSource = menuItemList;
            gvMenuItemList.DataBind();
        }
    }
    protected void btnSeq_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtSeq.Text))
        {
            lbMessage.Text = "请先输入要设置的序列号值！";
        }
        else
        {
            List<int> idList = new List<int>();
            int seq = 0;
            Int32.TryParse(txtSeq.Text, out seq);
            for (int i = 0; i < gvMenuItemList.Rows.Count; i++)
            {
                CheckBox chkSelect = gvMenuItemList.Rows[i].FindControl("chkSelect") as CheckBox;
                if (chkSelect.Checked)
                {
                    idList.Add(Convert.ToInt32(gvMenuItemList.DataKeys[i].Value));

                }
            }
            _portalMenuItemBusiness.UpdatePortalMenuItemSeq(idList, seq);
            BindData();
            lbMessage.Text = string.Format("序号设置成功，共影响{0}条菜单内容！", idList.Count);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int counter = 0;
        for (int i = 0; i < gvMenuItemList.Rows.Count; i++)
        {
            CheckBox chkSelect = gvMenuItemList.Rows[i].FindControl("chkSelect") as CheckBox;
            if (chkSelect.Checked)
            {
                _portalMenuItemBusiness.DeletePortalMenuItem(Convert.ToInt32(gvMenuItemList.DataKeys[i].Value));
                counter++;
            }
        }
        BindData();
        lbMessage.Text = string.Format("移出成功，共影响{0}条菜单内容！", counter);
    }
}