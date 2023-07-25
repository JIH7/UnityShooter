using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float throwForce = 6f;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    [SerializeField] public GameObject attatchPoint;
    private PlayerUI playerUI;
    private InputManager inputManager;

    [HideInInspector] public GameObject heldItem = null;
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        //Raycast forwards for interactables
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * distance);
        RaycastHit hitInfo; //Store collision info
        if(heldItem == null && Physics.Raycast(ray, out hitInfo, distance, mask)) {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if(inputManager.onFoot.Interact.triggered) {
                    interactable.BaseInteract(this.gameObject);
                }
            }
        }
        //Drop held item
        else if (heldItem != null) {
            if(inputManager.onFoot.PrimaryFire.triggered) {
                Grabbable grabbable = heldItem.GetComponent<Grabbable>();
                grabbable.attatchPoint = null;
                grabbable.Throw(throwForce);
                heldItem = null;
            }
            if(inputManager.onFoot.Interact.triggered) {
                heldItem.GetComponent<Grabbable>().attatchPoint = null;
                heldItem = null;
            }
        }
    }
}
