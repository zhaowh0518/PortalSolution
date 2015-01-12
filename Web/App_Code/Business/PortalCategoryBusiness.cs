using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///PortalCategoryBusiness 的摘要说明
/// </summary>
public class PortalCategoryBusiness : BaseBuiness
{
    /// <summary>
    /// 获取所有的内容分类信息
    /// </summary>
    /// <returns></returns>
    public List<PortalCategory> GetPortalCategoryList()
    {
        var c = from p in DBContext.PortalCategory
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalCategory>();
        }
    }
    /// <summary>
    /// 获取状态为1的内容分类
    /// </summary>
    /// <returns></returns>
    public List<PortalCategory> GetValidPortalCategoryList()
    {
        var c = from p in DBContext.PortalCategory
                where p.State == true
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalCategory>();
        }
    }
    /// <summary>
    /// 根据ID获取唯一的内容分类
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public PortalCategory GetPortalCategory(int id)
    {
        return DBContext.PortalCategory.Where(p => p.ID == id).SingleOrDefault();
    }
    /// <summary>
    /// 添加内容分类
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int AddPortalCategory(PortalCategory item)
    {
        var c = DBContext.PortalCategory.OrderByDescending(p => p.ID).FirstOrDefault();
        if (c == null)
        {
            item.ID = 1;
        }
        else
        {
            item.ID = c.ID + 1;
        }
        item.CreateDate = DateTime.Now;
        DBContext.PortalCategory.AddObject(item);
        return DBContext.SaveChanges();
    }
    /// <summary>
    /// 更新内容分类
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int UpdatePortalCategory(PortalCategory item)
    {
        var c = DBContext.PortalCategory.Where(p => p.ID == item.ID).SingleOrDefault();
        c.Name = item.Name;
        c.ParentID = item.ParentID;
        c.Seq = item.Seq;
        c.State = item.State;
        return DBContext.SaveChanges();
    }
    /// <summary>
    /// 删除内容分类
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeletePortalCategory(int id)
    {
        var c = DBContext.PortalCategory.Where(p => p.ID == id).SingleOrDefault();
        DBContext.DeleteObject(c);
        return DBContext.SaveChanges();
    }
}