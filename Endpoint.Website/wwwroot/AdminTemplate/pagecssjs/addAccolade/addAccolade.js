$(function () {       
    if (!isEmptyKing(filmId)) {
        $("#content").prop("hidden", false);
        $("#selectFilms").prop("disabled", true);
        $("#selectFilms").attr("style", "background-color:#ccc");
        $("#txtSearchFilm").prop("hidden", true);
    }
});
$("#selectFilms").on("change", function () {
    filmId = $(this).val();
    $("#content").prop("hidden", false);
});
function addAccolade() {

    var editorFa = CKEDITOR.instances['txtFa'];
    var editorEn = CKEDITOR.instances['txtEn'];
    $("#txtFa").text(DOMPurify.sanitize(editorFa.getData()));
    $("#txtEn").text(DOMPurify.sanitize(editorEn.getData()));

    if ($("#selectFilms").val() == null) {
        KingSweetAlert(0, "اثر باید انتخاب شود.");
        return;
    }
    if ($("#txtPriority").val() == 0) {
        KingWarningStyle("#txtPriority", 0);
        KingSweetAlert(0, "اولویت را بغیر از صفر تعیین کنید.");
        return;
    } else {
        KingWarningStyleOff("#txtPriority", 0);
    }

    if (isEmptyKing(editorFa.getData())) {
        KingWarningStyle("#txtFa", 0);
        KingSweetAlert(0, "افتخار فارسی پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtFa", 0);
    }

    if (isEmptyKing(editorEn.getData())) {
        KingWarningStyle("#txtEn", 0);
        KingSweetAlert(0, "افتخار انگلیسی پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtEn", 0);
    }

    var postData = new FormData();

    // file validations
    if (!isEmptyKing($("#fileImage").val())) {
        var _file = $("#fileImage")[0].files[0];
        var maxSize = "200600";
        if (!KingCheckSizeExtension(_file, ["webp"],
            maxSize, true)) {
            return;
        }
        postData.append("PosterFile", _file);
    }

    postData.append("FilmId", filmId);
    postData.append("AccoladeFa", editorFa.getData());
    postData.append("AccoladeEn", editorEn.getData());
    postData.append("Priority", DOMPurify.sanitize($("#txtPriority").val()));

    postData.append("ArtworkType", $("#selectArtworkType").val());
    postData.append("Director", DOMPurify.sanitize($("#txtDirector").val()));
    postData.append("TrailerLink", DOMPurify.sanitize($("#txtTrailer").val()));

    $.ajax({
        contentType: false,
        processData: false,
        type: 'POST',
        data: postData,
        url: '/admin/PostAccolade',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlertCenterWithoutTimer("درج افتخار با موفقیت انجام شد");
                window.location = "/admin/accolades";
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
function editAccolade() {

    var editorFa = CKEDITOR.instances['txtFa'];
    var editorEn = CKEDITOR.instances['txtEn'];
    $("#txtFa").text(DOMPurify.sanitize(editorFa.getData()));
    $("#txtEn").text(DOMPurify.sanitize(editorEn.getData()));

    if ($("#selectFilms").val() == null) {
        KingSweetAlert(0, "اثر باید انتخاب شود.");
        return;
    }
    if ($("#txtPriority").val() == 0) {
        KingWarningStyle("#txtPriority", 0);
        KingSweetAlert(0, "اولویت را بغیر از صفر تعیین کنید.");
        return;
    } else {
        KingWarningStyleOff("#txtPriority", 0);
    }

    if (isEmptyKing(editorFa.getData())) {
        KingWarningStyle("#txtFa", 0);
        KingSweetAlert(0, "افتخار فارسی پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtFa", 0);
    }

    if (isEmptyKing(editorEn.getData())) {
        KingWarningStyle("#txtEn", 0);
        KingSweetAlert(0, "افتخار انگلیسی پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtEn", 0);
    }

    var postData = new FormData();
    postData.append("FilmId", filmId);
    postData.append("AccoladeFa", editorFa.getData());
    postData.append("AccoladeEn", editorEn.getData());
    postData.append("Priority", DOMPurify.sanitize($("#txtPriority").val()));

    // file validations
    if (!isEmptyKing($("#fileImage").val())) {
        var _file = $("#fileImage")[0].files[0];
        var maxSize = "200600";
        if (!KingCheckSizeExtension(_file, ["webp"],
            maxSize, true)) {
            return;
        }
        postData.append("PosterFile", _file);
    }

    postData.append("ArtworkType", $("#selectArtworkType").val());
    postData.append("Director", DOMPurify.sanitize($("#txtDirector").val()));
    postData.append("TrailerLink", DOMPurify.sanitize($("#txtTrailer").val()));

    Swal.fire({
        title: 'ویرایش!',
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
                url: '/admin/UpdateAccolade',
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
    });

}

// dynamic search on <select>
document.addEventListener('DOMContentLoaded', function () {
    const selectFilms = document.getElementById('selectFilms');

    // Create a search input
    const searchInput = document.createElement('input');
    searchInput.id = 'txtSearchFilm';
    searchInput.type = 'text';
    searchInput.className = 'form-control search';
    searchInput.placeholder = 'جستجوی اثر ...';
    searchInput.style.marginBottom = '5px';

    // Insert search input before the select
    selectFilms.parentNode.insertBefore(searchInput, selectFilms);

    // Store original options
    const originalOptions = Array.from(selectFilms.options);

    // Filter function
    function filterOptions(searchTerm) {
        // Clear current options except the first disabled one
        while (selectFilms.options.length > 1) {
            selectFilms.remove(1);
        }

        if (!searchTerm) {
            // Restore all options
            originalOptions.forEach(option => {
                if (option.value) {
                    selectFilms.appendChild(option.cloneNode(true));
                }
            });
            return;
        }

        const term = searchTerm.toLowerCase();
        originalOptions.forEach(option => {
            if (option.textContent && option.textContent.toLowerCase().includes(term)) {
                selectFilms.appendChild(option.cloneNode(true));
            }
        });
    }

    // Add event listener for search
    searchInput.addEventListener('input', function () {
        filterOptions(this.value);
        if (isEmptyKing($("#selectFilms").val())) {
            $("#content").prop("hidden", true);
        }
        else {
            $("#content").prop("hidden", false);
        }
    });

    // Add event listener for key navigation
    searchInput.addEventListener('keydown', function (e) {
        if (e.key === 'ArrowDown') {
            e.preventDefault();
            selectFilms.focus();
            if (selectFilms.options.length > 1) {
                selectFilms.selectedIndex = 1;
            }
        }
    });
});
$("#btnShowHideMainImage").on("click", function () {
    if ($("#mainImgContent").prop("hidden"))
        $("#mainImgContent").prop("hidden", false);
    else
        $("#mainImgContent").prop("hidden", true);
})