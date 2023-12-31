using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Antagonist : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
    }

    public float Speed
    {
        get { return agent.speed; }
        set { agent.speed = value; }
    }
}

