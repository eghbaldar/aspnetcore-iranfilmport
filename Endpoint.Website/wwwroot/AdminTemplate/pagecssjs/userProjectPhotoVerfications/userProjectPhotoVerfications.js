function changestatus(id, status) {
	var postData = new FormData();
	postData.append("PhotoId", id);
	postData.append("Status", status);
	Swal.fire({
		title: 'تغییر وضعیت پروفایل!',
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
				url: '/admin/UpdateUserProjectPhoto',
				success: function (data) {
					if (data.isSuccess) {
						KingSweetAlert(1, 'با موفقیت انجام شد.');
						$("#tb").load("/admin/UserProjectPhotoVerfications #tb");
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