$(function () {
    if (!isEmptyKing(savedGenreValues)) setGenres();    
});
function setGenres() {
    
    // Convert to array
    const valuesArray = savedGenreValues.split(',');

    // Loop through values and check matching checkboxes
    valuesArray.forEach(val => {
        const checkbox = document.querySelector('.genres input[type="checkbox"][value="' + val + '"]');
        if (checkbox) {
            checkbox.checked = true;
        }
    });
}
function checkAtleastOneGenre() {
    const checkboxes = document.querySelectorAll('.genres input[type="checkbox"]');    
    const selectedValues = Array.from(checkboxes)
        .filter(cb => cb.checked)
        .map(cb => cb.value);

    if (selectedValues.length === 0) {
        KingSweetAlert(0, "حداقل یک گونه انتخاب شود.");
        return false;
    }
    return true;
}
function getSelectedGenres() {

    const checkboxes = document.querySelectorAll('.genres input[type="checkbox"]');
    const selectedValues = Array.from(checkboxes)
        .filter(cb => cb.checked)
        .map(cb => cb.value);

    if (selectedValues.length === 0) {
        e.preventDefault(); // stop form submission
        KingSweetAlert(0, "حداقل یک گونه انتخاب شود.");
        return;
    }

    // If at least one is selected, you can use the values
    const result = selectedValues.join(',');
    return result;
}
function addFestival() {

    var editor_txtDetail = CKEDITOR.instances['txtDetail'];
    var editor_txtAttributes = CKEDITOR.instances['txtAttributes'];
    var editor_txtRules = CKEDITOR.instances['txtRules'];
    var editor_txtSubmitWay = CKEDITOR.instances['txtSubmitWay'];

    if ($("#selectLevel").val() == null) {
        KingSweetAlert(0, "سطح باید انتخاب شود.");
        return;
    }
    if (!checkAtleastOneGenre()) {
        KingSweetAlert(0, "حداقل یک ژانر انتخاب شود.");
        return;
    }
    if ($("#selectShortFeature").val() == null) {
        KingSweetAlert(0, "گونه باید انتخاب شود.");
        return;
    }
    if (isEmptyKing($("#txtTitleEn").val())) {
        KingWarningStyle("#txtTitleEn", 0);
        KingSweetAlert(0, "نام انگلیسی فستیوال باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitleEn", 0);
    }
    if (isEmptyKing($("#txtTitleFa").val())) {
        KingWarningStyle("#txtTitleFa", 0);
        KingSweetAlert(0, "نام فارسی فستیوال باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitleFa", 0);
    }
    if ($("#selectCountry").val() == null) {
        KingSweetAlert(0, "کشور باید انتخاب شود.");
        return;
    }

    if (isEmptyKing($("#txtAddress").val())) {
        KingWarningStyle("#txtAddress", 0);
        KingSweetAlert(0, "آدرس را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtAddress", 0);
    }
    
    if (isEmptyKing($("#txtWebsite").val())) {
        KingWarningStyle("#txtWebsite", 0);
        KingSweetAlert(0, "وب سایت را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtWebsite", 0);
    }

    if (isEmptyKing($("#txtShamsiDate_Opening").val())) {
        KingWarningStyle("#txtShamsiDate_Opening", 0);
        KingSweetAlert(0, "تاریخ بازگشایی باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtShamsiDate_Opening", 0);
    }

    if (isEmptyKing($("#txtShamsiDate_Notification").val())) {
        KingWarningStyle("#txtShamsiDate_Notification", 0);
        KingSweetAlert(0, "تاریخ اعلان را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtShamsiDate_Notification", 0);
    }

    if (isEmptyKing($("#txtShamsiDate_EventStartDate").val())) {
        KingWarningStyle("#txtShamsiDate_EventStartDate", 0);
        KingSweetAlert(0, "تاریخ شروع افتتاحیه باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtShamsiDate_EventStartDate", 0);
    }

    if (isEmptyKing($("#txtShamsiDate_EventEndDate").val())) {
        KingWarningStyle("#txtShamsiDate_EventEndDate", 0);
        KingSweetAlert(0, "تاریخ پایان افتتاحیه باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtShamsiDate_EventEndDate", 0);
    }

    if ($("#selectPremiere").val() == null) {
        KingSweetAlert(0, "پریمیر باید انتخاب شود.");
        return;
    }
    if (isEmptyKing(editor_txtDetail.getData())) {
        KingWarningStyle("#txtDetail", 0);
        KingSweetAlert(0, "جزییات فستیوال را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtDetail", 0);
    }

    if (isEmptyKing(editor_txtAttributes.getData())) {
        KingWarningStyle("#txtAttributes", 0);
        KingSweetAlert(0, "مشخصات خاص را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtAttributes", 0);
    }

    if (isEmptyKing(editor_txtRules.getData())) {
        KingWarningStyle("#txtRules", 0);
        KingSweetAlert(0, "قوانین و مقررات را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtRules", 0);
    }
    if ($("#selectPlatform").val() == null) {
        KingSweetAlert(0, "پلتفرم باید انتخاب شود.");
        return;
    }
    if (isEmptyKing(editor_txtSubmitWay.getData())) {
        KingWarningStyle("#txtSubmitWay", 0);
        KingSweetAlert(0, "راه ثبت نام را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSubmitWay", 0);
    }     

    // file validations
    if (isEmptyKing($("#fileLogo").val())) {
        KingWarningStyle("#fileImage", 0);
        KingSweetAlert(0, "لوگو را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#fileLogo", 0);
    }
    var _file = $("#fileLogo")[0].files[0];
    var maxSize = "160600";
    if (!KingCheckSizeExtension(_file, ["webp"],
        maxSize, true)) {
        return;
    }

    const [shamsiYear_Opening, shamsiMonth_Opening, shamsiDay_Opening] = $("#txtShamsiDate_Opening").val().split('/').map(Number);
    const [shamsiYear_Notification, shamsiMonth_Notification, shamsiDay_Notification] = $("#txtShamsiDate_Notification").val().split('/').map(Number);
    const [shamsiYear_EventStartDate, shamsiMonth_EventStartDate, shamsiDay_EventStartDate] = $("#txtShamsiDate_EventStartDate").val().split('/').map(Number);
    const [shamsiYear_EventEndDate, shamsiMonth_EventEndDate, shamsiDay_EventEndDate] = $("#txtShamsiDate_EventEndDate").val().split('/').map(Number);

    var postData = new FormData();
    postData.append("TitleEn", $("#txtTitleEn").val());
    postData.append("TitleFa", $("#txtTitleFa").val());
    postData.append("Logo", _file);
    postData.append("Platform", $("#selectPlatform").val());
    postData.append("CountryCode", $("#selectCountry").val());
    postData.append("Premiere", $("#selectPremiere").val());
    postData.append("Detail", editor_txtDetail.getData());
    postData.append("Attribute", editor_txtAttributes.getData());
    postData.append("Rules", editor_txtRules.getData());
    postData.append("Submitway", editor_txtSubmitWay.getData());
    postData.append("Address", $("#txtAddress").val());
    postData.append("ShortFeature", $("#selectShortFeature").val());
    postData.append("Active", $("#chkActive").prop("checked"));
    postData.append("Level", $("#selectLevel").val());
    postData.append("Website", $("#txtWebsite").val());
    postData.append("Genres", getSelectedGenres()); // e.g. "2,3,6";

    postData.append("OpeningDate",/**/
        `${farvardin.solarToGregorian(shamsiYear_Opening, shamsiMonth_Opening, shamsiDay_Opening).toString().replaceAll(',', '-')}`);

    postData.append("NotificationDate",/**/
        `${farvardin.solarToGregorian(shamsiYear_Notification, shamsiMonth_Notification, shamsiDay_Notification).toString().replaceAll(',', '-')}`);

    postData.append("EventStartDate",/**/
        `${farvardin.solarToGregorian(shamsiYear_EventStartDate, shamsiMonth_EventStartDate, shamsiDay_EventStartDate).toString().replaceAll(',', '-')}`);

    postData.append("EventEndDate",/**/
        `${farvardin.solarToGregorian(shamsiYear_EventEndDate, shamsiMonth_EventEndDate, shamsiDay_EventEndDate).toString().replaceAll(',', '-')}`);


    $.ajax({
        contentType: false,
        processData: false,
        type: 'POST',
        url: '/admin/PostFestival',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlertCenterWithoutTimer("درج فستیوال با موفقیت انجام شد");
                window.location = "/admin/festivals";
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
function updateFestival(festivalId) {


    var editor_txtDetail = CKEDITOR.instances['txtDetail'];
    var editor_txtAttributes = CKEDITOR.instances['txtAttributes'];
    var editor_txtRules = CKEDITOR.instances['txtRules'];
    var editor_txtSubmitWay = CKEDITOR.instances['txtSubmitWay'];
    
    if ($("#selectLevel").val() == null) {
        KingSweetAlert(0, "سطح باید انتخاب شود.");
        return;
    }
    if (!checkAtleastOneGenre()) {
        KingSweetAlert(0, "حداقل یک ژانر انتخاب شود.");
        return;
    }
    if ($("#selectShortFeature").val() == null) {
        KingSweetAlert(0, "گونه باید انتخاب شود.");
        return;
    }
    if (isEmptyKing($("#txtTitleEn").val())) {
        KingWarningStyle("#txtTitleEn", 0);
        KingSweetAlert(0, "نام انگلیسی فستیوال باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitleEn", 0);
    }
    if (isEmptyKing($("#txtTitleFa").val())) {
        KingWarningStyle("#txtTitleFa", 0);
        KingSweetAlert(0, "نام فارسی فستیوال باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitleFa", 0);
    }
    if ($("#selectCountry").val() == null) {
        KingSweetAlert(0, "کشور باید انتخاب شود.");
        return;
    }
    
    if (isEmptyKing($("#txtAddress").val())) {
        KingWarningStyle("#txtAddress", 0);
        KingSweetAlert(0, "آدرس را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtAddress", 0);
    }

    if (isEmptyKing($("#txtWebsite").val())) {
        KingWarningStyle("#txtWebsite", 0);
        KingSweetAlert(0, "وب سایت را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtWebsite", 0);
    }

    if (isEmptyKing($("#txtShamsiDate_Opening").val())) {
        KingWarningStyle("#txtShamsiDate_Opening", 0);
        KingSweetAlert(0, "تاریخ بازگشایی باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtShamsiDate_Opening", 0);
    }

    if (isEmptyKing($("#txtShamsiDate_Notification").val())) {
        KingWarningStyle("#txtShamsiDate_Notification", 0);
        KingSweetAlert(0, "تاریخ اعلان را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtShamsiDate_Notification", 0);
    }

    if (isEmptyKing($("#txtShamsiDate_EventStartDate").val())) {
        KingWarningStyle("#txtShamsiDate_EventStartDate", 0);
        KingSweetAlert(0, "تاریخ شروع افتتاحیه باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtShamsiDate_EventStartDate", 0);
    }

    if (isEmptyKing($("#txtShamsiDate_EventEndDate").val())) {
        KingWarningStyle("#txtShamsiDate_EventEndDate", 0);
        KingSweetAlert(0, "تاریخ پایان افتتاحیه باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtShamsiDate_EventEndDate", 0);
    }

    if ($("#selectPremiere").val() == null) {
        KingSweetAlert(0, "پریمیر باید انتخاب شود.");
        return;
    }
    if (isEmptyKing(editor_txtDetail.getData())) {
        KingWarningStyle("#txtDetail", 0);
        KingSweetAlert(0, "جزییات فستیوال را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtDetail", 0);
    }

    if (isEmptyKing(editor_txtAttributes.getData())) {
        KingWarningStyle("#txtAttributes", 0);
        KingSweetAlert(0, "مشخصات خاص را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtAttributes", 0);
    }

    if (isEmptyKing(editor_txtRules.getData())) {
        KingWarningStyle("#txtRules", 0);
        KingSweetAlert(0, "قوانین و مقررات را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtRules", 0);
    }
    if ($("#selectPlatform").val() == null) {
        KingSweetAlert(0, "پلتفرم باید انتخاب شود.");
        return;
    }
    if (isEmptyKing(editor_txtSubmitWay.getData())) {
        KingWarningStyle("#txtSubmitWay", 0);
        KingSweetAlert(0, "راه ثبت نام را باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSubmitWay", 0);
    }     
    
    var postData = new FormData();

    // file validationsa
    var fileControl = document.getElementById("fileLogo").files.length;
    if (fileControl != 0) {
        if (isEmptyKing($("#fileLogo").val())) {
            KingWarningStyle("#fileLogo", 0);
            KingSweetAlert(0, "لوگو را انتخاب کنید.");
            return;
        } else {
            KingWarningStyleOff("#fileLogo", 0);
        }

        var _file = $("#fileLogo")[0].files[0];
        var maxSize = "160600";
        if (!KingCheckSizeExtension(_file, ["jpg", "png", "bmp", "jpeg", "webp"],
            maxSize, true)) {
            return;
        }
        postData.append("Logo", _file);
    }
    
    const [shamsiYear_Opening, shamsiMonth_Opening, shamsiDay_Opening] = KingConvertPersianNumberToEnglishNumber($("#txtShamsiDate_Opening").val()).split('/').map(Number);
    const [shamsiYear_Notification, shamsiMonth_Notification, shamsiDay_Notification] = KingConvertPersianNumberToEnglishNumber($("#txtShamsiDate_Notification").val()).split('/').map(Number);
    const [shamsiYear_EventStartDate, shamsiMonth_EventStartDate, shamsiDay_EventStartDate] = KingConvertPersianNumberToEnglishNumber($("#txtShamsiDate_EventStartDate").val()).split('/').map(Number);
    const [shamsiYear_EventEndDate, shamsiMonth_EventEndDate, shamsiDay_EventEndDate] = KingConvertPersianNumberToEnglishNumber($("#txtShamsiDate_EventEndDate").val()).split('/').map(Number);


    postData.append("Id", festivalId);
    postData.append("TitleEn", $("#txtTitleEn").val());
    postData.append("TitleFa", $("#txtTitleFa").val());
    postData.append("Platform", $("#selectPlatform").val());
    postData.append("CountryCode", $("#selectCountry").val());
    postData.append("Premiere", $("#selectPremiere").val());
    postData.append("Detail", editor_txtDetail.getData());
    postData.append("Attribute", editor_txtAttributes.getData());
    postData.append("Rules", editor_txtRules.getData());
    postData.append("Submitway", editor_txtSubmitWay.getData());
    postData.append("Address", $("#txtAddress").val());
    postData.append("ShortFeature", $("#selectShortFeature").val());
    postData.append("Active", $("#chkActive").prop("checked"));
    postData.append("Level", $("#selectLevel").val());
    postData.append("Website", $("#txtWebsite").val());
    postData.append("Genres", getSelectedGenres()); // e.g. "2,3,6";
    
    postData.append("OpeningDate",
        `${farvardin.solarToGregorian(shamsiYear_Opening, shamsiMonth_Opening, shamsiDay_Opening).toString().replaceAll(',', '-')}`);

    postData.append("NotificationDate",
        `${farvardin.solarToGregorian(shamsiYear_Notification, shamsiMonth_Notification, shamsiDay_Notification).toString().replaceAll(',', '-')}`);

    postData.append("EventStartDate",
        `${farvardin.solarToGregorian(shamsiYear_EventStartDate, shamsiMonth_EventStartDate, shamsiDay_EventStartDate).toString().replaceAll(',', '-')}`);

    postData.append("EventEndDate",
        `${farvardin.solarToGregorian(shamsiYear_EventEndDate, shamsiMonth_EventEndDate, shamsiDay_EventEndDate).toString().replaceAll(',', '-')}`);
    
    $.ajax({
        contentType: false,
        processData: false,
        type: 'PUT',
        url: '/admin/UpdateFestival',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, "ویرایش فستیوال را با موفقیت انجام شد");
            }
            else {
                KingSweetAlert(0, data.message);
            }
        },
        error: function (e) {
            KingSweetAlert(0, e);
        }
    });

}

$("#btnShowHideMainImage").on("click", function () {
    if ($("#mainImgContent").prop("hidden"))
        $("#mainImgContent").prop("hidden", false);
    else
        $("#mainImgContent").prop("hidden", true);
})