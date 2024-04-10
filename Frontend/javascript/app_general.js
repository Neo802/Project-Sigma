/*JavaScript for all pages*/ 

/* preloading implementation */
const preloader = document.querySelector(".preloader");
window.addEventListener("load",function(){
    preloader.classList.add("hide-preloader");
})
/* end of preloading*/

/* navbar switch implementation */
const navToggle = document.querySelector(".nav-toggle");
const links = document.querySelector(".links");

navToggle.addEventListener("click",function(){

    links.classList.toggle("show-links");
    
});
/* end of navbar switch */
