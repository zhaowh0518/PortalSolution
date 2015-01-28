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
        url = weinxin.GetAccessTokenUrl(code);
        result = RequestUtility.Get(url);
        WXWebAccessToken token = JsonUtility.JsonDeserialize<WXWebAccessToken>(result);
        if (token != null)
        {
            url = weinxin.GetUserInfoUrl(token.access_token, token.openid);
            result = RequestUtility.Get(url);
            WXUserInfo userInfo = JsonUtility.JsonDeserialize<WXUserInfo>(result);
            result = userInfo.nickname;
        }
        Response.Write(result);

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