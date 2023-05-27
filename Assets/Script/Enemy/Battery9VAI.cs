using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Battery9VAI : MonoBehaviour
{
    public GameObject bulletPrefab;          //�� �߻�� ������ źȯ
    public Transform firepoint;                 //�Ѿ��� �߻�� ��ġ
    GameObject target;                    //������ ���
    NavMeshAgent agent;                       //������ �ϴ´��(��)
    Vector2 mousepos;

    public Rigidbody2D rb;

    bool PlayerGet = false;                     //�÷��̾ �߰��Ͽ� ���ݸ�忡 ������
    bool isAtkack = false;

    float atkCool=0.5f;                       //���ݵ����� �ð�(�ν�����â���� ����)
    float bulletForce = 10f;                    //�Ѿ� �ӵ�

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
        //�������̾ƴҋ�
        if (isAtkack == false)
        {
            if (PlayerGet == true)                              //�÷��̾ ã���� ��� �ƴϸ� ����
            {
                isAtkack = true;
                Invoke("Shoot", atkCool);
            }
            else
                agent.SetDestination(target.transform.position);      //�÷��̾ ��ã���� ����
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

    void Shoot()
    {
        Debug.Log("����");
        //����
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
        isAtkack = false;
    }
}
