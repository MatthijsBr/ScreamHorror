using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class NavMeshBaker : MonoBehaviour
{
    NavMeshSurface navMeshSurface;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();         
    }

    public void Bake()
    {
        navMeshSurface.BuildNavMesh();
    }
}

