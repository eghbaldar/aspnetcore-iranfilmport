function addUser() {
    if ($("#selectRole").val() == "-1") {
        KingWarningStyle("#selectRole", 0);
        KingSweetAlert(0, "نقش را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#selectRole", 0);
    }

    if (isEmptyKing($("#txtFullname").val())) {
        KingWarningStyle("#txtFullname", 0);
        KingSweetAlert(0, "نام کامل کاربر وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtFullname", 0);
    }

    if (isEmptyKing($("#txtUsername").val())) {
        KingWarningStyle("#txtUsername", 0);
        KingSweetAlert(0, "نام کاربری وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtUsername", 0);
    }

    if (isEmptyKing($("#txtPassword").val())) {
        KingWarningStyle("#txtPassword", 0);
        KingSweetAlert(0, "پسورد وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtPassword", 0);
    }

    var postData = {
        Fullname: $("#txtFullname").val(),
        Username: $("#txtUsername").val(),
        Password: $("#txtPassword").val(),
        RoleId: $("#selectRole").val()
    };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        url: '/admin/PostAddUser',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, "درج با موفقیت انجام شد.");
                window.location = "/admin/users";
            }
            else {
                KingSweetAlert(0, "خطایی رخ داده است.");
            }
        },
        error: function (e) {
            alert(e);
        }
    })
}
function updateUser() {

    if ($("#selectRole").val() == "-1") {
        KingWarningStyle("#selectRole", 0);
        KingSweetAlert(0, "نقش را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#selectRole", 0);
    }

    if (isEmptyKing($("#txtFullname").val())) {
        KingWarningStyle("#txtFullname", 0);
        KingSweetAlert(0, "نام کامل کاربر وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtFullname", 0);
    }

    if (isEmptyKing($("#txtUsername").val())) {
        KingWarningStyle("#txtUsername", 0);
        KingSweetAlert(0, "نام کاربری وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtUsername", 0);
    }

    if ($("#ChangingPassword").prop("checked")) {
        if (isEmptyKing($("#txtPassword").val())) {
            KingWarningStyle("#txtPassword", 0);
            KingSweetAlert(0, "پسورد وارد شود.");
            return;
        } else {
            KingWarningStyleOff("#txtPassword", 0);
        }
    }

    var postData = {
        UserId: _userId,
        Fullname: $("#txtFullname").val(),
        Username: $("#txtUsername").val(),
        ChangingPassword: $("#ChangingPassword").prop("checked"),
        Password: $("#txtPassword").val(),
        RoleId: $("#selectRole").val()
    };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'PUT',
        url: '/admin/UpdateAddUser',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, "درج با موفقیت انجام شد.");
            }
            else {
                KingSweetAlert(0, "خطایی رخ داده است.");
            }
        },
        error: function (e) {
            alert(e);
        }
    })
}