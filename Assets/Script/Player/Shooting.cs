using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    //
    int[] HpRegen={ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80};

    //무기종류를 판단하는 변수
    static public int Weapon = 0;     //0없음, 1권총, 2기관총, 샷건 
    public AudioClip[] sound;
    public AudioSource audio;

    //플레이어 오프젝트
    public SpriteRenderer PlayerRend;

    //무기별 스테이터스
    static public int[] damage = { 0, 5, 4, 3 };                                   //공격력
    int[] Maxammo={0,8,20,5 };                                                  //탄창용량
    int[] UseHp = { 0, 3, 2, 5 };                                             //발사시 채력소모값
    float[] AtkCool = { 0,0.5f,0.2f,1f};                                      //공속
    static public bool atkCool = false;                     //공속및 딜레이 관련
    int[] ammo = { 0, 0, 0, 0 };                                //사용한 총알
    float[] UseHpCount= {0 ,0 ,0 ,0 };                          //사용한 체력
    SpriteRenderer weapon;
    public Sprite pistol;
    public Sprite rifle;
    public Sprite shotgun;

    //탄속
    float bulletForce = 20f;

    //총알 나가는 위치, 총알 프리팹
    public Transform firepoint;
    public GameObject bulletPrefab;

    //탄환
    public Text Ammo;

    private void Start()
    {
        weapon = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Weapon == 1)
        {
            weapon.sprite = pistol;
        }else if (Weapon == 2)
        {
            weapon.sprite = rifle;
        }
        else if (Weapon == 3)
        {
            weapon.sprite = shotgun;
        }

        gameObject.transform.localPosition = new Vector2(0, 0);

        //마우스 좌클릭시 총발사 및 채력감소 (쿨타임)
        if (Input.GetMouseButton(0) && atkCool == false&&ammo[Weapon]<Maxammo[Weapon])
        {
            Shoot();
            Player.CurrentHp -= UseHp[Weapon];
        }
        
        //장전
        if (Input.GetKeyDown("r"))
        {
            ammo[Weapon] = Maxammo[Weapon];
            StartCoroutine(Reload());
        }

        //탄환수 나오는거
        Ammo.text = ""+(Maxammo[Weapon]-ammo[Weapon])+" / "+Maxammo[Weapon];

    }

    void Shoot()
    {
        if (Weapon == 1|| Weapon == 2)
        {
            //총알생성및 발사
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
            ShootSound(Weapon);

            ReloadCount();
        }
        else if (Weapon == 3)
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
            ShootSound(Weapon);

            ReloadCount();
        }
        else return;
        //쿨타임 함수 호출
        StartCoroutine("atkCoolTime");
    }

    //장전
    IEnumerator Reload() 
    {
        yield return new WaitForSeconds(0.7f);
        ReloadSound(Weapon);
        yield return new WaitForSeconds(0.3f);
        Player.CurrentHp += (int)(UseHpCount[Weapon] * HpRegen[PlayerPrefs.GetInt("StatHpRegen")] * 0.01f);
        if (Player.CurrentHp>Player.MaxHp)
        {
            Player.CurrentHp = Player.MaxHp;
        }
        ammo[Weapon] = 0;
        UseHpCount[Weapon] = 0;
        atkCool = false;
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

    private void ShootSound(int i)
    {
        if (i == 1)
        {
            audio.clip = sound[0];
        }else if (i == 2)
        {
            audio.clip = sound[2];
        }
        else if (i == 3)
        {
            audio.clip = sound[4];
        }
        audio.Play();
    }

    private void ReloadSound(int i)
    {
        if (i == 1)
        {
            audio.clip = sound[1];
        }
        else if (i == 2)
        {
            audio.clip = sound[3];
        }
        else if (i == 3)
        {
            audio.clip = sound[5];
        }
        audio.Play();
    }

}
