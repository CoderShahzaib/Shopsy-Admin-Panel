document.addEventListener("DOMContentLoaded", function () {
    const menuBtn = document.getElementById("menuBtn");
    const sidebar = document.querySelector(".admin-sidebar");

    menuBtn.addEventListener("click", function () {
        sidebar.classList.toggle("open");
    });
});
