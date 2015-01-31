using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Write log
/// </summary>
public static class LogUtility
{
    static string logPath = string.Format("{0}\\Log\\{1}.txt", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMdd"));
    /// <summary>
    /// Write log
    /// </summary>
    /// <param name="source">Throw class</param>
    /// <param name="message">Log message</param>
    public static void WriteLog(string source, string message)
    {
        using (StreamWriter sw = new StreamWriter(logPath, true, System.Text.UTF8Encoding.UTF8))
        {
            sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", source, message, DateTime.Now, HttpContext.Current.Request.UserHostAddress));
            sw.AutoFlush = true;
            sw.Close();
        }
    }
    /// <summary>
    /// 记录调试的错误日志，每次只记录最新的日志
    /// </summary>
    /// <param name="source"></param>
    /// <param name="ex"></param>
    public static void WritePortalDebugLog(string source, Exception ex)
    {
        string msg = string.Format("{0}:{1}<br/>", source, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        HttpContext.Current.Application[ConstantUtility.Portal.ErrorMessageKey] = msg;
    }
}
