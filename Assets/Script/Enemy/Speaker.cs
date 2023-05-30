using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Speaker : MonoBehaviour
{
    public GameObject bulletPrefab;          //�� �߻�� ������ źȯ
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;
    public Transform firepoint;                 //�Ѿ��� �߻�� ��ġ
    public Transform firepoint1;
    public Transform firepoint2;
    private Animator anim;
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

    float atkCool = 2f;                       //���ݵ����� �ð�(�ν�����â���� ����)
    float bulletForce = 10f;                    //�Ѿ� �ӵ�

    int ran = 0;
    bool isDelay;

    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        rend = this.GetComponent<SpriteRenderer>();

        Invoke("Think", 5f);
    }

    private void Update()
    {

    }

    void Think()
    {
        //patternIndex = patternIndex == 4 ? 0 : patternIndex + 1;
        patternIndex = Random.Range(0, 5);

        curPatternCount = 0;

        switch(patternIndex)
        {
            case 0:
                FireShot();
                break;
                
            case 1:
                FireSpread();
                break;
                
            case 2:
                FireLine1();
                break;

            case 3:
                FireLine2();
                break;

            case 4:
                AudioSource.PlayClipAtPoint(Attack, transform.position);
                FireRandom();
                break;
        }
    }

    void FireShot()//��������1 ��������
    {
        AudioSource.PlayClipAtPoint(Attack, transform.position);
        anim.SetBool("isAttack", true);
        int roundNumA = 15;

            for (int index = 0; index < roundNumA; index++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = firepoint1.position;
                bullet.transform.rotation = Quaternion.identity;

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * -index / roundNumA), Mathf.Sin(Mathf.PI * -index / roundNumA));
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

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireShot", 2f);
        else
        {
            anim.SetBool("isAttack", false);
            Invoke("Think", 1f);
        }
    }

    void FireSpread() //��������2 ������ ������ ������ ������
    {
        anim.SetBool("isAttack", true);

        GameObject bullet = Instantiate(bulletPrefab1);
        bullet.transform.position = firepoint.position + new Vector3(Random.Range(-15f, 15f), Random.Range(0f, -35f), 0);
        GameObject bullet2 = Instantiate(bulletPrefab1);
        bullet2.transform.position = firepoint.position + new Vector3(Random.Range(-15f, 15f), Random.Range(0f, -35f), 0);
        GameObject bullet3 = Instantiate(bulletPrefab1);
        bullet3.transform.position = firepoint.position + new Vector3(Random.Range(-15f, 15f), Random.Range(0f, -35f), 0);

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireSpread", 2f);
        else
        {
            anim.SetBool("isAttack", false);
            Invoke("Think", 1f);
        }
    }

    void FireLine1()//��������3 ���������� �Ʒ��� ���ư���
    {
        anim.SetBool("isAttack", true);

            GameObject bullet = Instantiate(bulletPrefab2);
            bullet.transform.position = firepoint.position + new Vector3(0, -5f, 0);
            bullet.transform.rotation = Quaternion.identity;

            GameObject bullet1 = Instantiate(bulletPrefab3);
            bullet1.transform.position = firepoint.position + new Vector3(-25f, -20f, 0);
            bullet1.transform.rotation = Quaternion.Euler(0, 0, 90);

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireLine1", 0.5f);
        else
        {
            anim.SetBool("isAttack", false);
            Invoke("Think", 1f);
        }
    }

    void FireLine2()//��������4 �Ʒ��� �� �������� ��
    {
        AudioSource.PlayClipAtPoint(Attack, transform.position);
        anim.SetBool("isAttack", true);

        GameObject bullet = Instantiate(bulletPrefab4);
        bullet.transform.position = firepoint.position + new Vector3(0, -5f, 0);
        bullet.transform.rotation = Quaternion.identity;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * 2, ForceMode2D.Impulse);

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireLine2", 2f);
        else
        {
            anim.SetBool("isAttack", false);
            Invoke("Think", 1f);
        }
    }

    void FireRandom()//�����ϰ� ���
    {
            anim.SetBool("isAttack", true);

            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 ranVec = new Vector2(2 * Mathf.Sin(curPatternCount) + Random.Range(-5f,5f), -1);

            rb.AddForce(ranVec.normalized * 10, ForceMode2D.Impulse);

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            FireRandom();
        else
        {
            anim.SetBool("isAttack", false);
            Invoke("Think", 1f);
        }
    }
}
