/*JavaScript for log in, create account page*/ 

/*show-hide password implementation*/
const showPassword = document.querySelector("#show-password");
const passwordField = document.querySelector("#password");

showPassword.addEventListener("click", function(){
    
  if(this.classList.contains("fa-eye")){
      this.classList.replace("fa-eye","fa-eye-slash");
      console.log("verify1");
    }
    else{
      this.classList.replace("fa-eye-slash","fa-eye");
    }
    console.log("verify2");
    const type = passwordField.getAttribute("type")
        === "password" ? "text" : "password";
    /*that is equal with password will convert to text.
      Otherwise,(not password) will be converted in password*/
    passwordField.setAttribute("type", type);
    //set the attribute with new attribute once the user make click
})
/*end of show-hide password*/