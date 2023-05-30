using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Battery9VAI : MonoBehaviour
{
    public GameObject bulletPrefab;          //�� �߻�� ������ źȯ
    public Transform firepoint;                 //�Ѿ��� �߻�� ��ġ
    public GameObject AttackEffect;
    
    GameObject target;                    //������ ���
    NavMeshAgent agent;                       //������ �ϴ´��(��)
    SpriteRenderer rend;//�̹��� ������
    Vector2 mousepos;

    AudioSource audioSource;
    public AudioClip Attack;

    public Rigidbody2D rb;

    bool PlayerGet = false;                     //�÷��̾ �߰��Ͽ� ���ݸ�忡 ������
    bool isAtkack = false;

    float atkCool = 2f;                      //���ݵ����� �ð�(�ν�����â���� ����)
    float bulletForce = 10f;                    //�Ѿ� �ӵ�
    private float Angle = 0;
    private Animator anim;

    //int attackCount = 0;

    public Transform Enemy; //���� ��� �뵵
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
            if (PlayerGet == true )
            {
                isAtkack = true;
                anim.SetBool("isAttack", true);
                AttackEffect.SetActive(true);
                Invoke("Shoot", atkCool); //�� ��� ��� ������
                
            }
            else
            {
                agent.SetDestination(target.transform.position);      //�÷��̾ ��ã���� ����
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
        return Mathf.Atan2(target.transform.position.y - Enemy.position.y, target.transform.position.x - Enemy.position.x) * Mathf.Rad2Deg;
    }

    void Shoot()
    {
        //attackCount++;
        //Debug.Log("����");
        //����
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
