using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public GameObject Body;

    public int Hp = 700;

    int Damage;

    public GameObject Nasa;
    public GameObject MoonStone;
    public GameObject EnemyDie;

    public GameObject DieCount;

    public Image HealthBar;
    int health;

    private void Start()
    {
        //DieCount = GameObject.Find("MonsterSummoner");

        health = Hp;
    }

    private void Update()
    {
        HealthBar.fillAmount = (float)Hp / health;
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
                Instantiate(EnemyDie, transform.position, transform.rotation);//������ ����Ʈ�� ����
                Instantiate(Nasa, transform.position + new Vector3(0, -5, 0), transform.rotation);//���ζ�����
                Instantiate(MoonStone, transform.position, transform.rotation);

                DieCount.GetComponent<MonsterSummoner>().EnemyDie++;

                Destroy(Body);
            }
        }
    }
}
