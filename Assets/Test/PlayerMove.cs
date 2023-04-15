using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;
    Vector2 movement;

    //대쉬
    bool canDash = true;
    float DashTime = 0.3f;
    float dashCoolTime = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        //이동
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //마우스 우클릭시 대쉬
        if (Input.GetMouseButtonDown(1) && canDash == true)
            StartCoroutine(Dash());
    }

    void FixedUpdate()
    {
        //rb를 이용한 물리적 플레이어 이동
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    //대쉬
    private IEnumerator Dash()
    {
        canDash = false;
       // DashSpeed = 1;
        //대쉬시 무적
        gameObject.layer = 0;
        yield return new WaitForSeconds(DashTime);
      //  DashSpeed = 2;
        gameObject.layer = 10;
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
}
