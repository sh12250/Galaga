using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject level = default;
    public GameObject enemyBullet = default;
    public float speed = default;
    public Rigidbody rigid = default;

    private float shootRate = default;
    private float timeAfterShoot = default;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterShoot = 0f;
        shootRate = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterShoot += Time.deltaTime;
        if(shootRate < timeAfterShoot)
        {
            timeAfterShoot = 0;

            GameObject bullet = Instantiate(enemyBullet, transform.position, transform.rotation, level.transform);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
