using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class MainManager : MonoBehaviour
{
    [SerializeField] GameObject[] mazeGenerators;
    [SerializeField] NavMeshBaker navMeshBaker;
    // Start is called before the first frame update
    void Start()
    {
        GenerateAndBake();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateAndBake()
    {
        StartCoroutine(GenerateNBake());
    }

    public IEnumerator GenerateNBake()
    {
        foreach (GameObject mazeGenerator in mazeGenerators)
        {
            mazeGenerator.GetComponent<MazeGenerator>().GenerateMaze();
        }

        yield return new WaitForSeconds(1);

        navMeshBaker.Bake();

        yield return null;
    }

    public Vector3 RandomPositionInMaze()
    {
        Vector3 randomPosInMaze = new Vector3(Random.Range(0, 7) + 0.5f, 0, Random.Range(0, 7) + 0.5f);
        Transform randomMaze = mazeGenerators[Random.Range(0, mazeGenerators.Length)].transform;
        return randomMaze.position + randomPosInMaze;
    }
}
