using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Camera cam;
    static public Vector2 len;
    Vector2 mousepos;

    //무기 위치
    public Transform Right;
    public Transform Left;

    //총 위치 때문에 필요한것들
    public GameObject player;
    public GameObject Gun;

    //마우스 때문에 필요한것들
    public Rigidbody2D rb;

    void Update()
    {
        //마우스위치에 따른 손에서의 무기 위치
        if (mousepos.x < player.transform.position.x)
        {
            gameObject.transform.position = Right.position;
            Gun.transform.localScale = new Vector3(1.5f, -0.6f, 0);
        }
        else
        {
            gameObject.transform.position = Left.position;
            Gun.transform.localScale = new Vector3(1.5f, 0.6f, 0);
        }

        //무기 회전을 위한 마우스 좌표값 
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        //마우스 위치에 따른 플레이어 회전
        Vector2 lookdir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (angle >= -135 && angle <= -45)
        {
            Player.anim.SetBool("Down", true);
            Player.anim.SetBool("Back", false);
            Player.anim.SetBool("Right", false);
            Player.anim.SetBool("Left", false);
        }
        else if (angle >= 22 && angle < 158)
        {
            Player.anim.SetBool("Down", false);
            Player.anim.SetBool("Back", true);
            Player.anim.SetBool("Right", false);
            Player.anim.SetBool("Left", false);
        }
        else if (angle >= 158 || angle < -135)
        {
            Player.anim.SetBool("Down", false);
            Player.anim.SetBool("Back", false);
            Player.anim.SetBool("Right", false);
            Player.anim.SetBool("Left", true);
        }
        else
        {
            Player.anim.SetBool("Down", false);
            Player.anim.SetBool("Back", false);
            Player.anim.SetBool("Right", true);
            Player.anim.SetBool("Left", false);
        }
    }
}
