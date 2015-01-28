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
//设置分类选中的状态
function setActiveCategory() {
    var ulNav = document.getElementById("divCategory");
    var liList = ulNav.getElementsByTagName("a");
    var currentUrl = window.location.href;
    for (var i = 0; i < liList.length; i++) {
        liList[i].className = "btn btn-default";
        if (currentUrl == liList[i].href) {
            liList[i].className = "btn btn-primary";
        }
    }
}