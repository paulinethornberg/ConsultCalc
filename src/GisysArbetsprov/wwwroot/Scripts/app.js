$(document).foundation();



function UpdateHours(id) {

    $('#idHoursForm').val(id);
}


$("#deleteButton").click(function () {
    $.post("/Consultant/DeleteConsultant", function (deleteResult) {
        if (deleteResult)
            window.location.href = "/Consultant/List";

        else
            window.location.href = "/Consultant/List";
    });
});


function DeleteUser(id) {
    $.post("/Consultant/DeleteConsultant", { "id": id }, function (deleteResult) {
        if (deleteResult)
            window.location.href = "/Consultant/List";
        else
            window.location.href = "/Consultant/List";
    });
}

function GetConsultantInfo(id) {
    $('#idHoursForm').val(id);

    var firstName = $('#' + id + ' #firstName').html();
    $('#firsNameUpdateForm').val(firstName);


    var lastName = $('#' + id + ' #lastName').html();
    $('#lastNameUpdateForm').val(lastName);


    var date = $('#' + id + ' #dateEmp').html();
    rightDate = date.substring(0, 10);
    $('#dateUpdateForm').val(rightDate);

    $('#idUpdateForm').val(id);

}


