using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Message displayed when player is looking at interactable
    public string promptMessage;

    public void BaseInteract() {
        Interact();
    }

    protected virtual void Interact() {
        //Template function to be overidden
    }
}
