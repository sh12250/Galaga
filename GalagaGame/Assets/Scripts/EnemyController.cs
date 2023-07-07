using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject level = default;
    public GameObject enemyBullet = default;
    public GameObject enemyExplosionPrefab = default;

    private float shootRate = default;
    private float timeAfterShoot = default;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterShoot = 0f;
        shootRate = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterShoot += Time.deltaTime;
        if(shootRate < timeAfterShoot)
        {
            timeAfterShoot = 0;

            GameObject bullet = Instantiate(enemyBullet, transform.position, transform.rotation, level.transform);
            bullet.GetComponent<EnemyBullet>().level = level;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();

            enemySpawner.idxs.Remove(enemySpawner.enemies.FindIndex(0, enemySpawner.enemies.Count, x => x == collision.gameObject));
            enemySpawner.enemies.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    public void Die()
    {
        GameObject explosion = Instantiate(enemyExplosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 2f);
        gameObject.SetActive(false);
    }
}
