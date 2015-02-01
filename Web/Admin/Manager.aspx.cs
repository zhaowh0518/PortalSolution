using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Manager : System.Web.UI.Page
{
    private string dbFileName = string.Format("{0}\\App_Data\\portal.db3", AppDomain.CurrentDomain.BaseDirectory);
    private string pwd = "123qwe!@#";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSqlText.Text))
        {
            try
            {
                SQLiteHelper helper = new SQLiteHelper(dbFileName, pwd);
                gvList.DataSource = helper.GetData(txtSqlText.Text);
                gvList.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
    protected void btnExcute_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSqlText.Text))
        {
            try
            {
                SQLiteHelper helper = new SQLiteHelper(dbFileName, pwd);
                helper.ExcuteSQLText(txtSqlText.Text);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}