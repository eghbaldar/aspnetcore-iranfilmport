function showContact(id,msg) {
    var postData = new FormData();
    postData.append("Id", id);
    postData.append("Status", true);
    $.ajax({
        contentType: false,
        processData: false,
        type: 'PUT',
        data: postData,
        url: '/user/UpdateContactStatus',
        success: function (data) {
            if (data.isSuccess) {
                {
                    KingSweetAtCenter("", msg, "info");
                }
            }
        },
        error: function (e) {
            KingSweetAlert(0, null);
        }
    });
}