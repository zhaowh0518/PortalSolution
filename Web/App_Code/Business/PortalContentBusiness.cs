using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///PortalContentBusiness 的摘要说明
/// </summary>
public class PortalContentBusiness : BaseBuiness
{
    /// <summary>
    /// 获取所有的内容信息
    /// </summary>
    /// <returns></returns>
    public List<PortalContent> GetPortalContentList()
    {
        var c = from p in DBContext.PortalContent
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalContent>();
        }
    }
    /// <summary>
    /// 获取某一分类的内容信息
    /// </summary>
    /// <param name="categoryID">分类ID</param>
    /// <returns></returns>
    public List<PortalContent> GetPortalContentList(int categoryID)
    {
        var c = from p in DBContext.PortalContent
                where p.CategoryID == categoryID
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalContent>();
        }
    }
    /// <summary>
    /// 根据Code获取某一分类及其子类的内容信息
    /// </summary>
    /// <param name="categoryCode">分类编码</param>
    /// <returns></returns>
    public List<PortalContent> GetPortalContentList(string categoryCode)
    {
        PortalCategory category = new PortalCategoryBusiness().GetPortalCategory(categoryCode);
        var c = from p in DBContext.PortalContent
                join q in DBContext.PortalCategory on p.CategoryID equals q.ID
                where q.Code == category.Code | q.ParentID == category.ID
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalContent>();
        }
    }
    /// <summary>
    /// 获取状态为1的内容
    /// </summary>
    /// <returns></returns>
    public List<PortalContent> GetValidPortalContentList()
    {
        var c = from p in DBContext.PortalContent
                where p.State == true
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalContent>();
        }
    }
    /// <summary>
    /// 获取内容
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public PortalContent GetPortalContent(int id)
    {
        return DBContext.PortalContent.Where(p => p.ID == id).SingleOrDefault();
    }
    /// <summary>
    /// 添加内容
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int AddPortalContent(PortalContent item)
    {
        var c = DBContext.PortalContent.OrderByDescending(p => p.ID).FirstOrDefault();
        if (c == null)
        {
            item.ID = 1;
        }
        else
        {
            item.ID = c.ID + 1;
        }
        item.CreateDate = DateTime.Now;
        DBContext.PortalContent.AddObject(item);
        DBContext.SaveChanges();
        return item.ID;
    }
    /// <summary>
    /// 更新内容
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int UpdatePortalContent(PortalContent item)
    {
        var c = DBContext.PortalContent.Where(p => p.ID == item.ID).SingleOrDefault();
        c.ImageURL = item.ImageURL;
        c.ImageURL2 = item.ImageURL2;
        c.Description = item.Description;
        c.DisplayName = item.DisplayName;
        c.Name = item.Name;
        c.State = item.State;
        c.Type = item.Type;
        c.URL = item.URL;
        c.IsSeries = item.IsSeries;
        c.CategoryCode = item.CategoryCode;
        c.Extend1 = item.Extend1;
        c.BizStatus = item.BizStatus;
        return DBContext.SaveChanges();
    }
    /// <summary>
    /// 删除内容
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeletePortalContent(int id)
    {
        var c = DBContext.PortalContent.Where(p => p.ID == id).SingleOrDefault();
        DBContext.DeleteObject(c);
        return DBContext.SaveChanges();
    }
}