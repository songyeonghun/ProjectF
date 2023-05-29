using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    int WeaponCode;

    SpriteRenderer weapon;

    public Sprite pistol;
    public Sprite rifle;
    public Sprite shotgun;

    private void Start()
    {
        WeaponCode = Random.Range(1, 4);
        weapon = GetComponent<SpriteRenderer>();
        if (WeaponCode == 1)
        {
            weapon.sprite = pistol;
        }
        else if (WeaponCode == 2)
        {
            weapon.sprite = rifle;
        }
        else if (WeaponCode == 3)
        {
            weapon.sprite = shotgun;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shooting.Weapon = this.WeaponCode;
    }
}
