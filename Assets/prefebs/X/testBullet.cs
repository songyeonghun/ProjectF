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
        //테스트 용: 10초뒤 사라지게함
        //본게임에서는 0번 튕기면 사라짐 + 시간제한(오류로 인해 튕기지 않고 영구적으로 남을까봐)
        Invoke("DestroyBullet", 10);

        rb = GetComponent<Rigidbody2D>();

        //플레이어가 보는 방향으로 총알 발사
        move= PlayerControl.len;
        rb.velocity = move;
    }

    void Update()
    {

            LastVelocity = rb.velocity;
    }

    //총알 접촉시
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //플레이어일경우 흡수하기 때문에 오브젝트 파괴
        if(collision.gameObject.tag=="Player")
        {
            Destroy(gameObject);
        }
        else
        {
            //무언가에 맞으면 반사
            var speed = LastVelocity.magnitude;
            var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 10f);
        }
    }

    //총알 파괴 함수(나중에 다른것도 넣어야할까봐 함수로 만들어놓음)
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}