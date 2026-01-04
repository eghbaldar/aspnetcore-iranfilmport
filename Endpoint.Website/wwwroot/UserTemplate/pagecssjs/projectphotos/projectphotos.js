var gallery = $('.gallery-masonry');
var category = '.item';
function filterIsotope(filter) {
	var filter = filter || '*';
	gallery.isotope({
		filter: filter,
	});
}

var lightbox = $('.gallery-masonry');
function lightboxFilter(filter) {
	var filter = filter || '*';
	lightbox.magnificPopup({
		delegate: filter + '>a',
		type: 'image',
		gallery: {
			enabled: true,
		}
	});
}

filterIsotope();
lightboxFilter();

gallery.imagesLoaded().progress(function () {
	filterIsotope();
});

$('[data-category]').on('click', function () {
	var category = $(this).data('category');
	filterIsotope(category);
	lightboxFilter(category);
});

// code
function sendPhoto() {

    if ($("#selectPhotoType").val() == null) {
        KingSweetAlert(0, "گونه باید انتخاب شود.");
        KingWarningStyle("#selectPhotoType", 0);
        return;
    } else {
        KingWarningStyleOff("#selectPhotoType", 0);
    }

    if (isEmptyKing($("#filePhoto").val())) {
        KingWarningStyle("#filePhoto", 0);
        KingSweetAlert(0, "تصویر را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#filePhoto", 0);
    }

    var file = $("#filePhoto")[0].files[0];
    var maxSize = "160600";

    if (!KingCheckSizeExtension(file, ["webp"], maxSize, true)) {
        return;
    }

    var formData = new FormData();
    formData.append("ProjectId", projectId);
    formData.append("Type", $("#selectPhotoType").val());
    formData.append("File", file);

    $.ajax({
        url: '/user/PostProjectPhoto',
        type: 'POST',
        data: formData,
        processData: false,   // REQUIRED
        contentType: false,   // REQUIRED
        dataType: 'json',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, 'تصویر ثبت و در اسرع زمان بررسی خواهد شد.');
                $("#userproject-content")
                    .load(`/user/projectphotos/${projectId} #userproject-content`);
            } else {
                KingSweetAlert(0, data.message);
            }
        },
        error: function (xhr) {
            KingSweetAlert(0, "خطا در ارسال تصویر");
            console.error(xhr.responseText);
        }
    });
}
