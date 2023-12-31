using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected bool isPickedUp = false;

    public abstract void Use();

    public virtual void PickUp() 
    {
        isPickedUp = true;
    }

    public virtual void Drop()
    {
        isPickedUp = false;
    }
}
