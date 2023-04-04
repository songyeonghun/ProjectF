using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //임시변수
    int[] HpRegen={ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80};
    int Regen;

    //무기종류를 판단하는 변수
    static public int Weapon = 2;     //0없음, 1권총, 2샷건, 3기관총

    //무기별 스테이터스
    static public int[] damage = { 0, 3, 3, 3 };                                   //공격력
    int[] Maxammo={0,8,5,20 };                                                  //탄창용량
    int[] UseHp = { 0, 3, 7, 3 };                                             //발사시 채력소모값
    float[] AtkCool = { 0,0.5f,1f,0.2f};                                      //공속
    static public bool atkCool = false;                     //공속및 딜레이 관련

    int[] ammo = { 0, 0, 0, 0 };
    float[] UseHpCount= {0 ,0 ,0 ,0 };

    //총알 나가는 위치, 총알 프리팹
    public Transform firepoint;
    public GameObject bulletPrefab;

    //탄속
    float bulletForce = 20f;

    private void Start()
    {
        Regen= PlayerPrefs.GetInt("StatHpRegen");
    }
    void Update()
    {
        //마우스 좌클릭시 총발사 및 채력감소 (쿨타임)
        if (Input.GetMouseButton(0) && atkCool == false&&ammo[Weapon]<Maxammo[Weapon])
        {
            Shoot();
            Player.CurrentHp -= UseHp[Weapon];
        }
        //장전
        if (Input.GetKeyDown("r"))
        {
            Invoke("Reload",1);
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

            ReloadCount();
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
            ReloadCount();
        }
        else return;
        //쿨타임 함수 호출
        StartCoroutine("atkCoolTime");
    }

    //장전
    void Reload() 
    {
        ammo[Weapon] = 0;
        Debug.Log(HpRegen[Regen]);
        Debug.Log(UseHpCount[Weapon]);
        Player.CurrentHp += (int)(UseHpCount[Weapon] * HpRegen[Regen] * 0.01f);
        UseHpCount[Weapon] = 0;
    }

    //장전시 필요한 카운트
     void ReloadCount()
    {
        //사용Hp누적
        UseHpCount[Weapon] += UseHp[Weapon];
        //탄환사용 누적
        ammo[Weapon]++;
    }

    //공격에 쿨타임을 주기
    private IEnumerator atkCoolTime()
    {
        atkCool = true;
        yield return new WaitForSeconds(AtkCool[Weapon]);
        atkCool = false;
    }



}
