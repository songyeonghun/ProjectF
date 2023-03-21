using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider hpbar;
    public float maxHp;
    public float currentHp;

    //플레이어의 소지 열쇠
    int key = 0;


    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
       // hpbar.value = currentHp / maxHp;   

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //열쇠와 접촉시 열쇠는 사라지고 열쇠 소지갯수 1증가
        if (collision.gameObject.tag == "Key")
        {
            key++;
            Destroy(collision.gameObject);
        }
        //스탯코인과 접촉시 스탯코인은 사라지고 스탯코인 소지갯수 1증가
        else if (collision.gameObject.tag == "StatCoin")
        {
            GameManager.StatCoin += 1;
            Destroy(collision.gameObject);
        }
    }
}
