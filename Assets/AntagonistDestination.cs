using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntagonistDestination : MonoBehaviour
{
    [SerializeField] Transform[] mazes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Antagonist")
        {
            Vector3 randomPosInMaze = new Vector3(Random.Range(0, 7) + 0.5f, 0, Random.Range(0, 7) + 0.5f);
            Transform randomMaze = mazes[Random.Range(0, mazes.Length)];
            transform.position = randomMaze.position + randomPosInMaze;
        }
    }
}
