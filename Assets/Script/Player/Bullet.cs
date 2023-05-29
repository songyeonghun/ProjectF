using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    int[] statDamage = { 0, 0, 2, 0, 4, 0, 6, 0, 8, 0, 10 };


    private void Start()
    {
        damage = Shooting.damage[Shooting.Weapon]+statDamage[PlayerPrefs.GetInt("statAtk")];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
