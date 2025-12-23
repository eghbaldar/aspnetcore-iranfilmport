function deleteNews(id) {
    Swal.fire({
        title: "حذف خبر",
        text: "آیا از حذف این خبر مطمئن هستید؟",
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
                url: '/admin/DeleteNews',
                data: { Id: id },
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAlert(1, "با موفقیت حذف شد.");
                        $("#divNews").load("/admin/news #divNews");
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