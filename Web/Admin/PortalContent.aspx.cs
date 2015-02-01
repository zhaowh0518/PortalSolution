using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Admin_PortalContent : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindControlsUtility.BindCategoryTree(null, tvCategoryList, null, Request.Path);
            BindControlsUtility.BindDialogMenuTree(null, tvMenuList, null, Request.Path);
            BindContentList();
            ShowListState();
        }
    }

    #region Private Method
    private void BindContentList()
    {
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            List<PortalContent> contentList = _portalContentBusiness.GetPortalContentList(Convert.ToInt32(Request["id"]));
            gvContentList.DataSource = contentList;
            gvContentList.DataBind();
        }
    }
    private void ShowListState()
    {
        gvContentList.Visible = true;
        panelEdit.Visible = false;
        btnAdd.Visible = true;
        btnPush.Visible = true;
        btnSave.Visible = false;
        btnCancel.Visible = false;
    }
    private void ShowEidtState()
    {
        gvContentList.Visible = false;
        panelEdit.Visible = true;
        btnAdd.Visible = false;
        btnPush.Visible = false;
        btnSave.Visible = true;
        btnCancel.Visible = true;
    }
    private void NewContent()
    {
        txtName.Text = string.Empty;
        txtDisplayName.Text = string.Empty;
        txtDesciption.Text = string.Empty;
        txtURL.Text = string.Empty;
        txtExtend1.Text = string.Empty;

        cbState.Checked = true;
        cbBizStatus.Checked = false;
        cbIsSeries.Checked = false;
    }
    private void ShowContent(int id)
    {
        PortalContent content = _portalContentBusiness.GetPortalContent(id);
        txtName.Text = content.Name;
        txtDisplayName.Text = content.DisplayName;
        txtDesciption.Text = content.Description;
        txtURL.Text = content.URL;
        txtExtend1.Text = content.Extend1;
        hiddenImageURL.Value = content.ImageURL;
        linkViewImage.HRef = string.Format("{0}{1}", ConstantUtility.Site.ImageURLPath, content.ImageURL);
        hiddenImageURL2.Value = content.ImageURL2;
        linkViewImage2.HRef = string.Format("{0}{1}", ConstantUtility.Site.ImageURLPath, content.ImageURL2);
        ddlType.SelectedValue = content.Type.ToString();
        cbState.Checked = content.State;
        cbIsSeries.Checked = content.IsSeries;
    }
    #endregion

    #region Button Action
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request["id"]))
        {
            lbMessage.Text = "请先选择分类！";
        }
        else
        {
            NewContent();
            ShowEidtState();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            PortalContent content = new PortalContent();
            content.Name = txtName.Text;
            content.CategoryID = Convert.ToInt32(Request["id"]);
            content.CategoryCode = Request["code"];
            content.Description = txtDesciption.Text;
            content.DisplayName = txtDisplayName.Text;
            content.URL = txtURL.Text;
            content.State = cbState.Checked;
            content.IsSeries = cbIsSeries.Checked;
            content.Extend1 = txtExtend1.Text;
            content.Type = Convert.ToInt32(ddlType.SelectedValue);
            content.BizStatus = cbBizStatus.Checked ? 1 : 0;
            if (fileImage.PostedFile != null && fileImage.PostedFile.ContentLength > 0)
            {
                content.ImageURL = FileUtility.SaveImage(fileImage);
            }
            else
            {
                content.ImageURL = hiddenImageURL.Value;
            }
            if (fileImage2.PostedFile != null && fileImage2.PostedFile.ContentLength > 0)
            {
                content.ImageURL2 = FileUtility.SaveImage(fileImage2);
            }
            else
            {
                content.ImageURL2 = hiddenImageURL2.Value;
            }

            if (string.IsNullOrEmpty(hiddenID.Value)) //添加
            {
                if (content.IsSeries)
                {
                    content.URL = ConstantUtility.Site.ListPageURL;
                }
                else
                {
                    content.URL = ConstantUtility.Site.DetailPageURL.Replace("{mold}", ((int)ConstantUtility.Site.Mold.Content).ToString());
                }
                hiddenID.Value = _portalContentBusiness.AddPortalContent(content).ToString();
            }
            else
            {
                content.ID = Convert.ToInt32(hiddenID.Value);
                _portalContentBusiness.UpdatePortalContent(content);
            }
            lbMessage.Text = "保存成功！";
        }
        catch (Exception ex)
        {
            lbMessage.Text = "保存失败，详细信息：" + GetErrorMessage(ex);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        BindContentList();
        lbMessage.Text = string.Empty;
        ShowListState();
    }
    protected void btnSaveMenuItem_Click(object sender, EventArgs e)
    {
        if (tvMenuList.CheckedNodes.Count == 0)
        {
            lbMessage.Text = "未选择菜单，没有推荐任何内容！";
        }
        else
        {
            int contentID = 0;
            List<PortalMenuItem> menuItemList = new List<PortalMenuItem>();
            try
            {
                foreach (TreeNode menuNode in tvMenuList.CheckedNodes)
                {
                    PortalMenu menu = _portalMenuBuiness.GetPortalMenu(Convert.ToInt32(menuNode.Value));
                    for (int i = 0; i < gvContentList.Rows.Count; i++)
                    {
                        CheckBox chkSelect = gvContentList.Rows[i].FindControl("chkSelect") as CheckBox;
                        if (chkSelect.Checked)
                        {
                            contentID = Convert.ToInt32(gvContentList.DataKeys[i].Value);
                            if (menu.Type == 1) //内容菜单
                            {
                                PortalMenuItem item = new PortalMenuItem();
                                item.ContentID = contentID;
                                item.MenuID = menu.ID;
                                item.ContentName = gvContentList.Rows[i].Cells[2].Text;
                                menuItemList.Add(item);
                            }
                            else if (menu.Type == 2) //文档菜单
                            {
                                PortalDocument doc = new PortalDocument();
                                PortalContent content = _portalContentBusiness.GetPortalContent(contentID);
                                doc.Name = content.Name;
                                doc.Description = content.Description;
                                doc.DisplayName = content.DisplayName;
                                doc.ImageURL = content.ImageURL;
                                doc.ImageURL2 = content.ImageURL2;
                                doc.PortalMenuID = menu.ID;
                                doc.PortalMenuCode = menu.Code;
                                doc.State = true;
                                doc.Seq = ConstantUtility.AdminConstant.DefaultSeq;
                                doc.Extend1 = content.Extend1;
                                doc.Type = content.Type;
                                doc.URL = content.URL;
                                _portalDocumentBuiness.AddPortalDocument(doc);
                            }
                        }
                    }
                }
                _portalMenuItemBusiness.AddPortalMenuItem(menuItemList);
                lbMessage.Text = "推荐成功";
            }
            catch (Exception ex)
            {
                lbMessage.Text = "推荐失败，错误信息：" + GetErrorMessage(ex);
            }
        }
    }
    #endregion

    #region gvContentList Event
    protected void gvContentList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(e.Keys["ID"]);
        _portalContentBusiness.DeletePortalContent(id);
        gvContentList.DataBind();
        e.Cancel = true;
    }
    protected void gvContentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //State
            if (e.Row.Cells[4].Text == "True")
            {
                e.Row.Cells[4].Text = "上线";
            }
            else
            {
                e.Row.Cells[4].Text = "下线";
            }
            //删除按钮
            ((LinkButton)e.Row.Cells[1].Controls[2]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：" + e.Row.Cells[2].Text + " 吗?')");
            //设置内容集
            if (e.Row.Cells[e.Row.Cells.Count - 2].Text == "False")
            {
                ((HyperLink)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0]).Text = string.Empty;
                e.Row.Cells[e.Row.Cells.Count - 2].Text = "单集";
            }
            else
            {
                e.Row.Cells[e.Row.Cells.Count - 2].Text = "多集";
            }
        }
    }
    protected void gvContentList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id = Convert.ToInt32(gvContentList.DataKeys[e.NewEditIndex].Value);
        hiddenID.Value = id.ToString();
        ShowContent(id);
        ShowEidtState();
        gvContentList.SelectedIndex = e.NewEditIndex;
        e.Cancel = true;
    }
    #endregion
}