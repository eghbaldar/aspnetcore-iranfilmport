function OpenModalFlowingContact() {
    $("#ModalFlowingContact").modal("show");
}
// site top search
function openSearch() {
    document.getElementById("mySearchOverlay").style.display = "block";
    $('#txtTopSearch').focus();
}
function closeSearch() {
    document.getElementById("mySearchOverlay").style.display = "none";
}
function gotosearch() {
    window.open("https://www.google.com/search?q=site:http://iranfilmport.com%20" + $("#txtTopSearch").val(), "_blank");
}
document.getElementById('txtTopSearch').addEventListener('keypress', function (event) {
    if (event.key === 'Enter' && event.keyCode === 13) {
        gotosearch();
    }
});
document.addEventListener('keydown', function (event) {
    if (event.key === 'Escape' && event.keyCode === 27) {
        closeSearch();
    }
});
document.getElementById('mySearchOverlay').addEventListener('click', function (event) {
    if (event.target === this) {
        closeSearch();
    }
});
// top menu dropdown list menu
$(".navbar-toggler-icon").on("click", function () {
    if ($(".afterCollapse").prop("hidden")) {
        $(".afterCollapse").prop("hidden", false);
    } else {
        $(".afterCollapse").prop("hidden", true);
    }
})
window.addEventListener("scroll", (event) => {
    let scrollY = this.scrollY;
    if (scrollY == 0)
        document.getElementById("TOPTOP").style.display = 'none'
    else
        document.getElementById("TOPTOP").style.display = 'inline'
});
window.onload = function () {
    if (scrollY == 0)
        document.getElementById("TOPTOP").style.display = 'none'
    else
        document.getElementById("TOPTOP").style.display = 'inline'
}