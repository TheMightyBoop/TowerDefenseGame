using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopWaypoints : MonoBehaviour {

    public static float radius = 2f;
    public float RADIUS = 3f;

    public Transform[] points;

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

    void Start()
    {
        radius = RADIUS;
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
