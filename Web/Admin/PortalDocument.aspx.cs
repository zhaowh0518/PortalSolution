using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class Admin_PortalDocument : System.Web.UI.Page
{
    private PortalDocumentBusiness _portalDocumentBusiness = new PortalDocumentBusiness();

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
            ShowListState();
        }
    }

    private void ShowListState()
    {
        gvDocumentList.Visible = true;
        panelEdit.Visible = false;
        btnAdd.Visible = true;
        btnSave.Visible = false;
        btnCancel.Visible = false;
    }

    private void ShowEidtState()
    {
        gvDocumentList.Visible = false;
        panelEdit.Visible = true;
        btnAdd.Visible = false;
        btnSave.Visible = true;
        btnCancel.Visible = true;
    }

    private void Bind(int id)
    {
        List<PortalDocument> documentList = _portalDocumentBusiness.GetMenuPortalDocumentList(id);
        gvDocumentList.DataSource = documentList;
        gvDocumentList.DataBind();

    }
    /// <summary>
    /// 清空文本框，并设置默认值
    /// </summary>
    private void NewDoc()
    {
        txtName.Text = string.Empty;
        txtSeq.Text = "100";
        txtURL.Text = string.Empty;
        txtDisplayName.Text = string.Empty;
        richEditor.Text = string.Empty;
        hiddenImageURL.Value = string.Empty;
        linkViewImage.HRef = string.Empty;
        cbState.Checked = true;
    }

    private void ShowDoc(int id)
    {
        PortalDocument doc = _portalDocumentBusiness.GetPortalDocument(id);
        txtName.Text = doc.Name;
        txtSeq.Text = doc.Seq.ToString();
        txtURL.Text = doc.URL;
        txtDisplayName.Text = doc.DisplayName;
        richEditor.Text = doc.Description;
        hiddenImageURL.Value = doc.ImageURL;
        linkViewImage.HRef = string.Format("{0}{1}", ConstantUtility.Site.ImageURLPath, doc.ImageURL);
        cbState.Checked = doc.State;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        hiddenID.Value = string.Empty;
        NewDoc();
        ShowEidtState();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                lbMessage.Text = "请先选择栏目！";
            }
            else
            {
                PortalDocument doc = new PortalDocument();
                doc.Name = txtName.Text;
                doc.PortalMenuID = Convert.ToInt32(Request["id"]);
                doc.Seq = Convert.ToInt32(txtSeq.Text);
                doc.URL = txtURL.Text;
                doc.State = cbState.Checked;
                doc.Description = richEditor.Text;
                doc.DisplayName = txtDisplayName.Text;
                if (fileImage.PostedFile != null && fileImage.PostedFile.ContentLength > 0)
                {
                    doc.ImageURL = FileUtility.SaveImage(fileImage);
                }
                else
                {
                    doc.ImageURL = hiddenImageURL.Value;
                }
                if (string.IsNullOrEmpty(hiddenID.Value)) //添加
                {
                    hiddenID.Value = _portalDocumentBusiness.AddPortalDocument(doc).ToString();
                }
                else
                {
                    doc.ID = Convert.ToInt32(hiddenID.Value);
                    _portalDocumentBusiness.UpdatePortalDocument(doc);
                }
                lbMessage.Text = "保存成功！";
            }
        }
        catch (Exception ex)
        {
            lbMessage.Text = "保存失败，错误信息：" + ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ShowListState();
        lbMessage.Text = string.Empty;
        Bind(Convert.ToInt32(Request["id"]));
    }
    protected void gvDocumentList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id = Convert.ToInt32(gvDocumentList.DataKeys[e.NewEditIndex].Value);
        hiddenID.Value = id.ToString();
        ShowDoc(id);
        ShowEidtState();
        gvDocumentList.SelectedIndex = e.NewEditIndex;
        e.Cancel = true;
    }
    protected void gvDocumentList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(e.Keys["ID"]);
        _portalDocumentBusiness.DeletePortalDocument(id);
        gvDocumentList.DataBind();
        e.Cancel = true;
    }

    protected void gvDocumentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //State
            if (e.Row.Cells[3].Text == "True")
            {
                e.Row.Cells[3].Text = "上线";
            }
            else
            {
                e.Row.Cells[3].Text = "下线";
            }
            //删除按钮
            ((LinkButton)e.Row.Cells[0].Controls[2]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：" + e.Row.Cells[1].Text + " 吗?')");
        }
    }
    protected void lbtnViewImage_Click(object sender, EventArgs e)
    {
        string url = string.Format("../Resources/Images/{0}", hiddenImageURL.Value);
        Response.Redirect(url);
    }
}