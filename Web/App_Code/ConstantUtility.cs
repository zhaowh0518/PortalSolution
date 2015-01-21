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
        public static string ImageURLPath { get { return "../Resources/Images/"; } }
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
    }
}