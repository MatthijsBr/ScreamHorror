using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackableCube : Item
{
    [SerializeField] float placeRange = 2f;
    Camera mainCamera;
    [SerializeField] GameObject usePrompt;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public override void Use()
    {
        Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, mainCamera.transform.forward, out hit, placeRange))
        {
            // Remove from right hand of player
            transform.GetComponentInParent<InventoryManager>().DropLeftHandItem();
            isPickedUp = false;

            // Place cube in the right place
            float distance = Vector3.Distance(rayOrigin, hit.point) - transform.localScale.x;
            Vector3 normalizedDirection = Vector3.Normalize(hit.point - rayOrigin);
            transform.position = rayOrigin + distance * normalizedDirection;

            // Activate physics
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public override void PickUp()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        usePrompt.SetActive(true);
        base.PickUp();
    }

    public override void Drop()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        usePrompt.SetActive(false);
        base.Drop();
    }
}
