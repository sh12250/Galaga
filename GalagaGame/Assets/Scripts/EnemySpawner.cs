using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab = default;
    public List<GameObject> enemies = default;
    public List<Vector3> enemiesPoss = default;
    public List<int> idxs = default;

    private float spawnRate = default;
    private float timeAfterSpawn = default;

    private 

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = 3f;
        enemies = new List<GameObject>();
        enemiesPoss = new List<Vector3>
        {
            new Vector3(-45f, 50f, 0),
            new Vector3(-32.5f, 50f, 0),
            new Vector3(-45f, 37.5f, 0),
            new Vector3(-32.5f, 37.5f, 0),
            new Vector3(32.5f, 50f, 0),
            new Vector3(45f, 50f, 0),
            new Vector3(32.5f, 37.5f, 0),
            new Vector3(45f, 37.5f, 0),
            new Vector3(-6.25f, 75f, 0),
            new Vector3(6.25f, 75f, 0),
            new Vector3(-6.25f, 62.5f, 0),
            new Vector3(6.25f, 62.5f, 0)
        };
        idxs = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                int randIdx = Random.Range(0, enemiesPoss.Count);
                // Rigidbody rigid = enemies[i].GetComponent<Rigidbody>();
                enemies[i].transform.position = Vector3.MoveTowards(enemies[i].transform.position, enemiesPoss[randIdx], 1f);
            }
        }

        if (enemies.Count < 12)
        {
            if (spawnRate <= timeAfterSpawn)
            {
                GFunc.Log("들어가나?");
                timeAfterSpawn = 0;

                GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation, transform);
                enemies.Add(enemy);
            }
        }
    }
}
