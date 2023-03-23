using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider hpbar;
    public float maxHp;
    public float currentHp;

    static public int emp = 0;
    int key = 0;
    int coin = 0;


    void Update()
    {
       // hpbar.value = currentHp / maxHp;   

    }
private void OnTriggerEnter2D(Collider2D collision)
{
        //열쇠와 접촉시 열쇠는 사라지고 열쇠 소지갯수 1증가
        if (collision.gameObject.tag == "Key")
        {
            key++;
            Destroy(collision.gameObject);
        }
        //스탯코인과 접촉시 스탯코인은 사라지고 스탯코인 소지갯수 1증가
        if (collision.gameObject.tag == "StatCoin")
        {
            GameManager.StatCoin += 1;
            Destroy(collision.gameObject);
        }
        //emp와 접촉시 emp1개 증가
        if (collision.gameObject.tag == "emp")
        {
            emp++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "coin")
        {
            coin++;
            Destroy(collision.gameObject);
        }
    }
}
