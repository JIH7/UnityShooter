using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();

    void Awake() {
        waypoints = GetWaypoints();
    }

    private List<Transform> GetWaypoints() {
        List<Transform> path = new List<Transform>();

        for (int i = 0; i < this.transform.childCount; i++) {
            path.Add(this.transform.GetChild(i).GetComponent<Transform>());
        }

        return path;
    }
}
