using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 系统中用到的魔术字符或者数字的定义
/// 如：Session的Key
/// </summary>
public static class ConstantUtility
{
    public static class Site
    {
        /// <summary>
        /// 内容源的类型：Content/ContentIitem/Document
        /// </summary>
        public enum Mold
        {
            Content = 0,
            ContentItem = 1,
            Doucment = 2
        }
        public static string ImageURLPath { get { return "../Resources/Images/"; } }
        /// <summary>
        /// 内容列表页地址
        /// </summary>
        public static string ListPageURL { get { return "List.aspx?contentid={id}"; } }
        /// <summary>
        /// 内容详情页
        /// </summary>
        public static string DetailPageURL { get { return "Detail.aspx?id={id}&mold={mold}"; } }
    }
    /// <summary>
    /// 管理后台
    /// </summary>
    public static class AdminConstant
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public static string UserIDKey { get { return "ADMIN_USERID"; } }
        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserNameKey { get { return "ADMIN_USERNAME"; } }
        /// <summary>
        /// 默认排序号，100
        /// </summary>
        public static int DefaultSeq { get { return 100; } }
    }
    public static class Portal
    {
        /// <summary>
        /// 异常信息Key
        /// </summary>
        public static string ErrorMessageKey { get { return "EXCEPTION_MESSAGE"; } }
        /// <summary>
        /// 用户ID
        /// </summary>
        public static string UserIDKey { get { return "PORTAL_USERID"; } }
        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserNameKey { get { return "PORTALUSERNAME"; } }

    }
}