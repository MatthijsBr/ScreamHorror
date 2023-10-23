using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Transform rightHand;
    [SerializeField] Transform leftHand;
    [SerializeField] Transform drop;
    [SerializeField] MainManager mainManager;

    FlashLight itemInRightHand;
    Item itemInLeftHand;
    Camera mainCamera;
    [SerializeField] float handRange = 2f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Check wheter some raycast hits item
        Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        Item itemSelected = null;
        Puzzle puzzleSelected = null;

        if (Physics.Raycast(rayOrigin, mainCamera.transform.forward, out hit, handRange))
        {
            itemSelected = hit.collider.GetComponent<Item>();
            puzzleSelected = hit.collider.GetComponent<Puzzle>();

            // Maybe show some button prompt in UI so the user knows which button to use to pick it up.
        }

        // Check if player pressed pickup
        if (Input.GetButtonDown("Interact"))
        {
            if (itemSelected != null)
                PickUp(itemSelected);
            if (puzzleSelected != null)
                Activate(puzzleSelected);
        }
            

        // Check whether player uses any hand
        if (Input.GetButtonDown("FlashLight") && itemInRightHand != null)
            itemInRightHand.Use();
        if (Input.GetButtonDown("LeftHand") && itemInLeftHand != null)
            itemInLeftHand.Use();
    }

    public void HideItemsInMaze()
    {
        if (itemInLeftHand != null)
        {
            itemInLeftHand.transform.parent = null;
            itemInLeftHand.Drop();
            itemInLeftHand.transform.position = mainManager.RandomPositionInMaze() + Vector3.up * 0.5f;
            itemInLeftHand = null;
        }

        if (itemInRightHand != null)
        {
            itemInRightHand.transform.parent = null;
            itemInRightHand.transform.position = mainManager.RandomPositionInMaze() + Vector3.up * 0.5f;
            itemInRightHand = null;
        }
            
    }

    void Activate(Puzzle puzzle)
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponentInChildren<CameraController>().enabled = false;
        puzzle.ActivateUI();
    }

    public void EnableMovement()
    {
        GetComponent<PlayerMovement>().enabled = true;
        GetComponentInChildren<CameraController>().enabled = true;
    }

    void PickUp(Item item)
    {
        if (item is FlashLight)
        {
            itemInRightHand = item as FlashLight;
            item.transform.SetParent(transform);
            item.transform.position = rightHand.position;
            item.transform.up = rightHand.transform.up;     
        } 
        else
        {
            if (itemInLeftHand != null)
            {
                DropLeftHandItem();
            }
            itemInLeftHand = item;
            item.transform.SetParent(transform);
            item.transform.position = leftHand.position;
            item.transform.up = leftHand.transform.up;
            item.PickUp();
        }
    }

    public void DropLeftHandItem()
    {
        itemInLeftHand.Drop();
        itemInLeftHand.transform.position = drop.position;
        itemInLeftHand.transform.parent = null;
        itemInLeftHand = null;
    }
}
