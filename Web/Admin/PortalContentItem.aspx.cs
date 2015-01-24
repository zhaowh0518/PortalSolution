using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Admin_PortalContentItem : BasePage
{
    public PortalContent CurrentPortalCuurent = new PortalContent();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                CurrentPortalCuurent = _portalContentBusiness.GetPortalContent(Convert.ToInt32(Request["id"]));
                ViewState["CurrentPortalCuurent"] = CurrentPortalCuurent;
                BindContentItemList();
            }
            ShowListState();
        }
        if (ViewState["CurrentPortalCuurent"] != null)
        {
            CurrentPortalCuurent = (PortalContent)ViewState["CurrentPortalCuurent"];
        }
    }

    #region Private Method
    private void BindContentItemList()
    {
        List<PortalContentItem> itemList = _portalContentItemBusiness.GetPortalContentItemList(Convert.ToInt32(Request["id"]));
        gvContentItemList.DataSource = itemList;
        gvContentItemList.DataBind();
    }
    private void ShowListState()
    {
        gvContentItemList.Visible = true;
        panelEdit.Visible = false;
        btnAdd.Visible = true;
        btnSave.Visible = false;
        btnCancel.Visible = false;
    }
    private void ShowEidtState()
    {
        gvContentItemList.Visible = false;
        panelEdit.Visible = true;
        btnAdd.Visible = false;
        btnSave.Visible = true;
        btnCancel.Visible = true;
    }
    private void ShowContentItem(int id)
    {
        PortalContentItem item = _portalContentItemBusiness.GetPortalContentItem(id);
        txtName.Text = item.Name;
        txtDisplayName.Text = item.DisplayName;
        txtDesciption.Text = item.Description;
        txtURL.Text = item.URL;
        hiddenImageURL.Value = item.ImageURL;
        linkViewImage.HRef = string.Format("{0}{1}", ConstantUtility.Site.ImageURLPath, item.ImageURL);
        hiddenImageURL2.Value = item.ImageURL2;
        linkViewImage2.HRef = string.Format("{0}{1}", ConstantUtility.Site.ImageURLPath, item.ImageURL2);
        cbState.Checked = item.State;
        txtSeq.Text = item.Seq.ToString();
    }
    #endregion

    #region Button Action
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ShowEidtState();
        hiddenID.Value = string.Empty;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PortalContentItem item = new PortalContentItem();
        item.Name = txtName.Text;
        item.ContentID = Convert.ToInt32(Request["id"]);
        item.Description = txtDesciption.Text;
        item.DisplayName = txtDisplayName.Text;
        item.URL = txtURL.Text;
        item.State = cbState.Checked;
        item.Seq = Convert.ToInt32(txtSeq.Text);
        if (fileImage.PostedFile != null && fileImage.PostedFile.ContentLength > 0)
        {
            item.ImageURL = FileUtility.SaveImage(fileImage);
        }
        else
        {
            item.ImageURL = hiddenImageURL.Value;
        }
        if (fileImage2.PostedFile != null && fileImage2.PostedFile.ContentLength > 0)
        {
            item.ImageURL2 = FileUtility.SaveImage(fileImage2);
        }
        else
        {
            item.ImageURL2 = hiddenImageURL2.Value;
        }


        if (string.IsNullOrEmpty(hiddenID.Value)) //添加
        {
            hiddenID.Value = _portalContentItemBusiness.AddPortalContentItem(item).ToString();
        }
        else
        {
            item.ID = Convert.ToInt32(hiddenID.Value);
            _portalContentItemBusiness.UpdatePortalContentItem(item);
        }
        lbMessage.Text = "保存成功！";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        BindContentItemList();
        lbMessage.Text = string.Empty;
        ShowListState();
    }
    #endregion

    #region gvContentItemList Event
    protected void gvContentItemList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(e.Keys["ID"]);
        _portalContentItemBusiness.DeletePortalContentItem(id);
        gvContentItemList.DataBind();
        e.Cancel = true;
    }
    protected void gvContentItemList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //State
            if (e.Row.Cells[2].Text == "True")
            {
                e.Row.Cells[2].Text = "上线";
            }
            else
            {
                e.Row.Cells[2].Text = "下线";
            }
            //删除按钮
            ((LinkButton)e.Row.Cells[0].Controls[2]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：" + e.Row.Cells[1].Text + " 吗?')");
        }
    }
    protected void gvContentItemList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id = Convert.ToInt32(gvContentItemList.DataKeys[e.NewEditIndex].Value);
        hiddenID.Value = id.ToString();
        ShowContentItem(id);
        ShowEidtState();
        gvContentItemList.SelectedIndex = e.NewEditIndex;
        e.Cancel = true;
    }
    #endregion
}