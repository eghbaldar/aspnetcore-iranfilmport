function done(id) {
	var postData = new FormData();
	postData.append("Id",id);
	postData.append("Status", _done);
	Swal.fire({
		title: 'وضعیت!',
		text: 'آیا از تغییر وضعیت به بررسی شده مطمئن هستید؟',
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
				url: '/admin/UpdateSendInformation',
				success: function (data) {
					if (data.isSuccess) {
						KingSweetAlert(1, 'با موفقیت انجام شد.');
						$("#divSendInformation").load("/admin/sendInformation #divSendInformation");
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