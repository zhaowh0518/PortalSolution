using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///BaseBuiness 的摘要说明
/// </summary>
public class BaseBuiness
{
    /// <summary>
    /// 数据库连接
    /// </summary>
    public PortalEntities DBContext { get { return new PortalEntities(); } }

}