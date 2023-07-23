using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactable
{
    [SerializeField] private Triggerable triggerable;
    protected override void Interact()
    {
        triggerable.BaseTrigger();
        base.Interact();
    }
}
