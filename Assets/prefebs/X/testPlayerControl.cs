using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing;
    private float move = 0.01f;

    public float maxHP = 100;
    public float HP;
    public float moveSpeed;
    public float dashSpeed;
    public float dashTime = 0.2f;
    public float dashCoolTime = 0.5f;
    public bool atkCoolTime = false;

    static public Vector2 len;

    public GameObject bullet;
    public Transform bulletpos;
    public Slider hpBar;

    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        HP = maxHP;
    }

    void Update()
    {
        //상하좌우 이동
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, +move);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -move);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-move, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(+move, 0);
        }

        //플레이어 방향 회전
        len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        //대쉬(우클릭)
        if (Input.GetMouseButtonDown(1))
        {
            if (canDash == true)
            {
                StartCoroutine("dash");
            }
        }

        //총발사 (좌클릭)
        if (Input.GetMouseButton(0))
        {
            if (atkCoolTime == false)
            {
                HP--;
                Instantiate(bullet, bulletpos.position, transform.rotation);
                atkCoolTime = true;
                StartCoroutine("atkCool");
            }
        }

        //체력바
        hpBar.value = HP / maxHP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //총알 회수시 회복
        if (collision.gameObject.tag == "bullet")
        {
            HP++;
        }    
    }

    //대쉬 딜레이
    private IEnumerator dash()
    {
        canDash = false;
        move = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        move = moveSpeed;
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
    private IEnumerator atkCool()
    {
        yield return new WaitForSeconds(0.5f);
        atkCoolTime = false;
    }
}