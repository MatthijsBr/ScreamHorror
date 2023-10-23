using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCreator : MonoBehaviour
{
    [SerializeField] float minInterval = 20f;
    [SerializeField] float maxInterval = 30f;
    float nextSoundTime;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        nextSoundTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSoundTime)
        {
            audioSource.Play();
            nextSoundTime = Time.time + Random.Range(minInterval, maxInterval);
        }
    }
}
