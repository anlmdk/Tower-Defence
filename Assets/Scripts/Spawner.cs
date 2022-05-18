using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 1;
    public int spawnAmount = 1;
    public EnemyType[] enemyType;

    void Start()
    {
        // InvokeRepeating("Spawn", 0, 1);
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            for(int i = 0; i < enemyType.Length; i++)
            {
                GameObject insteadEnemy = Instantiate(enemyPrefab, transform);
                insteadEnemy.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = enemyType[i].enemySpeed;
                insteadEnemy.GetComponentInChildren<Renderer>().material.color = enemyType[i].enemyColor;
                insteadEnemy.GetComponent<EnemyHP>().maxHP = enemyType[i].enemyMaxHP;
                yield return new WaitForSeconds(0.4f);
            }
        }
    }
}
