async function reject(userId, status) {
    let result = await Swal.fire({
        title: 'رد کردن کارت ملی!',
        input: "text",
        inputLabel: "دلیل خود را بابت این ردی بنویسید:",
        showCancelButton: true,
        inputValidator: (value) => {
        }
    });
    if (!result.value || result.value == null) {
        KingSweetAlert(0, "دلیل قید شود.");
        return;
    } else {
        var postData = new FormData();
        postData.append("Status", status);
        postData.append("Message", result.value);
        postData.append("UserId", userId);
        $.ajax({
            contentType: false,
            processData: false,
            data: postData,
            type: 'PUT',
            url: '/admin/UpdateUserMeliCard',
            success: function (data) {
                if (data.isSuccess) {
                    KingSweetAlert(1, "با موفقیت ثبت شد.");
                    $("#tb").load("/admin/UserMeliCardVerifications #tb");
                }
                else {
                    KingSweetAlert(0, null);
                }
            },
            error: function (e) {
                KingSweetAlert(0, e);
            }
        });
    }
}
async function accept(userId, status) {
    let result = await swal.fire({
        title: 'تائید کارت ملی!',
        html: "آیا از تائید هویتی مطمئن هستید؟",
        icon: 'info',
        showCancelButton: true,
        confirmButtonColor: '#000222',
        cancelButtonColor: '#000222',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    });
    if (result.value) {

        var postData = new FormData();
        postData.append("Status", status);
        postData.append("UserId", userId);
        await $.ajax({
            contentType: false,
            processData: false,
            data: postData,
            type: 'PUT',
            url: '/admin/UpdateUserMeliCard',
            success: function (data) {
                if (data.isSuccess) {
                    KingSweetAlert(1, "با موفقیت ثبت شد.");
                    $("#tb").load("/admin/UserMeliCardVerifications #tb");
                }
                else {
                    KingSweetAlert(0, null);
                }
            },
            error: function (e) {
                KingSweetAlert(0, JSON.stringify(e));
            }
        })
    }
}