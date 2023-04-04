using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider HpBar;
    public int MaxHp;
    static public int CurrentHp;
    public Text Hp;

    static public int emp = 0;
    static public int key = 0;
    int coin = 0;


    private void Start()
    {
        MaxHp = PlayerState.stat[0][PlayerState.statHp];
        CurrentHp = MaxHp;
    }

    void Update()
    {
       HpBar.value = CurrentHp / MaxHp;
        Hp.text ="Hp: "+CurrentHp;
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
            GameManager2.StatCoin += 1;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Weapon")
        {
           Shooting.Weapon = Weapon.WeaponCode;
            Destroy(collision.gameObject);
        }
    }
}
