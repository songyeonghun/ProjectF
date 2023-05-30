using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePosition;
    public Transform firePosition1;
    public Transform firePosition2;
    public Transform firePosition3;
    public Transform firePosition4;
    public Transform firePosition5;
    public Transform firePosition6;
    public Transform firePosition7;
    public Transform firePosition8;
    public AudioClip Attack;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {      
        AudioSource.PlayClipAtPoint(Attack, transform.position);

        GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

        GameObject bullet1 = Instantiate(bulletPrefab, firePosition1.position, firePosition1.rotation);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        rb1.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrefab, firePosition2.position, firePosition2.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(bulletPrefab, firePosition3.position, firePosition3.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

        GameObject bullet4 = Instantiate(bulletPrefab, firePosition4.position, firePosition4.rotation);
        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        rb4.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

        GameObject bullet5 = Instantiate(bulletPrefab, firePosition5.position, firePosition5.rotation);
        Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
        rb5.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

        GameObject bullet6 = Instantiate(bulletPrefab, firePosition6.position, firePosition6.rotation);
        Rigidbody2D rb6 = bullet6.GetComponent<Rigidbody2D>();
        rb6.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

        GameObject bullet7 = Instantiate(bulletPrefab, firePosition7.position, firePosition7.rotation);
        Rigidbody2D rb7 = bullet7.GetComponent<Rigidbody2D>();
        rb7.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

        GameObject bullet8 = Instantiate(bulletPrefab, firePosition8.position, firePosition8.rotation);
        Rigidbody2D rb8 = bullet8.GetComponent<Rigidbody2D>();
        rb8.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

        Destroy(gameObject);
    } 
}
