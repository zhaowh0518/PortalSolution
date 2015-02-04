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
    public ConstantUtility.Site.Mold Mold { get; set; }
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

    /// <summary>
    /// 总计点赞的次数
    /// </summary>
    public int FeelCount { get; set; }
    /// <summary>
    /// 当前用户是否赞过
    /// </summary>
    public bool IsUserFelt { get; set; }
    /// <summary>
    /// 总计被收藏的次数
    /// </summary>
    public int FavoriteCount { get; set; }
    /// <summary>
    /// 是否被当前用户收藏过
    /// </summary>
    public bool IsUserHasFavorite { get; set; }
    /// <summary>
    /// 播放器代码
    /// </summary>
    public string PlayCode { get; set; }
    /// <summary>
    /// 评论列表
    /// </summary>
    public List<UserComment> CommentList { get; set; }
    #endregion

    #region Constructor
    public Program()
    {
        ID = 0;
        CommentList = new List<UserComment>();
    }
    /// <summary>
    /// 构造方法，根据ID和Mold获取信息
    /// </summary>
    /// <param name="id"></param>
    /// <param name="mold"></param>
    public static Program GetProgram(int id, ConstantUtility.Site.Mold mold)
    {
        Program p = new Program();
        switch (mold)
        {
            case ConstantUtility.Site.Mold.Content:
                p = new Program(_portalContentBusiness.GetPortalContent(id));
                break;
            case ConstantUtility.Site.Mold.ContentItem:
                p = new Program(_portalContentItemBusiness.GetPortalContentItem(id));
                break;
            case ConstantUtility.Site.Mold.Doucment:
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
        PlayCode = GetPlayCode(item.Type, item.Extend1);
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
        PlayCode = GetPlayCode((int)item.Type, item.Extend1);
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
        PlayCode = GetPlayCode(item.Type, item.Extend1);
        URL = item.URL;
        CreateDate = item.CreateDate;
        ContentType = 2;

        GetUserData();
    }
    #endregion

    #region Action
    public void AddFeel(int userID)
    {
        UserFeel item = new UserFeel();
        item.ContentID = ID;
        item.ContentType = ContentType;
        item.ContentName = Name;
        item.ContentImageURL = ImageURL;
        item.ContentSummary = DisplayName;
        item.ContentURL = URL;
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
        item.ContentName = Name;
        item.ContentImageURL = ImageURL;
        item.ContentSummary = DisplayName;
        item.ContentURL = URL;
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
    /// <summary>
    /// 根据类容类型返回播放代码
    /// </summary>
    /// <returns></returns>
    private string GetPlayCode(int type, string path)
    {
        string code = string.Empty;
        if (type == 0) //视频
        {
            code = string.Format("<iframe class=\"iframevd top20\" height=500 width=500 src=\"{0}\" frameborder=0 allowfullscreen ></iframe>", path);
        }
        else if (type == 1) //音频
        {
            code = string.Format("<div class=\"bot20\"><audio preload=\"auto\" controls><source src=\"{0}\"></audio><script src=\"js/jquery.js\" type=\"text/javascript\"></script><script src=\"js/audioplayer.js\" type=\"text/javascript\"></script><script type=\"text/javascript\">$(function () {{ $('audio').audioPlayer(); }});</script></div>", path);
        }
        return code;
    }
}