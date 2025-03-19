2022.3.29f1 sürümü kullanıldı.

Projede Yapılan Düzenlemeler:
Enemy, Enemy1 ve Enemy2'ye Rigidbody ve CapsuleCollider eklemesi yapıldı.
Player nesnesinin Prefab'i alındı
RifleStart transform'u ayarlanmamış (Karakterin elinde silah olmadığı için gerekli olmayabilir, ama elinde silah olsaydı o konumdan çıkardı)
GameOver ve Victory Prefab'i ayarlanmamış. (Oyunda şu anlık o durumu kapattım, ama Enemy tag'ine sahip düşman sayısına göre Victory ve GameOver yapılabilir)
Enemy2 ve Enemy1 nesnesinde CharacterController nesnesi eklenmiş, onun yerine CapsuleCollider kullanmak daha mantıklı olabilir.
Enemy, Enemy1 ve Enemy2'de Tag yoktu, düşman-karakter ayrımı yapabilmek için Tag gerekli, bu şekilde item tag'lerine göre ayrım yapıp kontrol edebiliyor ve nesneleri yok edebiliyoruz.

Kodlarda Yapılan Değişiklikler:
PlayerLook kısmında PlayerArms yerine Player'a rotation ayarlaması yapıldı.
PlayerController kısmında karakterin canı oyun başında ChangeHealth(0) yapılmış, bu oyun başında 100'e ayarlandı (eğer bunu yapmasaydık oyun bitti koşulu tetiklenirdi ve UI'da onu görüyor olurduk oyunu kaybetmiş olurduk)
Bullet script dosyasında tag'lere göre vurma kısmı koşulu ayarlanmış ama Destroy(gameObject) yoktu, yani mermimiz düşmanı vursa bile düşman yok olmayacaktı
PlayerLook script dosyasında Cursor.LockState update yerine start fonksiyonuna yerleştirdik, çünkü ilk oyun başında cursor'un kapalı olması bize yeterli, oyun başladıktan sonra bu engel devam etmemiş olacak.
PlayerController'da karakter mermi ateşlemesi Input.GetMouseButtonDown(0) ile tasarlanmış, ama düşmanları yok etmek sağ tuşa bastığımızda nesne çarpışıyorsa diye ayarlanmış. Sol tuşa bastığımızda mermi ateşlendiği için yapılacak olan mermi düşmana collide ettiğinde o nesneyi yok etmek olur
PlayerController içinde Collider targets ve altındaki Heal, Win, Lose elementler olmadığı için o kısmı devre dışı bıraktım. Ama gelecekte bir nesne eklenip merminin/karakterin o nesne ile çarpışması sağlanırsa bu ssitem çalıştırılabilir.
