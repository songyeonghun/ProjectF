using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    //임시변수
    int[] HpRegen={ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80};
    int Regen;

    //무기종류를 판단하는 변수
    static public int Weapon = 0;     //0없음, 1권총, 2샷건, 3기관총
    //획득한 무기 판별 변수

    //무기 위치
   public Transform Right;
   public Transform Left;

    //무기별 스테이터스
    static public int[] damage = { 0, 3, 3, 3 };                                   //공격력
    int[] Maxammo={0,8,5,20 };                                                  //탄창용량
    int[] UseHp = { 0, 3, 7, 3 };                                             //발사시 채력소모값
    float[] AtkCool = { 0,0.5f,1f,0.2f};                                      //공속
    static public bool atkCool = false;                     //공속및 딜레이 관련
    int[] ammo = { 0, 0, 0, 0 };                                //사용한 총알
    float[] UseHpCount= {0 ,0 ,0 ,0 };                          //사용한 체력
    
    //탄속
    float bulletForce = 20f;

    //총알 나가는 위치, 총알 프리팹
    public Transform firepoint;
    public GameObject bulletPrefab;



    //마우스 때문에 필요한것들
    public Rigidbody2D rb;
    public Camera cam;
    static public Vector2 len;
    Vector2 mousepos;

    //총 위치 때문에 필요한것들
    public GameObject player;

    //탄환
    public Text Ammo;

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

        //탄환수 나오는거
        Ammo.text = ""+(Maxammo[Weapon]-ammo[Weapon])+" / "+Maxammo[Weapon];

        //마우스위치에 따른 손에서의 무기 위치
        if (mousepos.x<player.transform.position.x)
        {
            gameObject.transform.position = Right.position;
            gameObject.transform.localScale=new Vector3(0.3f, -0.13f, 0);
        }
        else
        {
            gameObject.transform.position = Left.position;
            gameObject.transform.localScale = new Vector3(0.3f, 0.13f, 0);
        }

        //무기 회전을 위한 마우스 좌표값 
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        //마우스 위치에 따른 플레이어 회전
        Vector2 lookdir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (angle>=-135&&angle<=-45) //Up Right
        {
            Player.anim.SetBool("Down", true);
            Player.anim.SetBool("Back", false);
            Player.anim.SetBool("Right", false);
        }
        else if (angle >= 67 && angle <= 112)
        {
            Player.anim.SetBool("Down", false);
            Player.anim.SetBool("Back", true);
            Player.anim.SetBool("Right", false);
        }
        else
        {
            Player.anim.SetBool("Down", false);
            Player.anim.SetBool("Back", false);
            Player.anim.SetBool("Right", true);
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
