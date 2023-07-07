using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject level = default;
    public GameObject playerBullet = default;
    public GameObject playerExplosionPrefab = default;
    public float speed = default;

    private Rigidbody rigid = default;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(playerBullet, transform.position, transform.rotation, level.transform);
            bullet.GetComponent<PlayerBullet>().level = level;
        }

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, ySpeed, 0);
        rigid.velocity = newVelocity;
    }
    public void Die()
    {
        GameObject explosion = Instantiate(playerExplosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 2f);
        gameObject.SetActive(false);
    }
}
