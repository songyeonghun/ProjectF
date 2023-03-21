using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatNpc : MonoBehaviour
{
   public  GameObject StatUi;
    bool Player = false;
    GameObject PlayerState;
    public PlayerState Stat;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)&& Player==true)
        {
            StatUi.SetActive(true);
            Shooting.atkCool = true;
            Stat.StatCoinText.text = GameManager.StatCoin + "Coin";
            Debug.Log("코인 수치 변경 완료");
            Time.timeScale = 0;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Player = true;
            Debug.Log("npc접촉");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player = false;
            Debug.Log("npc비접촉");
        }
    }



}
