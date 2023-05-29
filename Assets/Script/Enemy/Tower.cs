using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    void Start()
    {
        StartCoroutine(tower());
    }

    IEnumerator tower()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        yield return new WaitForSeconds(1f);
        StartCoroutine(tower());

}

}