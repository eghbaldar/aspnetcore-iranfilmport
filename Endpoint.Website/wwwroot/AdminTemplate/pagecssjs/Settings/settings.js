function updateSettings() {
	var postData = new FormData();
	postData.append("DollarToRial", DOMPurify.sanitize($("#txtDollarToRial").val()));
	postData.append("ComissionForFee", DOMPurify.sanitize($("#txtComissionForFee").val()));
	postData.append("CommissionForFree", DOMPurify.sanitize($("#txtCommissionForFree").val()));
	postData.append("Version", DOMPurify.sanitize($("#txtVersion").val()));
	postData.append("ApkStuff", DOMPurify.sanitize($("#txtApkStuff").val()));
	postData.append("ApkClient", DOMPurify.sanitize($("#txtApkClient").val()));
	postData.append("WinApp", DOMPurify.sanitize($("#txtWinApp").val()));
	postData.append("Marquee", DOMPurify.sanitize($("#txtMarquee").val()));
	postData.append("ModalOnAllPage", $("#chkModalOnAllPage").prop("checked"));
	$.ajax({
		contentType: false,
		processData: false,
		type: 'PUT',
		data: postData,
		url: '/admin/UpdateSettings',
		success: function (data) {
			if (data.isSuccess) {
				$("#endAgreementFile").modal("hide");
				KingSweetAlert(1, 'با موفقیت انجام شد.');
				$("#maintable").load("/user/RequestSelling #maintable");
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