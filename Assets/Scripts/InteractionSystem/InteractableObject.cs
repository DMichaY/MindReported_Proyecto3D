using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class InteractableObject : MonoBehaviour
{
    public string promptMessage;
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {

    }
}
