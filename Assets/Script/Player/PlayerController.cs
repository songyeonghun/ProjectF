using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    //emp
    public GameObject emp;

    //�÷��̾� ����
    int MoveSpeed = PlayerState.stat[2][PlayerState.statMoveSpeed];  

    //�뽬
    bool canDash = true;
    int DashSpeed = 2;
    float DashTime=0.2f;
    float dashCoolTime = 0.5f;

    //���콺
    public Camera cam;
    static public Vector2 len;
    Vector2 movement;
    Vector2 mousepos;

    void Update()
    {
        //�÷��̾� ȸ���� ���� ���콺 ��ǥ�� 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        //���콺 ��Ŭ���� �뽬
        if (Input.GetMouseButtonDown(1)&& canDash==true)
           StartCoroutine(Dash());

        //�����̽��� emp���
        if(Input.GetKeyDown(KeyCode.Space)&&Player.emp>=1)
        {
            Instantiate(emp, gameObject.transform.position, Quaternion.identity);
            Player.emp--;
        }

    }
    void FixedUpdate()
    {
        //rb�� �̿��� ������ �÷��̾� �̵�
        rb.MovePosition(rb.position + movement * (MoveSpeed/DashSpeed) * Time.fixedDeltaTime);

        //���콺 ��ġ�� ���� �÷��̾� ȸ��
        Vector2 lookdir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    //�뽬�� ��Ÿ��
    private IEnumerator Dash()
    {
        Debug.Log("dash");
        canDash = false;
        DashSpeed = 1;
        //�뽬�� �����ڵ� �����ڸ�
        gameObject.layer = 0;
        yield return new WaitForSeconds(DashTime);
        DashSpeed = 2;
        gameObject.layer = 3;
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
}
