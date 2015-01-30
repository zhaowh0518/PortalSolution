using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserModel;

/// <summary>
/// 用户相关的所有逻辑
/// </summary>
public class UserBusiness
{
    private static UserEntities _db = new UserEntities();
    /// <summary>
    /// 数据库连接
    /// </summary>
    public static UserEntities DBContext { get { return _db; } }
    /// <summary>
    /// 用户互动的类型
    /// </summary>
    public enum ActType
    {
        Comment = 1,
        Favorite = 2,
        Feel = 3
    }

    public UserBusiness()
    {

    }

    #region UserInfo
    /// <summary>
    /// 添加由第三方（如微信）同步过来的用户
    /// </summary>
    /// <param name="user"></param>
    /// <returns>返回用户ID</returns>
    public int AddSycUser(UserInfo user)
    {
        //先判断用户是否存在，根据openid
        var c = DBContext.UserInfo.Where(p => p.OpenID == user.OpenID).SingleOrDefault();
        if (c == null || string.IsNullOrEmpty(c.OpenID))
        {
            //设置主键
            c = DBContext.UserInfo.OrderByDescending(p => p.ID).FirstOrDefault();
            user.ID = c == null ? 1 : c.ID + 1;
            user.CreateDate = DateTime.Now;
            DBContext.UserInfo.AddObject(user);
            DBContext.SaveChanges();
        }
        return c.ID;
    }
    #endregion

    #region UserComment
    /// <summary>
    /// 添加评论
    /// </summary>
    /// <param name="item"></param>
    public void AddComment(UserComment item)
    {
        var c = DBContext.UserComment.OrderByDescending(p => p.ID).FirstOrDefault();
        item.ID = c == null ? 1 : c.ID + 1;
        item.CreateDate = DateTime.Now;
        item.State = true;
        DBContext.UserComment.AddObject(item);
        DBContext.SaveChanges();

        UserAct act = new UserAct();
        act.ActType = Convert.ToInt32(ActType.Comment);
        act.ContentID = item.ContentID;
        act.ContentType = (int)item.ContentType;
        AddAct(act);
    }
    /// <summary>
    /// 获取某条类容下的评论 
    /// </summary>
    /// <param name="contentid"></param>
    /// <param name="contenttype"></param>
    /// <returns></returns>
    public List<UserComment> GetCommentList(int contentID, int contentType)
    {
        var c = from p in DBContext.UserComment
                where p.ContentID == contentID & p.ContentType == contentType
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<UserComment>();
        }
    }
    #endregion

    #region UserFavorite
    /// <summary>
    /// 添加收藏
    /// </summary>
    /// <param name="item"></param>
    public bool AddFavorite(UserFavorite item)
    {
        var a = from p in DBContext.UserFavorite
                where p.UserID == item.UserID & p.ContentID == item.ContentID & p.ContentType == item.ContentType
                select p;
        if (a == null || a.Count() == 0)
        {
            var c = DBContext.UserFavorite.OrderByDescending(p => p.ID).FirstOrDefault();
            item.ID = c == null ? 1 : c.ID + 1;
            item.CreateDate = DateTime.Now;
            item.State = true;
            DBContext.UserFavorite.AddObject(item);
            DBContext.SaveChanges();

            UserAct act = new UserAct();
            act.ActType = Convert.ToInt32(ActType.Favorite);
            act.ContentID = item.ContentID;
            act.ContentType = item.ContentType;
            AddAct(act);
            return true;
        }
        return false;
    }
    /// <summary>
    /// 获取某个用户的所有收藏
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    public List<UserFavorite> GetFavoriteList(int userID)
    {
        var c = from p in DBContext.UserFavorite
                where p.UserID == userID
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<UserFavorite>();
        }
    }
    #endregion

    #region UserFeel
    /// <summary>
    /// 点赞
    /// </summary>
    /// <param name="item"></param>
    public bool AddFeel(UserFeel item)
    {
        var a = from p in DBContext.UserFeel
                where p.UserID == item.UserID & p.ContentID == item.ContentID & p.ContentType == item.ContentType
                select p;
        if (a == null || a.Count() == 0)
        {
            var c = DBContext.UserFeel.OrderByDescending(p => p.ID).FirstOrDefault();
            item.ID = c == null ? 1 : c.ID + 1;
            item.CreateDate = DateTime.Now;
            DBContext.UserFeel.AddObject(item);
            DBContext.SaveChanges();

            UserAct act = new UserAct();
            act.ActType = Convert.ToInt32(ActType.Feel);
            act.ContentID = item.ContentID;
            act.ContentType = (int)item.ContentType;
            AddAct(act);
            return true;
        }
        return false;
    }
    #endregion

    #region UserAct
    /// <summary>
    /// 添加用户互动相关的信息,记录的是互动次数
    /// </summary>
    /// <param name="item"></param>
    private void AddAct(UserAct item)
    {
        var a = from p in DBContext.UserAct
                where p.UserID == item.UserID & p.ContentID == item.ContentID
                    & p.ContentType == item.ContentType & p.ActType == item.ActType
                select p;
        if (a != null && a.Count() > 0)
        {
            var b = a.SingleOrDefault();
            b.UpdateDate = DateTime.Now;
            b.ActCount += 1;
        }
        else
        {
            var c = DBContext.UserAct.OrderByDescending(p => p.ID).FirstOrDefault();
            item.ID = c == null ? 1 : c.ID + 1;
            item.ActCount = 1;
            item.UpdateDate = DateTime.Now;
            DBContext.UserAct.AddObject(item);
        }
        DBContext.SaveChanges();
    }
    /// <summary>
    /// 获取某条类容下的所有的互动数据 
    /// </summary>
    /// <param name="contentid"></param>
    /// <param name="contenttype"></param>
    /// <returns></returns>
    public List<UserAct> GetActList(int contentID, int contentType)
    {
        var c = from p in DBContext.UserAct
                where p.ContentID == contentID & p.ContentType == contentType
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<UserAct>();
        }
    }
    #endregion
}