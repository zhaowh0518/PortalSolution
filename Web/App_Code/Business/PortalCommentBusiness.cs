using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///PortalCommentBusiness 的摘要说明
/// </summary>
public class PortalCommentBusiness : BaseBuiness
{
    /// <summary>
    /// 获取某个内容的所有评论
    /// </summary>
    /// <param name="contentID"></param>
    /// <returns></returns>
    public List<PortalComment> GetPortalCommentList(int contentID)
    {
        var c = from p in DBContext.PortalComment
                where p.ContentID == contentID
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalComment>();
        }
    }
    /// <summary>
    /// 添加评论
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int AddPortalComment(PortalComment item)
    {
        var c = DBContext.PortalComment.OrderByDescending(p => p.ID).FirstOrDefault();
        if (c == null)
        {
            item.ID = 1;
        }
        else
        {
            item.ID = c.ID + 1;
        }
        item.CreateDate = DateTime.Now;
        DBContext.PortalComment.AddObject(item);
        return DBContext.SaveChanges();
    }
}