using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //�Ѿ� ������ ��ġ, �Ѿ� ������
    public Transform firepoint;
    public GameObject bulletPrefab;

    //�Ѿ� �ӵ�
    public float bulletForce = 20f;

    //���ӹ� ������ ����
    static public bool atkCool=false;
    float pistolCool = 0.5f;
    //�߻�� ä�¼Ҹ�
    int PistolUseHp = 3;

    void Update()
    {
        //���콺 ��Ŭ���� �ѹ߻� �� ä�°��� (��Ÿ��)
        if (Input.GetMouseButton(0) && atkCool == false)
        {
            Shoot();
            Player.CurrentHp -= PistolUseHp;
        }
    }

    void Shoot()
    {
        //�Ѿ˻����� �߻�
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);

        //��Ÿ�� �Լ� ȣ��
        StartCoroutine("atkCoolTime");

    }

    //���ݿ� ��Ÿ���� �ֱ�
    private IEnumerator atkCoolTime()
    {
        atkCool = true;
        yield return new WaitForSeconds(pistolCool);
        atkCool = false;
    }

}
