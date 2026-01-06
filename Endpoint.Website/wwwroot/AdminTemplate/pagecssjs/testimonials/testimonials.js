function addTestimonial() {

    if (isEmptyKing($("#txtName").val())) {
        KingWarningStyle("#txtName", 0);
        KingSweetAlert(0, "نام هنرمند وارد شود.");
        return;
    } else {
        KingWarningStyleOff("#txtName", 0);
    }
    
    // file validations
    if (isEmptyKing($("#fileImageAudio").val())) {
        KingWarningStyle("#fileImageAudio", 0);
        KingSweetAlert(0, "فایل اصلی را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#fileImageAudio", 0);
    }

    var _file = $("#fileImageAudio")[0].files[0];
    var maxSize = "500600";
    if (!KingCheckSizeExtension(_file, ["webp","ogg"],
        maxSize, true)) {
        return;
    }
    var postData = new FormData();

    postData.append("Name", DOMPurify.sanitize($("#txtName").val()));
    postData.append("Type", $("#chkType").prop("checked"));
    postData.append("File", _file);

    $.ajax({
        contentType: false,
        processData: false,
        type: 'POST',
        data: postData,
        url: '/admin/PostTestimonial',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, 'با موفقیت انجام شد.');
                $("#divTestimonials").load("/admin/testimonials #divTestimonials");
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
function deleteTestimonial(id) {
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
                url: '/Admin/DeleteTestimonial',
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAlert(1, 'با موفقیت انجام شد.');
                        $("#divTestimonials").load("/admin/testimonials #divTestimonials");
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