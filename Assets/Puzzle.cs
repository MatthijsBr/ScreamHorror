using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] GameObject UIToOpen;
    [SerializeField] Animator DoorToOpen;
    [SerializeField] InventoryManager player;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        UIToOpen.SetActive(false);
        player.EnableMovement();

        if (succesFull)
        {
            Debug.Log("Door opened");
            // Open the door
        }

    }
}
