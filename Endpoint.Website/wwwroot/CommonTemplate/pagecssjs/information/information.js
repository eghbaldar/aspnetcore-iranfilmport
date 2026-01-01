function updateInfo() {

    if (isEmptyKing($("#txtFirstname").val())) {
        KingWarningStyle("#txtFirstname", 0);
        KingSweetAlert(0, "نام باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtFirstname", 0);
    }


    if (isEmptyKing($("#txtLastname").val())) {
        KingWarningStyle("#txtLastname", 0);
        KingSweetAlert(0, "نام خانوادگی باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtLastname", 0);
    }


    if (isEmptyKing($("#txtUsername").val())) {
        KingWarningStyle("#txtUsername", 0);
        KingSweetAlert(0, "نام کاربری باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtUsername", 0);
    }
    
    var postData = new FormData();
    postData.append("Firstname", DOMPurify.sanitize($("#txtFirstname").val()));
    postData.append("Lastname", DOMPurify.sanitize($("#txtLastname").val()));
    postData.append("Username", DOMPurify.sanitize($("#txtUsername").val()));

    postData.append("Firstname_En", DOMPurify.sanitize($("#txtFirstname_En").val()));
    postData.append("Lastname_En", DOMPurify.sanitize($("#txtLastname_En").val()));
    postData.append("Resume", DOMPurify.sanitize($("#txtResume").val()));
    postData.append("Resume_En", DOMPurify.sanitize($("#txtResume_En").val()));
    postData.append("Website", DOMPurify.sanitize($("#txtWebsite").val()));
    postData.append("DegreeField", DOMPurify.sanitize($("#txtDegreeField").val()));
    postData.append("Twitter", DOMPurify.sanitize($("#txtTwitter").val()));
    postData.append("Facebook", DOMPurify.sanitize($("#txtFacebook").val()));
    postData.append("Instagram", DOMPurify.sanitize($("#txtInstagram").val()));
    postData.append("IMDb", DOMPurify.sanitize($("#txtIMDb").val()));

    postData.append("Phone_Visibility", $("#chkMobile").prop("checked"));
    postData.append("Email_Visibility", $("#chkEmail").prop("checked"));
    postData.append("Degree", $("#selectDegree").val());
    postData.append("Position", $("#selectPosition").val());


    if (!isEmptyKing($("#txtBirthday").val())) {
        const [shamsiYear, shamsiMonth, shamsiDay] = KingConvertPersianNumberToEnglishNumber($("#txtBirthday").val()).split('/').map(Number);
        postData.append("Birthday",
            `${farvardin.solarToGregorian(shamsiYear, shamsiMonth, shamsiDay).toString().replaceAll(',', '-')}`);
    }

    Swal.fire({
        title: 'توجه!',
        text: 'پروفایل شما پس از بروزرسانی تا بررسی و تائید ادمین معلق خواهد شد. مطمئن هستید؟',
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#000222',
        cancelButtonColor: '#000222',
        confirmButtonText: 'بلی',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                contentType: false,
                processData: false,
                type: 'PUT',
                url: '/common/UpdateInformationUser',
                data: postData,
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAlert(1, "اطلاعات شما با موفقیت بروز شد");
                        $("#divInfo").load("/common/information #divInfo");
                    }
                    else {
                        KingSweetAlert(0, data.message);
                    }
                },
                error: function (e) {
                    KingSweetAlert(0, "خطایی رخ داده است.");
                }
            });
        }
    });
}
function updateHeadshot() {

    var postData = new FormData();

    // file validations
    const checkfileHeashotExist = document.getElementById('fileHeashot');
    if (checkfileHeashotExist != null) {
        if (!isEmptyKing($("#fileHeashot").val())) {
            var _fileHeadshotFile = $("#fileHeashot")[0].files[0];
            if (!KingCheckSizeExtension(_fileHeadshotFile, ["jpg", "png"],
                "160000", true)) {
                return;
            }
            postData.append("HeadshotFile", _fileHeadshotFile);
        }
    }

    Swal.fire({
        title: 'توجه!',
        text: 'تصویر پروفایل شما پس از بروزرسانی تا بررسی و تائید ادمین معلق خواهد شد. مطمئن هستید؟',
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#000222',
        cancelButtonColor: '#000222',
        confirmButtonText: 'بلی',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                contentType: false,
                processData: false,
                type: 'PUT',
                url: '/common/UpdateHeadshotUser',
                data: postData,
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAlert(1, "اطلاعات شما با موفقیت بروز شد");
                        $("#divInfo").load("/common/information #divInfo");
                    }
                    else {
                        KingSweetAlert(0, data.message);
                    }
                },
                error: function (e) {
                    KingSweetAlert(0, "خطایی رخ داده است.");
                }
            });
        }
    });
}
function updateMelicard() {

    var postData = new FormData();

    // file validations
    const checkfileMeliCardExist = document.getElementById('fileMeliCard');
    if (checkfileMeliCardExist != null) {
        if (!isEmptyKing($("#fileMeliCard").val())) {
            var _fileMeliCardFile = $("#fileMeliCard")[0].files[0];
            if (!KingCheckSizeExtension(_fileMeliCardFile, ["jpg", "png"],
                "200000", true)) {
                return;
            }
            postData.append("MeliCardFile", _fileMeliCardFile);
        }
    }

    $.ajax({
        contentType: false,
        processData: false,
        type: 'PUT',
        url: '/common/UpdateMeliCardUser',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, "اطلاعات شما با موفقیت بروز شد");
                $("#divInfo").load("/common/information #divInfo");
            }
            else {
                KingSweetAlert(0, data.message);
            }
        },
        error: function (e) {
            KingSweetAlert(0, "خطایی رخ داده است.");
        }
    });
}