using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBullet : MonoBehaviour
{
    public int Damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Player.CurrentHp -= Damage; //데미지를 몬스터의 데미지를 가져올것

            Destroy(this.gameObject);     
    }

}
