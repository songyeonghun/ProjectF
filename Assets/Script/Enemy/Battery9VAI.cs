using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Battery9VAI : MonoBehaviour
{
    public GameObject bulletPrefab;          //총 발사시 생성될 탄환
    public Transform firepoint;                 //총알이 발사될 위치
    public GameObject AttackEffect;
    
    GameObject target;                    //추적할 상대
    NavMeshAgent agent;                       //추적을 하는대상(나)
    SpriteRenderer rend;//이미지 뒤집기
    Vector2 mousepos;

    AudioSource audioSource;
    public AudioClip Attack;

    public Rigidbody2D rb;

    bool PlayerGet = false;                     //플레이어를 발견하여 공격모드에 들어가는지
    bool isAtkack = false;

    float atkCool = 2f;                      //공격딜레이 시간(인스펙터창에서 수정)
    float bulletForce = 10f;                    //총알 속도
    private float Angle = 0;
    private Animator anim;

    //int attackCount = 0;

    public Transform Enemy; //각도 재는 용도
    //public Transform AngleTarget;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = GameObject.FindGameObjectWithTag("Player");

        anim = this.GetComponent<Animator>();
        rend = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Angle = GetAngle();
        agent.SetDestination(gameObject.transform.position);
        //공격중이아닐떄
        //Debug.Log(Angle);
        if (Angle >= 0 && Angle < 90)//각도에 맞는 움직임
        {
            rend.flipX = true;
            anim.SetBool("isFront", false);
        }
        else if (Angle >= 90 && Angle <= 180)
        {
            rend.flipX = false;
            anim.SetBool("isFront", false);
        }
        else if (Angle >= -180 && Angle < -90) 
        {
            rend.flipX = false;
            anim.SetBool("isFront", true);
        }
        else
        {
            rend.flipX = true;
            anim.SetBool("isFront", true);
        }

        if (isAtkack == false)
        {           
            if (PlayerGet == true )
            {
                isAtkack = true;
                anim.SetBool("isAttack", true);
                AttackEffect.SetActive(true);
                Invoke("Shoot", atkCool); //총 쏘고 대기 딜레이
                
            }
            else
            {
                agent.SetDestination(target.transform.position);      //플레이어를 못찾으면 추적
                anim.SetBool("isAttack", false);
                AttackEffect.SetActive(false);
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

    private float GetAngle()
    {
        return Mathf.Atan2(target.transform.position.y - Enemy.position.y, target.transform.position.x - Enemy.position.x) * Mathf.Rad2Deg;
    }

    void Shoot()
    {
        //attackCount++;
        //Debug.Log("공격");
        //공격
        AudioSource.PlayClipAtPoint(Attack, transform.position);
        /*GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);*/

        for (int i = 0; i < 6; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            bulletPrefab.transform.position = transform.position + new Vector3(0, -1f, 0);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = target.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 3f));
            dirVec += ranVec;
            rb.AddForce(dirVec.normalized * 4, ForceMode2D.Impulse);
        }

        isAtkack = false;

    }
}
