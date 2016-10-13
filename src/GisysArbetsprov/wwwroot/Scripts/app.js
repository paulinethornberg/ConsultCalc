$(document).foundation();

$("#deleteButton").click(function () {
    $.post("/Consultant/DeleteConsultant", function (deleteResult) {
        if (deleteResult)
            window.location.href = "/";
            
        else
            window.location.href = "/Consultant/List";
    });
});

//function GetConsultantInfo(id) {
//    $.post("/Consultant/GetConsultantInfo",  {"id": id})}

function DeleteUser(id) {
    $.post("/Consultant/DeleteConsultant",  {"id": id}, function (deleteResult) {
        if (deleteResult)
            window.location.href = "/";

        else
            window.location.href = "/Consultant/List";
    });
}


function GetConsultantInfo(id) {

    alert(document.getElementById(id).innerHTML);
    var lista = document.getElementById(id).innerHTML;
    
    //document.getElementById("firstNameForm").innerHTML = lista.getElementsByClassName(firstName).innerHTML;

    //document.getElementById("firstNameForm").innerHTML = document.getElementById("firstName"-id).innerHTML;
  

    $('button.reveal-link').trigger('click');

}

//document.getElementById("lastNameForm").innerHTML = document.getElementById("lastname" + id).innerHTML;
//document.getElementById("lastNameForm").value = document.getElementById("lastname" + id).innerHTML;
//document.getElementById("lastNameForm").value = document.getElementById("lastname" + id).value;


  //document.getElementById("summaryPreview").innerHTML = document.getElementById("sumform").value;
  // document.getElementById("descriptionPreview").innerHTML = document.getElementById("descriptionform").value;
  //  document.getElementById("websitePreview").innerHTML = document.getElementById("websiteform").value;
  // document.getElementById("facebookPreview").innerHTML = document.getElementById("facebookform").value;
//    document.getElementById("emailPreview").innerHTML = document.getElementById("emailform").value;
//}

//function openModal() {
//   $.post(/)
//}

//$("#login-submit").click(function () {
//    $.post("/User/Login", { "Username": document.getElementById("username").value, "Password": document.getElementById("password").value }, function (result) {
//        if (result === false)
//            $("#messageLabel").text("Login failed, please try again");
//        else {
//            $('#myModal').modal('hide');
//            checkIsLoggedIn();
//        }
//        console.log(result);

//    });
//});