using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///PortalContentItemBusiness 的摘要说明
/// </summary>
public class PortalContentItemBusiness : BaseBuiness
{
    /// <summary>
    /// 获取某一内容的所有集
    /// </summary>
    /// <param name="id">内容id</param>
    /// <returns></returns>
    public List<PortalContentItem> GetPortalContentItemList(int id)
    {
        var c = from p in DBContext.PortalContentItem
                where p.ContentID == id
                orderby p.Seq descending
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalContentItem>();
        }
    }
    /// <summary>
    /// 获取单个内容
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public PortalContentItem GetPortalContentItem(int id)
    {
        return DBContext.PortalContentItem.Where(p => p.ID == id).SingleOrDefault();
    }
    /// <summary>
    /// 添加内容集
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int AddPortalContentItem(PortalContentItem item)
    {
        var c = DBContext.PortalContentItem.OrderByDescending(p => p.ID).FirstOrDefault();
        if (c == null)
        {
            item.ID = 1;
        }
        else
        {
            item.ID = c.ID + 1;
        }
        item.CreateDate = DateTime.Now;
        DBContext.PortalContentItem.AddObject(item);
        DBContext.SaveChanges();
        return item.ID;
    }
    /// <summary>
    /// 更新内容集
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int UpdatePortalContentItem(PortalContentItem item)
    {
        var c = DBContext.PortalContentItem.Where(p => p.ID == item.ID).SingleOrDefault();
        c.ImageURL = item.ImageURL;
        c.ImageURL2 = item.ImageURL2;
        c.Description = item.Description;
        c.DisplayName = item.DisplayName;
        c.Name = item.Name;
        c.Type = item.Type;
        c.State = item.State;
        c.URL = item.URL;
        c.Seq = item.Seq;
        return DBContext.SaveChanges();
    }
    /// <summary>
    /// 删除内容集
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeletePortalContentItem(int id)
    {
        var c = DBContext.PortalContentItem.Where(p => p.ID == id).SingleOrDefault();
        DBContext.DeleteObject(c);
        return DBContext.SaveChanges();
    }
}