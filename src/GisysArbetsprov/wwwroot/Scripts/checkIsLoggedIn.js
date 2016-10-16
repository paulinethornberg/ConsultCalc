$(document).ready(function () {
    checkIsLoggedIn();
})
// check if user is logged in 
function checkIsLoggedIn() {
    $.get("/account/CheckIsLoggedIn", function (loggedIn) {
        if (loggedIn) {
            //Create navbar buttons
            console.log(loggedIn);
            //$("#editBtn").removeClass('none');
            //$("#deleteButton").removeClass('none');
        }
        else {
            console.log("Utloggad");
            $(".menumenu").addClass('none');
        }
    });
}
