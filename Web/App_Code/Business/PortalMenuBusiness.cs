﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalModel;

/// <summary>
///PortalMenuBusiness 的摘要说明
/// </summary>
public class PortalMenuBusiness : BaseBuiness
{
    /// <summary>
    /// 获取所有的菜单信息
    /// </summary>
    /// <returns></returns>
    public List<PortalMenu> GetPortalMenuList()
    {
        var c = from p in DBContext.PortalMenu
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalMenu>();
        }
    }
    /// <summary>
    /// 获取某个菜单下所有可见的菜单
    /// </summary>
    /// <param name="rootMenuCode"></param>
    /// <returns></returns>
    public List<PortalMenu> GetValidPortalMenuList(string rootMenuCode)
    {
        var c = from p in DBContext.PortalMenu
                where p.State == true & p.ParentCode == rootMenuCode
                orderby p.Seq
                select p;
        if (c != null && c.Count() > 0)
        {
            return c.ToList();
        }
        else
        {
            return new List<PortalMenu>();
        }
    }
    /// <summary>
    /// 根据ID得到唯一的菜单
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public PortalMenu GetPortalMenu(int id)
    {
        return DBContext.PortalMenu.Where(p => p.ID == id).SingleOrDefault();
    }
    /// <summary>
    /// 添加菜单,返回菜单的ID
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int AddPortalMenu(PortalMenu item)
    {
        var c = DBContext.PortalMenu.OrderByDescending(p => p.ID).FirstOrDefault();
        if (c == null)
        {
            item.ID = 1;
        }
        else
        {
            item.ID = c.ID + 1;
        }
        item.CreateDate = DateTime.Now;
        //处理ParentCode
        item.ParentCode = GetPortalMenu(item.ParentID).Code;
        DBContext.PortalMenu.AddObject(item);
        DBContext.SaveChanges();
        return item.ID;
    }
    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int UpdatePortalMenu(PortalMenu item)
    {
        var c = DBContext.PortalMenu.Where(p => p.ID == item.ID).SingleOrDefault();
        c.ImageUrl = item.ImageUrl;
        c.Code = item.Code;
        c.Description = item.Description;
        c.DisplayName = item.DisplayName;
        c.Name = item.Name;
        c.ParentID = item.ParentID;
        c.Seq = item.Seq;
        c.State = item.State;
        c.Type = item.Type;
        c.Style = item.Style;
        c.URL = item.URL;
        return DBContext.SaveChanges();
    }
    /// <summary>
    /// 删除菜单
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeletePortalMenu(int id)
    {
        var c = DBContext.PortalMenu.Where(p => p.ID == id).SingleOrDefault();
        DBContext.DeleteObject(c);
        return DBContext.SaveChanges();
    }
}