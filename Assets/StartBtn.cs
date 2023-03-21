using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void click()
    {
        SceneManager.LoadScene("2WaitRoom");
    }

}
