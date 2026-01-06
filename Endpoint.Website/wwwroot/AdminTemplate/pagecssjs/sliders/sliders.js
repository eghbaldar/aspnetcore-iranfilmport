function addSlider() {

    if (isEmptyKing($("#txtTitle").val())) {
        KingWarningStyle("#txtTitle", 0);
        KingSweetAlert(0, "عنوان فارسی وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitle", 0);
    }
    if (isEmptyKing($("#txtTitleEn").val())) {
        KingWarningStyle("#txtTitleEn", 0);
        KingSweetAlert(0, "عنوان انگلیسی وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitleEn", 0);
    }
    if (isEmptyKing($("#txtSubText").val())) {
        KingWarningStyle("#txtSubText", 0);
        KingSweetAlert(0, "زیر عنوان وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSubText", 0);
    }
    if (isEmptyKing($("#txtLink").val())) {
        KingWarningStyle("#txtLink", 0);
        KingSweetAlert(0, "لینک وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtLink", 0);
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

    postData.append("Text", DOMPurify.sanitize($("#txtTitle").val()));
    postData.append("TextEn", DOMPurify.sanitize($("#txtTitleEn").val()));
    postData.append("SubText", DOMPurify.sanitize($("#txtSubText").val()));
    postData.append("Link", DOMPurify.sanitize($("#txtLink").val()));
    postData.append("Active", $("#chkActive").prop("checked"));
    postData.append("File", _file);

    $.ajax({
        contentType: false,
        processData: false,
        type: 'POST',
        data: postData,
        url: '/admin/PostSlider',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, 'با موفقیت انجام شد.');
                $("#divSliders").load("/admin/sliders #divSliders");
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
function showDetail(id, text, textEn, subtext, link, active) {
    $("#ModalEditSlider").modal("show");
    $("#hiddenModalUserId").val(id);
    $("#edit_chkActive").prop("checked", active === true || active === "true");
    $("#edit_txtTitle").val(text);
    $("#edit_txtTitleEn").val(textEn);
    $("#edit_txtSubText").val(subtext);
    $("#edit_txtLink").val(link);
}
function updateSlider() {

    if (isEmptyKing($("#edit_txtTitle").val())) {
        KingWarningStyle("#edit_txtTitle", 0);
        KingSweetAlert(0, "عنوان فارسی وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#edit_txtTitle", 0);
    }
    if (isEmptyKing($("#edit_txtTitleEn").val())) {
        KingWarningStyle("#edit_txtTitleEn", 0);
        KingSweetAlert(0, "عنوان انگلیسی وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#edit_txtTitleEn", 0);
    }
    if (isEmptyKing($("#edit_txtSubText").val())) {
        KingWarningStyle("#edit_txtSubText", 0);
        KingSweetAlert(0, "زیر عنوان وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#edit_txtSubText", 0);
    }
    if (isEmptyKing($("#edit_txtLink").val())) {
        KingWarningStyle("#edit_txtLink", 0);
        KingSweetAlert(0, "لینک وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#edit_txtLink", 0);
    }


    var postData = new FormData();

    postData.append("Id", $("#hiddenModalUserId").val());
    postData.append("Text", $("#edit_txtTitle").val());
    postData.append("TextEn", $("#edit_txtTitleEn").val());
    postData.append("SubText", $("#edit_txtSubText").val());
    postData.append("Link", $("#edit_txtLink").val());
    postData.append("Active", $("#edit_chkActive").prop("checked"));


    // file validations
    if (!isEmptyKing($("#edit_fileImage").val())) {
        var _file = $("#edit_fileImage")[0].files[0];
        var maxSize = "200600";
        if (!KingCheckSizeExtension(_file, ["webp"],
            maxSize, true)) {
            return;
        }
        postData.append("File", _file);
    }

    $.ajax({
        contentType: false,
        processData: false,
        type: 'PUT',
        data: postData,
        url: '/admin/UpdateSlider',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, 'با موفقیت انجام شد.');
                $("#divSliders").load("/admin/sliders #divSliders");
                $("#ModalEditSlider").modal("hide");
                $("#hiddenSliderId").val("");
                $("#edit_chkActive").prop((active) ? 'checked' : '');
                $("#edit_txtTitle").val("");
                $("#edit_txtTitleEn").val("");
                $("#edit_txtSubText").val("");
                $("#edit_txtLink").val("");
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
function deleteSlider(id) {
    var postData = new FormData();
    postData.append("Id", id);
    Swal.fire({
        title: 'حذف!',
        text: 'مطمئن هستید؟',
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
                data: postData,
                url: '/Admin/DeleteSlider',
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAlert(1, 'با موفقیت انجام شد.');
                        $("#divSliders").load("/admin/sliders #divSliders");
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
    });

}