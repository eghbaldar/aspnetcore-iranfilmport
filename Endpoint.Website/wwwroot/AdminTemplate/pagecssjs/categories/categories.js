function addCategory() {
    if (isEmptyKing($("#txtTitle").val())) {
        KingWarningStyle("#txtTitle", 0);
        KingSweetAlert(0, "عنوان دسته باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitle", 0);
    }
    var postData = {
        Title: $("#txtTitle").val(),
        SubId: $("#selectCatParent").val()
    };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        url: '/admin/PostNewsCategory',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, "درج با موفقیت انجام شد.");
                $("#treeview").load("/admin/newscategories #treeview");
                $("#tbCat").load("/admin/newscategories #tbCat");
                $("#txtTitle").val("");
            }
            else {
                KingSweetAlert(0, "خطایی رخ داده است.");
            }
        },
        error: function (e) {
            KingSweetAlert(0, "خطایی رخ داده است.");
        }
    })
}
function deleteCategory(id) {
    Swal.fire({
        title: "حذف دسته",
        text: "آیا از حذف این دسته مطمئن هستید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "حذف",
        cancelButtonText: 'لغو',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: 'PUT',
                url: '/admin/DeleteNewsCategory',
                data: { Id: id },
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAlert(1, "با موفقیت حذف شد.");
                        $("#treeview").load("/admin/newscategories #treeview");
                        $("#tbCat").load("/admin/newscategories #tbCat");
                        $("#txtTitle").val("");
                    }
                    else {
                        KingSweetAlert(0, "خطایی رخ داده است.");
                    }
                },
                error: function (e) {
                    KingSweetAlert(0, "خطایی رخ داده است.");
                }
            })
        }
    });
}
function updateCategory(id, title) {
    Swal.fire({
        title: "ویرایش عنوان دسته",
        input: "text",
        inputValue: title,
        showCancelButton: true,
        inputValidator: (value) => {
            if (!value) {
                return "عنوان جدید الزامی است";
            } else {
                Swal.fire({
                    title: 'ویرایش',
                    text: 'مطمئن هستید؟',
                    icon: 'info',                    
                    showCancelButton: true,
                    confirmButtonColor: '#000222',
                    cancelButtonColor: '#000222',
                    confirmButtonText: 'بله,حتما.',
                    cancelButtonText: 'کنسل'
                }).then((result) => {
                    if (result.value) {
                        var postData = new FormData();
                        postData.append("Id", id);
                        postData.append("Title", value);
                        $.ajax({
                            contentType: false,
                            processData: false,
                            type: 'PUT',
                            data: postData,
                            url: '/admin/UpdateNewsCategory',
                            success: function (data) {
                                if (data.isSuccess) {
                                    KingSweetAlert(true, "انجام شد.");
                                    $("#treeview").load("/admin/newscategories #treeview");
                                    $("#tbCat").load("/admin/newscategories #tbCat");
                                    $("#txtTitle").val("");
                                }
                                else {
                                    KingSweetAlert(false, "خطا!");
                                }
                            },
                            error: function (e) {
                                KingSweetAlert(false, "خطا!");
                            }
                        });
                    }
                });
            }
        }
    });
}