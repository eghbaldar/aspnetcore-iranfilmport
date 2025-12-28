$(function () {
    $("#selectMainCat").change(function () {
        var postData = {
            ParentId: $("#selectMainCat").val()
        };
        $.ajax({
            contentType: 'application/json',
            dataType: 'json',
            type: 'GET',
            url: '/admin/GetNewsCategoriesBySubId',
            data: postData,
            success: function (data) {
                $("#selectChildCategory").empty();
                for (var i = 0; i <= data.result.length; i++) {
                    $("#selectChildCategory").append(new Option(data.result[i].title, data.result[i].id));
                }
            },
            error: function (e) {
                alert(JSON.stringify(e));
            }
        });
    });
});
function addNews() {
    var editor = CKEDITOR.instances['txtBodyText'];
    $("#txtSummary").text(DOMPurify.sanitize(editor.getData()));

    if ($("#selectChildCategory").val() == null) {
        KingSweetAlert(0, "دسته باید انتخاب شود.");
        return;
    }

    if (isEmptyKing($("#txtTitle").val())) {
        KingWarningStyle("#txtTitle", 0);
        KingSweetAlert(0, "عنوان خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitle", 0);
    }

    if (isEmptyKing($("#txtTitleEn").val())) {
        KingWarningStyle("#txtTitleEn", 0);
        KingSweetAlert(0, "عنوان انگلیسی خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitleEn", 0);
    }

    if (isEmptyKing($("#txtSummary").val())) {
        KingWarningStyle("#txtSummary", 0);
        KingSweetAlert(0, "خلاصه متن خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSummary", 0);
    }

    if (isEmptyKing(editor.getData())) {
        KingWarningStyle("#txtBodyText", 0);
        KingSweetAlert(0, "متن کامل خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtBodyText", 0);
    }

    // file validations
    if (isEmptyKing($("#fileImage").val())) {
        KingWarningStyle("#fileImage", 0);
        KingSweetAlert(0, "تصویر اصلی را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#fileImage", 0);
    }

    var _file = $("#fileImage")[0].files[0];
    var maxSize = "160600";
    if (!$("#chkAllowedOver150").prop("checked")) {
        if (!KingCheckSizeExtension(_file, ["webp"],
            maxSize, true)) {
            return;
        }
    }

    if (isEmptyKing($("#txtAuthor").val())) {
        KingWarningStyle("#txtAuthor", 0);
        KingSweetAlert(0, "نویسنده خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtAuthor", 0);
    }

    if (isEmptyKing($("#txtReference").val())) {
        KingWarningStyle("#txtReference", 0);
        KingSweetAlert(0, "منبع خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtReference", 0);
    }

    if (isEmptyKing($("#txtShamsiDate").val())) {
        KingWarningStyle("#txtShamsiDate", 0);
        KingSweetAlert(0, "تاریخ خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtShamsiDate", 0);
    }

    if (isEmptyKing($("#txtTimeHour").val())) {
        KingWarningStyle("#txtTimeHour", 0);
        KingSweetAlert(0, "ساعت انتشار خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTimeHour", 0);
    }

    if (isEmptyKing($("#txtTimeMinutes").val())) {
        KingWarningStyle("#txtTimeMinutes", 0);
        KingSweetAlert(0, "دقیقه انتشار خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTimeMinutes", 0);
    }


    var tags = [];
    $(".bootstrap-tagsinput").each(function () {
        $(this).children("span").each(function () {
            tags.push($(this).text());
        })
    });
    if (tags.length < 3) {
        KingSweetAlert(0, "حداقل تعداد تگ ها باید 3 عدد باشد.");
        return;
    }

    const [shamsiYear, shamsiMonth, shamsiDay] = $("#txtShamsiDate").val().split('/').map(Number);
    const time = `${$("#txtTimeHour").val()}:${$("#txtTimeMinutes").val()}`;


    var postData = new FormData();
    postData.append("Title", $("#txtTitle").val());
    postData.append("TitleEn", $("#txtTitleEn").val());
    postData.append("Summary", $("#txtSummary").val());
    postData.append("BodyText", editor.getData());
    postData.append("Author", $("#txtAuthor").val());
    postData.append("Reference", $("#txtReference").val());
    postData.append("Active", $("#chkActive").prop("checked"));
    postData.append("CategoryId", $("#selectChildCategory").val());
    postData.append("AllowedOver150", $("#chkAllowedOver150").prop("checked"));
    postData.append("Tags", tags.join(','));
    postData.append("FutureDateTime",
        `${farvardin.solarToGregorian(shamsiYear, shamsiMonth, shamsiDay).toString().replaceAll(',', '-')} ${time}`);

    postData.append("MainImage", _file);


    $.ajax({
        contentType: false,
        processData: false,
        type: 'POST',
        url: '/admin/PostNews',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlertCenterWithoutTimer("درج خبر با موفقیت انجام شد");
                window.location = "/admin/news";
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
function updateNews(newsId) {

    if ($("#selectChildCategory").val() == null) {
        KingSweetAlert(0, "دسته باید انتخاب شود.");
        return;
    }

    if (isEmptyKing($("#txtTitle").val())) {
        KingWarningStyle("#txtTitle", 0);
        KingSweetAlert(0, "عنوان خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitle", 0);
    }


    if (isEmptyKing($("#txtTitleEn").val())) {
        KingWarningStyle("#txtTitleEn", 0);
        KingSweetAlert(0, "عنوان انگلیسی خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitleEn", 0);
    }


    if (isEmptyKing($("#txtSummary").val())) {
        KingWarningStyle("#txtSummary", 0);
        KingSweetAlert(0, "خلاصه متن خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSummary", 0);
    }


    var editor = CKEDITOR.instances['txtBodyText'];
    if (isEmptyKing(editor.getData())) {
        KingWarningStyle("#txtBodyText", 0);
        KingSweetAlert(0, "متن کامل خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtBodyText", 0);
    }


    if (isEmptyKing($("#txtAuthor").val())) {
        KingWarningStyle("#txtAuthor", 0);
        KingSweetAlert(0, "نویسنده خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtAuthor", 0);
    }

    if (isEmptyKing($("#txtReference").val())) {
        KingWarningStyle("#txtReference", 0);
        KingSweetAlert(0, "منبع خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtReference", 0);
    }

    if (isEmptyKing($("#txtShamsiDate").val())) {
        KingWarningStyle("#txtShamsiDate", 0);
        KingSweetAlert(0, "تاریخ خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtShamsiDate", 0);
    }

    if (isEmptyKing($("#txtTimeHour").val())) {
        KingWarningStyle("#txtTimeHour", 0);
        KingSweetAlert(0, "ساعت انتشار خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTimeHour", 0);
    }

    if (isEmptyKing($("#txtTimeMinutes").val())) {
        KingWarningStyle("#txtTimeMinutes", 0);
        KingSweetAlert(0, "دقیقه انتشار خبر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTimeMinutes", 0);
    }

    var tags = [];
    $(".bootstrap-tagsinput").each(function () {
        $(this).children("span").each(function () {
            tags.push($(this).text());
        })
    });
    if (tags.length < 3) {
        KingSweetAlert(0, "حداقل تعداد تگ ها باید 3 عدد باشد.");
        return;
    }

    const [shamsiYear, shamsiMonth, shamsiDay] =
        KingConvertPersianNumberToEnglishNumber($("#txtShamsiDate").val()).split('/').map(Number);
    const time = `${$("#txtTimeHour").val()}:${$("#txtTimeMinutes").val()}`;

    var postData = new FormData();
    // file validationsa
    var fileControl = document.getElementById("fileImage").files.length;
    if (fileControl != 0) {
        if (isEmptyKing($("#fileImage").val())) {
            KingWarningStyle("#fileImage", 0);
            KingSweetAlert(0, "تصویر اصلی را انتخاب کنید.");
            return;
        } else {
            KingWarningStyleOff("#fileImage", 0);
        }

        var _file = $("#fileImage")[0].files[0];
        var maxSize = "160600";
        if (!$("#chkAllowedOver150").prop("checked")) {
            if (!KingCheckSizeExtension(_file, ["jpg", "png", "bmp", "jpeg", "webp"],
                maxSize, true)) {
                return;
            }
        }
        postData.append("MainImage", _file);
    }

    postData.append("Id", newsId);
    postData.append("Title", $("#txtTitle").val());
    postData.append("TitleEn", $("#txtTitleEn").val());
    postData.append("Summary", $("#txtSummary").val());
    postData.append("BodyText", editor.getData());
    postData.append("Author", $("#txtAuthor").val());
    postData.append("AllowedOver150", $("#chkAllowedOver150").prop("checked"));
    postData.append("Reference", $("#txtReference").val());
    postData.append("Active", $("#chkActive").prop("checked"));
    postData.append("CategoryId", $("#selectChildCategory").val());
    postData.append("Tags", tags.join(','));


    postData.append("FutureDateTime",
        `${farvardin.solarToGregorian(shamsiYear, shamsiMonth, shamsiDay).toString().replaceAll(',', '-')} ${time}`);


    $.ajax({
        contentType: false,
        processData: false,
        type: 'PUT',
        url: '/admin/UpdateNews',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, "ویرایش خبر با موفقیت انجام شد");
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

$("#txtTimeHour").on("change", function () {
    if (parseInt($("#txtTimeHour").val()) < 20) {
        KingSweetAtCenter("توجه مهم", "ساعت انتخاب شده خارج عرف تعیین شده از طرف مدیریت است. ساعات عرف، 20،21،22 و 23 می باشد. آیا مطمئن هستید؟", "info");
    }
})
