using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    static public bool atkCool=false;
    float pistolCool = 0.5f;

    void Update()
    {
        if (Input.GetMouseButton(0) && atkCool == false)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);


        StartCoroutine("atkCoolTime");

    }

    //공격에 쿨타임을 주기
    private IEnumerator atkCoolTime()
    {
        atkCool = true;
        yield return new WaitForSeconds(pistolCool);
        atkCool = false;
    }

}
