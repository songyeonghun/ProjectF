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
    int Hp;
    int MaxHp;
    int MoveSpeed = PlayerState.stat[2][PlayerState.statMoveSpeed];  

    //�뽬
    bool canDash = true;
    bool isDashing = false;
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




    /*
    SpriteRenderer spriteRenderer;
    Animator anim;
    float flip;

    private bool canDash = true;
    private bool isDashing;
    private float move = 1f;

    public float maxHP = 100;
    public float HP;
    public float moveSpeed = 5f;
    public float dashSpeed;
    public float dashTime = 0.2f;
    public float dashCoolTime = 0.5f;

    static public Vector2 len;

    public Slider hpBar;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousepos;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        HP = maxHP;
    }

    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

       mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("move", true);
        }

        //ü�¹�
        hpBar.value = HP / maxHP;
    }

    */
}
