function KategoriEkle() {
    Kategori = new Object();
    Kategori.KategoriAdi = $("#kategoriAdi").val();
    Kategori.Url = $("#kategoriUrl").val();
    Kategori.Aktif = $("#kategoriAktif").is(":checked");
    Kategori.ParentId = $("#ParentId").val();

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

function KategoriSil(id) {
    $.ajax({
        url: "/Kategori/Sil/" + id,
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