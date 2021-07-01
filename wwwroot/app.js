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