using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FileBtn : MonoBehaviour
{
    public GameObject player;
    public void Restart()
    {
        SceneManager.LoadScene("2WaitRoom");
        Time.timeScale = 1f;
        Destroy(player);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
