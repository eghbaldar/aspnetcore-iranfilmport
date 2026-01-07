function done(id) {
	var postData = new FormData();
	postData.append("Id", id);
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
				url: '/admin/UpdateJobRequest',
				success: function (data) {
					if (data.isSuccess) {
						KingSweetAlert(1, 'با موفقیت انجام شد.');
						$("#divJob").load("/admin/JobRequests #divJob");
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
function showResume(element) {
	// Get the 'data-bio' attribute content
	var value = element.getAttribute('data-resume');

	// If there are newlines, replace them with <br />
	var formattedValue = value.replace(/\n/g, '<br />');

	// Show the formatted content in SweetAlert
	Swal.fire({
		html: formattedValue,  // This renders the HTML content with <br /> line breaks
		confirmButtonText: 'بررسی شد'
	});
} 