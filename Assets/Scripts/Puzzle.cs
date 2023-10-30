using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] GameObject UIToOpen;
    [SerializeField] GameObject[] doorsToOpen;
    [SerializeField] InventoryManager player;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            PuzzleFinished(false);
    }

    public void ActivateUI()
    {
        UIToOpen.SetActive(true);
    }

    public void PuzzleFinished(bool succesFull)
    {
        // Play correct sound

        UIToOpen.SetActive(false);
        player.EnableMovement();

        if (succesFull)
        {
            audioSource.Play();
            Debug.Log("Door opened");

            // Open the door
            foreach (GameObject door in doorsToOpen)
            {
                door.GetComponent<Animation>().Play();
                door.GetComponent<Collider>().enabled = false;
            }
        }

    }
}
