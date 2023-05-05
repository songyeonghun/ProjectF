using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public Rigidbody2D rb;
    public Rigidbody2D wprb;

    //emp
    public GameObject emp;

    //플레이어 스탯
    int MoveSpeed = PlayerState.stat[2][PlayerState.statMoveSpeed];  

    //대쉬
    bool canDash = true;
    int DashSpeed = 2;
    float DashTime=0.3f;
    float dashCoolTime = 0.5f;

    Vector2 movement;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        //마우스 우클릭시 대쉬
        if (Input.GetMouseButtonDown(1)&& canDash==true)
           StartCoroutine(Dash());

        //스페이스바 emp사용
        if(Input.GetKeyDown(KeyCode.Space)&&Player.emp>=1)
        {
            Instantiate(emp, gameObject.transform.position, Quaternion.identity);
            Player.emp--;
        }

        //이동
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            anim.SetBool("Move", true);
            anim.SetBool("Right", true);

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            anim.SetBool("Move", true);
            anim.SetBool("Right", true);
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            anim.SetBool("Move", true);
            anim.SetBool("Back", true);
        }
        else
        {
            anim.SetBool("Move", true);
            anim.SetBool("Down", true);

        }
    }
    void FixedUpdate()
    {
        //rb를 이용한 물리적 플레이어 이동
        rb.MovePosition(rb.position + movement * (MoveSpeed / DashSpeed) * Time.fixedDeltaTime);
        wprb.MovePosition(wprb.position + movement * (MoveSpeed / DashSpeed) * Time.fixedDeltaTime);
    }

        //대쉬와 쿨타임
        private IEnumerator Dash()
    {
        canDash = false;
        DashSpeed = 1;
        //대쉬시 무적
        gameObject.layer = 0;
        yield return new WaitForSeconds(DashTime);
        DashSpeed = 2;
        gameObject.layer = 10;
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
}
