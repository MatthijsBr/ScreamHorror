using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
