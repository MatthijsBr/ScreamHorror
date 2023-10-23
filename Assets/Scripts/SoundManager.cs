using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Transform antagonist;
    [SerializeField] Transform player;
    
    [SerializeField] float goOffDistance = 3;
    float nextPlayTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(antagonist.position, player.position) < goOffDistance && Time.time > nextPlayTime)
        {
            Debug.Log("Terror");
            foreach (Transform child in transform)
            {
                AudioSource audioSource = child.GetComponent<AudioSource>();
                //audioSource.PlayDelayed(Random.Range(0f, goOffDistance / 2f));
                audioSource.Play();
            }
            nextPlayTime = Time.time + 10;
        }
    }
}
