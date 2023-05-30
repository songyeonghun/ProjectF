using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public GameObject Body;

    public int Hp=10;
    public int coin = 0;

    int Damage;

    public GameObject Nasa;
    public GameObject MoonStone;
    public GameObject EnemyDie;

    GameObject DieCount;

    private void Start()
    {
        DieCount = GameObject.Find("MonsterSummoner");
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Hp <= 0)//아이템드랍 예외처리
            return;

        if (collision.gameObject.tag == "Bullet")
        {
                Bullet BulletDamage = collision.GetComponent<Bullet>();
                Hp -= BulletDamage.damage;

            Destroy(collision.gameObject);

            if (Hp <= 0)
            {
                /*int ran = Random.Range(0, 9);//아이템(코인)드랍
                if(ran < Ran)//확률 조정
                {
                    Debug.Log("Not Item");
                }
                else
                {
                    for (int i = 0; i >= coin; i++)
                    {
                        Instantiate(itemCoin, transform.position, itemCoin.transform.rotation);//코인떨구기
                    }
                }*/

                Instantiate(EnemyDie, transform.position, transform.rotation);//죽을시 이펙트와 사운드
                Instantiate(Nasa, transform.position, Nasa.transform.rotation);//코인떨구기

                DieCount.GetComponent<MonsterSummoner>().EnemyDie++;

                Destroy(Body);
            }
        }
    }
}
