using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision col) {
        Transform hitTransform = col.transform;
        if(hitTransform.CompareTag("Player")) {
            Debug.Log("Hit player");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
