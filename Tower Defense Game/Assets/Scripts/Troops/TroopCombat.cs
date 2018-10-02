using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TroopCombat : MonoBehaviour {

    Transform target;
    Enemy targetEnemy;

    NavMeshAgent agent;
    TroopMovement troopMovement;
    Troop troop;

    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    public float attackDelay = .6f;

    public event System.Action OnAttack;

    public string enemyTag = "Enemy";

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        troopMovement = GetComponent<TroopMovement>();
        troop = GetComponent<Troop>();
	}

    // Update is called once per frame
    void Update() {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        attackCooldown -= Time.deltaTime;

        if (nearestEnemy != null && shortestDistance <= troop.range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();

            agent.SetDestination(target.position);

            if (shortestDistance <= agent.stoppingDistance)
            {
                Troop troop = GetComponent<Troop>();
                if (troop != null)
                {
                    Attack(targetEnemy);
                }

                FaceTarget();
            }
        }
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void Attack(Enemy enemyStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(enemyStats, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed;
        }

    }

    IEnumerator DoDamage(Enemy stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(troop.damage);
    }
}
