using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///SysConfigBusiness 的摘要说明
/// </summary>
public class SysConfigBusiness : BaseBuiness
{
    /// <summary>
    /// 获取所有的配置项
    /// </summary>
    /// <returns></returns>
    public List<SysConfig> GetSysConfigList()
    {
        var c = from p in DBContext.SysConfig
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<SysConfig>();
        }
    }
    /// <summary>
    /// 更新系统配置
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int UpdateSysConfig(SysConfig item)
    {
        var c = DBContext.SysConfig.Where(p => p.ID == item.ID).SingleOrDefault();
        c.Value = item.Value;
        c.Description = item.Description;
        return DBContext.SaveChanges();
    }
}