using System.Collections;
using UnityEngine;

public class TroopMovement : MonoBehaviour
{

    private Transform target;
    
    public int waypointIndex = 0;

    private Troop troop;

    void Start()
    {
        troop = GetComponent<Troop>();
        target = TroopWaypoints.points[waypointIndex];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        if (target != null)
        {
            MoveTroop();
            LockOnTarget(dir);
            CheckInCamp();
        }
        
        if (Input.GetKeyDown(KeyCode.G) && troop.isInCamp == true)
        {
            StartCoroutine(FollowPoints());
        }

        troop.speed = troop.startSpeed;
    }

    void MoveTroop()
    {
        troop.transform.position = Vector3.MoveTowards(troop.transform.position, target.position, troop.speed *Time.deltaTime);
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
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            for (int i = 0; i < TroopWaypoints.points.Length - 2; i++)
            {
                GetNextWayPoint();
                MoveTroop();
                Debug.Log(waypointIndex);
                yield return new WaitUntil(() => troop.transform.position == target.position);
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
        if (troop.transform.position == TroopWaypoints.points[0].position)
        {
            troop.isInCamp = true;
            PlayerStats.TroopsInCamp++;
            return;
        }
    }
}
