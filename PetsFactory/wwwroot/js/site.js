function Delete(url) {
    // display sweet alert

    Swal.fire({
        title: 'Are you sure you want to Delete?',
        text: "You will not be able to restore the data!",
        showCancelButton: true,
        confirmButtonText: `Delete`
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data1) {
                    if (data1.success) {
                        Swal.fire(
                            'Success!',
                            data1.message,
                            'success'
                        ).then((btnOk) => {
                            location.reload(true);
                        });
                    } else {
                        Swal.fire(
                            'Error!',
                            data.message,
                            'error'
                        )
                    }
                }
            });
        }
    });
}