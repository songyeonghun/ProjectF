using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    int[] statDamage = { 0, 0, 1, 0, 2, 0, 3, 0, 4, 0, 5 };
    static public int itemDamage;


    private void Start()
    {
        damage = Shooting.damage[Shooting.Weapon]+statDamage[PlayerPrefs.GetInt("statAtk")]+itemDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
