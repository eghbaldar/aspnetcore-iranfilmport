function updatePage(selector) {

	var postData = new FormData();
	var editor = CKEDITOR.instances['txtFa'];
	if (isEmptyKing(editor.getData())) {
		KingWarningStyle("#txtFa", 0);
		KingSweetAlert(0, "متن فارسی باید پر شود.");
		return;
	} else {
		KingWarningStyleOff("#txtFa", 0);
	}

	const element = document.getElementById('txtEn');
	if (element) {
		var editorEn = CKEDITOR.instances['txtEn'];
		if (isEmptyKing(editorEn.getData())) {
			KingWarningStyle("#txtEn", 0);
			KingSweetAlert(0, "متن انگلیسی باید پر شود.");
			return;
		} else {
			KingWarningStyleOff("#txtEn", 0);
		}
		postData.append("ValueEn", editorEn.getData());
	}
	postData.append("Selector", selector);
	postData.append("Value", editor.getData());

	Swal.fire({
		title: 'تغییر!',
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
				url: '/admin/UpdatePage',
				success: function (data) {
					if (data.isSuccess) {
						KingSweetAlert(1, 'با موفقیت انجام شد.');
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