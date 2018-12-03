using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class TroopMovement : MonoBehaviour
{
    private Transform target;

    //[HideInInspector]
    public int waypointIndex = 0;
    public int pathIndex = 0;

    private Troop troop;

    private NavMeshAgent agent;

    private Paths TroopPaths;

    Vector3 dir;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        troop = GetComponent<Troop>();
        agent.speed = troop.speed;
        if(troop.CompareTag("Player 1"))
        {
            target = PlayerStats.WaitingArea;
            TroopPaths = PlayerStats.Paths;
            troop.enemyTag = "Player 2";
        } else if (troop.CompareTag("Player 2"))
        {
            target = EnemyStats.WaitingArea;
            TroopPaths = EnemyStats.Paths;
            troop.enemyTag = "Player 1";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && troop.isInCamp)
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        if (target == PlayerStats.WaitingArea || target == EnemyStats.WaitingArea)
        {
            dir = target.position - transform.position;

            MoveTroop();
            LockOnTarget(dir);
            CheckInCamp();
        }

        troop.speed = troop.startSpeed;
    }

    public void MoveTroop()
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
        if (waypointIndex >= TroopPaths.paths[pathIndex].points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = TroopPaths.paths[pathIndex].points[waypointIndex];
    }

    public IEnumerator FollowPoints()
    {
        target = TroopPaths.paths[pathIndex].points[waypointIndex];

        if (PathChecker())
        {
            for (int i = 0; i < TroopPaths.paths[pathIndex].points.Length; i++)
            {
                dir = target.position - transform.position;

                GetNextWayPoint();
                MoveTroop();
                LockOnTarget(dir);
                Debug.Log(waypointIndex);
                yield return new WaitUntil(() => Vector3.Distance(troop.transform.position, target.position) <= TroopWaypoints.radius);
            }
        }
    }

    void EndPath()
    {
        if (troop.CompareTag("Player 1"))
        {
            EnemyStats.Lives--;
        } else
        {
            PlayerStats.Lives--;
        }
        Destroy(gameObject);
    }

    public void Attack()
    {
        GetPath();
        troop.isInCamp = false;
        StartCoroutine(FollowPoints());
        PlayerStats.TroopsInCamp = 0;
    }

    void GetPath()
    {
        if (troop.CompareTag("Player 1"))
        {
            pathIndex = PlayerStats.PathIndex;
        } else
        {
            pathIndex = EnemyStats.PathIndex;
        }
        
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
        } else
        {
            troop.isInCamp = false;
        }
    }
}
