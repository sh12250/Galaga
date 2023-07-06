using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
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
        if (other.tag.Equals("Player") || other.tag.Equals("Wall"))
        {
            PlayerController playerControler = other.GetComponent<PlayerController>();

            if (playerControler != null)
            {
                playerControler.Die();
            }

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
