function GetLogin() {
    
    if (isEmptyKing($("#txtUsername").val())) {
        KingWarningStyle("#txtUsername", 0);
        KingSweetAlert(0, "نام کاربری وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtUsername", 0);
    }
    
    if (isEmptyKing($("#txtPassword").val())) {
        KingWarningStyle("#txtPassword", 0);
        KingSweetAlert(0, "کلمه عبور وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtPassword", 0);
    }

    var postData = {
        'Username': DOMPurify.sanitize($("#txtUsername").val()),
        'Password': DOMPurify.sanitize($("#txtPassword").val()),
        'UserAgent': navigator.userAgent,
    };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: '/auth/GetLogin',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlertCenterWithoutTimer('در حال ورود به پرتال ...');
                window.location = "/user/";
            }
            else {
                KingSweetAlert(0, data.message);
            }
        },
        error: function (e) {
            KingSweetAlert(0, null);
        }
    });
}