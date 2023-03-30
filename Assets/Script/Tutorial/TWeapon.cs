using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TWeapon : MonoBehaviour
{
    static public int WeaponCode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Shooting.Weapon = 1;
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        WeaponCode = 1;
        Debug.Log(WeaponCode);
    }

}
