using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string PortalName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision);
        if (collision.gameObject.tag=="Player")
        {
            SceneManager.LoadScene(PortalName);
        }
    }


}
