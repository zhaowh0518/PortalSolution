using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///PortalManagerBusiness 的摘要说明
/// </summary>
public class PortalManagerBusiness : BaseBuiness
{
    /// <summary>
    /// 管理员登陆
    /// </summary>
    /// <returns></returns>
    public PortalManager GetPortalManager(string userName, string pwd)
    {
        var c = from p in DBContext.PortalManager
                where p.UserName == userName & p.Password == pwd
                select p;
        return c.SingleOrDefault();
    }
    /// <summary>
    /// 添加管理员
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int AddPortalManager(PortalManager item)
    {
        var c = DBContext.PortalManager.OrderByDescending(p => p.ID).FirstOrDefault();
        if (c == null)
        {
            item.ID = 1;
        }
        else
        {
            item.ID = c.ID + 1;
        }
        item.CreateDate = DateTime.Now;
        DBContext.PortalManager.AddObject(item);
        return DBContext.SaveChanges();
    }
    /// <summary>
    /// 删除管理员
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeletePortalManager(int id)
    {
        var c = DBContext.PortalManager.Where(p => p.ID == id).SingleOrDefault();
        DBContext.DeleteObject(c);
        return DBContext.SaveChanges();
    }
}