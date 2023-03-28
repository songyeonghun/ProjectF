using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //���������� �Ǵ��ϴ� ����
    static public int Weapon = 0;     //0����, 1����, 2����, 

    //���⺰ �������ͽ�
    int ammo;                                                  //źâ�뷮
    int damage=3;                                             //���ݷ�
    static public bool atkCool = false;                     //���ӹ� ������ ����
    float AtkCool = 0.5f;                                      //����
    int UseHp = 3;                                             //�߻�� ä�¼Ҹ�

    //�Ѿ� ������ ��ġ, �Ѿ� ������
    public Transform firepoint;
    public GameObject bulletPrefab;

    //�Ѿ� �ӵ�
    public float bulletForce = 20f;


    void Update()
    {
        //���콺 ��Ŭ���� �ѹ߻� �� ä�°��� (��Ÿ��)
        if (Input.GetMouseButton(0) && atkCool == false)
        {
            Shoot();
            Player.CurrentHp -= UseHp;
        }
    }

    void Shoot()
    {
        if (Weapon == 1)
        {
            //�Ѿ˻����� �߻�
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
        }
        if (Weapon == 2)
        {
            //���� �ڵ�
        }
        //��Ÿ�� �Լ� ȣ��
        StartCoroutine("atkCoolTime");

    }

    //���ݿ� ��Ÿ���� �ֱ�
    private IEnumerator atkCoolTime()
    {
        atkCool = true;
        yield return new WaitForSeconds(AtkCool);
        atkCool = false;
    }



}
