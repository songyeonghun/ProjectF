using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //총알 나가는 위치, 총알 프리팹
    public Transform firepoint;
    public GameObject bulletPrefab;

    //총알 속도
    public float bulletForce = 20f;

    //공속및 딜레이 관련
    static public bool atkCool=false;
    float pistolCool = 0.5f;
    //발사시 채력소모값
    int PistolUseHp = 3;

    void Update()
    {
        //마우스 좌클릭시 총발사 및 채력감소 (쿨타임)
        if (Input.GetMouseButton(0) && atkCool == false)
        {
            Shoot();
            Player.CurrentHp -= PistolUseHp;
        }
    }

    void Shoot()
    {
        //총알생성및 발사
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);

        //쿨타임 함수 호출
        StartCoroutine("atkCoolTime");

    }

    //공격에 쿨타임을 주기
    private IEnumerator atkCoolTime()
    {
        atkCool = true;
        yield return new WaitForSeconds(pistolCool);
        atkCool = false;
    }

}
