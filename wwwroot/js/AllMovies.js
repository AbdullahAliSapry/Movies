let currentPage = parseInt(new URL(window.location.href).searchParams.get("page")) || 1;

const ButtonLeft = document.querySelector(".ButtonLeft");
const ButtonRight = document.querySelector(".ButtonRight");
const conToPag = Array.from(document.querySelector(".conToPag").children);


if (new URL(window.location.href).searchParams.get("page") < 0) {
    const url = new URL(window.location.href);
    url.searchParams.set("page", 1)
    console.log("enter");
    window.location.href = url;
}
if (new URL(window.location.href).searchParams.get("page") > conToPag.length) {
    const url = new URL(window.location.href);
    url.searchParams.set("page", conToPag.length)
    console.log("enter");
    window.location.href = url;
}



function updateActiveElement() {
    conToPag.forEach((element, index) => {
        element.classList.toggle("active", index === currentPage - 1);
    });

    ButtonLeft.classList.toggle("notactive", currentPage === 1);
    ButtonRight.classList.toggle("notactive", currentPage === conToPag.length);
}

function updateUrl(page) {
    const url = new URL(window.location.href);
    url.searchParams.set("page", page);
    window.location.href = url;
    history.pushState(null, '', url);
}

ButtonRight.addEventListener("click", () => {
    if (currentPage < conToPag.length) {
        currentPage++;
        updateActiveElement();
        updateUrl(currentPage);
    }
});

ButtonLeft.addEventListener("click", () => {
    if (currentPage > 1) {
        currentPage--;
        updateActiveElement();
        updateUrl(currentPage);
    }
});

updateActiveElement();
