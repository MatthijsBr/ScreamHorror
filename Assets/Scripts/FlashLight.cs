using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Item
{
    bool on;
    [SerializeField] float batteryTime = 20f;
    [SerializeField] GameObject flashlightPrompt;

    public override void Use()
    {
        on = !on;
    }

    private void Update()
    {
        flashlightPrompt.SetActive(isPickedUp);

        if (on)
        {
            batteryTime -= Time.deltaTime;

            // Shine some light
            Debug.Log("Shining Light");

            if (batteryTime < batteryTime / 2)
            {
                // Randomize light intensity or turn off and on at random intervals
            }
        }
    }
}
