using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Weixin_WebAuth : System.Web.UI.Page
{
    private WeinxinWeb weinxin = new WeinxinWeb();
    string url = string.Empty;
    string result = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request["code"];
        string result = string.Empty;
        WXWebAccessToken accessToken = weinxin.GetAccessToken(code);
        WXUserInfo userInfo = new WXUserInfo();
        if (accessToken != null)
        {
            userInfo = weinxin.GetUserInfo(accessToken);
            if (userInfo != null)
            {
                //保存用户到数据库

                //在Session中记录用户信息
            }
        }
        Response.Write(userInfo.nickname);

    }
    /// <summary>
    /// 获取请求的信息
    /// </summary>
    /// <returns></returns>
    private string GetRequestMsg()
    {
        byte[] buffer = new byte[(int)Request.InputStream.Length];
        Request.InputStream.Read(buffer, 0, (int)Request.InputStream.Length);
        return System.Text.UTF8Encoding.UTF8.GetString(buffer);
    }
}