using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab = default;
    public GameObject level = default;
    public List<GameObject> enemies = default;
    public List<Vector3> enemiesPoss = default;
    public List<Vector3> enemiesPossTemp = default;
    public List<int> idxs = default;

    private float spawnRate = default;
    private float timeAfterSpawn = default;

    private float moveRate = default;
    private float timeAfterMove = default;

    private

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = 1f;
        timeAfterMove = 0f;
        moveRate = 3f;
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
        enemiesPossTemp = new List<Vector3>();

        for (int i = 0; i < enemiesPoss.Count; i++)
        {
            enemiesPossTemp.Add(enemiesPoss[i]);
        }

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

                int count = 0;
                while (idxs.Contains(randIdx) && count < 10)
                {
                    randIdx = Random.Range(0, enemiesPoss.Count);
                    count++;
                }

                if (!idxs.Contains(randIdx))
                {
                    idxs.Add(randIdx);
                }

                enemies[i].transform.position = Vector3.MoveTowards(enemies[i].transform.position, enemiesPoss[idxs[i]], 1f);
            }
        }

        if (enemies.Count < 12)
        {
            if (spawnRate <= timeAfterSpawn)
            {
                timeAfterSpawn = 0f;

                GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation, transform);
                //EnemyController enemyController = enemy.GetComponent<EnemyController>();
                enemy.GetComponent<EnemyController>().level = level;
                enemies.Add(enemy);
            }
        }

        if (enemies.Count == 12)
        {
            timeAfterMove += Time.deltaTime;

            if (moveRate <= timeAfterMove)
            {
                timeAfterMove = 0f;

                for (int i = 0; i < enemiesPoss.Count; i++)
                {
                    enemiesPoss[i] += new Vector3(0, -12.5f, 0);
                }
            }
        }
        else if (enemies.Count == 0)
        {
            for (int i = 0; i < enemiesPoss.Count; i++)
            {
                enemiesPoss[i] = enemiesPossTemp[i];
            }
        }
    }
}
