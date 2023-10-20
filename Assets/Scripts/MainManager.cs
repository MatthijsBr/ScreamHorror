using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class MainManager : MonoBehaviour
{
    [SerializeField] MazeGenerator[] mazeGenerators;
    [SerializeField] NavMeshBaker navMeshBaker;
    // Start is called before the first frame update
    void Start()
    {
        foreach (MazeGenerator mazeGenerator in mazeGenerators)
            mazeGenerator.GenerateMaze();

        navMeshBaker.Bake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
