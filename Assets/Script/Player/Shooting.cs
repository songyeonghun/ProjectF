using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //무기종류를 판단하는 변수
    static public int Weapon = 2;     //0없음, 1권총, 2샷건, 3기관총

    //무기별 스테이터스
    static public int[] damage = { 0, 3, 3, 3 };                                   //공격력
    int[] ammo={0,8,5,20 };                                                  //탄창용량
    int[] UseHp = { 0, 3, 7, 3 };                                             //발사시 채력소모값
    float[] AtkCool = { 0,0.5f,1f,0.2f};                                      //공속
    static public bool atkCool = false;                     //공속및 딜레이 관련

    //총알 나가는 위치, 총알 프리팹
    public Transform firepoint;
    public GameObject bulletPrefab;

    //탄속
    float bulletForce = 20f;

    void Update()
    {
        //마우스 좌클릭시 총발사 및 채력감소 (쿨타임)
        if (Input.GetMouseButton(0) && atkCool == false)
        {
            Shoot();
            Player.CurrentHp -= UseHp[Weapon];
        }
    }

    void Shoot()
    {
        if (Weapon == 1|| Weapon == 3)
        {
            //총알생성및 발사
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
        }
        else if (Weapon == 2)
        {
            //샷건 코드
            for (int i = 0; i < 5; i++)
            {
                transform.Rotate(new Vector3(0, 0, Random.Range(-10, 10)));
                int shotgunForce = Random.Range(10, 15);
                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint.right * shotgunForce, ForceMode2D.Impulse);
                transform.Rotate(new Vector3(0, 0, 0));
            }
        }
        else return;
        //쿨타임 함수 호출
        StartCoroutine("atkCoolTime");
    }

    //공격에 쿨타임을 주기
    private IEnumerator atkCoolTime()
    {
        atkCool = true;
        yield return new WaitForSeconds(AtkCool[Weapon]);
        atkCool = false;
    }



}
