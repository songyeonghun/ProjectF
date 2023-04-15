using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerState : MonoBehaviour
{
    //저장할 스탯
    static public int statHp;
    static public int statAtk;
    static public int statMoveSpeed;
    static public int statAtkSpeed;
    static public int StatHpRegen;

    public Text StatCoinText;
    public Text[] needStatCoin;
    public int statNum;

    //스탯코인 증가량
    int []useCoin = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };


    //스탯표
    static public int[][] stat = new int[5][]
    {
        new int[]{ 300,320,340,360,380,400,420,440,460,480,500},    //0 채력
        new int[]{ 0,0,2,0,4,0,6,0,8,0,10},                                 //1 공격력
        new int[]{ 10,11,12,13,14,15},                                    //2 이동속도
        new int[]{ 10, 0, 11, 0, 12, 0, 13, 0, 14, 0, 15},                //3 공격속도
        new int[]{ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80}                 //5 채력회복
    };

    void Awake()
    {
        //저장한 스탯을 불러오기
        statHp = PlayerPrefs.GetInt("statHp");
        statAtk = PlayerPrefs.GetInt("statAtk");
        statMoveSpeed = PlayerPrefs.GetInt("statMoveSpeed");
        statAtkSpeed = PlayerPrefs.GetInt("statAtkSpeed");
        StatHpRegen = PlayerPrefs.GetInt("StatHpRegen");
        needStatCoin[0].text = "" + useCoin[statHp];
        needStatCoin[1].text = "" + useCoin[statAtk];
        needStatCoin[2].text = "" + useCoin[statAtkSpeed];
        needStatCoin[3].text = "" + useCoin[statMoveSpeed];
        needStatCoin[4].text = "" + useCoin[StatHpRegen];

        StatCoinText.text = GameManager2.StatCoin + "Coin";
    }


    //스탯업
    public void HpUp()
    {
        if (statHp < 10 && GameManager2.StatCoin >= useCoin[statHp])
        {
            UseCoin(statHp);
            statHp++;                                                               //해당 스탯 레벨업
            PlayerPrefs.SetInt("statHp", statHp);                                   //스탯 레벨 저장
            needStatCoin[0].text = "" + useCoin[statHp];
            Player.MaxHp = stat[0][statHp];
            Player.CurrentHp = Player.MaxHp;

        }
        Debug.Log(statHp);
    }
    public void AtkUp()
    {
        if (statAtk < 10 && GameManager2.StatCoin >= useCoin[statAtk])
        {
            UseCoin(statAtk);
            statAtk +=2;
            PlayerPrefs.SetInt("statAtk", statAtk);
            needStatCoin[1].text = "" + useCoin[statAtk];
        }
        Debug.Log(statAtk);
    }
    public void AtkSpeedUp()
    {
        if (statAtkSpeed < 10 && GameManager2.StatCoin >= useCoin[statAtkSpeed])
        {
            UseCoin(statAtkSpeed);
            statAtkSpeed += 2;
            PlayerPrefs.SetInt("statAtkSpeed", statAtkSpeed);
            needStatCoin[2].text = "" + useCoin[statAtkSpeed];
        }

        Debug.Log(statAtkSpeed);
    }
    public void MoveSpeedUp()
    {
        if (statMoveSpeed < 5 && GameManager2.StatCoin >= useCoin[statMoveSpeed])
        {
            UseCoin(statMoveSpeed);
            statMoveSpeed++;
            PlayerPrefs.SetInt("statMoveSpeed", statMoveSpeed);
            needStatCoin[3].text = "" + useCoin[statMoveSpeed];
        }
        Debug.Log(statMoveSpeed);
    }

    public void HpRegenUp()
    {
        if (StatHpRegen < 10 && GameManager2.StatCoin >= useCoin[StatHpRegen])
        {
            UseCoin(StatHpRegen);
            StatHpRegen +=2;
            PlayerPrefs.SetInt("StatHpRegen", StatHpRegen);
            needStatCoin[4].text = "" + useCoin[StatHpRegen];
        }

        Debug.Log(StatHpRegen);
    }


    void UseCoin(int A)
    {
        GameManager2.StatCoin -= useCoin[A];                                //코인 소모
        GameManager2.SaveCoin();                                                    //소모된 코인을 저장
        StatCoinText.text = GameManager2.StatCoin + "Coin";                      //남은 코인 택스트 변경
    }
}
