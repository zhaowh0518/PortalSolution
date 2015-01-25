using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///WXAccessToken 的摘要说明
///{"access_token":"ACCESS_TOKEN","expires_in":7200}
/// </summary>
public class WXAccessToken
{
    /// <summary>
    /// 获取到的凭证
    /// </summary>
    public string access_token { get; set; }
    /// <summary>
    /// 凭证有效时间，单位：秒
    /// </summary>
    public string expires_in { get; set; }
}