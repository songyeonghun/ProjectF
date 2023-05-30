using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryAA : MonoBehaviour
{
    public GameObject Body;

    public int Hp=10;
    public int Ran = 0;
    public int coin = 0;

    int Damage;

    public GameObject itemCoin;
    public GameObject EnemyDie;

    public GameObject DieCount;

    private void Start()
    {
        //DieCount = GameObject.Find("MonsterSummoner");
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
                if (ran < Ran)//Ȯ�� ����
                {
                    Debug.Log("Not Item");
                }
                else
                {
                    
                }*/

                Instantiate(EnemyDie, transform.position, transform.rotation);//������ ����Ʈ�� ����

                for (int i = 0; i < coin; i++)
                {
                    Instantiate(itemCoin, transform.position, itemCoin.transform.rotation);//���ζ�����
                }

                DieCount.GetComponent<MonsterSummoner>().EnemyDie++;
                Destroy(Body);
            }
        }
    }
}
