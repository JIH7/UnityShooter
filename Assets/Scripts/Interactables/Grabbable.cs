using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : Interactable
{
    Rigidbody rigidbody;
    [SerializeField] string itemName;
    // Start is called before the first frame update
    void Start()
    {
        promptMessage = "Pick up " + itemName;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Awake() {
        rigidbody.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
