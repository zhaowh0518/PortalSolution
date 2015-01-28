using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 微信网页授权
/// 授权步骤：
/// 1、引导用户进入授权页面同意授权，获取code
/// 2、通过code换取网页授权access_token（与基础支持中的access_token不同）
/// 3、如果需要，开发者可以刷新网页授权access_token，避免过期
/// 4、通过网页授权access_token和openid获取用户基本信息（支持UnionID机制）
/// </summary>
public class WeinxinWeb
{
    #region Const Define
    private readonly string appid = "wxea6a07398924e93b";
    private readonly string secret = "474a5bab4fda01dd91695644ffa34fc3";
    private readonly string token = "disappearwind";

    /// <summary>
    /// 获取access token
    /// </summary>
    public static string url_authorize = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state={2}#wechat_redirect";
    public static string url_access_token = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
    public static string url_refresh_token = "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token=REFRESH_TOKEN";
    public static string url_get_userinfo = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";
    #endregion

    public string access_token = string.Empty;

    public WeinxinWeb()
    {

    }
    /// <summary>
    /// 获取弹出授权页面的地址
    /// </summary>
    /// <param name="redirectUrl"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public string GetAuthorizeUrl(string redirectUrl, string state)
    {
        return string.Format(url_authorize, appid, redirectUrl, state);
    }
    /// <summary>
    /// 获取得到Access_Token的字符串
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public string GetAccessTokenUrl(string code)
    {
        return string.Format(url_access_token, appid, secret, code);
    }
    public WXWebAccessToken GetAccessToken(string msg)
    {
        return JsonUtility.JsonDeserialize<WXWebAccessToken>(msg);
    }
    /// <summary>
    /// 获取用户信息的Url
    /// </summary>
    /// <returns></returns>
    public string GetUserInfoUrl(string access_token, string openID)
    {
        return string.Format(url_get_userinfo, access_token, openID);
    }
}