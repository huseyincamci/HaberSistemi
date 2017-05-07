function KategoriEkle(parameters) {
    Kategori = new Object();
    Kategori.Adi = $("#kategoriAdi").val();
    Kategori.Url = $("#kategoriUrl").val();
    Kategori.Aktif = $("#kategoriAktif").is(":checked");


    $.ajax({
        url: "Kategori/Ekle",
        data: Kategori,
        type: "POST",
        success: function(response) {
            if (response.success) {
                
            } else {
                
            }
        }
    });
}