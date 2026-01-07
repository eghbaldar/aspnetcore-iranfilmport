function active(id) {
	var postData = new FormData();
	postData.append("Id", id);
	Swal.fire({
		title: 'فعال سازی این مودال!',
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
				url: '/admin/UpdateActiveAdvModal',
				success: function (data) {
					if (data.isSuccess) {
						KingSweetAlert(1, 'با موفقیت انجام شد.');
						$("#divAdvs").load("/admin/advModals #divAdvs");
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