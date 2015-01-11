using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///PortalUserBusiness 的摘要说明
/// </summary>
public class PortalUserBusiness : BaseBuiness
{
    /// <summary>
    /// 用户登录
    /// </summary>
    /// <returns></returns>
    public List<PortalUser> GetPortalUser(string userName, string pwd)
    {
        var c = from p in DBContext.PortalUser
                where p.UserName == userName & p.Password == pwd
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalUser>();
        }
    }
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int AddPortalUser(PortalUser item)
    {
        var c = DBContext.PortalUser.OrderByDescending(p => p.ID).FirstOrDefault();
        if (c == null)
        {
            item.ID = 1;
        }
        else
        {
            item.ID = c.ID + 1;
        }
        item.CreateDate = DateTime.Now;
        DBContext.PortalUser.AddObject(item);
        return DBContext.SaveChanges();
    }
    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeletePortalUser(int id)
    {
        var c = DBContext.PortalUser.Where(p => p.ID == id).SingleOrDefault();
        DBContext.DeleteObject(c);
        return DBContext.SaveChanges();
    }
}