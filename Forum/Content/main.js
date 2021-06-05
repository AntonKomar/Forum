let headRegistrate = document.querySelector(".head_signIn");
let container = document.querySelectorAll(".container");
let x = window.matchMedia("(min-width: 781px)");

window.onload = hideRegistration();

function hideRegistration() {
    if (document.URL.includes("Login") ||
        document.URL.includes("Register")) {
        headRegistrate.style.display = 'none';
        container.forEach(e => {
            e.style.maxWidth = "1000px";
        });
    }
    else {
        container.forEach(e => {
            e.style.maxWidth = "1350px";
        });
        if(x.matches){
            headRegistrate.style.display = 'flex';
        }else{
            headRegistrate.style.display = 'none';
        }
    }
}

window.addEventListener("resize", function (e) {
    if (x.matches) {
        headRegistrate.style.display = 'flex';
    } else {
        headRegistrate.style.display = 'none';
    }
});

function toggleMenu(y) {
    y.classList.toggle("change");
}

function ShowHideItem(idParent, idChild, display) {
    var parent = document.getElementById(idParent);
    var child = document.getElementById(idChild);
    if (child.style.display == "none") {
        child.style.display = display;
    } else {
        child.style.display = "none";
    }
}