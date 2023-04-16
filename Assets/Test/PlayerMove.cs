using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    Animator anim;
    public GameObject emp;

    float moveSpeed;

    //대쉬
    bool canDash = true;
    float dashTime = 0.3f;


    void Start()
    {
        moveSpeed = Player.stat[2][PlayerPrefs.GetInt("statMoveSpeed")]/2;
    }

    void Update()
    {
        //이동
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //마우스 우클릭시 대쉬
        if (Input.GetMouseButtonDown(1) && canDash == true)
            StartCoroutine(Dash());
        //emp
        if (Input.GetKeyDown(KeyCode.Space) && Player.emp >= 1)
        {
            Instantiate(emp, gameObject.transform.position, Quaternion.identity);
            Player.emp--;
        }
    }

    void FixedUpdate()
    {
        //rb를 이용한 물리적 플레이어 이동
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //대쉬
    private IEnumerator Dash()
    {
        canDash = false;
        gameObject.layer = 0;
        moveSpeed = moveSpeed * 1.5f;
        yield return new WaitForSeconds(dashTime);
        canDash = true;
        gameObject.layer = 0;
        moveSpeed = Player.stat[2][PlayerPrefs.GetInt("statMoveSpeed")]/2;
    }
}
