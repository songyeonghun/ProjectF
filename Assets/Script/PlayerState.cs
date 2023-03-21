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
        new int[]{ 100,110,120,130,140,150},                            //1 공격력
        new int[]{ 10,11,12,13,14,15},                                    //2 이동속도
        new int[]{ 10,11,12,13,14,15},                                    //3 공격속도
        new int[]{ 30,40,50}                                               //5 채력회복
    };

    void Start()
    {
        //저장한 스탯을 불러오기
        statHp = PlayerPrefs.GetInt("statHP");
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
        if (statHp < 10 && GameManager.StatCoin > useCoin[statHp])
        {
            GameManager.StatCoin -= useCoin[statHp];                                //코인 소모
            statHp++;                                                               //해당 스탯 레벨업
            HPText.text = "Level: " + statHp + "\nHP: " + stat[0][statHp];          //해당 스탯 수치 택스트 변경
            PlayerPrefs.SetInt("statHp", statHp);                                   //스탯 레벨 저장
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //남은 코인 택스트 변경
        }
        Debug.Log(statHp);
    }
    public void AtkUp()
    {
        if (statAtk < 5 && GameManager.StatCoin > 300)
        {
            statAtk++;
            AtkText.text = "Level: " + statAtk + "\nATK: " + stat[1][statAtk];
            PlayerPrefs.SetInt("statAtk", statAtk);
            GameManager.StatCoin -= 300;
            StatCoinText.text = GameManager.StatCoin + "Coin";
        }
        Debug.Log(statAtk);
    }
    public void MoveSpeedUp()
    {
        if (statMoveSpeed < 5 && GameManager.StatCoin > 500)
        {
            statMoveSpeed++;
            MoveSpeedText.text = "Level: " + statMoveSpeed + "\nMoveSpeed: " + stat[2][statMoveSpeed];
            PlayerPrefs.SetInt("statMoveSpeed", statMoveSpeed);
            GameManager.StatCoin -= 500;
            StatCoinText.text = GameManager.StatCoin + "Coin";
        }
        Debug.Log(statMoveSpeed);
    }
    public void AtkSpeedUp()
    {
        if (statAtkSpeed < 5 && GameManager.StatCoin > 300)
        {
            statAtkSpeed++;
            AtkSpeedText.text = "Level: " + statAtkSpeed + "\nAtkSpeed: " + stat[3][statAtkSpeed];
            PlayerPrefs.SetInt("statAtkSpeed", statAtkSpeed);
            GameManager.StatCoin -= 300;
            StatCoinText.text = GameManager.StatCoin + "Coin";
        }

        Debug.Log(statAtkSpeed);
    }

    public void HpRegenUp()
    {
        if (StatHpRegen < 2 && GameManager.StatCoin > 1000)
        {
            StatHpRegen++;
            HPRegenText.text = "Level: " + StatHpRegen + "\nHpRegen: " + stat[4][StatHpRegen] + "%";
            PlayerPrefs.SetInt("StatHpRegen", StatHpRegen);
            GameManager.StatCoin -= 1000;
            StatCoinText.text = GameManager.StatCoin + "Coin";
        }

        Debug.Log(StatHpRegen);
    }


    //테스트중
    static public void coinadd()
    {
        //StatCoinText.text = GameManager.StatCoin + "Coin";
    }

}
