# veri_yapilari_mezun_bilgi_sistemi
Geliştirilecek bir mezun öğrenci bilgi sistemi kapsamında, sisteme kayıtlı olan öğrencilere ilişkin bilgiler, öğrenci numarasına göre, ikili arama ağacı yapısı üzerinde tutulacaktır. Ağacın her düğümü, bir öğrenciye ilişkin bilgileri (adı, adresi, telefon, e-posta, uyruğu, doğum tarihi, öğrenci numarası, yabancı dil, ilgi alanları) içerecektir. Ayrıca her bir düğümde, o kişinin Staj Bilgileri yani daha önce yaptığı stajların bilgileri (şirketin adı, staj tarihi, departmanı veya görevi) ve mezun olduğu bölümün bilgileri (bölüm adı, başlangıç ve bitiş tarihleri yıl olarak, not ortalaması, başarı belgesi (boolean)) bağlı listede tutulacaktır.  
 
Bölümlere ait mezunlar ayrı ayrı tutulacaktır. Örneğin, Yazılım Mühendisliğinden mezun olan bir kişi sistemde Yazılım Mühendisliği grubunun altına kaydedilecektir. Bunun için, bölüme göre kayıt olan üyeler, bölüm adına göre bir Hash Table (key-value hash map) içerisinde tutulacaktır. Hash Table‘da her bir bölüm için bir Heap tutulacaktır. Heap’in her bir düğümü, herhangi bir bölüm altına kayıt olan öğrenci bilgilerini ve o kişinin başarı derecesini gösteren bir sayıyı içerecektir. Bu sayı mezuniyet ortalaması olup (100 üzerinden), eğer kişi herhangi bir başarı belgesi almışsa başarı derecesine 10 puan eklenecektir.       
 
Ayrıca şirketler de bu sisteme kayıt olup, istedikleri elemanla ilgili bölümü seçip, en yüksek başarı derecesinden sona doğru kişileri filtreleyip görebilmelidir. Ayrıca yabancı dil bilgisi ( preintermediate ,intermediate, upper intermediate, advanced) ve ilgi alanları’na  göre mezun listeleyip, görebilmelidir. 
 
Bu bilgilere göre aşağıdaki işlemleri yapan programı yazınız: 
 
1. Sisteme Kayıt Yapan Kişilerin Kullanacağı Bölüm  Sisteme kayıt (kendi kişisel bilgilerini girme)  Sistemdeki bilgilerini güncelleme  Sistemden çıkma (bilgilerini silme) 
 
2. Eleman Arayan Şirketlerin Kullanacağı Bölüm  Aranılan bölümde tüm mezun bilgilerini listeleme, (başarı derecesine göre en yüksekten en düşüğe)  En uygun mezuna iş teklifi yapma (Bu kişi Heap’ten çekilecektir)    Yabancı dil bilgisine göre filtreleme 
 
Ağaç İşlemleri (İkili Arama Ağacı Üzerinde):  
 Öğrenci numarasına göre mezun arama, tüm bilgilerini listeleme,  Not ortalamalarından 90’ın üzerinde olan kişilerin adlarının listelenmesi,  İngilizcesi “advanced”  düzeyinde olan kişilerin adlarının listelenmesi.   İkili arama ağacındaki tüm kişilerin adlarını bölümleri ile birlikte Listeleme (Inorder, preorder, postorder), 
Celal Bayar Üniversitesi – Hasan Ferdi Turgutlu Teknoloji Fakültesi 
 
 Ağacın derinliğini ve eleman sayısını yazdırma, 
 
Program ilk çalıştırıldığında: 
 Sisteme kayıtlanmak isteyen kişilerin bilgilerini içeren eleman.txt adlı dosyanın okunması ile, bellekte kişi adına göre ikili arama ağacı oluşturulacaktır (İlk bilgiler dosya yerine bellekten veya klavyeden de alınabilir).   Ardından, sistemdeki kişilerin sistemdeki bölümlerin altına kayıt olması ile Hash Table içerisindeki Heap’ler doldurulacaktır. 
