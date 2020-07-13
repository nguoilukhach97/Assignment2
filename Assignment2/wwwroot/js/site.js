var student = {
    init: function () {
        student.events();
        student.loadData();

    },
    loadAddress: function (idx,idh,idt) {
        $(document).ready(function () {
            $.ajax({
                url: "/Home/GetProvince",
                dataType: "json",
                data: "GET",
                success: function (response) {
                    var data = response.ltsItem;
                    var html = '<option disabled readonly>Chọn Tỉnh/Thành phố</option>';
                    $.each(data, function (i, item) {
                        if (item.id==idt) {
                            html += '<option class="item_province" value="' + item.title + '" data-id=' + item.id + ' selected>' + item.title + '</option>';
                        }
                        else {
                            html += '<option class="item_province" value="' + item.title + '" data-id=' + item.id + '>' + item.title + '</option>';
                        }
                        
                    });
                    $('#Province').html(html);

                }
            });


            $.ajax({
                url: "/Home/GetDistrict",
                data: { id: idt },
                dataType: "json",
                type: "GET",
                success: function (response) {
                    var data = response;
                    var html = '<option disabled>Chọn Quận/Huyện</option>';
                    $.each(data, function (i, item) {
                        if (item.id == idh) {
                            html += '<option class="item_province" value="' + item.title + '" data-id=' + item.id + ' selected>' + item.title + '</option>';
                        }
                        else {
                            html += '<option class="item_province" value="' + item.title + '" data-id=' + item.id + '>' + item.title + '</option>';
                        }
                    });
                    $('#District').html(html);
                    
                }
            });

            $.ajax({
                url: "/Home/GetCommune",
                data: { id: idh},
                dataType: "json",
                type: "GET",
                success: function (response) {
                    var data = response;
                    var html = '';
                    $.each(data, function (i, item) {
                        if (item.id == idx) {
                            html += '<option class="item_province" value="' + item.title + '" data-id=' + item.id + ' selected>' + item.title + '</option>';
                        }
                        else {
                            html += '<option class="item_province" value="' + item.title + '" data-id=' + item.id + '>' + item.title + '</option>';
                        }
                    });
                    $('#Commune').html(html);
                    
                }
            });

            




        });
    },
    events: function () {
        $(document).ready(function () {

            $('.edit-student').off('click').on('click', function () {
                $('#modal').modal('show');
                var id = $(this).data('id');
                var idadd = $(this).data('address');

                $.ajax({
                    url: "/Home/GetStudent",
                    data: {
                        id: id,
                        idAddress: idadd
                    },
                    dataType: "json",
                    type: "GET",
                    success: function (response) {
                        var data = response.student;
                        var address = response.address;
                        $('#Id').val(id);
                        $('#IdAddress').val(idadd);
                        $('#Address').val(data.address);
                        $('#Name').val(data.name);
                        $('#YearOfBirth').val(data.yearOfBirth);
                        $('#PhoneNumber').val(data.phoneNumber);
                        student.loadAddress(address.id,address.quanHuyenID, address.tinhThanhID);
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
                    var html = '<option disabled selected>Chọn Tỉnh/Thành phố</option>';
                    $.each(data, function (i, item) {
                        html += '<option class="item_province" value="' + item.title + '" data-id=' + item.id + '>' + item.title + '</option>';
                    });
                    $('#Province').html(html);


                }
            });

            $(document).delegate('#Province', 'change', function () {
                var idProvince = $(this).find('option:selected').data('id');
                //var idProvince = $(this).val();
                $('#Commune').empty();
                $.ajax({
                    url: "/Home/GetDistrict",
                    data: { id: idProvince },
                    dataType: "json",
                    type: "GET",
                    success: function (response) {
                        var data = response;
                        var html = '<option disabled selected>Chọn Quận/Huyện</option>';
                        $.each(data, function (i, item) {
                            html += '<option value="' + item.title + '" data-id=' + item.id + '>' + item.title + '</option>';
                        });
                        $('#District').html(html);
                    }
                });


            });

            //$(document).on('change', '#Province', function () {


            //    var idProvince = $(this).data('id');
            //    $('#Commune').empty();
            //    $.ajax({
            //        url: "/Home/GetDistrict",
            //        data: { id: idProvince },
            //        dataType: "json",
            //        type: "GET",
            //        success: function (response) {
            //            var data = response;
            //            var html = '<option value=0 disabled selected>Chọn Quận/Huyện</option>';
            //            $.each(data, function (i, item) {
            //                html += '<option value="' + item.id + '" data-id=' + item.id + '>' + item.title + '</option>';
            //            });
            //            $('#District').html(html);
            //        }
            //    });
            //});

            $(document).on('change', '#District', function () {
                var idDistrict = $(this).find('option:selected').data('id');
                $.ajax({
                    url: "/Home/GetCommune",
                    data: { id: idDistrict },
                    dataType: "json",
                    type: "GET",
                    success: function (response) {
                        var data = response;
                        var html = '';
                        $.each(data, function (i, item) {
                            html += '<option value="' + item.title + '" data-id=' + item.id + '>' + item.title + '</option>';
                        });
                        $('#Commune').html(html);
                        var idad = $('#Commune').find('option:selected').data('id');
                        $('#IdAddress').val(idad);
                    }
                });

            });

            $(document).on('change', '#Commune', function () {
                var id = $(this).find('option:selected').data('id');

                $('#IdAddress').val(id);
            });

        });
    }
}
student.init();
