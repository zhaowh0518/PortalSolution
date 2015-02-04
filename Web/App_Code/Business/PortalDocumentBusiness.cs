using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///PortalDocumentBusiness 的摘要说明
/// </summary>
public class PortalDocumentBusiness : BaseBuiness
{
    /// <summary>
    /// 获取所有的文档信息
    /// </summary>
    /// <returns></returns>
    public List<PortalDocument> GetPortalDocumentList()
    {
        var c = from p in DBContext.PortalDocument
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalDocument>();
        }
    }
    /// <summary>
    /// 获取指定菜单下以及菜单的子类下的所有文档
    /// </summary>
    /// <returns></returns>
    public List<PortalDocument> GetMenuPortalDocumentList(int id)
    {
        var c = from p in DBContext.PortalDocument
                join q in DBContext.PortalMenu on p.PortalMenuID equals q.ID
                where p.State == true & (q.ID == id | q.ParentID == id)
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalDocument>();
        }
    }
    /// <summary>
    /// 获取指定菜单下以及菜单的子类下的所有文档
    /// </summary>
    /// <returns></returns>
    public List<PortalDocument> GetValidMenuPortalDocumentList(string menuCode)
    {
        var c = from p in DBContext.PortalDocument
                join q in DBContext.PortalMenu on p.PortalMenuID equals q.ID
                where p.State == true & (q.Code == menuCode | q.ParentCode == menuCode)
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalDocument>();
        }
    }
    /// <summary>
    /// 获取文档
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public PortalDocument GetPortalDocument(int id)
    {
        return DBContext.PortalDocument.Where(p => p.ID == id).SingleOrDefault();
    }
    /// <summary>
    /// 添加文档,返回文档的ID
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int AddPortalDocument(PortalDocument item)
    {
        var c = DBContext.PortalDocument.OrderByDescending(p => p.ID).FirstOrDefault();
        if (c == null)
        {
            item.ID = 1;
        }
        else
        {
            item.ID = c.ID + 1;
        }
        item.CreateDate = DateTime.Now;
        //处理PortalMenuCode
        item.PortalMenuCode = new PortalMenuBusiness().GetPortalMenu(item.PortalMenuID).Code;
        DBContext.PortalDocument.AddObject(item);
        DBContext.SaveChanges();
        DBContext.Refresh(System.Data.Objects.RefreshMode.StoreWins, DBContext.PortalDocument);
        return item.ID;
    }
    /// <summary>
    /// 更新文档
    /// </summary>
    /// <param name="item"></param>
    public void UpdatePortalDocument(PortalDocument item)
    {
        var c = DBContext.PortalDocument.Where(p => p.ID == item.ID).SingleOrDefault();
        c.ImageURL = item.ImageURL;
        c.ImageURL2 = item.ImageURL2;
        c.Description = item.Description;
        c.DisplayName = item.DisplayName;
        c.Name = item.Name;
        c.Seq = item.Seq;
        c.State = item.State;
        c.URL = item.URL;
        c.Extend1 = item.Extend1;
        c.Extend2 = item.Extend2;
        c.Extend3 = item.Extend3;
        c.Type = item.Type;
        DBContext.SaveChanges();
        DBContext.Refresh(System.Data.Objects.RefreshMode.StoreWins, DBContext.PortalDocument);
    }
    /// <summary>
    /// 删除文档
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeletePortalDocument(int id)
    {
        var c = DBContext.PortalDocument.Where(p => p.ID == id).SingleOrDefault();
        DBContext.DeleteObject(c);
        return DBContext.SaveChanges();
    }
}