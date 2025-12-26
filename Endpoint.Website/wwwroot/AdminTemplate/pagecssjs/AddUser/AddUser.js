function addUser() {
    if ($("#selectRole").val() == "-1") {
        KingWarningStyle("#selectRole", 0);
        KingSweetAlert(0, "نقش را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#selectRole", 0);
    }

    if (isEmptyKing($("#txtFirstname").val())) {
        KingWarningStyle("#txtFirstname", 0);
        KingSweetAlert(0, "نام کامل کاربر وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtFirstname", 0);
    }

    if (isEmptyKing($("#txtLastname").val())) {
        KingWarningStyle("#txtLastname", 0);
        KingSweetAlert(0, "نام خانوادگی کاربری وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtLastname", 0);
    }

    if (isEmptyKing($("#txtUsername").val())) {
        KingWarningStyle("#txtUsername", 0);
        KingSweetAlert(0, "نام کاربری وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtUsername", 0);
    }

    if (isEmptyKing($("#txtemail").val())) {
        KingWarningStyle("#txtemail", 0);
        KingSweetAlert(0, "ایمیل وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtemail", 0);
    }

    if (isEmptyKing($("#txtPhone").val())) {
        KingWarningStyle("#txtPhone", 0);
        KingSweetAlert(0, "شماره موبایل وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtPhone", 0);
    }

    if (isEmptyKing($("#txtPassword").val())) {
        KingWarningStyle("#txtPassword", 0);
        KingSweetAlert(0, "کلمه عبور وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtPassword", 0);
    }

    var postData = {
        Firstname: $("#txtFirstname").val(),
        Lastname: $("#txtLastname").val(),
        Username: $("#txtUsername").val(),
        Email: $("#txtemail").val(),
        Password: $("#txtPassword").val(),
        Phone: $("#txtPhone").val(),
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

                const params = new URLSearchParams(window.location.search);
                var parameterValue = params.get('role');
                window.location = `/admin/users/${parameterValue}`;
            }
            else {
                KingSweetAlert(0,data.message);
            }
        },
        error: function (e) {
            KingSweetAlert(1, "خطایی رخ داده است.");
        }
    })
}
function updateUser(userId) {

    var postData = new FormData();
    if ($("#selectRole").val() == "-1") {
        KingWarningStyle("#selectRole", 0);
        KingSweetAlert(0, "نقش را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#selectRole", 0);
    }

    if (isEmptyKing($("#txtFirstname").val())) {
        KingWarningStyle("#txtFirstname", 0);
        KingSweetAlert(0, "نام کامل کاربر وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtFirstname", 0);
    }

    if (isEmptyKing($("#txtLastname").val())) {
        KingWarningStyle("#txtLastname", 0);
        KingSweetAlert(0, "نام خانوادگی کاربری وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtLastname", 0);
    }

    if (isEmptyKing($("#txtUsername").val())) {
        KingWarningStyle("#txtUsername", 0);
        KingSweetAlert(0, "نام کاربری وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtUsername", 0);
    }

    if (isEmptyKing($("#txtemail").val())) {
        KingWarningStyle("#txtemail", 0);
        KingSweetAlert(0, "ایمیل وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtemail", 0);
    }

    if (isEmptyKing($("#txtPhone").val())) {
        KingWarningStyle("#txtPhone", 0);
        KingSweetAlert(0, "شماره موبایل وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtPhone", 0);
    }
    if ($("#chkChangePassword").prop("checked")) {        
        if (isEmptyKing($("#txtPassword").val())) {
            KingWarningStyle("#txtPassword", 0);
            KingSweetAlert(0, "پسورد وارد شود.");
            return;
        } else {
            KingWarningStyleOff("#txtPassword", 0);
        }
        postData.append("Password", $("#txtPassword").val());
    }
    
    postData.append("UserId", userId);
    postData.append("Firstname", $("#txtFirstname").val());
    postData.append("Lastname", $("#txtLastname").val());
    postData.append("Username", $("#txtUsername").val());
    postData.append("Email", $("#txtemail").val());
    postData.append("Phone", $("#txtPhone").val());
    postData.append("RoleId", $("#selectRole").val());


    $.ajax({
        contentType: false,
        processData: false,
        type: 'PUT',
        url: '/admin/UpdateUser',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, "ویرایش با موفقیت انجام شد.");
            }
            else {
                KingSweetAlert(0, data.message);
            }
        },
        error: function (e) {
            KingSweetAlert(1, "خطایی رخ داده است.");
        }
    })
}