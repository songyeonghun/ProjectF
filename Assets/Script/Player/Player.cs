using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb; public Rigidbody2D wprb;
    Vector2 movement;
    public static Animator anim;
    public GameObject emp;
    public GameObject weapon;

    float time = 0;

    //대쉬
    bool canDash = true;
    float dashTime = 0.6f;
    float moveSpeed;

    //UI
    public GameObject DeadFile;
    public GameObject Menu;
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

    //시스템
    public AudioClip[] sound;
    public AudioSource audio;

    //스탯표
    static public int[][] stat = new int[2][]
    {
         new int[]{ 300,320,340,360,380,400,420,440,460,480,500},    //0 채력
         new int[]{ 10,11,12,13,14,15},                                    //2 이동속도
    };

    int[] HealCoin = { 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 100};
    int HealCount = 0;

    void Start()
    {
        //스폰 초기화
        HaveEmp = 0;
        HaveKey = 0;
        HaveCoin = 0;
        weapon.SetActive(false);

        MaxHp = stat[0][PlayerPrefs.GetInt("statHp")];
        moveSpeed = stat[1][PlayerPrefs.GetInt("statMoveSpeed")]/2;
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

        /*if (CurrentHp > MaxHp)
        {
            CurrentHp = MaxHp;
        }*/
        //이동
        //죽음
        if (CurrentHp <= 0)
        {
            anim.SetBool("Die", true);
            StartCoroutine(dead());
        }
        else
        {
            float moveX= Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            movement = new Vector2(moveX, moveY).normalized;
        }

        //마우스 우클릭시 대쉬
        if (Input.GetMouseButtonDown(1) && canDash == true)
            StartCoroutine(Dash());

        //emp
        if (Input.GetKeyDown(KeyCode.Space) && HaveEmp >= 1)
        {
            Instantiate(emp, gameObject.transform.position, Quaternion.identity);
            SoundPlay(0);
            HaveEmp--;
        }

        //제화 회복
        if (Input.GetKey(KeyCode.LeftShift)&&HaveCoin>HealCoin[HealCount]&&CurrentHp<MaxHp)
        {
            Heal();
        }
        else
        {
            HealGaugeMax.SetActive(false);
            HealGauge.gameObject.SetActive(false);
            time = 0;
        }


            //애니메이션
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

        //메뉴UI
        if (Input.GetKey(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
            Shooting.atkCool = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }

    //대쉬
    private IEnumerator Dash()
    {
        canDash = false;
        gameObject.layer = 0;
        moveSpeed = stat[1][PlayerPrefs.GetInt("statMoveSpeed")];
        anim.SetBool("Roll", true);
        anim.SetBool("Move", false);
        SoundPlay(2);
        yield return new WaitForSeconds(dashTime);
        anim.SetBool("Roll", false);
        canDash = true;
        gameObject.layer = 10;
        moveSpeed = stat[1][PlayerPrefs.GetInt("statMoveSpeed")]/2;
    }

    //제화회복
    void Heal()
    {
        time += Time.deltaTime;
        HealGauge.fillAmount = time / 2;
        HealGaugeMax.SetActive(true);
        HealGauge.gameObject.SetActive(true);
        if (time >= 2 && HaveCoin >= HealCoin[HealCount])
        {
            CurrentHp += (int)(MaxHp*0.3f);
            HaveCoin -= HealCoin[HealCount];
            if(CurrentHp>MaxHp)
            {
                CurrentHp = MaxHp;
            }

            time = 0;
            HealGauge.gameObject.SetActive(false);
            HealGaugeMax.SetActive(false);
        }
    }

    //소모품 획득
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //픽업 아이템 획득
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
            weapon.SetActive(true);
            Destroy(collision.gameObject);
            SoundPlay(1);
        }
        else if (collision.gameObject.tag == "TWeapon")
        {
            Shooting.Weapon = 1;
            weapon.SetActive(true);
            Destroy(collision.gameObject);
            SoundPlay(1);
        }
    }

    //죽음
    IEnumerator dead()
    {
        Shooting.atkCool = true;
        movement.x = 0;
        movement.y = 0;
        yield return new WaitForSeconds(2f);    //죽음 애니메이션 시간
        DeadFile.SetActive(true);                   //이후 서류철 오픈
    }

    private void SoundPlay(int i)
    {
        audio.clip = sound[i];
        audio.Play();
    }
}
