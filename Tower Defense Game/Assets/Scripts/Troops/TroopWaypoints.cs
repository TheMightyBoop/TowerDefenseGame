using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopWaypoints : MonoBehaviour {

    public float radius = 5f;

    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] == null)
            {
                points[i] = transform.GetChild(i);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            if(points[i] == null)
            {
                points[i] = transform.GetChild(i);
            }
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(points[i].position, radius);
        }
    }
}
