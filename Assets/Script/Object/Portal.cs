using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string PortalName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PortalName== "3TutorialStage")
        {
            collision.transform.position = new Vector2(-17.5f,- 32.5f);
        }
        if (collision.gameObject.tag=="Player")
        {
            SceneManager.LoadScene(PortalName);
        }
    }


}
