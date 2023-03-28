using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject Body;

    int Hp=10;
    int Damage;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //�Ѿ˿� ���� ������������ Hp����;
            Bullet BulletDamage = collision.GetComponent<Bullet>();
            Hp -= BulletDamage.damage;
            //�ε��� �Ѿ� �ı�
            Destroy(collision.gameObject);

            if (Hp <= 0)
            {
                Destroy(Body);
            }
        }
    }


}
