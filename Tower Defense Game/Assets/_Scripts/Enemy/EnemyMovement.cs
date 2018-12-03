using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    private Transform target;
    
    public int waypointIndex = 0;

    private Troop enemy;

    private NavMeshAgent agent;

    Vector3 dir;

    public void SetFirstWayPoint(int firstWaypointIndex)
    {
        waypointIndex = firstWaypointIndex;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Troop>();
        target = EnemyWaypoints.points[waypointIndex];
        agent.speed = enemy.speed;
    }

    void Update()
    {
        if (target != null && target == EnemyWaypoints.points[waypointIndex])
        {
            dir = target.position - transform.position;

            MoveEnemy();
            LockOnTarget(dir);
        }

        StartCoroutine(FollowPoints());

        enemy.speed = enemy.startSpeed;
    }

    void MoveEnemy()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);
    }

    void GetNextWayPoint()
    {
        if (waypointIndex >= EnemyWaypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        Debug.Log("Bing");
       
        waypointIndex++;
        target = EnemyWaypoints.points[waypointIndex];
    }

    public IEnumerator FollowPoints()
    {   
        target = EnemyWaypoints.points[waypointIndex];
        
        if (PathChecker())
        {
            for (int i = 0; i < EnemyWaypoints.points.Length; i++)
            {
                dir = target.position - transform.position;

                GetNextWayPoint();
                MoveEnemy();
                LockOnTarget(dir);
                Debug.Log(waypointIndex);
                yield return new WaitUntil(() => Vector3.Distance(enemy.transform.position, target.position) <= EnemyWaypoints.radius);
            }
        }
    }

    void EndPath()
    {
        Debug.Log("bing");
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

    public bool PathChecker()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.velocity = Vector3.zero; //Prevent sliding
                agent.isStopped = true;

                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
