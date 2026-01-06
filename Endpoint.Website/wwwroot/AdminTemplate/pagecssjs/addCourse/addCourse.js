function addCourse() {

    if (isEmptyKing($("#txtTitle").val())) {
        KingWarningStyle("#txtTitle", 0);
        KingSweetAlert(0, "عنوان دوره وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitle", 0);
    }
    if (isEmptyKing($("#txtTeacher").val())) {
        KingWarningStyle("#txtTeacher", 0);
        KingSweetAlert(0, "عنوان مدرس وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTeacher", 0);
    }

    var editor = CKEDITOR.instances['txtBodyText'];
    $("#txtBodyText").text(DOMPurify.sanitize(editor.getData()));
    if (isEmptyKing(editor.getData())) {
        KingWarningStyle("#txtBodyText", 0);
        KingSweetAlert(0, "توضیحات دوره باید پر شود.");
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

    var _fileImage = $("#fileImage")[0].files[0];
    var maxSize = "200600";
    if (!KingCheckSizeExtension(_fileImage, ["webp"],
        maxSize, true)) {
        return;
    }


    // file validations
    if (isEmptyKing($("#fileTeacher").val())) {
        KingWarningStyle("#fileTeacher", 0);
        KingSweetAlert(0, "تصویر کدرس را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#fileTeacher", 0);
    }

    var _fileTeacher = $("#fileTeacher")[0].files[0];
    var maxSize = "200600";
    if (!KingCheckSizeExtension(_fileTeacher, ["webp"],
        maxSize, true)) {
        return;
    }


    var postData = new FormData();

    postData.append("Title", DOMPurify.sanitize($("#txtTitle").val()));
    postData.append("Teacher", DOMPurify.sanitize($("#txtTeacher").val()));
    postData.append("Detail", editor.getData());
    postData.append("Image", _fileImage);
    postData.append("TeacherHeadshot", _fileTeacher);

    $.ajax({
        contentType: false,
        processData: false,
        type: 'POST',
        data: postData,
        url: '/admin/PostCourse',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, 'با موفقیت انجام شد.');
                window.location = "/admin/courses";
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
function updateCourse(id) {

    var postData = new FormData();

    if (isEmptyKing($("#txtTitle").val())) {
        KingWarningStyle("#txtTitle", 0);
        KingSweetAlert(0, "عنوان دوره وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitle", 0);
    }
    if (isEmptyKing($("#txtTeacher").val())) {
        KingWarningStyle("#txtTeacher", 0);
        KingSweetAlert(0, "عنوان مدرس وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTeacher", 0);
    }

    var editor = CKEDITOR.instances['txtBodyText'];

    if (isEmptyKing(editor.getData())) {
        KingWarningStyle("#txtBodyText", 0);
        KingSweetAlert(0, "توضیحات دوره باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtBodyText", 0);
    }

    if (!isEmptyKing($("#fileImage").val())) {
        if (isEmptyKing($("#fileImage").val())) {
            KingWarningStyle("#fileImage", 0);
            KingSweetAlert(0, "تصویر اصلی را انتخاب کنید.");
            return;
        } else {
            KingWarningStyleOff("#fileImage", 0);
        }

        var _fileImage = $("#fileImage")[0].files[0];
        var maxSize = "200600";
        if (!KingCheckSizeExtension(_fileImage, ["webp"],
            maxSize, true)) {
            return;
        }
        postData.append("Image", _fileImage);
    }
    if (!isEmptyKing($("#fileTeacher").val())) {
        // file validations
        if (isEmptyKing($("#fileTeacher").val())) {
            KingWarningStyle("#fileTeacher", 0);
            KingSweetAlert(0, "تصویر کدرس را انتخاب کنید.");
            return;
        } else {
            KingWarningStyleOff("#fileTeacher", 0);
        }

        var _fileTeacher = $("#fileTeacher")[0].files[0];
        var maxSize = "200600";
        if (!KingCheckSizeExtension(_fileTeacher, ["webp"],
            maxSize, true)) {
            return;
        }
        postData.append("TeacherHeadshot", _fileTeacher);
    }

    postData.append("Id", id);
    postData.append("Title", DOMPurify.sanitize($("#txtTitle").val()));
    postData.append("Teacher", DOMPurify.sanitize($("#txtTeacher").val()));
    postData.append("Detail", editor.getData());

    $.ajax({
        contentType: false,
        processData: false,
        type: 'PUT',
        data: postData,
        url: '/admin/UpdateCourse',
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