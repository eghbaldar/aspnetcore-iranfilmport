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
    // loading part
    btnWaitMe_Start("btnLogin");
    GoogleLoader.start(); // goolge effect
    // end loading part
    turnstile.render('#turnstile-login', {
        sitekey: '0x4AAAAAACJBcc8Xh8rmgVEA',
        callback: function (token) {
            var postData = {
                'Username': DOMPurify.sanitize($("#txtUsername").val()),
                'Password': DOMPurify.sanitize($("#txtPassword").val()),
                'UserAgent': navigator.userAgent,
                'TurnstileToken': token,
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
                        window.location = data.reutrnedUrl;
                    }
                    else {
                        KingSweetAlert(0, data.message);
                        btnWaitMe_Stop("btnLogin");
                        GoogleLoader.finish();
                    }
                },
                error: function (e) {
                    KingSweetAlert(0, null);
                    btnWaitMe_Stop("btnLogin");
                    GoogleLoader.finish();
                }, done(e) {
                    GoogleLoader.finish();
                    btnWaitMe_Stop("btnLogin");
                }
            });
        },
        'error-callback': function (e) {
            KingSweetAlert(0, "مشکلی در هویت سنجی شما بوجود آماده است.");
            GoogleLoader.finish();
            btnWaitMe_Stop("btnLogin");
        }
    });    
}