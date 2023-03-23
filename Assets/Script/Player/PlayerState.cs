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

    //스탯출력
    public Text HPText;
    public Text AtkText;
    public Text MoveSpeedText;
    public Text AtkSpeedText;
    public Text HPRegenText;
    public Text StatCoinText;

    //스탯코인 증가량
    int []useCoin = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };


    //스탯표
    static public int[][] stat = new int[5][]
    {
        new int[]{ 300,320,340,360,380,400,420,440,460,480,500},    //0 채력
        new int[]{ 0,0,2,0,4,0,6,0,8,0,10},                            //1 공격력
        new int[]{ 10,11,12,13,14,15},                                    //2 이동속도
        new int[]{ 10, 0, 11, 0, 12, 0, 13, 0, 14, 0, 15},                //3 공격속도
        new int[]{ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80}                 //5 채력회복
    };

    void Start()
    {
        //저장한 스탯을 불러오기
        statHp = PlayerPrefs.GetInt("statHp");
        statAtk = PlayerPrefs.GetInt("statAtk");
        statMoveSpeed = PlayerPrefs.GetInt("statMoveSpeed");
        statAtkSpeed = PlayerPrefs.GetInt("statAtkSpeed");
        StatHpRegen = PlayerPrefs.GetInt("StatHpRegen");


        //스탯창에 래밸과 스탯 표시
        HPText.text = "Level: " + statHp + "\nHP: " + stat[0][statHp];
        AtkText.text = "Level: " + statAtk + "\nATK: " + stat[1][statAtk];
        MoveSpeedText.text = "Level: " + statMoveSpeed + "\nMoveSpeed: " + stat[2][statMoveSpeed];
        AtkSpeedText.text = "Level: " + statAtkSpeed + "\nAtkSpeed: " + stat[3][statAtkSpeed];
        HPRegenText.text = "Level: " + StatHpRegen + "\nHpRegen: " + stat[4][StatHpRegen] + "%";
        StatCoinText.text = GameManager.StatCoin + "Coin";
    }


    //스탯업
    public void HpUp()
    {
        if (statHp < 10 && GameManager.StatCoin >= useCoin[statHp])
        {
            GameManager.StatCoin -= useCoin[statHp];                                //코인 소모
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //남은 코인 택스트 변경
            statHp++;                                                               //해당 스탯 레벨업
            HPText.text = "Level: " + statHp + "\nHP: " + stat[0][statHp];          //해당 스탯 수치 택스트 변경
            PlayerPrefs.SetInt("statHp", statHp);                                   //스탯 레벨 저장

        }
        Debug.Log(statHp);
    }
    public void AtkUp()
    {
        if (statAtk < 10 && GameManager.StatCoin >= useCoin[statAtk])
        {
            GameManager.StatCoin -= useCoin[statAtk];                                //코인 소모
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //남은 코인 택스트 변경
            statAtk+=2;
            AtkText.text = "Level: " + statAtk/2 + "\nATK: " + stat[1][statAtk];
            PlayerPrefs.SetInt("statAtk", statAtk);
        }
        Debug.Log(statAtk);
    }
    public void MoveSpeedUp()
    {
        if (statMoveSpeed < 5 && GameManager.StatCoin >= useCoin[statMoveSpeed])
        {
            GameManager.StatCoin -= useCoin[statMoveSpeed];                                //코인 소모
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //남은 코인 택스트 변경
            statMoveSpeed++;
            MoveSpeedText.text = "Level: " + statMoveSpeed + "\nMoveSpeed: " + stat[2][statMoveSpeed];
            PlayerPrefs.SetInt("statMoveSpeed", statMoveSpeed);
        }
        Debug.Log(statMoveSpeed);
    }
    public void AtkSpeedUp()
    {
        if (statAtkSpeed < 10 && GameManager.StatCoin >= useCoin[statAtkSpeed])
        {
            GameManager.StatCoin -= useCoin[statAtkSpeed];                                //코인 소모
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //남은 코인 택스트 변경
            statAtkSpeed+=2;
            AtkSpeedText.text = "Level: " + statAtkSpeed/2 + "\nAtkSpeed: " + stat[3][statAtkSpeed];
            PlayerPrefs.SetInt("statAtkSpeed", statAtkSpeed);
        }

        Debug.Log(statAtkSpeed);
    }

    public void HpRegenUp()
    {
        if (StatHpRegen < 10 && GameManager.StatCoin >= useCoin[StatHpRegen])
        {
            GameManager.StatCoin -= useCoin[StatHpRegen];                                //코인 소모
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //남은 코인 택스트 변경
            StatHpRegen+=2;
            HPRegenText.text = "Level: " + StatHpRegen/2 + "\nHpRegen: " + stat[4][StatHpRegen] + "%";
            PlayerPrefs.SetInt("StatHpRegen", StatHpRegen);
        }

        Debug.Log(StatHpRegen);
    }


    //테스트중
    static public void coinadd()
    {
        //StatCoinText.text = GameManager.StatCoin + "Coin";
    }

}
