using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class TroopMovement : MonoBehaviour
{

    private Transform target;
    
    public int waypointIndex = 0;

    private Troop troop;

    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        troop = GetComponent<Troop>();
        target = TroopWaypoints.points[waypointIndex];
        agent.speed = troop.speed;
    }

    void Update()
    {
        if(target != null)
        {
            MoveTroop();
            FaceTarget();
        }
        
        CheckInCamp();

        if (Input.GetKeyDown(KeyCode.G) && troop.isInCamp == true)
        {
            StartCoroutine(FollowPoints());
        }

        troop.speed = troop.startSpeed;
    }

    void MoveTroop()
    {
        agent.SetDestination(target.position);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void FollowTarget(TroopWaypoints newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;

        target = newTarget.transform;
    }

    void GetNextWayPoint()
    {
        if (waypointIndex >= TroopWaypoints.points.Length - 2)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = TroopWaypoints.points[waypointIndex];
        
    }

    IEnumerator FollowPoints()
    {
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            for (int i = 0; i < TroopWaypoints.points.Length - 1; i++)
            {
                GetNextWayPoint();
                MoveTroop();
                Debug.Log(waypointIndex);
                yield return new WaitUntil(() => agent.transform.position == target.position);
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
    
    void CheckInCamp()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance && troop.isInCamp == false)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    troop.isInCamp = true;
                    PlayerStats.TroopsInCamp++;
                }
            }
        }
        else
        {
            troop.isInCamp = false;
        }
    }
}
