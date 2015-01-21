using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtUserName.Value) && !string.IsNullOrEmpty(txtPassword.Value))
        {
            PortalManagerBusiness managerBusiness = new PortalManagerBusiness();
            PortalModel.PortalManager manager = managerBusiness.GetPortalManager(txtUserName.Value, txtPassword.Value);
            if (manager != null && manager.ID > 0)
            {
                Session[ConstantUtility.AdminConstant.UserIDKey] = manager.ID;
                Session[ConstantUtility.AdminConstant.UserNameKey] = manager.UserName;
                Response.Redirect("Index.aspx");
            }
            else
            {
                message.InnerText = "用户名或密码错误！";
            }
        }
        else
        {
            message.InnerText = "用户名或密码不能为空！";
        }
    }
}