function KategoriEkle(parameters) {
    Kategori = new Object();
    Kategori.KategoriAdi = $("#kategoriAdi").val();
    Kategori.Url = $("#kategoriUrl").val();
    Kategori.Aktif = $("#kategoriAktif").is(":checked");

    $.ajax({
        url: "/Kategori/Ekle",
        data: Kategori,
        type: "POST",
        dataType: "json",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message,
                    function () {
                        location.reload();
                    });
            } else {
                bootbox.alert(response.Message,
                    function () {

                    });
            }
        }
    });
}