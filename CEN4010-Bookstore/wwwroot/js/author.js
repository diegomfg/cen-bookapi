var dataTable;

$(document).ready(function () {
    loadDataTable();
})


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/author/getall' },
        "columns": [
            { data: 'lastName', "width": "10%" },
            { data: 'firstName', "width": "10%" },
            { data: 'country', "width": "10%" },
            { data: 'publisher.name', "width": "10%" },
            { data: 'biography', "width": "40%" },
            { data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/author/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                        <a onClick=Delete('/admin/author/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete </a>
                    </div>`},
                "width": "20%"
            }
        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'Delete',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }

            })
        }
    })
}