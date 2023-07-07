using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject level = default;
    public GameObject bulletExplosionPrefab = default;
    public float speed = default;
    private Rigidbody rigid = default;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.up * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Wall"))
        {
            EnemyController enemyControler = other.GetComponent<EnemyController>();
            EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();

            if (enemyControler != null)
            {
                enemyControler.Die();
                GameManager gm = FindObjectOfType<GameManager>();
                gm.score += 1;
            }

            enemySpawner.idxs.Remove(enemySpawner.enemies.FindIndex(0, enemySpawner.enemies.Count, x => x == other.gameObject));
            enemySpawner.enemies.Remove(other.gameObject);

            GameObject explosion = Instantiate(bulletExplosionPrefab, transform.position + new Vector3(0, 8, 0), transform.rotation);
            Destroy(explosion, 1f);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
