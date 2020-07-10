var student = {
    init: function () {
        student.events();
    },
    events: function () {
        $(document).ready(function () {

            $('.edit-student').off('click').on('click', function () {
                $('#modal').modal('show');
                var id = $(this).data('id');
                

                $.ajax({
                    url: "/Home/GetStudent",
                    data: { id: id },
                    dataType: "json",
                    type: "GET",
                    success: function (response) {
                        $('#Id').val(id);
                        $('#Name').val(response.name);
                        $('#YearOfBirth').val(response.yearOfBirth);
                        $('#PhoneNumber').val(response.phoneNumber);

                    }
                });
            });
        });
    }
}
student.init();
