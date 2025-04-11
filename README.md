<h2>Asp.Net Core ile Traversal Rezervasyon Projesi</h2>
Bu proje Murat Yücedağ’ın YouTube'da yayınladığı Traversal Rezervasyon ASP.NET Core Mini Proje eğitimini içermektedir.<br><br> Proje tur rezervasyon sistemi üzerine kurulmuştur.
Kullanıcılar, sistemde sunulan tur rotaları arasından seyahat etmek istedikleri ülkeyi seçebilirler. Rezervasyon işlemlerine devam edebilmek için öncelikle web sitesine üye olmaları gerekmektedir. Üyelik işlemini tamamladıktan sonra, kullanıcı paneli üzerinden rezervasyonlarını yönetebilir, yeni rezervasyon oluşturabilir, mevcut rezervasyonların durumunu takip edebilir ve geçmiş rezervasyonlarına ulaşabilirler.

<h3>👤 Kullanıcı Ara Yüzü</h3>
<li>Profil bilgilerini güncelleyebilir</li>
<li>Aktif rezervasyonları ve onaylanmış rezervasyonları görüntüleyebilir.</li>
<li>Seyahati bitmiş rezervasyonları geçmiş kayıtlar olarak görüntüleyebilir.</li>
<li>Yeni rezervasyon yaparken seçilen rota için başvuru oluşturabilir. </li>
<li>Onay bekleyen rezervasyonlar sistem tarafından kontrol edilir.</li>
<li>Tur rotalarına yorum yapabilir ve yorum geçmişini görüntüleyebilir.</li>
<li>Mevcut tur rotalarını detaylı inceleyebilir.</li>
<h3>🛠️ Admin Ara Yüzü</h3>
<li>Rezervasyonları yönetebilir (Gelen,Onaylanan,Geçmiş,İptal Edilen)</li>
<li>Kullanıcı yorumlarını görebilir ve yönetebilir.</li>
<li>Yeni tur rotaları oluşturabilir ve mevcutları düzenleyebilir.</li>
<li>Üyeleri listeleyebilir, yorum ve rezervasyon geçmişini görüntüleyebilir.</li>
<li>İletişim formu üzerinden gelen mesajları yönetebilir.</li>
<li>Duyuru işlemlerinden yeni duyuru ekleyebilir ve bunu kullanıcıların panelinde görüntüleyebilirler.</li>
<li>Rehberleri aktif - pasif yapabilir ve yeni rehberler ekleyebilir.</li>
<li>Kullanıcılara sistem üzerinden e-posta gönderebilir.</li>
<li>Admin profil bilgilerini güncelleyebilir.</li>
<li>Roller oluşturabilir ve kullanıcılara rol atayabilir.</li>

Proje, ASP.NET Core teknolojileri kullanarak N Katmanlı Mimari prensipleriyle yapılandırılmıştır.
<h3>🧰 Kullanılan Teknolojiler</h3>
<li>ASP.NET Core (.NET Core Framework) : Projenin temel backend altyapısı. </li>
<li>Entity Framework Core : ORM kullanarak veritabanı işlemlerini yönetmek için kullanıldı. </li>
<li>FluentValidation : Kullanıcı girişleri için doğrulama kurallarını yönetmek için kullanıldı. </li>
<li>CQRS Design Pattern : Okuma ve yazma işlemlerini ayrıştırarak performans ve ölçeklenebilirlik sağlamak için kullanıldı. </li>
<li>Unit of Work : Transaction yönetimi ve veri tutarlılığını sağlamak için kullanıldı. </li>
<li>ASP.NET Core Identity : Kullanıcı kimlik doğrulama ve yetkilendirme işlemleri için kullanıldı. </li>
<li>SignalR : Gerçek zamanlı iletişim ve bildirimler için kullanıldı. </li>
<li>Web API & API Consume : API ile veri akışı ve veri tüketimi için kullanıldı. </li>
<li>HTML5 & CSS3 : Kullanıcı arayüzü tasarımı için kullanıldı. </li>
<li>Bootstrap : Responsive ve modern tasarım için kullanıldı. </li>
<li>JavaScript : Dinamik işlemler için kullanıldı. </li>
<li>MS SQL Server : Veritabanı yönetimi için kullanıldı. </li>
<li>Entity Framework Core – Code First : Veritabanı tablolarını kod üzerinden oluşturmak için kullanıldı. </li>
<li>SignalR : WebSocket kullanarak anlık veri akışı sağlamak için kullanıldı. </li>
<li>RESTful API : HTTP istekleri ile veri yönetimi için kullanıldı. </li>
<h3>Proje Görüntüleri</h3>

![13](https://github.com/user-attachments/assets/eb3211c1-e798-4007-8e3b-b794136d5cbd)
![12](https://github.com/user-attachments/assets/120121a4-5b40-4492-bef5-897b22adaba4)
![1](https://github.com/user-attachments/assets/c622cc58-7a84-4665-97a7-adbc153fdd3d)
![2](https://github.com/user-attachments/assets/a23cfcce-c092-43e8-8e8e-714c09b5c356)
![3](https://github.com/user-attachments/assets/ef11dc8c-6669-4e99-a079-cda5ad5faca1)
![4](https://github.com/user-attachments/assets/4b4b8f41-f3e9-4581-8f99-166b0eaaa97b)
![5](https://github.com/user-attachments/assets/9f071a26-7996-42ca-9bed-9a21dfce50e5)
![6](https://github.com/user-attachments/assets/57be5a70-964c-49bd-a6ac-b71d639ac20a)
![7](https://github.com/user-attachments/assets/773ed765-252e-491a-b750-dbb499540ecd)
![8](https://github.com/user-attachments/assets/0378d615-7254-44e0-a1da-c25d20b146b1)
![9](https://github.com/user-attachments/assets/fa13cb4a-41c7-4724-99c4-90f30df3ec67)
![10](https://github.com/user-attachments/assets/2ab3fb49-8d47-4eaa-bf68-b44b65c52ce0)
![11](https://github.com/user-attachments/assets/811d34d1-0f9a-4ed9-9357-9f6e0375a432)
