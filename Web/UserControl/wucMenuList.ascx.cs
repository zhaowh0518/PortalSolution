using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalModel;

public partial class UserControl_wucCategoryList : System.Web.UI.UserControl
{
    private PortalMenuBusiness _portalMenuBusiness = new PortalMenuBusiness();
    private List<PortalMenu> _tempDataSourace = new List<PortalMenu>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<PortalMenu> menuList = _portalMenuBusiness.GetPortalMenuList();
            BindTree(menuList, null);
        }

    }
    /// <summary>
    /// 用递归方式绑定分类树
    /// </summary>
    /// <param name="dataSource"></param>
    /// <param name="parentNode"></param>
    private void BindTree(List<PortalMenu> dataSource, TreeNode parentNode)
    {
        int parentID = 0;
        if (parentNode != null)
        {
            parentID = Convert.ToInt32(parentNode.Value);
        }
        _tempDataSourace = dataSource.Where(p => p.ParentID == parentID).OrderBy(p => p.Seq).ToList();
        foreach (var item in _tempDataSourace)
        {
            TreeNode node = new TreeNode();
            node.NavigateUrl = string.Format("{0}?id={1}", Request.Path, item.ID);
            node.Text = item.Name;
            node.Value = item.ID.ToString();
            //添加根节点
            if (parentNode == null)
            {
                BindTree(dataSource, node);
                tvMenuList.Nodes.Add(node);
            }
            else
            {
                parentNode.ChildNodes.Add(node);
            }
        }
    }
}