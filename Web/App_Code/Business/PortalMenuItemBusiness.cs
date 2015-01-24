using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///PortalMenuBusiness 的摘要说明
/// </summary>
public class PortalMenuItemBusiness : BaseBuiness
{
    /// <summary>
    /// 获取菜单下的所有内容
    /// </summary>
    /// <param name="menuID">菜单ID</param>
    /// <returns></returns>
    public List<PortalMenuItem> GetPortalMenuItemList(int menuID)
    {
        var c = from p in DBContext.PortalMenuItem
                where p.MenuID == menuID
                orderby p.Seq
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalMenuItem>();
        }
    }
    /// <summary>
    /// 批量添加菜单内容
    /// </summary>
    /// <param name="itemList"></param>
    /// <returns></returns>
    public void AddPortalMenuItem(List<PortalMenuItem> itemList)
    {
        var c = DBContext.PortalMenuItem.OrderByDescending(p => p.ID).FirstOrDefault();
        int id = c == null ? 0 : c.ID;
        foreach (var item in itemList)
        {
            id++;
            item.ID = id;
            item.Seq = ConstantUtility.AdminConstant.DefaultSeq;
            item.State = true;
            item.CreateDate = DateTime.Now;
            DBContext.PortalMenuItem.AddObject(item);
        }
        DBContext.SaveChanges();
    }
    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int UpdatePortalMenuItem(PortalMenuItem item)
    {
        var c = DBContext.PortalMenuItem.Where(p => p.ID == item.ID).SingleOrDefault();
        c.Seq = item.Seq;
        return DBContext.SaveChanges();
    }
    /// <summary>
    /// 更新菜单的顺序
    /// </summary>
    /// <param name="idList"></param>
    /// <param name="seq"></param>
    /// <returns></returns>
    public int UpdatePortalMenuItemSeq(List<int> idList, int seq)
    {
        foreach (var item in idList)
        {
            var c = DBContext.PortalMenuItem.Where(p => p.ID == item).SingleOrDefault();
            c.Seq = seq;
        }
        return DBContext.SaveChanges();
    }
    /// <summary>
    /// 删除菜单
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeletePortalMenuItem(int id)
    {
        var c = DBContext.PortalMenuItem.Where(p => p.ID == id).SingleOrDefault();
        DBContext.DeleteObject(c);
        return DBContext.SaveChanges();
    }
}