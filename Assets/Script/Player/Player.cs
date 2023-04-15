using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image HpBar;
    static public int MaxHp;
    static public int CurrentHp;
    public Text Hp;
    public Text Key;
    public Text Emp;
    public Text Coin;

    static public int emp = 0;
    static public int key = 0;
    static public int coin = 0;

    //스탯표
    static public int[][] stat = new int[5][]
    {
        new int[]{ 300,320,340,360,380,400,420,440,460,480,500},    //0 채력
        new int[]{ 0,0,2,0,4,0,6,0,8,0,10},                                 //1 공격력
        new int[]{ 10,11,12,13,14,15},                                    //2 이동속도
        new int[]{ 10, 0, 11, 0, 12, 0, 13, 0, 14, 0, 15},                //3 공격속도
        new int[]{ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80}                 //5 채력회복
    };

    private void Start()
    {
        MaxHp = stat[0][PlayerPrefs.GetInt("statHp")];
        CurrentHp = MaxHp;
    }

    void Update()
    {
       HpBar.fillAmount = (float)CurrentHp / MaxHp;
        Hp.text ="Hp: "+CurrentHp;
        Key.text = "" + key;
        Emp.text = "" + emp;
        Coin.text = "" + coin;
    }

private void OnTriggerEnter2D(Collider2D collision)
{
        //픽업 아이템 획득
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
