using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Item
{
    bool on;
    [SerializeField] float batteryTime = 20f;
    [SerializeField] GameObject flashlightPrompt;
    [SerializeField] Light spotlight;

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
            spotlight.enabled = true;

            if (batteryTime < 60)
            {
                // Randomize light intensity or turn off and on at random intervals
                spotlight.intensity = Random.Range(0f, 1f);
            }
        }
        else
            spotlight.enabled = false;
    }
}
