using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Battery9VAI : MonoBehaviour
{
    public GameObject bulletPrefab;          //총 발사시 생성될 탄환
    public Transform firepoint;                 //총알이 발사될 위치
    GameObject target;                    //추적할 상대
    NavMeshAgent agent;                       //추적을 하는대상(나)
    Vector2 mousepos;

    public Rigidbody2D rb;

    bool PlayerGet = false;                     //플레이어를 발견하여 공격모드에 들어가는지
    bool isAtkack = false;

    float atkCool=0.5f;                       //공격딜레이 시간(인스펙터창에서 수정)
    float bulletForce = 10f;                    //총알 속도

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        agent.SetDestination(gameObject.transform.position);
        //공격중이아닐떄
        if (isAtkack == false)
        {
            if (PlayerGet == true)                              //플레이어를 찾으면 사격 아니면 추적
            {
                isAtkack = true;
                Invoke("Shoot", atkCool);
            }
            else
                agent.SetDestination(target.transform.position);      //플레이어를 못찾으면 추적
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

    void Shoot()
    {
        Debug.Log("공격");
        //공격
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
        isAtkack = false;
    }
}
