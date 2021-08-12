function SelectToggle(triggerId, selectId) {
    var x = document.getElementById(selectId);
    if (x.style.display === "block")
        x.style.display = "none";
    else
        x.style.display = "block";

    document.addEventListener("click", (e) => {
        if (!document.getElementById(triggerId).contains(e.target)) {
            x.style.display = "none";
        }
    });
}

function verticalIndicator() {
    window.addEventListener("scroll", function () {
        let winScroll = document.body.scrollTop || document.documentElement.scrollTop,
            height = document.documentElement.scrollHeight - document.documentElement.clientHeight,
            scrolled = (winScroll / height) * 100;
        document.getElementById("progressBar").style.width = scrolled + "%";
    });
}

function onScrollEvent() {
    var toTop = document.getElementById("scroll-btn");
    window.addEventListener("scroll", function () {
        if (window.pageYOffset > 100) {
            toTop.style.display = "block";
        } else {
            toTop.style.display = "none";
        }
    });
}

function onScrollButton() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}
