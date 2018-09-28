using System.Collections;
using UnityEngine;

public class TroopMovement : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    
    [HideInInspector]
    public int waypointIndex = 0;

    private Troop troop;

    public string enemyTag = "Enemy";

    void Start()
    {
        troop = GetComponent<Troop>();
        target = TroopWaypoints.points[waypointIndex];
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            
            MoveTroop();
            LockOnTarget(dir);
            CheckInCamp();
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.G) && troop.isInCamp == true)
        {
            Attack();
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
        target = TroopWaypoints.points[waypointIndex];

        if (Vector3.Distance(troop.transform.position, target.position) <= 0.2f)
        {
            for (int i = 1; i < TroopWaypoints.points.Length - 1; i++)
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
        PlayerStats.TroopsInCamp = 0;
        StartCoroutine(FollowPoints());
    }
    
    void CheckInCamp()
    {
        if (troop.transform.position == TroopWaypoints.points[0].position)
        {
            troop.isInCamp = true;
            PlayerStats.TroopsInCamp++;
            target = null;
            return;
        }
    }
}
