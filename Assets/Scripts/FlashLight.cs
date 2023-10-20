using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Item
{
    [SerializeField] float batteryTime = 20f;

    public override void Use()
    {
        batteryTime -= Time.deltaTime;

        // Shine some light
        Debug.Log("Shining Light");
    }
}
