using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Speaker : MonoBehaviour
{
    public GameObject bulletPrefab;          //총 발사시 생성될 탄환
    public GameObject bulletPrefab1;
    //public GameObject bulletPrefab2;
    //public GameObject bulletPrefab3;
    public Transform firepoint;                 //총알이 발사될 위치
    public Transform firepoint1;
    public Transform firepoint2;
    public static Animator anim;
    //public GameObject AttackEffect;

    GameObject target;                    //추적할 상대
    NavMeshAgent agent;                       //추적을 하는대상(나)
    SpriteRenderer rend;//이미지 뒤집기
    Vector2 mousepos;

    AudioSource audioSource;
    public AudioClip Attack;

    public Rigidbody2D rb;

    bool PlayerGet = false;                     //플레이어를 발견하여 공격모드에 들어가는지
    bool isAtkack = false;

    float atkCool=2f;                       //공격딜레이 시간(인스펙터창에서 수정)
    float bulletForce = 10f;                    //총알 속도

    int ran = 0;
    //float Angle = 0;

    //int attackCount = 0;

    //public Transform Enemy; //각도 재는 용도
    //public Transform AngleTarget;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = GameObject.FindGameObjectWithTag("Player");

        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {    

        if (isAtkack == false)
        {
            if (PlayerGet == true)
            {
                isAtkack = true;
                anim.SetBool("isAttack", true);
                //AttackEffect.SetActive(true);
                Invoke("FireSpread", 3f); //총 쏘고 대기 딜레이

                /*ran = Random.Range(0, 4);
                if (ran == 0)
                {
                    Invoke("FireShot", 3f);
                    Invoke("FireShot", 2f);
                }*/
                /*else if (ran == 1)
                {
                    Invoke("FireSpread", 3f);
                }*/
            }
            else
            {
                agent.SetDestination(target.transform.position);      //플레이어를 못찾으면 추적
                anim.SetBool("isAttack", false);
                //AttackEffect.SetActive(false);
            }
        }
        mousepos = target.transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 lookdir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어가 공격범위에 들어오면
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("플레이어 겟");
            PlayerGet = true;       //플레이어 캪치
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("플레이어 미싱");
        //플레이어가 공격범위를 벋어나면
        if (collision.gameObject.tag == "Player")
        {
            PlayerGet = false;      //플레이어 미싱
        }
    }

    /*private float GetAngle()
    {
        return Mathf.Atan2(target.transform.position.y - Enemy.position.y, target.transform.position.x - Enemy.position.x) * Mathf.Rad2Deg;
    }*/

    void Shoot()
    {
        /*Debug.Log("공격");
        //공격
        AudioSource.PlayClipAtPoint(Attack, transform.position);
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
        isAtkack = false;*/

    }

    void FireShot()//보스1 패턴 퍼지듯이
    {
        int roundNumA = 15;

        for (int index = 0; index < roundNumA; index++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = firepoint1.position;
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * -index/ roundNumA), Mathf.Sin(Mathf.PI * -index / roundNumA));
            rb.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        }

        for (int index = 0; index < roundNumA; index++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = firepoint2.position;
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * -index / roundNumA * 1.1f), Mathf.Sin(Mathf.PI * -index / roundNumA * 1.1f));
            rb.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        }

        isAtkack = false;
    }

    void FireSpread()
    {
        GameObject bullet = Instantiate(bulletPrefab1);
        bullet.transform.position = firepoint.position + new Vector3(Random.Range(-15f, 15f), Random.Range(0f, -35f), 0);
        GameObject bullet2 = Instantiate(bulletPrefab1);
        bullet2.transform.position = firepoint.position + new Vector3(Random.Range(-15f, 15f), Random.Range(0f, -35f), 0);
        GameObject bullet3 = Instantiate(bulletPrefab1);
        bullet3.transform.position = firepoint.position + new Vector3(Random.Range(-15f, 15f), Random.Range(0f, -35f), 0);

        isAtkack = false;
    }
}
