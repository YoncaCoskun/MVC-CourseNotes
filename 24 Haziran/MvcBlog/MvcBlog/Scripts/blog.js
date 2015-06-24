function YorumGonder() {

    var makaleId = $('#MakaleId').val();
    var yazan = $('#Yazan').val();
    var icerik = $('#Icerik').val();

    $.ajax({
        type: "POST",
        url: "/Home/YorumYaz",
        data: { MakaleId: makaleId, Yazan: yazan, Icerik: icerik },
        success: function (data){$('#spanResult').text("Yorumunuz alınmıştır.Onaylandığı Takdirde görülecektir.")},
        dataType: "json"
    });
}

//function islemBasarili() {
    
//}