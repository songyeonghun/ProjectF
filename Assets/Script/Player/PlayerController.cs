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

    //�÷��̾� ����
    int MoveSpeed = PlayerState.stat[2][PlayerState.statMoveSpeed];  

    //�뽬
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

        //���콺 ��Ŭ���� �뽬
        if (Input.GetMouseButtonDown(1)&& canDash==true)
           StartCoroutine(Dash());

        //�����̽��� emp���
        if(Input.GetKeyDown(KeyCode.Space)&&Player.emp>=1)
        {
            Instantiate(emp, gameObject.transform.position, Quaternion.identity);
            Player.emp--;
        }

        //�̵�
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
        //rb�� �̿��� ������ �÷��̾� �̵�
        rb.MovePosition(rb.position + movement * (MoveSpeed / DashSpeed) * Time.fixedDeltaTime);
        wprb.MovePosition(wprb.position + movement * (MoveSpeed / DashSpeed) * Time.fixedDeltaTime);
    }

        //�뽬�� ��Ÿ��
        private IEnumerator Dash()
    {
        canDash = false;
        DashSpeed = 1;
        //�뽬�� ����
        gameObject.layer = 0;
        yield return new WaitForSeconds(DashTime);
        DashSpeed = 2;
        gameObject.layer = 10;
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
}
