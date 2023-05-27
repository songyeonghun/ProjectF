using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Player.CurrentHp -= 10; //�������� ������ �������� �����ð�

            Destroy(this.gameObject);     
    }

}
