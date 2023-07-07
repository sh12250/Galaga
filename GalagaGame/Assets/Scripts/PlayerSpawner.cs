using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject level = default;
    public GameObject playerPrefab = default;
    public int life = default;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindWithTag("Player") && life != 0)
        {
            GameObject player = Instantiate(playerPrefab, transform.position, transform.rotation, transform);
            player.GetComponent<PlayerController>().level = level;
        }

        if(life == 0)
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.GameOver();
        }
    }
}
