using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public void OpenDoors()
    {
        GetComponent<Animation>().Play();
        GetComponent<Collider>().enabled = false;
    }
}
