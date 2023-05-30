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
        if (Hp <= 0)//�����۵�� ����ó��
            return;

        if (collision.gameObject.tag == "Bullet")
        {
                Bullet BulletDamage = collision.GetComponent<Bullet>();
                Hp -= BulletDamage.damage;

            Destroy(collision.gameObject);

            if (Hp <= 0)
            {
                /*int ran = Random.Range(0, 9);//������(����)���
                if(ran < Ran)//Ȯ�� ����
                {
                    Debug.Log("Not Item");
                }
                else
                {
                    for (int i = 0; i >= coin; i++)
                    {
                        Instantiate(itemCoin, transform.position, itemCoin.transform.rotation);//���ζ�����
                    }
                }*/

                Instantiate(EnemyDie, transform.position, transform.rotation);//������ ����Ʈ�� ����
                Instantiate(Nasa, transform.position, Nasa.transform.rotation);//���ζ�����

                DieCount.GetComponent<MonsterSummoner>().EnemyDie++;

                Destroy(Body);
            }
        }
    }
}
