//打开菜单选择子页面
function openDivDialog() {
    document.documentElement.style.height = "100%";
    document.documentElement.style.width = "100%";
    document.documentElement.style.overflow = "hidden";
    document.body.style.height = "100%";
    document.body.style.width = "100%";
    document.body.style.overflow = "hidden";
    document.getElementById('divDialog').style.display = 'block';
    document.getElementById('divBackgroundLayer').style.display = "block";
}
function closeDivDialog() {
    document.getElementById('divDialog').style.display = 'none';
    document.getElementById('divBackgroundLayer').style.display = "none";
    document.body.style.height = "auto";
    document.body.style.width = "auto";
    document.body.style.overflow = "auto";
    document.documentElement.style.height = "auto";
    document.documentElement.style.width = "auto";
    document.documentElement.style.overflow = "auto";
}