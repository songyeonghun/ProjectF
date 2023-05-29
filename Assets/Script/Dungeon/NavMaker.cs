using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMaker : MonoBehaviour
{
    public GameObject Nav;


    // Start is called before the first frame update
    void Start()
    {

        Invoke("Maker",5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Maker()
    {
        Instantiate(Nav);
    }
}
