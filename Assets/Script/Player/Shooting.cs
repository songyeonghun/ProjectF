using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    //�ӽú���
    int[] HpRegen={ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80};
    int Regen;

    //���������� �Ǵ��ϴ� ����
    static public int Weapon = 0;     //0����, 1����, 2����, 3�����
    //ȹ���� ���� �Ǻ� ����

    //���� ��ġ
   public Transform Right;
   public Transform Left;

    //���⺰ �������ͽ�
    static public int[] damage = { 0, 3, 3, 3 };                                   //���ݷ�
    int[] Maxammo={0,8,5,20 };                                                  //źâ�뷮
    int[] UseHp = { 0, 3, 7, 3 };                                             //�߻�� ä�¼Ҹ�
    float[] AtkCool = { 0,0.5f,1f,0.2f};                                      //����
    static public bool atkCool = false;                     //���ӹ� ������ ����
    int[] ammo = { 0, 0, 0, 0 };                                //����� �Ѿ�
    float[] UseHpCount= {0 ,0 ,0 ,0 };                          //����� ü��
    
    //ź��
    float bulletForce = 20f;

    //�Ѿ� ������ ��ġ, �Ѿ� ������
    public Transform firepoint;
    public GameObject bulletPrefab;



    //���콺 ������ �ʿ��Ѱ͵�
    public Rigidbody2D rb;
    public Camera cam;
    static public Vector2 len;
    Vector2 mousepos;

    //�� ��ġ ������ �ʿ��Ѱ͵�
    public GameObject player;

    //źȯ
    public Text Ammo;

    private void Start()
    {

        Regen= PlayerPrefs.GetInt("StatHpRegen");
    }
    void Update()
    {
        //���콺 ��Ŭ���� �ѹ߻� �� ä�°��� (��Ÿ��)
        if (Input.GetMouseButton(0) && atkCool == false&&ammo[Weapon]<Maxammo[Weapon])
        {
            Shoot();
            Player.CurrentHp -= UseHp[Weapon];
        }
        
        //����
        if (Input.GetKeyDown("r"))
        {
            Invoke("Reload",1);
        }

        //źȯ�� �����°�
        Ammo.text = ""+(Maxammo[Weapon]-ammo[Weapon])+" / "+Maxammo[Weapon];

        //���콺��ġ�� ���� �տ����� ���� ��ġ
        if (mousepos.x<player.transform.position.x)
        {
            gameObject.transform.position = Right.position;
            gameObject.transform.localScale=new Vector3(0.3f, -0.13f, 0);
        }
        else
        {
            gameObject.transform.position = Left.position;
            gameObject.transform.localScale = new Vector3(0.3f, 0.13f, 0);
        }

        //���� ȸ���� ���� ���콺 ��ǥ�� 
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        //���콺 ��ġ�� ���� �÷��̾� ȸ��
        Vector2 lookdir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (angle>=-135&&angle<=-45) //Up Right
        {
            Player.anim.SetBool("Down", true);
            Player.anim.SetBool("Back", false);
            Player.anim.SetBool("Right", false);
        }
        else if (angle >= 67 && angle <= 112)
        {
            Player.anim.SetBool("Down", false);
            Player.anim.SetBool("Back", true);
            Player.anim.SetBool("Right", false);
        }
        else
        {
            Player.anim.SetBool("Down", false);
            Player.anim.SetBool("Back", false);
            Player.anim.SetBool("Right", true);
        }
    }

    void Shoot()
    {
        if (Weapon == 1|| Weapon == 3)
        {
            //�Ѿ˻����� �߻�
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);

            ReloadCount();
        }
        else if (Weapon == 2)
        {
            //���� �ڵ�
            for (int i = 0; i < 5; i++)
            {
                transform.Rotate(new Vector3(0, 0, Random.Range(-10, 10)));
                int shotgunForce = Random.Range(10, 15);
                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint.right * shotgunForce, ForceMode2D.Impulse);
                transform.Rotate(new Vector3(0, 0, 0));
            }
            ReloadCount();
        }
        else return;
        //��Ÿ�� �Լ� ȣ��
        StartCoroutine("atkCoolTime");
    }

    //����
    void Reload() 
    {
        ammo[Weapon] = 0;
        Player.CurrentHp += (int)(UseHpCount[Weapon] * HpRegen[Regen] * 0.01f);
        UseHpCount[Weapon] = 0;
    }

    //������ �ʿ��� ī��Ʈ
     void ReloadCount()
    {
        //���Hp����
        UseHpCount[Weapon] += UseHp[Weapon];
        //źȯ��� ����
        ammo[Weapon]++;
    }

    //���ݿ� ��Ÿ���� �ֱ�
    private IEnumerator atkCoolTime()
    {
        atkCool = true;
        yield return new WaitForSeconds(AtkCool[Weapon]);
        atkCool = false;
    }



}
