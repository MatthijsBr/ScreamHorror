using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : Item
{
    [SerializeField] float attackRange = 2f;
    [SerializeField] GameObject usePrompt;

    private void Update()
    {
        if (isPickedUp)
        {
            Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, attackRange))
            {
                Breakable breakable = hit.collider.GetComponent<Breakable>();
                usePrompt.SetActive(breakable != null);
            }
        }
    }

    public override void Use()
    {
        Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, attackRange))
        {
            Breakable breakable = hit.collider.GetComponent<Breakable>();
            if (breakable != null)
                breakable.Hit();
        }
    }
}
