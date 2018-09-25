using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Transform target;
    [HideInInspector]
    public int waypointIndex = 0;

    private Enemy enemy;

    public void SetFirstWayPoint(int firstWaypointIndex)
    {
        waypointIndex = firstWaypointIndex;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = EnemyWaypoints.points[waypointIndex];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (enemy.transform.position != target.position)
        {
            LockOnTarget(dir);
        }

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWayPoint()
    {
        if (waypointIndex >= EnemyWaypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
       
        waypointIndex++;
        target = EnemyWaypoints.points[waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    void LockOnTarget(Vector3 dir)
    {
        //Target lock on, so enemies face where they are going
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(enemy.transform.rotation, lookRotation, Time.deltaTime * enemy.speed).eulerAngles;
        enemy.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
