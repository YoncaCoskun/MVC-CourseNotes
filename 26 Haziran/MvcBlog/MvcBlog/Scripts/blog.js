function YorumGonder() {
    $('#loaderImg').show("fast");
    $('#btnYorumGonder').hide();
    //$('#btnYorumGonder').attr('disabled', 'disabled');
    $('#spanResult').text('');

    var makaleId = $('#MakaleId').val();
    var yazan = $('#Yazan').val();
    var icerik = $('#Icerik').val();

    $.ajax({
        type: "POST",
        url: "/Home/YorumYaz",
        data: { MakaleId: makaleId, Yazan: yazan, Icerik: icerik },
        success: function (data) {
            $('#loaderImg').hide("fast");
            $('#btnYorumGonder').show();
            //$('#btnYorumGonder').removeAttr('disabled');
            $('#spanResult').text("Yorumunuz alınmıştır. Onaylandığı takdirde görüntülenecektir.");
            $('#Yazan').val('');
            $('#Icerik').val('');
        },
        error: function (err) {
            $('#loaderImg').hide("fast");
            $('#btnYorumGonder').show();
            //$('#btnYorumGonder').removeAttr('disabled');
            $('#spanResult').text("Beklenmedik bir hata oluştu. Tekrar deneyiniz...");
        },
        dataType: "json"
    });
}

function DoDislike() {
    var makaleId = $('#Id').val();
    $.ajax({
        type: "POST",
        url: "/Home/DislikeArttir",
        data: { id: makaleId },
        success: function (data) {
            $('#dislikeSpan').text(data);
            $("#imgDislike").attr("src", "/Content/img/disliked.png");
        },
        error: function (err) {
        },
        dataType: "json"
    });
}
function DoLike() {
    var makaleId = $('#Id').val();
    $.ajax({
        type: "POST",
        url: "/Home/LikeArttir",
        data: { id: makaleId },
        success: function (data) {
            $('#likeSpan').text(data);
            $("#imgLike").attr("src", "/Content/img/liked.png");
        },
        error: function (err) {
        },
        dataType: "json"
    });
}

function YayinDurumGuncelle(makaleId) {
    $.ajax({
        type: "POST",
        url: "/Admin/YayinDurumDegistir",
        data: { id: makaleId },
        success: function (data) {
     


        },
        error: function (err) {
        },
        dataType: "json"
    });

    
}