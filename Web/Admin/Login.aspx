<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录</title>
    <link type="text/css" rel="stylesheet" href="~/Styles/Admin.css" />
</head>
<body>
    <div id="loginPanel">
        <form id="form1" runat="server">
        <div>
            <h1>
                欢迎登录！
            </h1>
            <p>
                <label for="txtUserName" class="lbTitle">
                    用户名:</label>
                <input type="text" id="txtUserName" name="txtUserName" class="textbox" runat="server" />
            </p>
            <p>
                <label for="txtPassword" class="lbTitle">
                    密&nbsp;&nbsp;&nbsp;&nbsp;码:</label>
                <input type="password" id="txtPassword" name="txtPassword" class="textbox" runat="server" />
            </p>
            <p class="submit">
                <asp:Button ID="btnLogin" runat="server" Text="登  录" OnClick="btnLogin_Click" />
            </p>
            <p class="message" id="message" runat="server">
            </p>
        </div>
        </form>
    </div>
</body>
</html>
