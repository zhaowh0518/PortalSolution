using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Demo : System.Web.UI.Page
{
    private string video_code = "";
    private string audio_code = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request["type"]) || Request["type"] == "0")
        {
            txtCode.Text = HandleHtml(divVideoShow.InnerHtml);
            divVideoShow.Visible = true;
            divAudioShow.Visible = false;
        }
        else if (Request["type"] == "1")
        {
            txtCode.Text = HandleHtml(divAudioShow.InnerHtml);
            divAudioShow.Visible = true;
            divVideoShow.Visible = false;
        }
    }

    private string HandleHtml(string html)
    {
        return html.TrimStart().Replace("\r\n", string.Empty).Replace("  ", string.Empty);
    }
}