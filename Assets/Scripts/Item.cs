using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected bool isPickedUp = false;

    public abstract void Use();

    public virtual void PickUp() { }

    public virtual void Drop()
    {

    }
}
