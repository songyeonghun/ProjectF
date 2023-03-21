using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 LastVelocity;
    Vector2 move;


    void Start()
    {
        //�׽�Ʈ ��: 10�ʵ� ���������
        //�����ӿ����� 0�� ƨ��� ����� + �ð�����(������ ���� ƨ���� �ʰ� ���������� �������)
        Invoke("DestroyBullet", 10);

        rb = GetComponent<Rigidbody2D>();

        //�÷��̾ ���� �������� �Ѿ� �߻�
        move= PlayerControl.len;
        rb.velocity = move;
    }

    void Update()
    {

            LastVelocity = rb.velocity;
    }

    //�Ѿ� ���˽�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�÷��̾��ϰ�� ����ϱ� ������ ������Ʈ �ı�
        if(collision.gameObject.tag=="Player")
        {
            Destroy(gameObject);
        }
        else
        {
            //���𰡿� ������ �ݻ�
            var speed = LastVelocity.magnitude;
            var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 10f);
        }
    }

    //�Ѿ� �ı� �Լ�(���߿� �ٸ��͵� �־���ұ�� �Լ��� ��������)
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}