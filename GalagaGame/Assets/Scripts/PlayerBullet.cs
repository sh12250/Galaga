using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
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
        if (other.tag.Equals("Enemy") || other.tag.Equals("Wall"))
        {
            EnemyController enemyControler = other.GetComponent<EnemyController>();

            if (enemyControler != null)
            {
                enemyControler.Die();
            }

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
