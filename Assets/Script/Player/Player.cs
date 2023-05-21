using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D wprb;
    Vector2 movement;
    public static Animator anim;
    public GameObject emp;
    public GameObject weapon;

    float time = 0;

    //�뽬
    bool canDash = true;
    float dashTime = 0.6f;
    float moveSpeed;

    //UI
    public GameObject DeadFile;
    public Image HealGauge;
    public GameObject HealGaugeMax;
    public Image HpBar;
    static public int MaxHp;
    static public int CurrentHp;
    public Text Hp;
    public Text Key;
    public Text Emp;
    public Text Coin;

    static public int HaveEmp = 0;
    static public int HaveKey = 0;
    static public int HaveCoin = 0;

    //�ý���
    public AudioClip[] sound;
    public AudioSource audio;

    //����ǥ
    static public int[][] stat = new int[5][]
    {
        new int[]{ 300,320,340,360,380,400,420,440,460,480,500},    //0 ä��
        new int[]{ 0,0,2,0,4,0,6,0,8,0,10},                                 //1 ���ݷ�
        new int[]{ 10,11,12,13,14,15},                                    //2 �̵��ӵ�
        new int[]{ 10, 0, 11, 0, 12, 0, 13, 0, 14, 0, 15},                //3 ���ݼӵ�
        new int[]{ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80}                 //5 ä��ȸ��
    };

    void Start()
    {
        moveSpeed = stat[2][PlayerPrefs.GetInt("statMoveSpeed")]/2;
        MaxHp = stat[0][PlayerPrefs.GetInt("statHp")];
        CurrentHp = MaxHp;
        anim = GetComponent<Animator>();
        anim.SetBool("Spawn", true);
    }

    void Update()
    {
        //UI
        HpBar.fillAmount = (float)CurrentHp / MaxHp;
        Hp.text = "Hp: " + CurrentHp;
        Key.text = "" + HaveKey;
        Emp.text = "" + HaveEmp;
        Coin.text = "" + HaveCoin;

        //�̵�
        //����
        if (CurrentHp <= 0)
        {
            anim.SetBool("Die", true);
            StartCoroutine(dead());
        }
        else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        //���콺 ��Ŭ���� �뽬
        if (Input.GetMouseButtonDown(1) && canDash == true)
            StartCoroutine(Dash());

        //emp
        if (Input.GetKeyDown(KeyCode.Space) && HaveEmp >= 1)
        {
            Instantiate(emp, gameObject.transform.position, Quaternion.identity);
            SoundPlay(0);
            HaveEmp--;
        }

        //��ȭ ȸ��
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Heal();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)&HaveCoin>=10)
        {
            HealGaugeMax.SetActive(true);
        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            HealGaugeMax.SetActive(false);
            time = 0;
        }

            //�ִϸ��̼�
            if (Input.GetAxisRaw("Horizontal") > 0.6f || Input.GetAxisRaw("Horizontal") < -0.6f)
            {
                anim.SetBool("Move", true);
                anim.SetBool("Idle", false);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.6f || Input.GetAxisRaw("Vertical") < -0.6f)
            {
                anim.SetBool("Move", true);
                anim.SetBool("Idle", false);
            }
            else
            {
                anim.SetBool("Idle", true);
                anim.SetBool("Move", false);
            }

    }

    void FixedUpdate()
    {
        //rb�� �̿��� ������ �÷��̾� �̵�
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //�뽬
    private IEnumerator Dash()
    {
        canDash = false;
        gameObject.layer = 0;
        moveSpeed = moveSpeed * 1.5f;
        anim.SetBool("Roll", true);
        anim.SetBool("Move", false);
        SoundPlay(2);
        yield return new WaitForSeconds(dashTime);
        anim.SetBool("Roll", false);
        canDash = true;
        gameObject.layer = 10;
        moveSpeed = stat[2][PlayerPrefs.GetInt("statMoveSpeed")]/2;
    }

    //��ȭȸ��
    void Heal()
    {
        time += Time.deltaTime;
        HealGauge.fillAmount = time / 2;
        if (time >= 2 && HaveCoin > 10)
        {
            CurrentHp += 10;
            HaveCoin -= 10;
            Debug.Log(time);
            time = 0;
            HealGauge.gameObject.SetActive(false);
        }
    }

    //�Ҹ�ǰ ȹ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Ⱦ� ������ ȹ��
        if (collision.gameObject.tag == "coin")
        {
            HaveCoin++;
            Destroy(collision.gameObject);
            SoundPlay(1);
        }
        else if (collision.gameObject.tag == "Key")
        {
            HaveKey++;
            Destroy(collision.gameObject);
            SoundPlay(1);
        }
        else if (collision.gameObject.tag == "emp")
        {
            HaveEmp++;
            Destroy(collision.gameObject);
            SoundPlay(1);
        }
        else if (collision.gameObject.tag == "StatCoin")
        {
            GameManager2.StatCoin += 1;
            Destroy(collision.gameObject);
            SoundPlay(1);
        }
        else if (collision.gameObject.tag == "Weapon")
        {
            Shooting.Weapon = Weapon.WeaponCode;
            weapon.SetActive(true);
            Destroy(collision.gameObject);
            SoundPlay(1);
        }
    }

    //����
    IEnumerator dead()
    {
        Shooting.atkCool = true;
        movement.x = 0;
        movement.y = 0;
        yield return new WaitForSeconds(2f);    //���� �ִϸ��̼� �ð�
        DeadFile.SetActive(true);                   //���� ����ö ����
    }

    private void SoundPlay(int i)
    {
        audio.clip = sound[i];
        audio.Play();
    }
}
