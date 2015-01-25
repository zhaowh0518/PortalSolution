﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Weixin_Default : System.Web.UI.Page
{
    private WeinXin wx = new WeinXin();

    protected void Page_Load(object sender, EventArgs e)
    {
        string msg = string.Empty;
        byte[] buffer = new byte[(int)Request.InputStream.Length];
        Request.InputStream.Read(buffer, 0, (int)Request.InputStream.Length);
        msg = System.Text.UTF8Encoding.UTF8.GetString(buffer);

        Response.Write(wx.ResponseMsg(msg));
        Response.End();
    }

}