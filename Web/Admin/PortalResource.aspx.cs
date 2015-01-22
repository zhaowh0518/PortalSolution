using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_PortalResource : System.Web.UI.Page
{
    public Dictionary<string, string> FileList = new Dictionary<string, string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetFileList();
    }

    private void GetFileList()
    {
        string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Images\\");
        DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
        string url = string.Empty;
        if (dirInfo != null && dirInfo.GetFiles().Length > 0)
        {
            foreach (var item in dirInfo.GetFiles().OrderByDescending(p => p.CreationTime))
            {
                url = string.Format("../{0}/{1}/{2}", Request.ApplicationPath, ConstantUtility.Site.ImageURLPath, item.Name);
                url = url.Replace("//", "/");
                FileList.Add(item.Name, url);
            }
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fileImage.PostedFile != null && fileImage.PostedFile.ContentLength > 0)
        {
            FileUtility.SaveImage(fileImage);
        }
        Response.Redirect(Request.RawUrl);
    }
}