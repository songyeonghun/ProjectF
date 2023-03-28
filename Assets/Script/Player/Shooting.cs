using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //무기종류를 판단하는 변수
    static public int Weapon = 0;     //0없음, 1권총, 2샷건, 

    //무기별 스테이터스
    int ammo;                                                  //탄창용량
    int damage=3;                                             //공격력
    static public bool atkCool = false;                     //공속및 딜레이 관련
    float AtkCool = 0.5f;                                      //공속
    int UseHp = 3;                                             //발사시 채력소모값

    //총알 나가는 위치, 총알 프리팹
    public Transform firepoint;
    public GameObject bulletPrefab;

    //총알 속도
    public float bulletForce = 20f;


    void Update()
    {
        //마우스 좌클릭시 총발사 및 채력감소 (쿨타임)
        if (Input.GetMouseButton(0) && atkCool == false)
        {
            Shoot();
            Player.CurrentHp -= UseHp;
        }
    }

    void Shoot()
    {
        if (Weapon == 1)
        {
            //총알생성및 발사
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
        }
        if (Weapon == 2)
        {
            //샷건 코드
        }
        //쿨타임 함수 호출
        StartCoroutine("atkCoolTime");

    }

    //공격에 쿨타임을 주기
    private IEnumerator atkCoolTime()
    {
        atkCool = true;
        yield return new WaitForSeconds(AtkCool);
        atkCool = false;
    }



}
