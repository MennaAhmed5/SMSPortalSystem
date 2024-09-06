﻿var dtble;

$(document).ready(function () {
    loadData();
});

function loadData() {
    dtble = $("#myTable").DataTable({
        "ajax": {
            "url": "/MessageTemplete/GetData"
        },
        "columns": [
            { "data": "name" },
            { "data": "content" },            
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <a href="/MessageTemplete/Edit/${data}" class="btn btn-success">Edit</a>
                        <a onClick=DeleteItem("/MessageTemplete/Delete/${data}") class="btn btn-danger">Delete</a>
                    `;
                }
            }
        ]
    });
}

function DeleteItem(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "Delete",
                success: function (data) {
                    if (data.success) {
                        dtble.ajax.reload()
                        toaster.success(data.message);
                    } else {
                        toaster.else(data.message);
                    }

                }
            })
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });
}