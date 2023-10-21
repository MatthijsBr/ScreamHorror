using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] Animator door1;
    [SerializeField] Animator door2;

    public void OpenDoors()
    {
        door1.SetTrigger("Open");
        door2.SetTrigger("Open");

        Debug.Log("Doors have been opened");
    }
}
