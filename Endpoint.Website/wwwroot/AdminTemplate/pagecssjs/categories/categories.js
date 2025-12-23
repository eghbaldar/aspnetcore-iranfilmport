function add() {
    if (isEmptyKing($("#txtCat").val())) {
        KingWarningStyle("#txtCat", 0);
        KingSweetAlert(0, "عنوان دسته باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtCat", 0);
    }
    var postData = {
        Title: $("#txtCat").val(),
        SubId: $("#selectParentId").val() 
    };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        url: '/admin/PostAddCategoryNews',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, "درج با موفقیت انجام شد.");
                $("#treeview").load("/admin/newscategories #treeview");
                $("#mainContent").load("/admin/newscategories #mainContent");                $("#txtCat").val("");
            }
            else {
                KingSweetAlert(0, "خطایی رخ داده است.");
            }
        },
        error: function (e) {
            alert(e);
        }
    })
}
function deleteCat(id) {
    Swal.fire({
        title: "حذف دسته",
        text: "آیا از حذف این دسته مطمئن هستید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "حذف",
        cancelButtonText:'لغو',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: 'PUT',
                url: '/admin/DeleteAddCategoryNews',
                data: { Id: id },
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAlert(1, "با موفقیت حذف شد.");
                        $("#treeview").load("/admin/newscategories #treeview");
                        $("#mainContent").load("/admin/newscategories #mainContent");
                    }
                    else {
                        KingSweetAlert(0, "خطایی رخ داده است.");
                    }
                },
                error: function (e) {
                    alert(e);
                }
            })
        }
    });
}
function showUpdationModal(id, title) {
    $("#updationCategory").modal("show");
    $("#idUpdationCategory").val(id);
    $("#txtUpdationCat").val(title);
}
function updateCat() {

    if (isEmptyKing($("#txtUpdationCat").val())) {
        KingWarningStyle("#txtUpdationCat", 0);
        KingSweetAlert(0, "عنوان دسته باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtUpdationCat", 0);
    }
    var postData = {
        Title: $("#txtUpdationCat").val(),
        Id: $("#idUpdationCategory").val()
    };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'PUT',
        url: '/admin/UpdateCategoryNews',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, "بروزرسانی با موفقیت انجام شد.");
                $("#treeview").load("/admin/newscategories #treeview");
                $("#mainContent").load("/admin/newscategories #mainContent");                $("#txtUpdationCat").val("");
                $("#updationCategory").modal("hide");
            }
            else {
                KingSweetAlert(0, "خطایی رخ داده است.");
            }
        },
        error: function (e) {
            alert(e);
        }
    })
}