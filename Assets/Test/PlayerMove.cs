using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;
    Vector2 movement;

    //�뽬
    bool canDash = true;
    float DashTime = 0.3f;
    float dashCoolTime = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        //�̵�
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //���콺 ��Ŭ���� �뽬
        if (Input.GetMouseButtonDown(1) && canDash == true)
            StartCoroutine(Dash());
    }

    void FixedUpdate()
    {
        //rb�� �̿��� ������ �÷��̾� �̵�
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    //�뽬
    private IEnumerator Dash()
    {
        canDash = false;
       // DashSpeed = 1;
        //�뽬�� ����
        gameObject.layer = 0;
        yield return new WaitForSeconds(DashTime);
      //  DashSpeed = 2;
        gameObject.layer = 10;
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
}
