using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject level = default;
    public GameObject bulletExplosionPrefab = default;
    public float speed = default;
    private Rigidbody rigid = default;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.up * (speed * -1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerControler = other.GetComponent<PlayerController>();

            if (playerControler != null)
            {
                playerControler.Die();
                PlayerSpawner pSpawner = FindObjectOfType<PlayerSpawner>();
                pSpawner.life -= 1;
            }

            GameObject explosion = Instantiate(bulletExplosionPrefab, transform.position + new Vector3(0, -8, 0), transform.rotation);
            Destroy(explosion, 1f);
            Destroy(gameObject);
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
