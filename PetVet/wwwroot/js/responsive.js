function openMenu() {
    var x = document.getElementById("myNavbar");
    var closeIcon = document.getElementById("close");
    var openMenu = document.getElementById("open")
    if (x.className === "navbar-container") {
        x.className += " responsive";
        openMenu.style.display = "none";
        closeIcon.style.display = "block";
    } else {
        x.className = "navbar-container";
        openMenu.style.display = "block";
        closeIcon.style.display = "none"
    }
}