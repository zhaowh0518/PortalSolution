//设置导航菜单的选中状态
function setActiveMenu() {
    var ulNav = document.getElementById("ulNav");
    var liList = ulNav.getElementsByTagName("li");
    var currentUrl = window.location.href;
    for (var i = 0; i < liList.length; i++) {
        liList[i].className = "";
        if (currentUrl.indexOf(liList[i].id) > 0) {
            liList[i].className = "active";
        }
    }
}
//设置选项菜单的选中
function setActiveTabMenu(containerID, activeClass, defaultClass) {
    var container = document.getElementById(containerID);
    var menuList = container.getElementsByTagName("a");
    var currentUrl = window.location.href;
    for (var i = 0; i < menuList.length; i++) {
        menuList[i].className = defaultClass;
        if (currentUrl == menuList[i].href) {
            menuList[i].className = activeClass;
        }
    }
}