using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform rifleStart;
    

    [SerializeField] private GameObject GameOver; //oyun bitişi ile alakalı, ama ayarlamasını yapmadım. karakterin canı 0 olduğunda kullanılabilir
    [SerializeField] private GameObject Victory; //oyun kazanma, tag ile düşman sayısı sayılıp düşman sayısı 0 olunca ayarlanabilir

    public float health = 0;


    [SerializeField] float movementSpeed = 5f;
    float currentSpeed;
    Rigidbody rb;
    Vector3 direction;

    void Start()
    {
        //Destroy(this); bu hata oyun başında karakterimizin canını 0 yapıp oyunda hata almamızı sağlıyordu
        ChangeHealth(100);
        rb = GetComponent<Rigidbody>(); //rigidbody ataması
        currentSpeed = movementSpeed; //oyunun başındaki hızı serializefield'dan verdik
    }

    public void ChangeHealth(int hp)
    {
        health += hp; //can bonusu verme
        if (health > 100)
        {
            health = 100;
        }
        else if (health <= 0) //kaybetme
        {
            Lost();
        }
        //HpText.text = health.ToString(); can ayarlaması yapmadığım için geçici süreliğine elemanı kapattım, enemy karakterlerine player değince kaybettin koşulu ile yapılabilir
    }

    public void Win() //kazanma
    {
        Victory.SetActive(true);
        Destroy(GetComponent<PlayerLook>());
        Cursor.lockState = CursorLockMode.None;
    }

    public void Lost()
    {
        GameOver.SetActive(true);
        Destroy(GetComponent<PlayerLook>()); 
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //karakter hareketi: yatay
        float moveVertical = Input.GetAxis("Vertical"); //karakter hareket: dikey

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical); //karakter hareketlerini alma
        direction = transform.TransformDirection(direction); 

        if (Input.GetMouseButtonDown(0))
        {
            GameObject buf = Instantiate(bullet);
            buf.transform.position = rifleStart.position;
            buf.GetComponent<Bullet>().setDirection(transform.forward);
            buf.transform.rotation = transform.rotation;

            Collider[] tar = Physics.OverlapSphere(transform.position, 2);
            foreach (var item in tar)
            {
                if (item.tag == "Enemy")
                {
                    Destroy(item.gameObject);
                }
            }
        }
        /* fare sağ tuşa göre yapılmış.
        if (Input.GetMouseButtonDown(1))
        {
            Collider[] tar = Physics.OverlapSphere(transform.position, 2);
            foreach (var item in tar)
            {
                if (item.tag == "Enemy")
                {
                    Destroy(item.gameObject);
                }
            }
        }
        */

        /* can alınacak bir nesne yok, o yüzden bu kodu devre dışı bıraktım
        Collider[] targets = Physics.OverlapSphere(transform.position, 3);
        foreach (var item in targets)
        {
            
            if (item.tag == "Heal")
            {
                ChangeHealth(50);
                Destroy(item.gameObject);
            }
            
            if (item.tag == "Finish")
            {
                Win();
            }
            if (item.tag == "Enemy")
            {
                Lost();
            }
        }
        */
    }

    void FixedUpdate() //her update fonksiyonu sonrasında update'de oluşacak işlemlerde düzeltilme işlemleri
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime); //karakter yürüme hesaplaması, arada geçen farkı ve mesafeyi hesaplayıp karaktere ekliyor
    }
}
