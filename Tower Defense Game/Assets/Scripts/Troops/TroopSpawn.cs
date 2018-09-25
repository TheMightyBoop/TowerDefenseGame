using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopSpawn : MonoBehaviour {

    public float rate = 0f;
    private float cooldown = 0f;

    public Transform spawnPoint;

    public GameObject troop;

    void Update()
    {
        if (PlayerStats.TroopsInCamp == PlayerStats.MaxTroops)
        {
            this.enabled = false;
        }
        else
        {
            this.enabled = true;
        }

        while (cooldown <= 0f)
        {
            StartCoroutine(SpawnTroop(troop));
            cooldown = rate;
            return;
        }

        cooldown -= Time.deltaTime;
        cooldown = Mathf.Clamp(cooldown, 0f, Mathf.Infinity);
    }
    

	IEnumerator SpawnTroop(GameObject troop)
    {
        Instantiate(troop, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(1f / rate);
    }
}
