using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //���������� �Ǵ��ϴ� ����
    static public int Weapon = 2;     //0����, 1����, 2����, 3�����

    //���⺰ �������ͽ�
    static public int[] damage = { 0, 3, 3, 3 };                                   //���ݷ�
    int[] ammo={0,8,5,20 };                                                  //źâ�뷮
    int[] UseHp = { 0, 3, 7, 3 };                                             //�߻�� ä�¼Ҹ�
    float[] AtkCool = { 0,0.5f,1f,0.2f};                                      //����
    static public bool atkCool = false;                     //���ӹ� ������ ����

    //�Ѿ� ������ ��ġ, �Ѿ� ������
    public Transform firepoint;
    public GameObject bulletPrefab;

    //ź��
    float bulletForce = 20f;

    void Update()
    {
        //���콺 ��Ŭ���� �ѹ߻� �� ä�°��� (��Ÿ��)
        if (Input.GetMouseButton(0) && atkCool == false)
        {
            Shoot();
            Player.CurrentHp -= UseHp[Weapon];
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
        }
        else return;
        //��Ÿ�� �Լ� ȣ��
        StartCoroutine("atkCoolTime");
    }

    //���ݿ� ��Ÿ���� �ֱ�
    private IEnumerator atkCoolTime()
    {
        atkCool = true;
        yield return new WaitForSeconds(AtkCool[Weapon]);
        atkCool = false;
    }



}
