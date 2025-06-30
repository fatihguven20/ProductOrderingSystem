# ProductOrderingSystem

Proje Açıklaması

Bu proje, bir stok yönetimi ve sipariş otomasyonu sistemidir. Fake Store API ile entegre çalışarak gerçek ürün verilerini içeri aktarabilir, stok seviyelerini takip edebilir, kritik seviyeye düşen ürünler için otomatik sipariş oluşturabilir.

Ana Katmanlar

API: REST API servisleri sunar.

Contracts: Katmanlar arasında kullanılan DTO modellerini barındırır.

Infrastructure: Fake Store API ile dış servis entegrasyonu ve in-memory veri tutma.

Application: İş mantığı, servis arayüzleri.

BlazorUI: Blazor WebAssembly kullanarak arayüz sağlar.

Nasıl Çalışır?

Kullanıcı, Fake Store API'den  ürünleri çekmek için "Ürünleri Import Et" butonuna tıklar. FakeStoreAPI üzerinde bulunan tüm bilgiler iç sisteme aktarılır.

Kritik stokta olan ürünler, "Kritik Stok Ürünleri" sayfasında listelenir. Bu sayfada yer alan "Sipariş ver" butonu ile, kritik seviyedeki ürünler için en az maliyetli sipariş oluşturulur.

"Yeni Ürün Ekle" butonu ile açılan sayfadan productCode üzerinden eklenebilir FakeProduct ürün bilgileri getirilir ve manuel ekleme yapılabilir.


API
-----

POST  /products
Örnek İstek: 
{
  "productCode": 1,
  "title": "fg1",
  "price": 10,
  "description": "aciklama",
  "category": "yok",
  "image": "1",
  "stock": 40,
  "threshold": 30
}
Yanıt : 1

GET /products/low-stock
Yanıt:
[
  {
    "productCode": 1,
    "title": "fg2",
    "price": 10,
    "description": "aciklama2",
    "category": "yok",
    "image": "1",
    "stock": 20,
    "threshold": 30
  }
]

GET /products/all-stock
Yanıt:
[
  {
    "productCode": 1,
    "title": "fg1",
    "price": 10,
    "description": "aciklama",
    "category": "yok",
    "image": "1",
    "stock": 40,
    "threshold": 30
  },
  {
    "productCode": 1,
    "title": "fg2",
    "price": 10,
    "description": "aciklama2",
    "category": "yok",
    "image": "1",
    "stock": 20,
    "threshold": 30
  }
]


POST products/import
Yanıt : Ürünler başarıyla içe aktarıldı.Toplam:20


POST orders/check-and-place
Yanıt:
{
  "productCode": 19,
  "title": "Opna Women's Short Sleeve Moisture",
  "image": "https://fakestoreapi.com/img/51eg55uWmdL._AC_UX679_.jpg",
  "orderedQuantity": 5,
  "unitPrice": 7.95,
  "totalCost": 39.75,
  "newStock": 15
}




