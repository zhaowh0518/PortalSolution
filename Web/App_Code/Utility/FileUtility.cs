using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// 文件处理的通用类
/// </summary>
public class FileUtility
{
    /// <summary>
    /// 上传图片到Resources\Images目录下
    /// </summary>
    /// <param name="fileImage"></param>
    /// <returns></returns>
    public static string SaveImage(FileUpload file)
    {
        string fileName = string.Empty;
        if (file.PostedFile != null && file.PostedFile.ContentLength > 0)
        {
            int idx = file.PostedFile.FileName.LastIndexOf(".");
            string suffix = file.PostedFile.FileName.Substring(idx);//获得上传的图片的后缀名 
            fileName = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), suffix);
            file.PostedFile.SaveAs(string.Format("{0}\\Resources\\Images\\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName));
        }
        return fileName;
    }
}