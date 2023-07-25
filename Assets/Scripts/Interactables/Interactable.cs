using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Add or remove InteractionEvent component to this gameobject
    public bool useEvents;
    //Message displayed when player is looking at interactable
    public string promptMessage;

    public void BaseInteract(GameObject player) {
        if (useEvents) {
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact(player);
    }

    protected virtual void Interact(GameObject player) {
        //Template function to be overidden
    }
}
