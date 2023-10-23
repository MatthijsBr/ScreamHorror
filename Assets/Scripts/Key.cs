using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    [SerializeField] float unlockRange = 2f;
    [SerializeField] GameObject usePrompt;

    private void Update()
    {
        if (isPickedUp)
        {
            Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, unlockRange))
            {
                DoorOpener doorOpener = hit.collider.GetComponent<DoorOpener>();
                usePrompt.SetActive(doorOpener != null);
            }
        }
    }

    public override void Use()
    {
        Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, unlockRange))
        {
            DoorOpener doorOpener = hit.collider.GetComponent<DoorOpener>();
            if (doorOpener != null)
                doorOpener.OpenDoors();
        }
    }
}
