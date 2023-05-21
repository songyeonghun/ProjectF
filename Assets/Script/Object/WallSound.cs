using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSound : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Sound());
    }

    IEnumerator Sound()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

}
