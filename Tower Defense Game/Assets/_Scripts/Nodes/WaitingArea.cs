using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingArea : MonoBehaviour {

    public float radius = 5f;
    public static Transform point;

    void Awake()
    {
        point = transform;
    }

    void OnDrawGizmosSelected()
    {
        if (point == null)
        {
            point = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(point.position, radius);
    }
}
