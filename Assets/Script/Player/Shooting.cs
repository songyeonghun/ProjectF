using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    //
    int[] HpRegen={ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80};

    //���������� �Ǵ��ϴ� ����
    static public int Weapon = 0;     //0����, 1����, 2�����, ���� 
    public AudioClip[] sound;
    public AudioSource audio;

    //�÷��̾� ������Ʈ
    public SpriteRenderer PlayerRend;

    //���⺰ �������ͽ�
    static public int[] damage = { 0, 5, 4, 3 };                                   //���ݷ�
    int[] Maxammo={0,8,20,5 };                                                  //źâ�뷮
    int[] UseHp = { 0, 3, 2, 5 };                                             //�߻�� ä�¼Ҹ�
    float[] AtkCool = { 0,0.5f,0.2f,1f};                                      //����
    static public bool atkCool = false;                     //���ӹ� ������ ����
    int[] ammo = { 0, 0, 0, 0 };                                //����� �Ѿ�
    float[] UseHpCount= {0 ,0 ,0 ,0 };                          //����� ü��
    SpriteRenderer weapon;
    public Sprite pistol;
    public Sprite rifle;
    public Sprite shotgun;

    //ź��
    float bulletForce = 20f;

    //�Ѿ� ������ ��ġ, �Ѿ� ������
    public Transform firepoint;
    public GameObject bulletPrefab;

    //źȯ
    public Text Ammo;

    private void Start()
    {
        weapon = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Weapon == 1)
        {
            weapon.sprite = pistol;
        }else if (Weapon == 2)
        {
            weapon.sprite = rifle;
        }
        else if (Weapon == 3)
        {
            weapon.sprite = shotgun;
        }

        gameObject.transform.localPosition = new Vector2(0, 0);

        //���콺 ��Ŭ���� �ѹ߻� �� ä�°��� (��Ÿ��)
        if (Input.GetMouseButton(0) && atkCool == false&&ammo[Weapon]<Maxammo[Weapon])
        {
            Shoot();
            Player.CurrentHp -= UseHp[Weapon];
        }
        
        //����
        if (Input.GetKeyDown("r"))
        {
            ammo[Weapon] = Maxammo[Weapon];
            StartCoroutine(Reload());
        }

        //źȯ�� �����°�
        Ammo.text = ""+(Maxammo[Weapon]-ammo[Weapon])+" / "+Maxammo[Weapon];

    }

    void Shoot()
    {
        if (Weapon == 1|| Weapon == 2)
        {
            //�Ѿ˻����� �߻�
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
            ShootSound(Weapon);

            ReloadCount();
        }
        else if (Weapon == 3)
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
            ShootSound(Weapon);

            ReloadCount();
        }
        else return;
        //��Ÿ�� �Լ� ȣ��
        StartCoroutine("atkCoolTime");
    }

    //����
    IEnumerator Reload() 
    {
        yield return new WaitForSeconds(0.7f);
        ReloadSound(Weapon);
        yield return new WaitForSeconds(0.3f);
        Player.CurrentHp += (int)(UseHpCount[Weapon] * HpRegen[PlayerPrefs.GetInt("StatHpRegen")] * 0.01f);
        if (Player.CurrentHp>Player.MaxHp)
        {
            Player.CurrentHp = Player.MaxHp;
        }
        ammo[Weapon] = 0;
        UseHpCount[Weapon] = 0;
        atkCool = false;
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

    private void ShootSound(int i)
    {
        if (i == 1)
        {
            audio.clip = sound[0];
        }else if (i == 2)
        {
            audio.clip = sound[2];
        }
        else if (i == 3)
        {
            audio.clip = sound[4];
        }
        audio.Play();
    }

    private void ReloadSound(int i)
    {
        if (i == 1)
        {
            audio.clip = sound[1];
        }
        else if (i == 2)
        {
            audio.clip = sound[3];
        }
        else if (i == 3)
        {
            audio.clip = sound[5];
        }
        audio.Play();
    }

}
