using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;
using UserModel;

/// <summary>
/// 统一的内容展示类，处理Content、ContentItem、Document
/// </summary>
public class Program
{
    #region Business Class
    protected static PortalDocumentBusiness _portalDocumentBuiness = new PortalDocumentBusiness();
    protected static PortalContentBusiness _portalContentBusiness = new PortalContentBusiness();
    protected static PortalContentItemBusiness _portalContentItemBusiness = new PortalContentItemBusiness();
    protected UserBusiness _userBusiness = new UserBusiness();
    #endregion

    #region Property
    public int ID { get; set; }
    /// <summary>
    /// 节目类型：0：Content;1：ContentItem;2：Document
    /// </summary>
    public int Type { get; set; }
    /// <summary>
    /// 内容类型：空的时候就是文本，0:视频；1：音频；
    /// </summary>
    public int ContentType { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public int ParentID { get; set; }
    public string ParentName { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
    public string ImageURL2 { get; set; }
    public string URL { get; set; }
    public DateTime CreateDate { get; set; }

    public int FeelCount { get; set; }
    public bool IsUserFelt { get; set; }
    public int FavoriteCount { get; set; }
    public bool IsUserHasFavorite { get; set; }
    /// <summary>
    /// 评论列表
    /// </summary>
    public List<UserComment> CommentList { get; set; }
    #endregion

    public Program()
    {
        ID = 0;
        CommentList = new List<UserComment>();
    }
    /// <summary>
    /// 构造方法，根据ID和Type获取信息
    /// </summary>
    /// <param name="id"></param>
    /// <param name="type"></param>
    public static Program GetProgram(int id, int type)
    {
        Program p = new Program();
        switch (type)
        {
            case 0:
                p = new Program(_portalContentBusiness.GetPortalContent(id));
                break;
            case 1:
                p = new Program(_portalContentItemBusiness.GetPortalContentItem(id));
                break;
            case 2:
                p = new Program(_portalDocumentBuiness.GetPortalDocument(id));
                break;
        }

        return p;
    }

    public Program(PortalContent item)
    {
        ID = item.ID;
        Name = item.Name;
        DisplayName = item.DisplayName;
        ParentID = item.CategoryID;
        Description = item.Description;
        ImageURL = item.ImageURL;
        ImageURL2 = item.ImageURL2;
        URL = item.URL;
        ContentType = item.Type;
        CreateDate = item.CreateDate;

        GetUserData();
    }
    public Program(PortalContentItem item)
    {
        ID = item.ID;
        Name = item.Name;
        DisplayName = item.DisplayName;
        ParentID = item.ContentID;
        Description = item.Description;
        ImageURL = item.ImageURL;
        ImageURL2 = item.ImageURL2;
        URL = item.URL;
        ContentType = (int)item.Type;
        CreateDate = item.CreateDate;

        GetUserData();
    }
    public Program(PortalDocument item)
    {
        ID = item.ID;
        Name = item.Name;
        DisplayName = item.DisplayName;
        ParentID = item.PortalMenuID;
        Description = item.Description;
        ImageURL = item.ImageURL;
        ImageURL2 = item.ImageURL2;
        URL = item.URL;
        CreateDate = item.CreateDate;
        ContentType = 2;

        GetUserData();
    }

    /// <summary>
    /// 用户互动的数据
    /// </summary>
    private void GetUserData()
    {
        List<UserAct> actList = _userBusiness.GetUserActList(ID, ContentType);
        if (actList != null && actList.Count > 0)
        {
            var feel = actList.Where(p => p.ActType == (int)UserBusiness.ActType.Feel).SingleOrDefault();
            IsUserFelt = feel == null ? false : true;
            var favorite = actList.Where(p => p.ActType == (int)UserBusiness.ActType.Favorite).SingleOrDefault();
            IsUserHasFavorite = favorite == null ? false : true;
        }
        List<UserProgramAct> programActList = _userBusiness.GetProgramActList(ID, ContentType);
        if (actList != null && actList.Count > 0)
        {
            var feel = programActList.Where(p => p.ActType == (int)UserBusiness.ActType.Feel).SingleOrDefault();
            FeelCount = feel == null ? 0 : feel.ActCount;
            var favorite = programActList.Where(p => p.ActType == (int)UserBusiness.ActType.Favorite).SingleOrDefault();
            FavoriteCount = favorite == null ? 0 : favorite.ActCount;
        }
        CommentList = _userBusiness.GetCommentList(ID, ContentType);
        CommentList = CommentList == null ? new List<UserComment>() : CommentList;
    }

    #region Action
    public void AddFeel(int userID)
    {
        UserFeel item = new UserFeel();
        item.ContentID = ID;
        item.ContentType = ContentType;
        item.Feeling = 1;
        item.UserID = userID;
        _userBusiness.AddFeel(item);
        FeelCount++;
    }
    public void AddFavorite(int userID)
    {
        UserFavorite item = new UserFavorite();
        item.ContentID = ID;
        item.ContentType = ContentType;
        item.ContentImageURL = ImageURL;
        item.ContentSummary = DisplayName;
        item.UserID = userID;
        _userBusiness.AddFavorite(item);
        FavoriteCount++;
    }
    public void AddComment(int userID, string userName, string comment)
    {
        UserComment item = new UserComment();
        item.ContentID = ID;
        item.ContentType = ContentType;
        item.UserName = userName;
        item.Comment = comment;
        item.UserID = userID;
        _userBusiness.AddComment(item);
        CommentList = _userBusiness.GetCommentList(ID, ContentType);
        FeelCount++;
    }
    #endregion
}