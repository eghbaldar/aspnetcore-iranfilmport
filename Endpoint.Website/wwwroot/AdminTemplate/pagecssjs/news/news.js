function NewsByFilter(filter) {    
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'GET',
        data: { 'Filter': filter, 'CurrentPage': 1 },
        url: '/admin/NewsByFilter',
        success: function (data) {
            $("#tbNews").empty();
            for (var i = 0; i <= data.result.length - 1; i++) {
                $("#tbNews").append(newsBox(data.result[i]));
            }
        },
        error: function (e) {
            KingSweetAlert(false, JSON.stringify(e));
        }
    });
}
var newsBox = function (o) {

    var title = (o.title == null) ? '' : o.title;
    var categoryName = (o.categoryName == null) ? '' : o.categoryName;

    var visit = (o.visit == null) ? '' : o.visit;
    var active = (o.active == null) ? '' : o.active;
    var uniqueCode = (o.uniqueCode == null) ? '' : o.uniqueCode;
    var futureDateTime = kingConvertMildaToShamsiDate(o.futureDateTime);
    var insertDate = kingConvertMildaToShamsiDate(o.insertDate);

    var _active = '';
    if (active)
        _active = `<input type="checkbox" disabled checked />`;
    else
        _active = `<input type="checkbox" disabled />`;

    var _status = '';
    if (o.futureDateTime != null &&
        new Date(o.futureDateTime).setHours(0, 0, 0, 0) > new Date().setHours(0, 0, 0, 0)) {
        _status = `<span class="badge badge-warning">در آینده</span>`;
    } else {
        _status = `<span class="badge badge-success">منتشر شده</span>`;
    }
    return `
    <tr>
        <td>
            ${_active}
            <a target="_blank" href="/admin/addnews/${uniqueCode}">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-box-arrow-up-right" viewBox="0 0 16 16">
                    <path fill-rule="evenodd" d="M8.636 3.5a.5.5 0 0 0-.5-.5H1.5A1.5 1.5 0 0 0 0 4.5v10A1.5 1.5 0 0 0 1.5 16h10a1.5 1.5 0 0 0 1.5-1.5V7.864a.5.5 0 0 0-1 0V14.5a.5.5 0 0 1-.5.5h-10a.5.5 0 0 1-.5-.5v-10a.5.5 0 0 1 .5-.5h6.636a.5.5 0 0 0 .5-.5" />
                    <path fill-rule="evenodd" d="M16 .5a.5.5 0 0 0-.5-.5h-5a.5.5 0 0 0 0 1h3.793L6.146 9.146a.5.5 0 1 0 .708.708L15 1.707V5.5a.5.5 0 0 0 1 0z" />
                </svg>
            </a>
            <a href='/admin/addnews/${uniqueCode}'>
            ${title}
            </a>
        </td>
        <td>${categoryName}</td>
        <td>${visit}</td>
        <td>${_status}</td>
        <td>${insertDate }</td>
        <td>
            <div class="dropdown float-right">
                <a href="#" class="dropdown-toggle arrow-none card-drop" data-toggle="dropdown" aria-expanded="false">
                    <i class="mdi mdi-dots-vertical"></i>
                </a>
                <div class="dropdown-menu dropdown-menu-right">
                    <a href="/admin/addnews/${uniqueCode}" class="dropdown-item">ویرایش</a>
                    <a href="/${uniqueCode}" target="_blank" class="dropdown-item">مشاهده</a>
                    <a onclick="deleteNews('${o.id}')" class="dropdown-item">حذف</a>
                </div>
            </div>
        </td>
    </tr>
                    `
}
function deleteNews(id) {
    Swal.fire({
        title: "حذف خبر",
        text: "آیا از حذف این خبر مطمئن هستید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "حذف",
        cancelButtonText: 'لغو',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: 'PUT',
                url: '/admin/DeleteNews',
                data: { Id: id },
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAlert(1, "با موفقیت حذف شد.");
                        switch (_filter) {
                            case statusAll:
                                $("#divNews").load("/admin/news #divNews");
                                break;
                            case statusPublished:
                                $("#divNews").load("/admin/NewsByFilterOnlyPublished #divNews");
                                break;
                            case statusFuture:
                                $("#divNews").load("/admin/NewsByFilterOnlyFuture #divNews");
                                break;
                        }                                                                        
                    }
                    else {
                        KingSweetAlert(0, "خطایی رخ داده است.");
                    }
                },
                error: function (e) {
                    alert(e);
                }
            })
        }
    });
}