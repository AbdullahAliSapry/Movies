
//handling buttons to navbar
const button = document.getElementsByClassName("buttonToggle");
const NavProfile = document.getElementsByClassName("ProfileUser");
const MenueToggle = document.querySelector(".toggleMenueMin");
const MenueLinks = document.getElementById("mobile-menu");

button[0].addEventListener("click", () => {
    NavProfile[0].classList.toggle("hidden");

});
MenueToggle.addEventListener("click", () => {

    MenueLinks.classList.toggle("hidden");

})
// handling video


const buttonVideo = document.querySelector(".toggleVideo");
const xButton = document.querySelector(".xButton");
const video = document.querySelector(".conVideo");
const videoPlay = document.querySelector(".videoPlay");
buttonVideo.addEventListener("click", () => {

    video.classList.remove("hidden");
    videoPlay.play();

})

xButton.addEventListener("click", () => {
    if (!video.classList.contains("hidden")) {

        video.classList.add("hidden");
        videoPlay.pause();
    }
});


// handling click on swiper


const toggleVideosection = document.querySelectorAll(".toggleVideosection");
const Videos = document.querySelectorAll(".conVideoPopular");
const xButtonPopulars = document.querySelectorAll(".xButtonPopular");
toggleVideosection.forEach((e,index) => {

    e.addEventListener("click", (b) => {

        Videos[index].classList.toggle("hidden");
   
        if (!Videos[index].classList.contains("hidden")) {
            xButtonPopulars[index].addEventListener("click",() => {
                Videos[index].classList.add("hidden");
           })
        }
    })
})