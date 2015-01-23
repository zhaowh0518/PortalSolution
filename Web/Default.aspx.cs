using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("~/Portal/Index.aspx");
        ShowRequestInfo();
    }

    private void ShowRequestInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Head:<br>");
        for (int i = 0; i < Request.Headers.Count; i++)
        {
            sb.AppendFormat("{0}:{1}<br>", Request.Headers.Keys[i], Request.Headers[i]);
        }
        sb.AppendLine("<hr>");
        sb.AppendFormat("<br>Query String:{0}", Request.QueryString);
        Response.Write(sb.ToString());
    }
}