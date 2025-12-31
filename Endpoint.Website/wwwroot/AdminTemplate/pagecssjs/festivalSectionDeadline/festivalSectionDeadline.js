function addSection() {

    if (isEmptyKing($("#txtSection").val())) {
        KingWarningStyle("#txtSection", 0);
        KingSweetAlert(0, "بخش باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtSection", 0);
    }


    var postData = {
        'Title': DOMPurify.sanitize($("#txtSection").val()),
        'FestivalId': _festivalId,
    };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: '/admin/PostFestivalSection',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, 'با موفقیت انجام شد.');
                $("#div_sections").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_sections`);
                $("#div_deadlines").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_deadlines`);
                $("#txtSection").val("");
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
function updateSection(id, preTitle) {
    Swal.fire({
        title: "ویرایش بخش",
        input: "text",
        showCancelButton: true,
        inputValue: preTitle,
        inputValidator: (value) => {
            if (!value) {
                return "بخش الزامی است";
            } else {
                Swal.fire({
                    title: 'ویرایش',
                    text: 'مطمئن هستید؟',
                    icon: 'info',
                    showCancelButton: true,
                    confirmButtonColor: '#000222',
                    cancelButtonColor: '#000222',
                    confirmButtonText: 'بله,حتما.',
                    cancelButtonText: 'کنسل',
                }).then((result) => {
                    if (result.value) {
                        var postData = new FormData();
                        postData.append("Id", id);
                        postData.append("Title", value);
                        $.ajax({
                            contentType: false,
                            processData: false,
                            type: 'PUT',
                            data: postData,
                            url: '/admin/UpdateFestivalSection',
                            success: function (data) {
                                if (data.isSuccess) {
                                    KingSweetAlert(true, "انجام شد.");
                                    $("#div_sections").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_sections`);
                                    $("#div_deadlines").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_deadlines`);
                                }
                                else {
                                    KingSweetAlert(false, "خطا!");
                                }
                            },
                            error: function (e) {
                                KingSweetAlert(false, "خطا!");
                            }
                        });
                    }
                });
            }
        }
    });
}
function deleteSection(id) {
    Swal.fire({
        title: 'حذف',
        text: 'آیا از حذف این بخش مطمن هستید؟',
        icon: 'info',
        showCancelButton: true,
        confirmButtonColor: '#000222',
        cancelButtonColor: '#000222',
        confirmButtonText: 'بله، قطعا.',
        cancelButtonText: 'کنسل'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: 'PUT',
                data: { 'Id': id },
                url: '/admin/DeleteFestivalSection/',
                success: function (data) {
                    if (data.isSuccess) {
                        $("#div_sections").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_sections`);
                        $("#div_deadlines").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_deadlines`);
                        KingSweetAlert(true, "انجام شد.");
                    }
                    else
                        KingSweetAlert(false, data.message);
                },
                error: function (e) {
                    alert(e);
                }
            });
        }
    });
}
function addDeadline() {
    if ($("#selectSecion").val() == null) {
        KingWarningStyle("#selectSecion", 0);
        KingSweetAlert(0, "بخش را انتخاب کنید..");
        return;
    } else {
        KingWarningStyleOff("#selectSecion", 0);
    }

    if (isEmptyKing($("#txtDeadline").val())) {
        KingWarningStyle("#txtDeadline", 0);
        KingSweetAlert(0, "ددلاین باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtDeadline", 0);
    }

    if (isEmptyKing($("#txtFee").val())) {
        KingWarningStyle("#txtFee", 0);
        KingSweetAlert(0, "مقدار ورودی باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtFee", 0);
    }


    var postData = {
        'FestivalSectionId': $("#selectSecion").val(),
        'Deadline': DOMPurify.sanitize($("#txtDeadline").val()),
        'Fee': DOMPurify.sanitize($("#txtFee").val()),
    };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: '/admin/PostFestivalDeadline',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(1, 'با موفقیت انجام شد.');
                $("#div_deadlines").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_deadlines`);
                $("#txtFee").val("");
                $("#txtDeadline").val("0");
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
function showModalDeadline(id, deadline, fee) {    
    $("#txtUpdateFee").val(fee);

    // get and convert the date
    var deadline = new Date(deadline); 
    var year = deadline.getFullYear();
    var month = ('0' + (deadline.getMonth() + 1)).slice(-2); 
    var day = ('0' + deadline.getDate()).slice(-2);
    var formattedDate = `${year}-${month}-${day}`;

    // Set the value of the date input
    $("#txtUpdateDeadline").val(formattedDate);
    $("#updateHiddenDeadlineId").val(id)
    $("#ModalDeadline").modal("show");
}
function updateDeadline() {

    if (isEmptyKing($("#txtUpdateDeadline").val())) {
        KingWarningStyle("#txtUpdateDeadline", 0);
        KingSweetAlert(0, "ددلاین باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtUpdateDeadline", 0);
    }

    if (isEmptyKing($("#txtUpdateFee").val())) {
        KingWarningStyle("#txtUpdateFee", 0);
        KingSweetAlert(0, "مقدار ورودی باید پر شود.");
        return;
    } else {
        KingWarningStyleOff("#txtUpdateFee", 0);
    }

    var postData = new FormData();
    postData.append("Id", $("#updateHiddenDeadlineId").val());
    postData.append("Deadline", $("#txtUpdateDeadline").val());
    postData.append("Fee", $("#txtUpdateFee").val());
    $.ajax({
        contentType: false,
        processData: false,
        type: 'PUT',
        data: postData,
        url: '/admin/UpdateFestivalDeadline',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(true, "انجام شد.");
                $("#div_sections").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_sections`);
                $("#div_deadlines").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_deadlines`);
                $("#ModalDeadline").modal("hide");
                $("#updateHiddenDeadlineId").val(null);
                $("#txtUpdateFee").val("");
                $("#txtUpdateDeadline").val("");
            }
            else {
                KingSweetAlert(false, "خطا!");
            }
        },
        error: function (e) {
            KingSweetAlert(false, "خطا!");
        }
    });
    //txtUpdateDeadline
    //txtUpdateFee
}
function deleteDeadline(id) {
    Swal.fire({
        title: 'حذف',
        text: 'آیا از حذف این ددلاین مطمن هستید؟',
        icon: 'info',
        showCancelButton: true,
        confirmButtonColor: '#000222',
        cancelButtonColor: '#000222',
        confirmButtonText: 'بله، قطعا.',
        cancelButtonText: 'کنسل'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: 'PUT',
                data: { 'Id': id },
                url: '/admin/DeleteFestivalDeadline/',
                success: function (data) {
                    if (data.isSuccess) {
                        $("#div_sections").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_sections`);
                        $("#div_deadlines").load(`/admin/FestivalSectionDeadline/${_uniqueCode} #div_deadlines`);
                        KingSweetAlert(true, "انجام شد.");
                    }
                    else
                        KingSweetAlert(false, data.message);
                },
                error: function (e) {
                    alert(e);
                }
            });
        }
    });
}