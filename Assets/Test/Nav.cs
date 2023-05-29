using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav : MonoBehaviour
{
    NavMeshSurface2d nav;

    private void Start()
    {
        nav = GetComponent<NavMeshSurface2d>();

        nav.BuildNavMesh();
    }

}
