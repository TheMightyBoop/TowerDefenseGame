using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class TroopMovement_NavMesh : MonoBehaviour
{
    private Transform target;

    [HideInInspector]
    public int waypointIndex = 0;

    private Troop troop;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        troop = GetComponent<Troop>();
        target = TroopWaypoints.points[waypointIndex];
        agent.speed = troop.speed;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;

            MoveTroop();
            LockOnTarget(dir);
            CheckInCamp();
        }

        if (Input.GetKeyDown(KeyCode.G) && troop.isInCamp)
        {
            Attack();
        }

        troop.speed = troop.startSpeed;
    }

    void MoveTroop()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);
    }

    void LockOnTarget(Vector3 dir)
    {
        //Target lock on, so enemies face where they are going
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(troop.transform.rotation, lookRotation, Time.deltaTime * troop.speed).eulerAngles;
        troop.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void GetNextWayPoint()
    {
        if (waypointIndex >= TroopWaypoints.points.Length - 3)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = TroopWaypoints.points[waypointIndex];
    }

    IEnumerator FollowPoints()
    {
        target = TroopWaypoints.points[waypointIndex];

        if (PathChecker())
        {
            for (int i = 0; i < TroopWaypoints.points.Length - 2; i++)
            {
                GetNextWayPoint();
                MoveTroop();
                Debug.Log(waypointIndex);
                yield return new WaitUntil(() => Vector3.Distance(troop.transform.position, target.position) <= TroopWaypoints.radius);
            }
        }
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    public void Attack()
    {
        StartCoroutine(FollowPoints());
        PlayerStats.TroopsInCamp = 0;
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

    void CheckInCamp()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance && troop.isInCamp == false && waypointIndex == 0)
            {
                agent.velocity = Vector3.zero; //Prevent sliding
                agent.isStopped = true;

                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    troop.isInCamp = true;
                    PlayerStats.TroopsInCamp++;
                    target = null;
                    return;
                }
            }
        }
        else
        {
            troop.isInCamp = false;
        }
    }
}
