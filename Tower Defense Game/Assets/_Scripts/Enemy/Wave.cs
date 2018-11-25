using UnityEngine;

[System.Serializable]
public class Wave {

    public GameObject enemy;
    public int count;
    public float rate;
    public int firstWaypointIndex;
    public Transform spawnPoint;
    public EnemyMovement enemyMovement;
}