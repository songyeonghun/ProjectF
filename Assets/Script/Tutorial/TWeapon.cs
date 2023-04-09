using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TWeapon : MonoBehaviour
{
    public int WeaponCode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Shooting.Weapon = WeaponCode;
            Destroy(gameObject);
        }
    }
}
