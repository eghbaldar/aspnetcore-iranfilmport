function addModal() {

    if (isEmptyKing($("#txtTitle").val())) {
        KingWarningStyle("#txtTitle", 0);
        KingSweetAlert(0, "عنوان فارسی وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitle", 0);
    }
    if (isEmptyKing($("#txtBlinkText").val())) {
        KingWarningStyle("#txtBlinkText", 0);
        KingSweetAlert(0, "متن چمشک زن وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtBlinkText", 0);
    }
    if (isEmptyKing($("#txtSubText1").val())) {
        KingWarningStyle("#txtSubText1", 0);
        KingSweetAlert(0, "زیر متن یک وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSubText1", 0);
    }
    if (isEmptyKing($("#txtLinkSubText1").val())) {
        KingWarningStyle("#txtLinkSubText1", 0);
        KingSweetAlert(0, "لینک زیر متن یک وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtLinkSubText1", 0);
    }
    if (isEmptyKing($("#txtSubText2").val())) {
        KingWarningStyle("#txtSubText2", 0);
        KingSweetAlert(0, "زیر متن دو وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSubText2", 0);
    }
    if (isEmptyKing($("#txtLinkSubText2").val())) {
        KingWarningStyle("#txtLinkSubText2", 0);
        KingSweetAlert(0, "لینک زیر متن دو وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtLinkSubText2", 0);
    }
    if (isEmptyKing($("#txtColor").val())) {
        KingWarningStyle("#txtColor", 0);
        KingSweetAlert(0, "رنگ وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtColor", 0);
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
    var maxSize = "200600";
    if (!KingCheckSizeExtension(_file, ["webp"],
        maxSize, true)) {
        return;
    }
    var postData = new FormData();

    postData.append("Title", DOMPurify.sanitize($("#txtTitle").val()));
    postData.append("BlinkText", DOMPurify.sanitize($("#txtBlinkText").val()));
    postData.append("SubText1", DOMPurify.sanitize($("#txtSubText1").val()));
    postData.append("LinkSubText1", DOMPurify.sanitize($("#txtLinkSubText1").val()));
    postData.append("SubText2", DOMPurify.sanitize($("#txtSubText2").val()));
    postData.append("LinkSubText2", DOMPurify.sanitize($("#txtLinkSubText2").val()));
    postData.append("Color", DOMPurify.sanitize($("#txtColor").val()));
    postData.append("Photo", _file);

    $.ajax({
        contentType: false,
        processData: false,
        type: 'POST',
        data: postData,
        url: '/admin/PostAdvModal',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAtCenter("", 'با موفقیت انجام شد.',"info");
                window.location = "/admin/AdvModals/";
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
function updateModal(id) {

    if (isEmptyKing($("#txtTitle").val())) {
        KingWarningStyle("#txtTitle", 0);
        KingSweetAlert(0, "عنوان فارسی وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitle", 0);
    }
    if (isEmptyKing($("#txtBlinkText").val())) {
        KingWarningStyle("#txtBlinkText", 0);
        KingSweetAlert(0, "متن چمشک زن وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtBlinkText", 0);
    }
    if (isEmptyKing($("#txtSubText1").val())) {
        KingWarningStyle("#txtSubText1", 0);
        KingSweetAlert(0, "زیر متن یک وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSubText1", 0);
    }
    if (isEmptyKing($("#txtLinkSubText1").val())) {
        KingWarningStyle("#txtLinkSubText1", 0);
        KingSweetAlert(0, "لینک زیر متن یک وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtLinkSubText1", 0);
    }
    if (isEmptyKing($("#txtSubText2").val())) {
        KingWarningStyle("#txtSubText2", 0);
        KingSweetAlert(0, "زیر متن دو وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSubText2", 0);
    }
    if (isEmptyKing($("#txtLinkSubText2").val())) {
        KingWarningStyle("#txtLinkSubText2", 0);
        KingSweetAlert(0, "لینک زیر متن دو وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtLinkSubText2", 0);
    }
    if (isEmptyKing($("#txtColor").val())) {
        KingWarningStyle("#txtColor", 0);
        KingSweetAlert(0, "رنگ وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtColor", 0);
    }


    var postData = new FormData();

    postData.append("Id", id);
    postData.append("Title", DOMPurify.sanitize($("#txtTitle").val()));
    postData.append("BlinkText", DOMPurify.sanitize($("#txtBlinkText").val()));
    postData.append("SubText1", DOMPurify.sanitize($("#txtSubText1").val()));
    postData.append("LinkSubText1", DOMPurify.sanitize($("#txtLinkSubText1").val()));
    postData.append("SubText2", DOMPurify.sanitize($("#txtSubText2").val()));
    postData.append("LinkSubText2", DOMPurify.sanitize($("#txtLinkSubText2").val()));
    postData.append("Color", DOMPurify.sanitize($("#txtColor").val()));


    // file validations
    if (!isEmptyKing($("#fileImage").val())) {
        var _file = $("#fileImage")[0].files[0];
        var maxSize = "200600";
        if (!KingCheckSizeExtension(_file, ["webp"],
            maxSize, true)) {
            return;
        }
        postData.append("Photo", _file);
    }

    $.ajax({
        contentType: false,
        processData: false,
        type: 'PUT',
        data: postData,
        url: '/admin/UpdateAdvModal',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, 'با موفقیت انجام شد.');
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
$("#btnShowHideMainImage").on("click", function () {
    if ($("#mainImgContent").prop("hidden"))
        $("#mainImgContent").prop("hidden", false);
    else
        $("#mainImgContent").prop("hidden", true);
})