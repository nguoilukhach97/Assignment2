var student = {
    init: function () {
        student.events();
        student.loadData();

        
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
        
    },
    loadData: function () {
        $(document).ready(function () {
            $.ajax({
                url: "/Home/GetProvince",
                dataType: "json",
                data: "GET",
                success: function (response) {
                    var data = response.ltsItem;
                    var html = '<option value=0 disabled selected>Chọn Tỉnh/Thành phố</option>';
                    $.each(data, function (i, item) {
                        html += '<option class="item_001" onClick="clickItem()" value="' + item.title + '" data-id=' + item.id + '>' + item.title + '</option>';
                    });
                    $('#Province').html(html);


                }
            });

            var clickItem = function () {
                
                 console.log("ok");
                
            }

           



            $(document).on('change', '#Province', function () {

                console.log($(this).attr("class"));
                var idProvince = $(this).data('id');
                $('#Commune').empty();
                $.ajax({
                    url: "/Home/GetDistrict",
                    data: { id: idProvince },
                    dataType: "json",
                    type: "GET",
                    success: function (response) {
                        var data = response;
                        var html = '<option value=0 disabled selected>Chọn Quận/Huyện</option>';
                        $.each(data, function (i, item) {
                            html += '<option value="' + item.title + '" data-id=' + item.id + '>' + item.title + '</option>';
                        });
                        $('#District').html(html);
                    }
                });
            });
            
            $(document).on('change', '#District', function () {
                var idDistrict = $(this).data('id');
                $.ajax({
                    url: "/Home/GetCommune",
                    data: { id: idDistrict },
                    dataType: "json",
                    type: "GET",
                    success: function (response) {
                        var data = response;
                        var html = '<option value=0 disabled selected>Chọn Xã/Phường</option>';
                        $.each(data, function (i, item) {
                            html += '<option value=' + item.title + ' data-id=' + item.id + '>' + item.title + '</option>';
                        });
                        $('#Commune').html(html);
                    }
                });
            });
            
        });
    }
}
student.init();
