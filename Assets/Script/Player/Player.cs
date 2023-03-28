using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider HpBar;
    public float MaxHp;
    static public float CurrentHp;

    static public int emp = 0;
    int key = 0;
    int coin = 0;


    private void Start()
    {
        MaxHp = PlayerState.stat[0][PlayerState.statHp];
        CurrentHp = MaxHp;
    }

    void Update()
    {
       HpBar.value = CurrentHp / MaxHp;
    }

private void OnTriggerEnter2D(Collider2D collision)
{
        //«»æ˜ æ∆¿Ã≈€ »πµÊ
        if (collision.gameObject.tag == "coin")
        {
            coin++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Key")
        {
            key++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "emp")
        {
            emp++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "StatCoin")
        {
            GameManager.StatCoin += 1;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Weapon")
        {
           Shooting.Weapon = Weapon.WeaponCode;
            Destroy(collision.gameObject);
        }
    }
}
