using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoTop : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletForce = 1f;

    void Start()
    {
        StartCoroutine(tower());
    }

    IEnumerator tower()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        StartCoroutine(tower());

}

}