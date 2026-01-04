$("#selectType").on("change", function () {
    switch ($(this).val()) {
        case '1':
        case '2':
            $("#notselectedYet").prop("hidden", true);
            $("#film").prop("hidden", false);
            $("#script").prop("hidden", true);
            break;
        case '3':
            $("#notselectedYet").prop("hidden", true);
            $("#film").prop("hidden", true);
            $("#script").prop("hidden", false);
            break;
    }    
});
function addArtwork() {

    if (isEmptyKing($("#selectType").val())) {
        KingWarningStyle("#selectType", 0);
        KingSweetAlert(0, "گونه اثر را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#selectType", 0);
    }

    if (isEmptyKing($("#txtTitleFa").val())) {
        KingWarningStyle("#txtTitleFa", 0);
        KingSweetAlert(0, "نام اثر به فارسی باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitleFa", 0);
    }

    if (isEmptyKing($("#txtSynopsisFa").val())) {
        KingWarningStyle("#txtSynopsisFa", 0);
        KingSweetAlert(0, "خلاصه فارسی اثر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSynopsisFa", 0);
    }

    if (isEmptyKing($("#txtProductionDate").val())) {
        KingWarningStyle("#txtProductionDate", 0);
        KingSweetAlert(0, "تاریخ تولد اثر باید مشخص شود.");
        return;
    } else {
        KingWarningStyleOff("#txtProductionDate", 0);
    }

    var postData = new FormData();
    postData.append("Type", DOMPurify.sanitize($("#selectType").val()));
    postData.append("TitleFa", DOMPurify.sanitize($("#txtTitleFa").val()));
    postData.append("TitleEn", DOMPurify.sanitize($("#txtTitleEn").val()));

    postData.append("SynopsisFa", DOMPurify.sanitize($("#txtSynopsisFa").val()));
    postData.append("SynopsisEn", DOMPurify.sanitize($("#txtSynopsisEn").val()));
    postData.append("PageLink", DOMPurify.sanitize($("#txtPageLink").val()));
    postData.append("Director", DOMPurify.sanitize($("#txtDirectorFa").val()));
    postData.append("DirectorEn", DOMPurify.sanitize($("#txtDirectorEn").val()));
    postData.append("Writer", DOMPurify.sanitize($("#txtWriterFa").val()));
    postData.append("WriterEn", DOMPurify.sanitize($("#txtWriterEn").val()));
    postData.append("Producer", DOMPurify.sanitize($("#txtProducer").val()));
    postData.append("ProducerEn", DOMPurify.sanitize($("#txtProducerEn").val()));
    postData.append("Detail", DOMPurify.sanitize($("#txtDetail").val()));
    postData.append("DetailEn", DOMPurify.sanitize($("#txtDetailEn").val()));
    postData.append("ArtworkLink", DOMPurify.sanitize($("#txtArtworkLink").val()));
    postData.append("ArtworkPassword", DOMPurify.sanitize($("#txtArtworkPassword").val()));

    const [shamsiYear, shamsiMonth, shamsiDay] = $("#txtProductionDate").val().split('/').map(Number);
    postData.append("ProductionDate",
        `${farvardin.solarToGregorian(shamsiYear, shamsiMonth, shamsiDay).toString().replaceAll(',', '-')}`);
    $.ajax({
        contentType: false,
        processData: false,
        type: 'POST',
        url: '/user/PostProject',
        data: postData,
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlertCenterWithoutTimer("اطلاعات اثر شما با موفقیت ثبت شد");
                window.location = "/user/projects/";
            }
            else {
                KingSweetAlert(0, data.message);
            }
        },
        error: function (e) {
            KingSweetAlert(0, "خطایی رخ داده است.");
        }
    });
}
function editArtwork(id) {
    if (isEmptyKing($("#selectType").val())) {
        KingWarningStyle("#selectType", 0);
        KingSweetAlert(0, "گونه اثر را انتخاب کنید.");
        return;
    } else {
        KingWarningStyleOff("#selectType", 0);
    }

    if (isEmptyKing($("#txtTitleFa").val())) {
        KingWarningStyle("#txtTitleFa", 0);
        KingSweetAlert(0, "نام اثر به فارسی باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtTitleFa", 0);
    }

    if (isEmptyKing($("#txtSynopsisFa").val())) {
        KingWarningStyle("#txtSynopsisFa", 0);
        KingSweetAlert(0, "خلاصه فارسی اثر باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSynopsisFa", 0);
    }

    if (isEmptyKing($("#txtProductionDate").val())) {
        KingWarningStyle("#txtProductionDate", 0);
        KingSweetAlert(0, "تاریخ تولد اثر باید مشخص شود.");
        return;
    } else {
        KingWarningStyleOff("#txtProductionDate", 0);
    }

    var postData = new FormData();
    postData.append("Id", id);
    postData.append("Type", DOMPurify.sanitize($("#selectType").val()));
    postData.append("TitleFa", DOMPurify.sanitize($("#txtTitleFa").val()));
    postData.append("TitleEn", DOMPurify.sanitize($("#txtTitleEn").val()));

    postData.append("SynopsisFa", DOMPurify.sanitize($("#txtSynopsisFa").val()));
    postData.append("SynopsisEn", DOMPurify.sanitize($("#txtSynopsisEn").val()));
    postData.append("PageLink", DOMPurify.sanitize($("#txtPageLink").val()));
    postData.append("Director", DOMPurify.sanitize($("#txtDirectorFa").val()));
    postData.append("DirectorEn", DOMPurify.sanitize($("#txtDirectorEn").val()));
    postData.append("Writer", DOMPurify.sanitize($("#txtWriterFa").val()));
    postData.append("WriterEn", DOMPurify.sanitize($("#txtWriterEn").val()));
    postData.append("Producer", DOMPurify.sanitize($("#txtProducer").val()));
    postData.append("ProducerEn", DOMPurify.sanitize($("#txtProducerEn").val()));
    postData.append("Detail", DOMPurify.sanitize($("#txtDetail").val()));
    postData.append("DetailEn", DOMPurify.sanitize($("#txtDetailEn").val()));
    postData.append("ArtworkLink", DOMPurify.sanitize($("#txtArtworkLink").val()));
    postData.append("ArtworkPassword", DOMPurify.sanitize($("#txtArtworkPassword").val()));

    const [shamsiYear, shamsiMonth, shamsiDay] =
        KingConvertPersianNumberToEnglishNumber($("#txtProductionDate").val()).split('/').map(Number);
    postData.append("ProductionDate",
        `${farvardin.solarToGregorian(shamsiYear, shamsiMonth, shamsiDay).toString().replaceAll(',', '-')}`);

    Swal.fire({
        title: 'توجه!',
        text: 'پس از هر بروزرسانی،صفحه اثر شما تا تائید موقتا غیر فعال خواهد شد، مطمئن هستید؟',
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
                url: '/user/UpdateProject',
                data: postData,
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAtCenter("", "اطلاعات اثر شما با موفقیت بروز شد.", "success");
                    }
                    else {
                        KingSweetAlert(0, data.message);
                    }
                },
                error: function (e) {
                    KingSweetAlert(0, "خطایی رخ داده است.");
                }
            });
        }
    });

}