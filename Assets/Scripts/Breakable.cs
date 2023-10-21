using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] int hitsToBreak = 10;

    public void Hit()
    {
        // Play sound fx
        hitsToBreak--;

        if (hitsToBreak <= 0)
        {
            Debug.Log("Door has been broken");
            // Play sound effect

            // Destroy door
        }
    }
}
