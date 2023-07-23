using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Triggerable : MonoBehaviour
{
    public void BaseTrigger() {
        Trigger();
    }
    
    protected virtual void Trigger() {
        //Template method
    }
}
