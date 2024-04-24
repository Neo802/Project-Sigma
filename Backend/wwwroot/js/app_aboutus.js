/*JavaScript for AbousUs page*/ 

/* show-hide text implementation */
var x = 0;
function showHide(){
    if(x==0){
        document.getElementById('hide').style='display:block';
        document.getElementById('switch-text').innerText='Read less';
        x = 1;
    }
    else{
        document.getElementById('hide').style='display:none';
        document.getElementById('switch-text').innerText='Read more';
        x = 0;
    }
}
/* end of show-hide text implementation */