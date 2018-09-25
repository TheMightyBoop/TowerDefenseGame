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

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
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
