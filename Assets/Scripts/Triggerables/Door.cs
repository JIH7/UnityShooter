using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Door : Triggerable
{
    bool open = false;
    Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    protected override void Trigger()
    {
        open = !open;
        animator.SetBool("open", open);
        base.Trigger();
    }
}
