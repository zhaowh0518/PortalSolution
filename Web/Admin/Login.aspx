<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录</title>
    <link type="text/css" rel="stylesheet" href="~/Content/Admin.css" />
</head>
<body>
    <div id="loginPanel">
        <form action="/Web/Login" method="post" onsubmit="return doLogin(this)" runat="server">
        <div>
            <h1>
                欢迎登录！
            </h1>
            <p>
                <label for="txtUserName" class="lbTitle">
                    用户名:</label>
                <input type="text" id="txtUserName" name="txtUserName" class="textbox" />
            </p>
            <p>
                <label for="txtPassword" class="lbTitle">
                    密&nbsp;&nbsp;&nbsp;&nbsp;码:</label>
                <input type="password" id="txtPassword" name="txtPassword" class="textbox" />
            </p>
            <p class="submit">
                <input type="submit" value="登  录" />
            </p>
            <p class="message" id="message">
            </p>
        </div>
        </form>
    </div>
</body>
</html>
