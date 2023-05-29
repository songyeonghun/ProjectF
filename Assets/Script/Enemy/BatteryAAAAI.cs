using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BatteryAAAAI : MonoBehaviour
{
    public GameObject bulletPrefab;          //�� �߻�� ������ źȯ
    public Transform firepoint;                 //�Ѿ��� �߻�� ��ġ
    public static Animator anim;
    //public GameObject AttackEffect;
    
    GameObject target;                    //������ ���
    NavMeshAgent agent;                       //������ �ϴ´��(��)
    SpriteRenderer rend;//�̹��� ������
    Vector2 mousepos;

    AudioSource audioSource;
    public AudioClip Attack;

    public Rigidbody2D rb;

    bool PlayerGet = false;                     //�÷��̾ �߰��Ͽ� ���ݸ�忡 ������
    bool isAtkack = false;

    float atkCool=0.33f;                       //���ݵ����� �ð�(�ν�����â���� ����)
    float bulletForce = 15f;                    //�Ѿ� �ӵ�
    float Angle = 0;

    int attackCount = 0;

    public Transform Enemy; //���� ��� �뵵
    public Transform AngleTarget;

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
        Angle = GetAngle();
        agent.SetDestination(gameObject.transform.position);
        //�������̾ƴҋ�
        //Debug.Log(Angle);
        if (Angle >= 0 && Angle < 90)//������ �´� ������
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
            if (PlayerGet == true && attackCount >= 3)                              //�÷��̾ ã���� ��� �ƴϸ� ����
            {
                isAtkack = true;
                anim.SetBool("isAttack", true);
                //AttackEffect.SetActive(true);
                Invoke("Shoot", 2f); //�� ��� ��� ������
                attackCount = 0;
            }
            else if (PlayerGet == true )
            {
                isAtkack = true;
                anim.SetBool("isAttack", true);
                //AttackEffect.SetActive(true);
                Invoke("Shoot", atkCool); //�� ��� ��� ������
                
            }
            else
            {
                agent.SetDestination(target.transform.position);      //�÷��̾ ��ã���� ����
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
        //�÷��̾ ���ݹ����� ������
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�÷��̾� ��");
            PlayerGet = true;       //�÷��̾� �Lġ
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("�÷��̾� �̽�");
        //�÷��̾ ���ݹ����� �����
        if (collision.gameObject.tag == "Player")
        {
            PlayerGet = false;      //�÷��̾� �̽�
        }
    }

    private float GetAngle()
    {
        return Mathf.Atan2(AngleTarget.position.y - Enemy.position.y, AngleTarget.position.x - Enemy.position.x) * Mathf.Rad2Deg;
    }

    void Shoot()
    {
        attackCount++;
        Debug.Log("����");
        //����
        AudioSource.PlayClipAtPoint(Attack, transform.position);
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
        isAtkack = false;

    }
}
