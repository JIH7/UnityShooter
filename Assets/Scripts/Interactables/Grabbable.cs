using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : Interactable
{
    Rigidbody rb;
    Collider collider;
    [HideInInspector]public GameObject attatchPoint = null;
    [SerializeField] string itemName;
    
    void Start()
    {
        promptMessage = "Pick up " + itemName;
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        rb.isKinematic = false;
    }

    void Update()
    {
        if (attatchPoint != null) {
            transform.position = attatchPoint.transform.position;
            transform.rotation = attatchPoint.transform.rotation;
        } else {
            rb.isKinematic = false;
            collider.enabled = true;
        }
    }

    protected override void Interact(GameObject player)
    {
        PlayerInteract playerInteract = player.GetComponent<PlayerInteract>();
        attatchPoint = playerInteract.attatchPoint;
        playerInteract.heldItem = gameObject;
        rb.isKinematic = true;
        collider.enabled = false;
        
        base.Interact(player);
    }

    public void Throw(float throwForce) {
        rb.isKinematic = false;
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
