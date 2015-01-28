using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// 微信
/// </summary>
public class WeinXin
{
    #region Const Define
    private readonly string appid = "wx5ab373c26f4dd503";
    private readonly string secret = "ed3fb09d9692dd74066b394afa219f4c";
    private readonly string token = "disappearwind";

    /// <summary>
    /// 获取access token
    /// </summary>
    public static string url_access_token = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
    public static string url_user_info = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";
    #endregion

    public string access_token = string.Empty;

    public WeinXin()
    {
        GetAccessToken();
    }

    /// <summary>
    /// 接入时校验
    /// 开发者通过检验signature对请求进行校验（下面有校验方式）。
    /// 若确认此次GET请求来自微信服务器，请原样返回echostr参数内容，则接入生效，成为开发者成功，否则接入失败。
    /// 加密/校验流程如下：
    ///1. 将token、timestamp、nonce三个参数进行字典序排序
    ///2. 将三个参数字符串拼接成一个字符串进行sha1加密
    ///3. 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信
    /// </summary>
    /// <returns></returns>
    private string GetSignature(string timestamp, string nonce)
    {
        var arr = new[] { token, timestamp, nonce }.OrderBy(p => p).ToArray(); ;
        string str = string.Join(string.Empty, arr);
        byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(str);
        byte[] sha1data = System.Security.Cryptography.SHA1.Create().ComputeHash(data);
        string sha1 = System.Text.UTF8Encoding.UTF8.GetString(sha1data);
        return sha1;
    }

    /// <summary>
    /// 获取access_token
    /// </summary>
    private void GetAccessToken()
    {
        string url = string.Format(url_access_token, appid, secret);
        string result = RequestUtility.Get(url);
        if (!string.IsNullOrEmpty(result))
        {
            WXAccessToken accessToken = JsonUtility.JsonDeserialize<WXAccessToken>(result);
            if (accessToken != null)
            {
                access_token = accessToken.access_token;
            }
        }
    }
    /// <summary>
    /// 根据用户请求响应
    /// </summary>
    /// <param name="reqMsg"></param>
    /// <returns></returns>
    public string ResponseMsg(string reqMsg)
    {
        string repStr = string.Empty;
        if (!string.IsNullOrEmpty(reqMsg))
        {
            Dictionary<string, string> reqParms = XmlUtility.XmlToDictionary(reqMsg);
            Dictionary<string, string> repParms = new Dictionary<string, string>();
            repParms.Add("ToUserName", reqParms["FromUserName"]);
            repParms.Add("FromUserName", reqParms["ToUserName"]);
            repParms.Add("CreateTime", DateTime.Now.Ticks.ToString());
            //repParms.Add("MsgType", "text");
            //repParms.Add("Content", "欢迎与袁老师一起交流！<a href='http://182.92.155.19/portal/index.aspx'>点击进入</a>");
            repParms.Add("MsgType", "news");
            List<PortalModel.PortalDocument> docList = new PortalDocumentBusiness().GetMenuPortalDocumentList("Index");
            docList = docList.Where(p => p.PortalMenuCode == "Index_NewWorks").ToList();
            Dictionary<string, string> article = new Dictionary<string, string>();
            string articleListXml = string.Empty;
            foreach (var item in docList)
            {
                article.Clear();
                article.Add("Title", item.Name);
                article.Add("Description", item.Description);
                article.Add("PicUrl", string.Format("http://182.92.155.19/Resources/Images/{0}", item.ImageURL));
                //article.Add("Url", string.Format("http://182.92.155.19/Portal/{0}", item.URL));
                article.Add("Url", string.Format("http://www.tonsfeit.com/weixin/webAuth.aspx"));
                articleListXml += XmlUtility.DictionaryToXml(article, "item");
            }
            repParms.Add("ArticleCount", docList.Count.ToString());
            repParms.Add("Articles", articleListXml);

            repStr = XmlUtility.DictionaryToXml(repParms);
        }
        return repStr;
    }
    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <param name="openID"></param>
    private void GetUserInfo(string openID)
    {
        string url = string.Format(url_user_info, access_token, openID);
        string result = RequestUtility.Get(url);
    }
}