using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Transform rightHand;
    [SerializeField] Transform leftHand;

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

        if (Physics.Raycast(rayOrigin, mainCamera.transform.forward, out hit, handRange))
        {
            itemSelected = hit.collider.GetComponent<Item>();

            // Maybe show some button prompt in UI so the user knows which button to use to pick it up.
        }

        // Check if player pressed pickup
        if (Input.GetButton("PickUp") && itemSelected != null)
            PickUp(itemSelected);

        // Check whether player uses any hand
        if (Input.GetButton("FlashLight") && itemInRightHand != null)
            itemInRightHand.Use();
        if (Input.GetButton("LeftHand") && itemInLeftHand != null)
            itemInLeftHand.Use();
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
            itemInLeftHand = item;
        }
    }
}
