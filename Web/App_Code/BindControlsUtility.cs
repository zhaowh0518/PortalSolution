using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using PortalModel;

/// <summary>
/// 绑定控件的数据
/// </summary>
public class BindControlsUtility
{
    private static PortalCategoryBusiness _portalCategoryBuiness = new PortalCategoryBusiness();
    private static PortalMenuBusiness _portalMenuBusiness = new PortalMenuBusiness();

    /// <summary>
    /// 用递归方式绑定菜单树
    /// </summary>
    /// <param name="dataSource"></param>
    /// <param name="parentNode"></param>
    /// <param name="tvControl"></param>
    /// <param name="urlPath"></param>
    public static void BindMenuTree(List<PortalMenu> dataSource, TreeView tvControl, TreeNode parentNode, string urlPath)
    {
        if (dataSource == null) //第一次绑定或者刷新
        {
            dataSource = _portalMenuBusiness.GetPortalMenuList();
            tvControl.Nodes.Clear();
        }
        int parentID = 0;
        if (parentNode != null)
        {
            parentID = Convert.ToInt32(parentNode.Value);
        }
        foreach (var item in dataSource.Where(p => p.ParentID == parentID).OrderBy(p => p.Seq).ToList())
        {
            TreeNode node = new TreeNode();
            node.NavigateUrl = string.Format("{0}?id={1}&name={2}", urlPath, item.ID, item.Name);
            node.Text = item.Name;
            node.Value = item.ID.ToString();
            //添加根节点
            if (parentNode == null)
            {
                BindMenuTree(dataSource, tvControl, node, urlPath);
                tvControl.Nodes.Add(node);
            }
            else
            {
                parentNode.ChildNodes.Add(node);
            }
        }
    }

    /// <summary>
    /// 用递归方式绑定f内容分类树
    /// </summary>
    /// <param name="dataSource"></param>
    /// <param name="parentNode"></param>
    /// <param name="tvControl"></param>
    /// <param name="urlPath"></param>
    public static void BindCategoryTree(List<PortalCategory> dataSource, TreeView tvControl, TreeNode parentNode, string urlPath)
    {
        if (dataSource == null)
        {
            dataSource = _portalCategoryBuiness.GetPortalCategoryList();
            tvControl.Nodes.Clear();
        }
        int parentID = 0;
        if (parentNode != null)
        {
            parentID = Convert.ToInt32(parentNode.Value);
        }
        foreach (var item in dataSource.Where(p => p.ParentID == parentID).OrderBy(p => p.Seq).ToList())
        {
            TreeNode node = new TreeNode();
            node.NavigateUrl = string.Format("{0}?id={1}&name={2}&code={3}", urlPath, item.ID, item.Name, item.Code);
            node.Text = item.Name;
            node.Value = item.ID.ToString();
            //添加根节点
            if (parentNode == null)
            {
                BindCategoryTree(dataSource, tvControl, node, urlPath);
                tvControl.Nodes.Add(node);
            }
            else
            {
                parentNode.ChildNodes.Add(node);
            }
        }
    }

    /// <summary>
    /// 用递归方式绑定菜单树
    /// </summary>
    /// <param name="dataSource"></param>
    /// <param name="parentNode"></param>
    /// <param name="tvControl"></param>
    /// <param name="urlPath"></param>
    public static void BindDialogMenuTree(List<PortalMenu> dataSource, TreeView tvControl, TreeNode parentNode, string urlPath)
    {
        if (dataSource == null) //第一次绑定或者刷新
        {
            dataSource = _portalMenuBusiness.GetPortalMenuList();
            tvControl.Nodes.Clear();
        }
        int parentID = 0;
        if (parentNode != null)
        {
            parentID = Convert.ToInt32(parentNode.Value);
        }
        foreach (var item in dataSource.Where(p => p.ParentID == parentID).OrderBy(p => p.Seq).ToList())
        {
            TreeNode node = new TreeNode();
            node.ShowCheckBox = true;
            node.Value = item.ID.ToString();
            if (item.Type == 1) //内容类菜单为绿色
            {
                node.Text = string.Format("<font color='green'>{0}</font>", item.Name);
            }
            else if (item.Type == 2)//文档类菜单为蓝色
            {
                node.Text = string.Format("<font color='blue'>{0}</font>", item.Name);
            }
            else //父菜单为黑色
            {
                node.Text = string.Format("<font color='black'>{0}</font>", item.Name);
            }
            //添加根节点
            if (parentNode == null)
            {
                BindDialogMenuTree(dataSource, tvControl, node, urlPath);
                tvControl.Nodes.Add(node);
            }
            else
            {
                parentNode.ChildNodes.Add(node);
            }
        }
    }
}